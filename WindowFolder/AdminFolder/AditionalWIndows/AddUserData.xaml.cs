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

namespace MedStockControl_Goncharov.WindowFolder.AdminFolder.AditionalWIndows
{
    /// <summary>
    /// Логика взаимодействия для AddUserData.xaml
    /// </summary>
    public partial class AddUserData : Window
    {
        CBClass cBClass;
        public AddUserData()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }





        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.CBLoadUserRole(RoleCB);
        }


        private void UserAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand("INSERT INTO dbo.[User] " +
                    "(Login_User, Password_User,RoleID) " +
                    $"Values('{EmailTB.Text}', " +
                    $"      '{PasswordTB.Text}', " +
                    $"      '{RoleCB.SelectedValue}')", sqlConnection);

                sqlCommand.ExecuteNonQuery();

                MBClass.Info("Данные пользователя успешно добавлены!");
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
                AddUserBT.IsEnabled = false;
            }
            else
            {
                AddUserBT.IsEnabled = true;
            }
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
                    if (AddUserBT.IsEnabled)
                    {
                        UserAdd_Click(sender, e);
                    }
                }
            }
        }
    }
}

