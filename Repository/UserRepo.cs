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
    public class UserRepo : IUserRepo
    {
        private readonly ISqlConnection _sqlConnection;

        public UserRepo(ISqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<ResponseDE> AMDUser(UserDE userDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@User_Name", SqlDbType.VarChar)
                {
                    Value = userDE.User_Name
                },

                new SqlParameter("@Password", SqlDbType.VarChar)
                {
                    Value = userDE.Password
                },

                new SqlParameter("@User_Type", SqlDbType.VarChar)
                {
                    Value = userDE.User_Type
                },

                new SqlParameter("@Entity_ID", SqlDbType.Int)
                {
                    Value = userDE.Entity_ID
                },

                new SqlParameter("@Entity_Name", SqlDbType.VarChar)
                {
                    Value = userDE.Entity_Name
                },

                new SqlParameter("@Mode", SqlDbType.Char)
                {
                    Value = userDE.Mode
                },

                new SqlParameter("@Msg", SqlDbType.VarChar, 200)
                {
                    Direction = ParameterDirection.Output
                },

                new SqlParameter("@Status", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
                };

                DataTable dataTable = await _sqlConnection.FunDataTable(
                    "usp_AMD_User_Mst",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                responseDE.Message = objSqlParameter[6].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[7].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[7].Value)
                    : 0;

                responseDE.data = dataTable;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
