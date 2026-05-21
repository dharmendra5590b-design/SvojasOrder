using Domain;
using Domain.Login;
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
    public class LoginRepo: ILoginRepo
    {
        private readonly ISqlConnection IsqlConnection;
        public LoginRepo(ISqlConnection sqlConnection)
        {
            IsqlConnection = sqlConnection;
        }
        public async Task<ResponseDE> ValidateUser(LoginRequestDE loginRequestDE)
        {
            ResponseDE responseDE=new ResponseDE();
            try
            {

                SqlParameter[] ObjSqlParameter = new SqlParameter[]{
                    new SqlParameter("@UserName",SqlDbType.VarChar){Value=loginRequestDE.UserName},
                     new SqlParameter("@Password",SqlDbType.VarChar){Value=loginRequestDE.Password},
                         // Output parameter - Message
                    new SqlParameter("@Msg", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    },

                    // Output parameter - Status
                    new SqlParameter("@Status", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }

                    };
                DataTable dataTable= await IsqlConnection.FunDataTable("usp_UserLogin", CommandType.StoredProcedure, ObjSqlParameter);
                responseDE.Message = ObjSqlParameter[2].Value?.ToString();
                responseDE.StatusCode= ObjSqlParameter[3].Value != DBNull.Value ? Convert.ToInt32(ObjSqlParameter[3].Value): 0;
                responseDE.data = dataTable;
                return responseDE;


            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<ResponseDE> ChangePassword(ChangePasswordDE changePassword)
        {
            ResponseDE responseDE = new ResponseDE();
            try
            {

                SqlParameter[] ObjSqlParameter = new SqlParameter[]{
                    new SqlParameter("@UserID",DbType.String){Value=changePassword.UserID},
                     new SqlParameter("@Old_Password",DbType.String){Value=changePassword.Password},
                     new SqlParameter("@New_Password",DbType.String){Value=changePassword.NewPassword},
                     new SqlParameter("@Msg", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    },

                    // Output parameter - Status
                    new SqlParameter("@Status", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                    };
                 await IsqlConnection.FunDataTable("usp_UPDATE_User_Password", CommandType.StoredProcedure, ObjSqlParameter);
                responseDE.Message = ObjSqlParameter[2].Value?.ToString();
                responseDE.StatusCode = ObjSqlParameter[3].Value != DBNull.Value ? Convert.ToInt32(ObjSqlParameter[3].Value) : 0;
                return responseDE;
            }
            catch (Exception)
            {
                throw;

            }
        }

    }
}
