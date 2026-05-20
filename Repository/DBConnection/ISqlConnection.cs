using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DBConnection
{
    public interface ISqlConnection
    {
       
        Task<DataTable> FunDataTable(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters);
        Task<DataTable> FunDataTable(string StrLocQuery, CommandType SqlCommandType);
        Task<DataTable> FunDataTable(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters, SqlTransaction SqlLocTransaction);
        Task<DataTable> FunDataTable(string StrLocQuery, CommandType SqlCommandType, SqlTransaction SqlLocTransaction);
        Task<DataSet> FunDataSet(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters);
        Task<DataSet> FunDataSet(string StrLocQuery, CommandType SqlCommandType);
        Task<DataSet> FunDataSet(string StrLocQuery, CommandType SqlCommandType, SqlTransaction SqlLocTransaction);
        Task<object> FunScalarData(SqlCommand SqlLoccmd);
        Task<object> FunScalarData(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters);
        //Task<Task<DataTable>> FunDataTable(string v, CommandType storedProcedure, SqlParameter[] sqlParameters);
        Task<SqlDataReader> FunReaderData(SqlCommand SqlLoccmd);
        Task<DataSet> FunDataSet(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters, SqlTransaction SqlLocTransaction);
        Task<object> FunScalarData(string StrLocQuery, CommandType SqlCommandType);

        Task<bool> FunExecuteNonQuery(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters);

        void FunExecuteNonQuery(string StrLocQuery, CommandType SqlCommandType);
        Task<SqlCommand> FunExecuteNonQueryWithStatus(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters);
        void FunExecuteNonQuery(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters, SqlTransaction SqlLocTransaction);
        void FunExecuteNonQuery(string StrLocQuery, CommandType SqlCommandType, SqlTransaction SqlLocTransaction);
        Task<int> FunExecuteNonQueryReturn(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters);
    }
}
