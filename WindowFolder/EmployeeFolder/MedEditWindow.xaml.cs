using MedStockControl_Goncharov.ClassFolder;
using MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow;
using MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow.ConditionDispensingWindow;
using MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow.ManufacturerWindow;
using MedStockControl_Goncharov.WindowFolder.EmployeeFolder.AdditionalWindow.PharmoGroupWindow;
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
    /// Логика взаимодействия для MedEditWindow.xaml
    /// </summary>
    public partial class MedEditWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;

        CBClass cBClass;

        public MedEditWindow()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.CBLoadCondDisp(СonditionForDispensing_StuffCB);
            cBClass.CBLoadPharmacoGroup(PharmacoGroup_StuffCB);
            cBClass.CBLoadManufacture(Manufacturer_StuffCB);

            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand("SELECT * FROM dbo.[Stuff] " +
                    $"Where StuffID = '{VariableGetID.StuffID}' ",
                    sqlConnection);

                sqlDataReader = sqlCommand.ExecuteReader();

                sqlDataReader.Read();

                Name_StuffTB.Text = sqlDataReader[1].ToString();
                Manufacturer_StuffCB.SelectedValue = sqlDataReader[2].ToString();
                Composition_StuffTB.Text = sqlDataReader[3].ToString();
                Description_StuffTB.Text = sqlDataReader[4].ToString();
                Indication_StuffTB.Text = sqlDataReader[5].ToString();
                Contraindication_StuffTB.Text = sqlDataReader[6].ToString();
                PharmacoGroup_StuffCB.SelectedValue = sqlDataReader[7].ToString();
                MethodUsage_StuffTB.Text = sqlDataReader[8].ToString();
                SideEffects_StuffTB.Text = sqlDataReader[9].ToString();
                Overdose_StuffTB.Text = sqlDataReader[10].ToString();
                Interaction_StuffTB.Text = sqlDataReader[11].ToString();
                SpecInstruct_StuffTB.Text = sqlDataReader[12].ToString();
                StorageСondition_StuffTB.Text = sqlDataReader[13].ToString();
                ReleaseForm_StuffTB.Text = sqlDataReader[14].ToString();
                DateOfRelease_StuffTB.Text = sqlDataReader[15].ToString();
                ExpirationDate_StuffTB.Text = sqlDataReader[16].ToString();
                СonditionForDispensing_StuffCB.SelectedValue = sqlDataReader[17].ToString();
                Amount_StuffTB.Text = sqlDataReader[18].ToString();
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

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(Composition_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(Description_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(Indication_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(Contraindication_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(MethodUsage_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(SideEffects_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(Overdose_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(Interaction_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(SpecInstruct_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(StorageСondition_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(ReleaseForm_StuffTB.Text) ||
            string.IsNullOrWhiteSpace(DateOfRelease_StuffTB.Text) ||
            Manufacturer_StuffCB.SelectedIndex == -1 ||
            PharmacoGroup_StuffCB.SelectedIndex == -1 ||
            СonditionForDispensing_StuffCB.SelectedIndex == -1)
            {
                MBClass.Error("Не все поля заполнены!");
            }
            else
            {
                try
                {
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand("Update dbo.[Stuff] " +
                        $"Set NameStuff = '{Name_StuffTB.Text}' ," +
                        $"ManufacterID = '{Manufacturer_StuffCB.SelectedValue}', " +
                        $"Composition = '{Composition_StuffTB.Text}', " +
                        $"Description = '{Description_StuffTB.Text}', " +
                        $"Indication = '{Indication_StuffTB.Text}', " +
                        $"Contraindication = '{Contraindication_StuffTB.Text}', " +
                        $"PharmacoGroupID = '{PharmacoGroup_StuffCB.SelectedValue}', " +
                        $"MethodUsage = '{MethodUsage_StuffTB.Text}', " +
                        $"SideEffects = '{SideEffects_StuffTB.Text}', " +
                        $"Overdose = '{Overdose_StuffTB.Text}', " +
                        $"Interaction = '{Interaction_StuffTB.Text}', " +
                        $"SpecInstruct = '{SpecInstruct_StuffTB.Text}', " +
                        $"StorageСondition = '{StorageСondition_StuffTB.Text}', " +
                        $"ReleaseForm = '{ReleaseForm_StuffTB.Text}', " +
                        $"DateOfRelease = " +
                        $"      '{DateTime.Parse(DateOfRelease_StuffTB.Text)}', " +
                        $"ExpirationDate =" +
                        $"     '{DateTime.Parse(ExpirationDate_StuffTB.Text)}', " +
                        $"СonditionDispensingID = " +
                        $"               '{СonditionForDispensing_StuffCB.SelectedValue}', " +
                        $"Amount = '{Amount_StuffTB.Text}' " +
                        $"Where StuffID = '{VariableGetID.StuffID}' "
                        , sqlConnection);

                    sqlCommand.ExecuteNonQuery();

                    MBClass.Info("Редактирование произошло успешно!");
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand("DELETE FROM dbo.[Stuff] " +
                    $"Where StuffID = '{VariableGetID.StuffID}' ",
                    sqlConnection);

                sqlCommand.ExecuteNonQuery();

                MBClass.Info("Препарат успешно удалён!");
                Close();
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


        private void EditManufacturer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            VariableGetID.ManufacturerID =
            Manufacturer_StuffCB.SelectedValue.ToString();

            new EditManufacturerWindow().ShowDialog();

            cBClass.CBLoadManufacture(Manufacturer_StuffCB);
            Manufacturer_StuffCB.SelectedValue = VariableGetID.ManufacturerID;

        }

        private void EditFramGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          VariableGetID.PharmoGroupID = 
                PharmacoGroup_StuffCB.SelectedValue.ToString();

            new EditPharmoGroup().ShowDialog();

            cBClass.CBLoadPharmacoGroup(PharmacoGroup_StuffCB);
            PharmacoGroup_StuffCB.SelectedValue = VariableGetID.PharmoGroupID;
        }

        private void EditCondition_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VariableGetID.ConditionID = 
                СonditionForDispensing_StuffCB.SelectedValue.ToString();

            new EditConditionDispensingWindow().ShowDialog();

            cBClass.CBLoadCondDisp(СonditionForDispensing_StuffCB);
            СonditionForDispensing_StuffCB.SelectedValue =
                VariableGetID.ConditionID;
        }

    }
}
