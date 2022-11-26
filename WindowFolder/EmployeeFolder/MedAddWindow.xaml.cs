using MedStockControl_Goncharov.ClassFolder;
using MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow;
using MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow.ManufacturerWindow;
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
    /// Логика взаимодействия для MedAddWindow.xaml
    /// </summary>
    public partial class MedAddWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlCommand sqlCommand;

        CBClass cBClass;


        public MedAddWindow()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.CBLoadCondDisp(СonditionForDispensing_StuffCB);
            cBClass.CBLoadPharmacoGroup(PharmacotherapeuticGroup_StuffCB);
            cBClass.CBLoadManufacture(Manufacturer_StuffCB);

        }

        private void AddStuff_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(Composition_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(Description_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(Indication_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(Contraindication_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(Usage_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(SideEffects_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(Overdose_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(Interaction_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(SpecInstruct_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(StorageСondition_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(ReleaseForm_StuffTB.Text) ||
                string.IsNullOrWhiteSpace(DateOfRelease_StuffTB.Text) ||
                Manufacturer_StuffCB.SelectedIndex == -1 ||
                PharmacotherapeuticGroup_StuffCB.SelectedIndex == -1 ||
                СonditionForDispensing_StuffCB.SelectedIndex == -1)
            {
                MBClass.Error("Не все поля заполнены");
            }
            else


                try
                {
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand("INSERT INTO dbo.[Stuff] " +
                        "(NameStuff, ManufacterID, Composition, Description," +
                        " Indication, Contraindication, PharmacoGroupID, " +
                        "MethodUsage, SideEffects, Overdose, Interaction, " +
                        "SpecInstruct, StorageСondition, ReleaseForm, DateOfRelease, " +
                        "ExpirationDate, СonditionDispensingID, Amount) " +
                        $"VALUES ('{Name_StuffTB.Text}', " +
                        $"'{Manufacturer_StuffCB.SelectedValue}'," +
                        $"'{Composition_StuffTB.Text}'," +
                        $"'{Description_StuffTB.Text}', " +
                        $"'{Indication_StuffTB.Text}', " +
                        $"'{Contraindication_StuffTB.Text}', " +
                        $"'{PharmacotherapeuticGroup_StuffCB.SelectedValue}', " +
                        $"'{Usage_StuffTB.Text}', " +
                        $"'{SideEffects_StuffTB.Text}', " +
                        $"'{Overdose_StuffTB.Text}', " +
                        $"'{Interaction_StuffTB.Text}', " +
                        $"'{SpecInstruct_StuffTB.Text}', " +
                        $"'{StorageСondition_StuffTB.Text}', " +
                        $"'{ReleaseForm_StuffTB.Text}', " +
                        $"'{DateTime.Parse(DateOfRelease_StuffTB.Text)}', " +
                        $"'{DateTime.Parse(ExpirationDate_StuffTB.Text)}', " +
                        $"'{СonditionForDispensing_StuffCB.SelectedValue}', " +
                        $"'{Amount_StuffTB.Text}')", sqlConnection);

                    sqlCommand.ExecuteNonQuery();

                    MBClass.Info("Препарат успешно добавлен!");
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


        private void AddNewManufacturer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new AddManufacturerWindow().ShowDialog();
        }

        private void AddNewFramGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new NewPharmoGroupWindow().ShowDialog();
        }

        private void AddNewCondition_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new NewConditionDispensingWindow().ShowDialog();
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DateOfRelease_StuffTB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ExpirationDate_StuffTB.SelectedDate == null ||
                ExpirationDate_StuffTB.SelectedDate < DateOfRelease_StuffTB.SelectedDate)
            {
                ExpirationDate_StuffTB.Text = DateOfRelease_StuffTB.Text;
            }
        }

        private void ExpirationDate_StuffTB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DateOfRelease_StuffTB.SelectedDate == null ||
                ExpirationDate_StuffTB.SelectedDate < DateOfRelease_StuffTB.SelectedDate)
            {
                    DateOfRelease_StuffTB.Text = ExpirationDate_StuffTB.Text;
            }
        }
    }
}
