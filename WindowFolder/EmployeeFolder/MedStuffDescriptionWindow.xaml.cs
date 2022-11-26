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

namespace MedStockControl_Goncharov.WindowFolder.EmployeeFolder
{
    /// <summary>
    /// Логика взаимодействия для MedStuffDescriptionWindow.xaml
    /// </summary>
    public partial class MedStuffDescriptionWindow : Window
    {


        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;

        public MedStuffDescriptionWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand("SELECT * FROM dbo.[Stuff] " +
                    $"Where StuffID = '{VariableGetID.StufID}' ",sqlConnection);

                sqlDataReader = sqlCommand.ExecuteReader();

                sqlDataReader.Read();

                NameStuffTB.Text = sqlDataReader[1].ToString();
                ManufacturerStuffTB.Text = sqlDataReader[2].ToString();
                CompositionStuffTB.Text = sqlDataReader[3].ToString();
                DescriptionStuffTB.Text = sqlDataReader[4].ToString(); 
                IndicationStuffTB.Text = sqlDataReader[5].ToString();
                ContraindicationStuffTB.Text = sqlDataReader[6].ToString();
                PharmacoGroupStuffTB.Text = sqlDataReader[7].ToString();
                MethodUsageStuffTB.Text = sqlDataReader[8].ToString();
                SideEffectsStuffTB.Text = sqlDataReader[9].ToString();
                OverdoseStuffTB.Text = sqlDataReader[10].ToString();
                InteractionStuffTB.Text = sqlDataReader[11].ToString();
                SpecInstructStuffTB.Text = sqlDataReader[12].ToString();
                StorageСonditionStuffTB.Text = sqlDataReader[13].ToString();
                ReleaseFormStuffTB.Text = sqlDataReader[14].ToString();
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
    }
}
