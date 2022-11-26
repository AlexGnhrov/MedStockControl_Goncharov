using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedStockControl_Goncharov.ClassFolder
{
    class CBClass
    {

        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        public void CBLoadUserRole(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select RoleID," +
                    " RoleName FROM dbo.[Role]" +
                    " Order by RoleID ASC", sqlConnection);

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet,"[Role]");



                comboBox.ItemsSource = dataSet.Tables["[Role]"].DefaultView;

                comboBox.DisplayMemberPath = dataSet.Tables["[Role]"].
                    Columns["RoleName"].ToString();

                comboBox.SelectedValuePath = dataSet.Tables["[Role]"].
                    Columns["RoleID"].ToString();

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
        public void CBLoadCondDisp(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter =
                    new SqlDataAdapter("Select СonditionDispensingID," +
                    " NameCondtion FROM dbo.[СonditionDispensing]" +
                    " Order by СonditionDispensingID ASC",
                    sqlConnection);

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "[СonditionDispensing]");



                comboBox.ItemsSource = dataSet.
                    Tables["[СonditionDispensing]"].
                    DefaultView;

                comboBox.DisplayMemberPath = dataSet.
                    Tables["[СonditionDispensing]"].
                    Columns["NameCondtion"].ToString();

                comboBox.SelectedValuePath = dataSet.
                    Tables["[СonditionDispensing]"].
                    Columns["СonditionDispensingID"].ToString();

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
        public void CBLoadPharmacoGroup(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter =
                    new SqlDataAdapter("Select PharmacoGroupID," +
                    " NameGroup FROM dbo.[PharmacoGroup]" +
                    " Order by PharmacoGroupID ASC",
                    sqlConnection);

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "[PharmacoGroup]");


                comboBox.ItemsSource = dataSet.
                    Tables["[PharmacoGroup]"].
                    DefaultView;

                comboBox.DisplayMemberPath = dataSet.
                    Tables["[PharmacoGroup]"].
                    Columns["NameGroup"].ToString();

                comboBox.SelectedValuePath = dataSet.
                    Tables["[PharmacoGroup]"].
                    Columns["PharmacoGroupID"].ToString();

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

        public void CBLoadManufacture(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter =
                    new SqlDataAdapter("Select ManufacterID," +
                    " NameManufacter FROM dbo.[Manufacter]" +
                    " Order by ManufacterID ASC",
                    sqlConnection);

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "[Manufacter]");


                comboBox.ItemsSource = dataSet.
                    Tables["[Manufacter]"].
                    DefaultView;

                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Manufacter]"].
                    Columns["NameManufacter"].ToString();

                comboBox.SelectedValuePath = dataSet.
                    Tables["[Manufacter]"].
                    Columns["ManufacterID"].ToString();

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

        public void CBLoadUser(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter =
                    new SqlDataAdapter("Select UserID," +
                    " Login_User FROM dbo.[User]" +
                    " Order by UserID ASC",
                    sqlConnection);

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "[User]");


                comboBox.ItemsSource = dataSet.
                    Tables["[User]"].
                    DefaultView;

                comboBox.DisplayMemberPath = dataSet.
                    Tables["[User]"].
                    Columns["Login_User"].ToString();

                comboBox.SelectedValuePath = dataSet.
                    Tables["[User]"].
                    Columns["UserID"].ToString();

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

        public void CBStaffPosition(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select PositionStaffID," +
                    " NamePosition FROM dbo.[PositionStaff]" +
                    " Order by PositionStaffID ASC", sqlConnection);

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "[PositionStaff]");



                comboBox.ItemsSource = dataSet.Tables["[PositionStaff]"].DefaultView;

                comboBox.DisplayMemberPath = dataSet.Tables["[PositionStaff]"].
                    Columns["NamePosition"].ToString();

                comboBox.SelectedValuePath = dataSet.Tables["[PositionStaff]"].
                    Columns["PositionStaffID"].ToString();

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
