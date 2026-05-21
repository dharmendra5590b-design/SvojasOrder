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
        public async Task<DataTable> ValidateUser(LoginRequestDE loginRequestDE)
        {
            try
            {

                SqlParameter[] ObjSqlParameter = new SqlParameter[]{
                    new SqlParameter("@UserName",DbType.String){Value=loginRequestDE.UserName},
                     new SqlParameter("@Password",DbType.String){Value=loginRequestDE.Password}
                    };
                return await IsqlConnection.FunDataTable("usp_UserLogin", CommandType.StoredProcedure, ObjSqlParameter);

            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<DataTable> ChangePassword(ChangePasswordDE changePassword)
        {
            try
            {

                SqlParameter[] ObjSqlParameter = new SqlParameter[]{
                    new SqlParameter("@UserID",DbType.String){Value=changePassword.UserID},
                     new SqlParameter("@Old_Password",DbType.String){Value=changePassword.Password},
                     new SqlParameter("@New_Password",DbType.String){Value=changePassword.NewPassword}
                    };
                return await IsqlConnection.FunDataTable("usp_UPDATE_User_Password", CommandType.StoredProcedure, ObjSqlParameter);

            }
            catch (Exception)
            {
                throw;

            }
        }

    }
}
