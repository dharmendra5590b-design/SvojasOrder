using Domain;
using Microsoft.Data.SqlClient;
using Repository.DBConnection;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdminDashboardRepo : IAdminDashboardRepo
    {
        private readonly ISqlConnection _sqlConnection;

        public AdminDashboardRepo(ISqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<DataTable> GetAdminDashboard()
        {
            DataTable dataTable = new DataTable();

            try
            {

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_ADIMN_Dashboard",
                    CommandType.StoredProcedure
                );


                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
