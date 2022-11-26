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
    /// Логика взаимодействия для AdminAddUser.xaml
    /// </summary>
    public partial class AdminAddUser : Window
    {
        CBClass cBClass;

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;

        public AdminAddUser()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }


        string[] str = new string[3];

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.CBStaffPosition(StaffPositionCB);
            cBClass.CBLoadUser(UserCB);
        }


        private void AddStaffBT_Click(object sender, RoutedEventArgs e)
        {

            str = FSLNameStaffTB.Text.Split(' ');

            try
            {
                sqlConnection.Open();

                if (str.Length == 2)
                {
                    sqlCommand = new SqlCommand("INSERT INTO dbo.[Staffs] " +
                   "(FirstNameStaff, " +
                   "SecondNameStaff, " +
                   "PhoneNumStaff, " +
                   "PositionStaffID, " +
                   "UserID) " +
                   $"Values('{str[1]}', " +
                   $"      '{str[0]}', " +
                   $"      '{PhoneNumberTB.Text}', " +
                   $"      '{StaffPositionCB.SelectedValue.ToString()}'," +
                   $"      '{UserCB.SelectedValue.ToString()}')", sqlConnection);
                }
                else
                {
                    sqlCommand = new SqlCommand("INSERT INTO dbo.[Staffs] " +
                   "(FirstNameStaff, " +
                   "SecondNameStaff, " +
                   "LastNameStaff, " +
                   "PhoneNumStaff, " +
                   "PositionStaffID, " +
                   "UserID) " +
                   $"Values('{str[1]}', " +
                   $"      '{str[0]}', " +
                   $"      '{str[2]}', " +
                   $"      '{PhoneNumberTB.Text}', " +
                   $"      '{StaffPositionCB.SelectedValue.ToString()}'," +
                   $"      '{UserCB.SelectedValue.ToString()}')", sqlConnection);
                }

                sqlCommand.ExecuteNonQuery();

                MBClass.Info("Работник успешно добавлен!");
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
        

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void FSLNameStaffTB_TextChanged(object sender, TextChangedEventArgs e)
        {

            int strlen = FSLNameStaffTB.Text.LastIndexOf(" ");
            str = FSLNameStaffTB.Text.Split(' ');

            CheckTextBoxes();

            if (str.Length > 3 )
            {


                FSLNameStaffTB.Text = "хуууууууй";
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
                (str.Length == 1 ||str.Length == 2 && str[1] == ""))

            {
               
                AddStaffBT.IsEnabled = false;

            }
            else
            {
                AddStaffBT.IsEnabled = true;
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
                    if (AddStaffBT.IsEnabled)
                    {
                        AddStaffBT_Click(sender, e);
                    }
                }
            }
        }



        private void UserCB_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (UserCB.SelectedValue == null)
            {
                MBClass.Error("Вы не выбрали пользователя!");
            }
            else
            {
                VariableGetID.UserID =
                    UserCB.SelectedValue.ToString();

                new EditUserData().ShowDialog();

                cBClass.CBLoadUser(UserCB);
                UserCB.SelectedValue = VariableGetID.UserID;
            }
        }

        private void StaffPositionCB_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (StaffPositionCB.SelectedValue == null)
            {
                MBClass.Error("Вы не выбрали должность!");
            }
            else
            {
                VariableGetID.StaffPositionID =
                     StaffPositionCB.SelectedValue.ToString();

                new EditStaffCondition().ShowDialog();

                cBClass.CBStaffPosition(StaffPositionCB);
                StaffPositionCB.SelectedValue = VariableGetID.StaffPositionID;
            }
        }


        private void AddStaffPosition_Click(object sender, RoutedEventArgs e)
        {
            if (StaffPositionCB.SelectedValue == null)
            {

                new AddStaffCondition().ShowDialog();

                cBClass.CBStaffPosition(StaffPositionCB);
            }
            else
            {
                VariableGetID.StaffPositionID =
                      StaffPositionCB.SelectedValue.ToString();

                new AddStaffCondition().ShowDialog();


                cBClass.CBStaffPosition(StaffPositionCB);
                StaffPositionCB.SelectedValue = VariableGetID.StaffPositionID;

            }

        }

        private void AddDataUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserCB.SelectedValue == null)
            {
                new AddUserData().ShowDialog();

                cBClass.CBLoadUser(UserCB);

            }
            else
            {
                VariableGetID.UserID =
                       UserCB.SelectedValue.ToString();

                new AddUserData().ShowDialog();

                cBClass.CBLoadUser(UserCB);
                UserCB.SelectedValue = VariableGetID.UserID;

            }
        }
    }
}
