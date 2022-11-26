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

namespace MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow.ConditionDispensingWindow
{
    /// <summary>
    /// Логика взаимодействия для EditConditionDispensingWindow.xaml
    /// </summary>
    public partial class EditConditionDispensingWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;

        SqlDataReader sqlDataReader;



        public EditConditionDispensingWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand =
                    new SqlCommand("Select * FROM dbo.[СonditionDispensing] " +
                    $"Where СonditionDispensingID = '{VariableGetID.ConditionID}'", sqlConnection);


                sqlDataReader = sqlCommand.ExecuteReader();

                sqlDataReader.Read();

                ConditionDispensingTB.Text = sqlDataReader[1].ToString();


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

        private void EditCondition(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand =
                    new SqlCommand("UPDATE dbo.[СonditionDispensing] " +
                    $"SET NameCondtion = '{ConditionDispensingTB.Text}' " +
                    $"Where СonditionDispensingID = " +
                    $"'{VariableGetID.ConditionID} " +
                    $"'", sqlConnection);

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


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConditionDispensing_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ConditionDispensingTB.Text))
            {
                EditBT.IsEnabled = false;
            }
            else
            {
                EditBT.IsEnabled = true;
            }
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
                if (!string.IsNullOrWhiteSpace(ConditionDispensingTB.Text))
                {
                    if (EditBT.IsEnabled)
                    {
                        EditCondition(sender, e);
                    }
                }

                return;
            }
        }
    }
}
