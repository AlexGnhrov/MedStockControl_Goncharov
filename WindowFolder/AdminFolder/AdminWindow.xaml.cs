using MedStockControl_Goncharov.ClassFolder;
using MedStockControl_Goncharov.WindowFolder.AdminFolder.AditionalWIndows;
using MedStockControl_Goncharov.WindowFolder.AdminFolder.AditionalWIndows.UserData;
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

namespace MedStockControl_Goncharov.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        DGClass dGClass, dGClassUser;

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());
        SqlCommand sqlCommand;

        public AdminWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListUserDG);
            dGClassUser = new DGClass(ListUserDataDG);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("Select * From dbo.[ViewStaff]");
            dGClassUser.LoadDG("Select * From dbo.[ViewUserData]");
        }

        private void ChangeUserMI_CLick(object sender, RoutedEventArgs e)
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

        private void AddUserMI_Click(object sender, RoutedEventArgs e)
        {
            if (UserTI.IsSelected)
            {
                new AdminAddUser().ShowDialog();
                dGClass.LoadDG("Select * From dbo.[ViewStaff]");
            }
            else if (UserDataTI.IsSelected)
            {
                new AddUserData().ShowDialog();

                dGClassUser.LoadDG("Select * From dbo.[ViewUserData]");
            }
        }


        private void Search_TextChange(object sender, TextChangedEventArgs e)
        {
            if (UserTI.IsSelected)
            {
                dGClass.LoadDG("Select * From dbo.[ViewStaff]" +
                $"Where SecondNameStaff Like '%{SearchTB.Text}%' " +
                $"OR FirstNameStaff LIKE '%{SearchTB.Text}%' " +
                $"OR LastNameStaff Like '%{SearchTB.Text}%' " +
                $"OR PhoneNumStaff LIKE '%{SearchTB.Text}%' " +
                $"OR NamePosition LIKE '%{SearchTB.Text}%' " +
                $"OR Login_User Like '%{SearchTB.Text}%'");
            }
            else if (UserDataTI.IsSelected)
            {
                dGClassUser.LoadDG("Select * From dbo.[ViewUserData] " +
                $"Where Login_User Like '%{SearchTB.Text}%' " +
                $"OR Password_User Like '%{SearchTB.Text}%' " +
                $"OR RoleName Like '%{SearchTB.Text}%'");
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedItemDataGrid();
        }

        private void EdiUserMI_Click(object sender, RoutedEventArgs e)
        {
            SelectedItemDataGrid();
        }

        private void DeleteUserMI_Click(object sender, RoutedEventArgs e)
        {
            bool res = MBClass.Question("Вы действительно " +
                "хотите удалить пользователя?");
            VariableGetID.StaffID = dGClass.LoadID();

            if (res == true)
            {

                try
                {

                    sqlConnection.Open();

                    sqlCommand = new SqlCommand("DELETE dbo.[Staffs] " +
                    $"Where StaffID = '{VariableGetID.StaffID}'", sqlConnection);

                    sqlCommand.ExecuteNonQuery();

                    MBClass.Info("Работник успешно удалён!");

                    dGClass.LoadDG("Select * From dbo.[ViewStaff]");
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

        private void DataGrid2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedItemDataGrid();
        }

        private void SelectedItemDataGrid()
        {
            if (UserTI.IsSelected)
            {
                if (ListUserDG.SelectedItem == null)
                {
                    MBClass.Error("Выбранной таблицы не существует");
                }
                else
                {
                    VariableGetID.StaffID = dGClass.LoadID();

                    new AdminEditUser().ShowDialog();

                    dGClass.LoadDG("Select * From dbo.[ViewStaff]");
                }
            }
            else if (UserDataTI.IsSelected)
            {
                if (ListUserDataDG.SelectedItem == null)
                {
                    MBClass.Error("Выбранной таблицы не существует");
                }
                else
                {

                    VariableGetID.UserID = dGClassUser.LoadID();

                    new EditUserData().ShowDialog();

                    dGClassUser.LoadDG("Select * From dbo.[ViewUserData]");
                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (UserTI.IsSelected)
            {
                AddMI.Header = "Добавить пользователя";
            }
            else if (UserDataTI.IsSelected)
            {
                AddMI.Header = "Добавить данные пользователя";
            }

        }
    }
}

