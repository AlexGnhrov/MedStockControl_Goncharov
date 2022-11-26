using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace MedStockControl_Goncharov.ClassFolder
{

    class DGClass
    {
        DataGrid dataGrid;
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionDB());

        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public DGClass(DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }


        public void LoadDG(String sqlCommand)
        {
            try
            {
                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand, sqlConnection);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                dataGrid.ItemsSource = dataTable.DefaultView;

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
        public string LoadID()
        {
            object[] mass = null;
            String id = "";
            try
            {

                if (dataGrid != null)
                {
                    DataRowView dataRowView =
                        dataGrid.SelectedItem as DataRowView;

                    if (dataRowView != null)
                    {
                        DataRow dataRow = (DataRow)dataRowView.Row;

                        mass = dataRow.ItemArray;
                    }
                }
                id = mass[0].ToString();

            }
            catch (Exception ex)
            {

                MBClass.Error(ex);
            }
            return id;
        }

    }
}
