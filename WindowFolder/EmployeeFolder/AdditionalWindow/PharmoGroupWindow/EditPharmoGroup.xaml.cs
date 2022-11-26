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

namespace MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow.PharmoGroupWindow
{
    /// <summary>
    /// Логика взаимодействия для EditPharmoGroup.xaml
    /// </summary>
    public partial class EditPharmoGroup : Window
    {

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;

        SqlDataReader sqlDataReader;

        public EditPharmoGroup()
        {
            InitializeComponent();
        }

        private void PharmoGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PharmoGroupTB.Text))
            {
                EditBT.IsEnabled = false;
            }
            else
            {
                EditBT.IsEnabled = true;
            }
        }

        private void EditGroup(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand =
                    new SqlCommand("UPDATE dbo.[PharmacoGroup] " +
                    $"SET NameGroup = '{PharmoGroupTB.Text}' " +
                    $"Where PharmacoGroupID = " +
                    $"'{VariableGetID.PharmoGroupID} " +
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand =
                    new SqlCommand("Select * FROM dbo.[PharmacoGroup] " +
                    $"WHERE PharmacoGroupID = '{VariableGetID.PharmoGroupID}'"
                    , sqlConnection);


                sqlDataReader = sqlCommand.ExecuteReader();

                sqlDataReader.Read();

                PharmoGroupTB.Text = sqlDataReader[1].ToString();


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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();

                return;
            }
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(PharmoGroupTB.Text))
                {
                    if (EditBT.IsEnabled)
                    {
                        EditGroup(sender, e);
                    }
                }

                return;
            }
        }

    }
}
