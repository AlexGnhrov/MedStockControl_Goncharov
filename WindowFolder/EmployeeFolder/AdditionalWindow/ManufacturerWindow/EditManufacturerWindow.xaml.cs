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

namespace MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow.ManufacturerWindow
{
    /// <summary>
    /// Логика взаимодействия для EditManufacturerWindow.xaml
    /// </summary>
    public partial class EditManufacturerWindow : Window
    {

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;

        SqlDataReader sqlDataReader;

        public EditManufacturerWindow()
        {
            InitializeComponent();
        }

        string[] str = new string[3];


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand("SELECT * FROM dbo.[Manufacter] " +
                    $"WHERE ManufacterID = '{VariableGetID.ManufacturerID}'",
                    sqlConnection);

                sqlDataReader = sqlCommand.ExecuteReader();

                sqlDataReader.Read();

                NameManufacterTB.Text = sqlDataReader[1].ToString();

                FSLNameResponPerseonTB.Text += sqlDataReader[3].ToString() +        
                                          " "+ sqlDataReader[2].ToString()+
                                          " "+ sqlDataReader[4].ToString();

                PhoneNumNameResponPersonTB.Text = sqlDataReader[5].ToString();

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

        private void EditManufacterBT_Click(object sender, RoutedEventArgs e)
        {
            str = FSLNameResponPerseonTB.Text.Split(' ');

            try
            {
                sqlConnection.Open();

                if(str.Length == 2)
                {
                    sqlCommand = new SqlCommand("UPDATE dbo.[Manufacter] " +
                       $"SET NameManufacter = '{NameManufacterTB.Text}'," +
                       $"    FirstNameResponPerson = '{str[1]}', " +
                       $"    SecondNameResponPerson = '{str[0]}', " +
                       $"    PhoneNumber = " +
                       $"           '{PhoneNumNameResponPersonTB.Text}'" +
                       $"WHERE ManufacterID = " +
                       $"            '{VariableGetID.ManufacturerID}'",
                       sqlConnection);
                }
                else
                {
                    sqlCommand = new SqlCommand("UPDATE dbo.[Manufacter] " +
                       $"SET NameManufacter = '{NameManufacterTB.Text}'," +
                       $"    FirstNameResponPerson = '{str[1]}', " +
                       $"    SecondNameResponPerson = '{str[0]}', " +
                       $"    LastNameResponPerson = '{str[2]}', " +
                       $"    PhoneNumber = " +
                       $"           '{PhoneNumNameResponPersonTB.Text}'" +
                       $"WHERE ManufacterID = " +
                       $"            '{VariableGetID.ManufacturerID}'",
                       sqlConnection);
                }

                sqlCommand.ExecuteNonQuery();

                MBClass.Info("Редактирование прошло успешно!");
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

        private void NameManufacterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButtonByTB();
        }

        private void FSLNameResponPerseonTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            int strlen = FSLNameResponPerseonTB.Text.Length;
            str = FSLNameResponPerseonTB.Text.Split(' ');

            EnableButtonByTB();

            if (str.Length > 3)
            {
                FSLNameResponPerseonTB.Text =
                    FSLNameResponPerseonTB.Text.Remove(strlen - 1);
            }
        }

        private void NumPhoneNameResponPerseonTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButtonByTB();
        }


        private void EnableButtonByTB()
        {
            if (string.IsNullOrWhiteSpace(NameManufacterTB.Text) ||
                string.IsNullOrWhiteSpace(FSLNameResponPerseonTB.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumNameResponPersonTB.Text) ||
                (str.Length == 1 || str.Length == 2 && str[1] == ""))
            {
                EditBT.IsEnabled = false;
            }
            else
            {
                EditBT.IsEnabled = true;
            }
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();

                return;
            }
            if (e.Key == Key.Enter)
            {
                if (NameManufacterTB.IsFocused)
                {
                    FSLNameResponPerseonTB.Focus();
                }
                else if (FSLNameResponPerseonTB.IsFocused)
                {
                    PhoneNumNameResponPersonTB.Focus();
                }
                else if (PhoneNumNameResponPersonTB.IsFocused)
                {
                    if (EditBT.IsEnabled)
                    {
                        EditManufacterBT_Click(sender, e);
                    }
                }

                return;
            }
        }
    }
}
