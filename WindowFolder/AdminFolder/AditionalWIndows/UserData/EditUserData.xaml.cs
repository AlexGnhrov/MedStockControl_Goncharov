using MedStockControl_Goncharov.ClassFolder;
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

namespace MedStockControl_Goncharov.WindowFolder.AdminFolder.AditionalWIndows.UserData
{
    /// <summary>
    /// Логика взаимодействия для EditUserData.xaml
    /// </summary>
    public partial class EditUserData : Window
    {

        CBClass cBClass;

        public EditUserData()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;

        SqlDataReader sqlDataReader;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.CBLoadUserRole(RoleCB);

            try
            {
                sqlConnection.Open();

                sqlCommand =  new SqlCommand("SELECT * FROM dbo.[User] " +
                    $"WHERE UserID = '{VariableGetID.UserID}' ",sqlConnection);


                sqlDataReader = sqlCommand.ExecuteReader();

                sqlDataReader.Read();


                EmailTB.Text = sqlDataReader[1].ToString();
                PasswordTB.Text = sqlDataReader[2].ToString();
                RoleCB.SelectedValue =  sqlDataReader[3].ToString();

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


        private void EditUserBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand("UPDATE dbo.[User] " +
                    $"SET Login_User = '{EmailTB.Text}', " +
                    $"    Password_User = '{PasswordTB.Text}'," +
                    $"    RoleID = '{RoleCB.SelectedValue.ToString()}' " +
                    $"WHERE UserID = '{VariableGetID.UserID}' ",
                    sqlConnection);

                sqlCommand.ExecuteNonQuery();

                MBClass.Info("Данные пользователя успешно отредактированы!");
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



        private void EmailTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxes();
        }

        private void PasswordTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxes();
        }

        private void RoleCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckTextBoxes();
        }

        private void CheckTextBoxes()
        {
            if (string.IsNullOrWhiteSpace(EmailTB.Text) ||
                string.IsNullOrWhiteSpace(PasswordTB.Text) ||
                RoleCB.SelectedIndex == -1)
            {
                EditUserBT.IsEnabled = false;
            }
            else
            {
                EditUserBT.IsEnabled = true;
            }
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (EmailTB.IsFocused)
                {
                    PasswordTB.Focus();
                }
                else if (PasswordTB.IsFocused)
                {
                    RoleCB.Focus();
                    RoleCB.IsDropDownOpen = true;
                }
                else if (RoleCB.SelectedIndex != -1)
                {
                    if (EditUserBT.IsEnabled)
                    {
                        EditUserBT_Click(sender, e);
                    }
                }
            }
        }
    }
}

