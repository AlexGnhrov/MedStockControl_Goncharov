using MedStockControl_Goncharov.ClassFolder;
using MedStockControl_Goncharov.WindowFolder.AdminFolder.AditionalWIndows;
using MedStockControl_Goncharov.WindowFolder.AdminFolder.AditionalWIndows.StaffCondition;
using MedStockControl_Goncharov.WindowFolder.AdminFolder.AditionalWIndows.UserData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MedStockControl_Goncharov.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminEditUser.xaml
    /// </summary>
    public partial class AdminEditUser : Window
    {

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        CBClass cBClass;

        public AdminEditUser()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }

        string[] str = new string[3];



    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.CBStaffPosition(StaffPositionCB);
            cBClass.CBLoadUser(UserCB);

            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand("SELECT * FROM dbo.[Staffs] " +
                    $"Where StaffID = '{VariableGetID.StaffID}' ",
                    sqlConnection);

                sqlDataReader = sqlCommand.ExecuteReader();

                sqlDataReader.Read();

                FSLNameStaffTB.Text = sqlDataReader[2].ToString();
                FSLNameStaffTB.Text += " " + sqlDataReader[1].ToString();
                FSLNameStaffTB.Text += " " + sqlDataReader[3].ToString();

                PhoneNumberTB.Text = sqlDataReader[4].ToString();
                StaffPositionCB.SelectedValue = sqlDataReader[5].ToString();
                UserCB.SelectedValue = sqlDataReader[6].ToString();

            }
            catch (Exception ex)
            {

                MBClass.Error(ex);
            }
            finally
            {
                sqlConnection.Close();
            }



        }


        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            str = FSLNameStaffTB.Text.Split(' ');

            try
            {
                sqlConnection.Open();

                if (str.Length == 2)
                {
                    sqlCommand = new SqlCommand("UPDATE dbo.[Staffs] " +
                            $"Set FirstNameStaff = '{str[1]}'," +
                            $" SecondNameStaff = '{str[0]}', " +
                            $" LastNameStaff = '{""}', " +
                            $" PhoneNumStaff = '{PhoneNumberTB.Text}', " +
                            $" PositionStaffID ='{StaffPositionCB.SelectedValue}', " +
                            $" UserID = '{UserCB.SelectedValue}' " +
                            $" WHERE StaffID = '{VariableGetID.StaffID}'",
                            sqlConnection);
                }
                else
                {
                    sqlCommand = new SqlCommand("UPDATE dbo.[Staffs] " +
                            $"Set FirstNameStaff = '{str[1]}'," +
                            $" SecondNameStaff = '{str[0]}', " +
                            $" LastNameStaff = '{str[2]}', " +
                            $" PhoneNumStaff = '{PhoneNumberTB.Text}', " +
                            $" PositionStaffID ='{StaffPositionCB.SelectedValue}', " +
                            $" UserID = '{UserCB.SelectedValue}' " +
                            $" WHERE StaffID = '{VariableGetID.StaffID}'",
                            sqlConnection);
                }

                sqlCommand.ExecuteNonQuery();

                MBClass.Info("Работник успешно отредактирован!");
            }
            catch (Exception ex)
            {

                MBClass.Error(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            bool res =
                MBClass.Question("Вы действительно хотите удалить работника?");

            if (res)
            {
                try
                {
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand("DELETE dbo.[Staffs] " +
                    $"Where StaffID = '{VariableGetID.StaffID}'", sqlConnection);

                    sqlCommand.ExecuteNonQuery();

                    MBClass.Info("Работник успешно удалён!");

                    Close();
                }
                catch (Exception ex)
                {

                    MBClass.Error(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }


        private void FSLNameStaffTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            int strlen = FSLNameStaffTB.Text.Length;
            str = FSLNameStaffTB.Text.Split(' ');

            CheckTextBoxes();

            if (str.Length > 3)
            {
                FSLNameStaffTB.Text = FSLNameStaffTB.Text.Remove(strlen - 1);
            }
        }

        private void PhoneNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxes();
        }

        private void StaffPositionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckTextBoxes();
        }

        private void UserCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckTextBoxes();
        }

        private void CheckTextBoxes()
        {
            if (string.IsNullOrWhiteSpace(FSLNameStaffTB.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberTB.Text) ||
                StaffPositionCB.SelectedIndex == -1 ||
                UserCB.SelectedIndex == -1 ||
                (str.Length == 1 || str.Length == 2 && str[1] == ""))
            {
                EditUserBT.IsEnabled = false;
            }
            else
            {
                EditUserBT.IsEnabled = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (FSLNameStaffTB.IsFocused)
                {
                    PhoneNumberTB.Focus();
                }
                else if (PhoneNumberTB.IsFocused)
                {
                    StaffPositionCB.Focus();
                    StaffPositionCB.IsDropDownOpen = true;
                }
                else if (StaffPositionCB.IsFocused)
                {
                    UserCB.Focus();
                    UserCB.IsDropDownOpen = true;
                }
                else if (UserCB.IsFocused)
                {
                    if (EditUserBT.IsEnabled)
                    {
                        EditUser_Click(sender, e);
                    }
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UserCB_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            VariableGetID.UserID = 
                UserCB.SelectedValue.ToString();

            new EditUserData().ShowDialog();

            cBClass.CBLoadUser(UserCB);
            UserCB.SelectedValue = VariableGetID.UserID;
        }

        private void StaffPositionCB_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            VariableGetID.StaffPositionID =
                 StaffPositionCB.SelectedValue.ToString();

            new EditStaffCondition().ShowDialog();

            cBClass.CBStaffPosition(StaffPositionCB);
            StaffPositionCB.SelectedValue = VariableGetID.StaffPositionID;
        }

        private void AddConditon_Click(object sender, RoutedEventArgs e)
        {
            VariableGetID.StaffPositionID =
                 StaffPositionCB.SelectedValue.ToString();

            new AddStaffCondition().ShowDialog();

            cBClass.CBStaffPosition(StaffPositionCB);
            StaffPositionCB.SelectedValue = VariableGetID.StaffPositionID;
        }

        private void AddUserData_Click(object sender, RoutedEventArgs e)
        {
            VariableGetID.UserID =
       UserCB.SelectedValue.ToString();

            new AddUserData().ShowDialog();

            cBClass.CBLoadUser(UserCB);
            UserCB.SelectedValue = VariableGetID.UserID;
        }
    }
}
