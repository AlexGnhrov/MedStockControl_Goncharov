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
    /// Логика взаимодействия для AddStaffCondition.xaml
    /// </summary>
    public partial class AddStaffCondition : Window
    {

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand SqlCommand;

        public AddStaffCondition()
        {
            InitializeComponent();
        }


        private void AddNewPositionBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand =
                    new SqlCommand("Insert Into dbo.[PositionStaff] " +
                    "(NamePosition) " +
                    $"Values('{PositionStaff.Text}') "
                    , sqlConnection);

                SqlCommand.ExecuteNonQuery();

                MBClass.Info("Должность успешно добавлена!");
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

        private void PositionStaff_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PositionStaff.Text))
            {
                AddNewPositionBT.IsEnabled = false;
            }
            else
            {
                AddNewPositionBT.IsEnabled = true;
            }
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Close();

                return;
            }
            if(e.Key == Key.Enter)
            {
                if(!string.IsNullOrWhiteSpace(PositionStaff.Text))
                {
                    if(AddNewPositionBT.IsEnabled)
                    {
                        AddNewPositionBT_Click(sender, e);
                    }
                }
                return;
            }
        }
    }
}
