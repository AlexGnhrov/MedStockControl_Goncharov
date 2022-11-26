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

namespace MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow
{
    /// <summary>
    /// Логика взаимодействия для NewConditionDispensingWindow.xaml
    /// </summary>
    public partial class NewConditionDispensingWindow : Window
    {

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand SqlCommand;


        public NewConditionDispensingWindow()
        {
            InitializeComponent();
        }

        private void AddNewCondition(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand =
                    new SqlCommand("Insert Into dbo.[СonditionDispensing] " +
                    "(NameCondtion) " +
                    $"Values('{ConditionDispensingTB.Text}') "
                    ,sqlConnection);

                SqlCommand.ExecuteNonQuery();

                MBClass.Info("Условие отпуска успешно добавлено!");
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
                AddNewConditionBT.IsEnabled = false;
            }
            else
            {
                AddNewConditionBT.IsEnabled = true;
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
                    if (AddNewConditionBT.IsEnabled)
                    {
                        AddNewCondition(sender, e);
                    }
                }

                return;
            }
        }
    }
}
