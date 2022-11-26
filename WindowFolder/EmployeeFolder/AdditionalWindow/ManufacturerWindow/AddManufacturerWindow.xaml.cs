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
    /// Логика взаимодействия для AddManufacturerWindow.xaml
    /// </summary>
    public partial class AddManufacturerWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;

        string[] str = new string[3];

        public AddManufacturerWindow()
        {
            InitializeComponent();
        }

        private void AddManufacterBT_Click(object sender, RoutedEventArgs e)
        {

            str = FSLNameResponPerseonTB.Text.Split(' ');


            try
            {
                sqlConnection.Open();

                if (str.Length == 2)
                {
                    sqlCommand =
                        new SqlCommand("INSERT INTO dbo.[Manufacter] " +
                        "(NameManufacter," +
                        " FirstNameResponPerson," +
                        " SecondNameResponPerson," +
                        "PhoneNumber) " +
                        $"VALUES" +
                        $" ('{NameManufacterTB.Text}', " +
                        $" '{str[0]}', " +
                        $" '{str[1]}', " +
                        $" '{PhoneNumNameResponPersonTB.Text}')",
                        sqlConnection);
                }
                else
                {
                    sqlCommand =
                   new SqlCommand("INSERT INTO dbo.[Manufacter] " +
                   "(NameManufacter," +
                   " FirstNameResponPerson," +
                   " SecondNameResponPerson," +
                   " LastNameResponPerson, " +
                   "PhoneNumber) " +
                   $"VALUES" +
                   $" ('{NameManufacterTB.Text}', " +
                   $" '{str[0]}', " +
                   $" '{str[1]}', " +
                   $" '{str[2]}', " +
                   $" '{PhoneNumNameResponPersonTB.Text}')",
                   sqlConnection);
                }

                sqlCommand.ExecuteNonQuery();

                MBClass.Info("Производитель успешно добавлен!");
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
                FSLNameResponPerseonTB.Text = FSLNameResponPerseonTB.Text.Remove(strlen-1);
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
                string.IsNullOrWhiteSpace(PhoneNumNameResponPersonTB.Text)||
                (str.Length == 1 || str.Length == 2 && str[1] == ""))
            {
                AddManufacterBT.IsEnabled = false;
            }
            else
            {
                AddManufacterBT.IsEnabled = true;
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
                if(NameManufacterTB.IsFocused)
                {
                    FSLNameResponPerseonTB.Focus();
                }
                else if(FSLNameResponPerseonTB.IsFocused)
                {
                    PhoneNumNameResponPersonTB.Focus();
                }
                else if (PhoneNumNameResponPersonTB.IsFocused)
                {
                    if (AddManufacterBT.IsEnabled)
                    {
                        AddManufacterBT_Click(sender, e);
                    }
                }

                return;
            }
        }
    }
}