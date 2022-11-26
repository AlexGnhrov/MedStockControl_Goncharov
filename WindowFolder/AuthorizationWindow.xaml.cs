using System.Data.SqlClient;
using System.Windows; 
using System.Windows.Controls;
using System.Windows.Input;
using System;
using MedStockControl_Goncharov.ClassFolder;
using MedStockControl_Goncharov.WindowFolder.AdminFolder;
using MedStockControl_Goncharov.WindowFolder.EmployeeFolder;

namespace MedStockControl_Goncharov.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;


        private void LogInBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * From dbo.[User]" +
                    $"Where Login_User = '{EmailTB.Text}'", sqlConnection);

                sqlDataReader = sqlCommand.ExecuteReader();

                sqlDataReader.Read();

                if (sqlDataReader[2].ToString() != PasswordPB.Password)
                {
                    throw
                        new InvalidCastException("Неверный логин или пароль");
                }
                else
                {
                    switch (sqlDataReader[3].ToString())
                    {
                        case "1":
                            new AdminWindow().Show();
                            Close();
                            break;
                        case "2":
                            new MedEmployeeWindow().Show();
                            Close();
                            break;
                    }
                }


            }
            catch (InvalidOperationException)
            {
                MBClass.Error("Неверный логин или пароль");
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
           EnableLogInBT();
            if (string.IsNullOrWhiteSpace(EmailTB.Text))
            {
                EmailTB.Text = "";
                EmailLB.Content = "Логин";
            }
            else
            {
                EmailLB.Content = "";
            }
        }

        private void PasswordPB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            EnableLogInBT();

            if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                PasswordPB.Password = "";
                PasswordLB.Content = "Пароль";
            }
            else
            {
                PasswordLB.Content = "";
            }

        }



        void EnableLogInBT ()
        {
            if (string.IsNullOrWhiteSpace(EmailTB.Text) || 
                string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                LogInBT.IsEnabled = false;
            }
            else
            {
                LogInBT.IsEnabled = true;
            }
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            MBClass.Exit();
        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (EmailTB.IsFocused)
                {
                    PasswordPB.Focus();
                }
                else if (PasswordPB.IsFocused)
                {
                    if (LogInBT.IsEnabled)
                    {
                        LogInBT_Click(sender, e);
                    }
                }
            }
        }
    }
}
