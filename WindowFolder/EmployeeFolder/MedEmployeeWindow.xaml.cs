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
    /// Логика взаимодействия для MedEmployeeWindow.xaml
    /// </summary>
    public partial class MedEmployeeWindow : Window
    {

        DGClass dGClass;

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());
        SqlCommand sqlCommand;

        public MedEmployeeWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListStuffDG);
        }

        string StrDGCommand = "SELECT * From dbo.[ViewStuff]";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG(StrDGCommand);
        }

        private void Search_TextChange(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG(StrDGCommand +
                           $"WHERE NameStuff LIKE '%{SearchTB.Text}%' " +
                           $"OR DateOfRelease LIKE '%{SearchTB.Text}%' " +
                           $"OR ExpirationDate LIKE  '%{SearchTB.Text}%' " +
                           $"OR NameCondtion LIKE  '%{SearchTB.Text}%' " +
                           $"OR Amount LIKE  '%{SearchTB.Text}%' ");
        }

        private void AddStuffMI_Click(object sender, RoutedEventArgs e)
        {
            new MedAddWindow().ShowDialog();
            dGClass.LoadDG(StrDGCommand);
        }


        private void ChangeUserMI_Click(object sender, RoutedEventArgs e)
        {
            bool res = MBClass.Question("Вы действительно хотите" +
                            " выйти из учётной записи?");

            if (res)
            {
                new AuthorizationWindow().Show();
                Close();
            }
        }


        private void ExitMI_Click(object sender, RoutedEventArgs e)
        {
            MBClass.Exit();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenDescriptionDG();
        }

        private void MedDelete_Click(object sender, RoutedEventArgs e)
        {
            bool res = MBClass.Question("Вы действительно хотите " +
                                            "удалить препарат?");

            VariableGetID.StuffID = dGClass.LoadID();
            if (res)
            {

                try
                {
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand("DELETE dbo.[Stuff] " +
                        $"Where StuffID = '{VariableGetID.StuffID}' ",
                        sqlConnection);

                    sqlCommand.ExecuteNonQuery();

                    MBClass.Info("Препарат удалён успешно!");
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
            dGClass.LoadDG(StrDGCommand);

        }

        private void MedEdit_Click(object sender, RoutedEventArgs e)
        {
            VariableGetID.StuffID = dGClass.LoadID();
            new MedEditWindow().ShowDialog();
            dGClass.LoadDG(StrDGCommand);
        }

        private void MedDescription_Click(object sender, RoutedEventArgs e)
        {
            OpenDescriptionDG();
        }


        private void OpenDescriptionDG()
        {
            if (ListStuffDG.SelectedItem == null)
            {
                MBClass.Error("Вы не выбрали таблицу");
            }
            else
            {
                VariableGetID.StuffID = dGClass.LoadID();
                new MedStuffDescriptionWindow().ShowDialog();
                dGClass.LoadDG(StrDGCommand);
            }
        }

    }
}
