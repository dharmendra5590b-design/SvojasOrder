
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.DBConnection;
using System.Data;
using System.Threading.Tasks;

namespace System.Repository
{
    public class ClSSqlConnection : IDisposable, ISqlConnection
    {

        private readonly string Connectionstring;
      
        public ClSSqlConnection(IConfiguration configuration)
        {


            Connectionstring = configuration.GetConnectionString("ApplicationConnection");
        }
        //public IConfigurationRoot GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder().se(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    return builder.Build();
        //}

        public async Task<DataTable> FunDataTable(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                         //Sqlconn.Open();
                        cmd.CommandType = SqlCommandType;
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable DtData = new DataTable();
                        cmd.CommandText = StrLocQuery;
                        cmd.Parameters.AddRange(SqlParameters);
                        cmd.CommandTimeout = 600;


                        cmd.Connection = Sqlconn;
                        adp.SelectCommand = cmd;


                        adp.Fill(DtData);
                        return DtData;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DataTable> FunDataTable(string StrLocQuery, CommandType SqlCommandType)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        cmd.CommandType = SqlCommandType;
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable DtData = new DataTable();
                        cmd.CommandText = StrLocQuery;
                        cmd.CommandTimeout = 600;


                        cmd.Connection = Sqlconn;
                        adp.SelectCommand = cmd;


                        adp.Fill(DtData);
                        return DtData;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DataTable> FunDataTable(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters, SqlTransaction SqlLocTransaction)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        cmd.CommandType = SqlCommandType;
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable DtData = new DataTable();
                        cmd.Transaction = SqlLocTransaction;
                        cmd.CommandText = StrLocQuery;
                        cmd.Parameters.AddRange(SqlParameters);
                        cmd.CommandTimeout = 600;


                        cmd.Connection = Sqlconn;
                        adp.SelectCommand = cmd;


                        adp.Fill(DtData);
                        return DtData;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DataTable> FunDataTable(string StrLocQuery, CommandType SqlCommandType, SqlTransaction SqlLocTransaction)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        cmd.CommandType = SqlCommandType;
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataTable DtData = new DataTable();
                        cmd.Transaction = SqlLocTransaction;
                        cmd.CommandText = StrLocQuery;
                        cmd.CommandTimeout = 600;


                        cmd.Connection = Sqlconn;
                        adp.SelectCommand = cmd;


                        adp.Fill(DtData);
                        return DtData;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task<DataSet> FunDataSet(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        cmd.CommandType = SqlCommandType;
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet DSData = new DataSet();
                        cmd.CommandText = StrLocQuery;
                        cmd.Parameters.AddRange(SqlParameters);
                        cmd.CommandTimeout = 600;


                        cmd.Connection = Sqlconn;
                        adp.SelectCommand = cmd;


                        adp.Fill(DSData);
                        return DSData;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DataSet> FunDataSet(string StrLocQuery, CommandType SqlCommandType)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        cmd.CommandType = SqlCommandType;
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet DSData = new DataSet();
                        cmd.CommandText = StrLocQuery;
                        cmd.CommandTimeout = 600;


                        cmd.Connection = Sqlconn;
                        adp.SelectCommand = cmd;


                        adp.Fill(DSData);
                        return DSData;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task<DataSet> FunDataSet(string StrLocQuery, CommandType SqlCommandType, SqlTransaction SqlLocTransaction)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        cmd.CommandType = SqlCommandType;
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet DSData = new DataSet();
                        cmd.CommandText = StrLocQuery;
                        cmd.Transaction = SqlLocTransaction;
                        cmd.CommandTimeout = 600;


                        cmd.Connection = Sqlconn;
                        adp.SelectCommand = cmd;


                        adp.Fill(DSData);
                        return DSData;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DataSet> FunDataSet(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters, SqlTransaction SqlLocTransaction)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        cmd.CommandType = SqlCommandType;
                        SqlDataAdapter adp = new SqlDataAdapter();
                        DataSet DSData = new DataSet();
                        cmd.CommandText = StrLocQuery;
                        cmd.Transaction = SqlLocTransaction;
                        cmd.Parameters.AddRange(SqlParameters);
                        cmd.CommandTimeout = 600;


                        cmd.Connection = Sqlconn;
                        adp.SelectCommand = cmd;


                        adp.Fill(DSData);
                        return DSData;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }



        public async Task<SqlDataReader> FunReaderData(SqlCommand SqlLoccmd)
        {
            try
            {

                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    await Sqlconn.OpenAsync();



                    SqlLoccmd.Connection = Sqlconn;

                    return SqlLoccmd.ExecuteReader(); ;
                }



            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<object> FunScalarData(SqlCommand SqlLoccmd)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    await Sqlconn.OpenAsync();



                    SqlLoccmd.Connection = Sqlconn;

                    return SqlLoccmd.ExecuteScalar(); ;

                }



            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<object> FunScalarData(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand Sqlcmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        Sqlcmd.CommandType = SqlCommandType;

                        Sqlcmd.CommandText = StrLocQuery;
                        Sqlcmd.Parameters.AddRange(SqlParameters);
                        Sqlcmd.CommandTimeout = 600;


                        Sqlcmd.Connection = Sqlconn;

                        return Sqlcmd.ExecuteScalar();


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<object> FunScalarData(string StrLocQuery, CommandType SqlCommandType)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand Sqlcmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        Sqlcmd.CommandType = SqlCommandType;

                        Sqlcmd.CommandText = StrLocQuery;
                        Sqlcmd.CommandTimeout = 600;


                        Sqlcmd.Connection = Sqlconn;

                        return Sqlcmd.ExecuteScalar();


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task<Boolean> FunExecuteNonQuery(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand Sqlcmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        Sqlcmd.CommandType = SqlCommandType;

                        Sqlcmd.CommandText = StrLocQuery;
                        Sqlcmd.Parameters.AddRange(SqlParameters);
                        Sqlcmd.CommandTimeout = 600;


                        Sqlcmd.Connection = Sqlconn;

                        await Sqlcmd.ExecuteNonQueryAsync();


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public async Task<SqlCommand> FunExecuteNonQueryWithStatus(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand Sqlcmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        Sqlcmd.CommandType = SqlCommandType;

                        Sqlcmd.CommandText = StrLocQuery;
                        Sqlcmd.Parameters.AddRange(SqlParameters);
                        Sqlcmd.CommandTimeout = 600;


                        Sqlcmd.Connection = Sqlconn;

                        Sqlcmd.ExecuteNonQuery();

                        return Sqlcmd;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void FunExecuteNonQuery(string StrLocQuery, CommandType SqlCommandType)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand Sqlcmd = new SqlCommand())
                    {
                        Sqlconn.OpenAsync();
                        Sqlcmd.CommandType = SqlCommandType;

                        Sqlcmd.CommandText = StrLocQuery;
                        Sqlcmd.CommandTimeout = 600;


                        Sqlcmd.Connection = Sqlconn;

                        Sqlcmd.ExecuteNonQuery();


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async void FunExecuteNonQuery(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters, SqlTransaction SqlLocTransaction)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand Sqlcmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        Sqlcmd.CommandType = SqlCommandType;
                        Sqlcmd.Transaction = SqlLocTransaction;
                        Sqlcmd.CommandText = StrLocQuery;
                        Sqlcmd.Parameters.AddRange(SqlParameters);
                        Sqlcmd.CommandTimeout = 600;


                        Sqlcmd.Connection = Sqlconn;

                        Sqlcmd.ExecuteNonQuery();


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Int32> FunExecuteNonQueryReturn(string StrLocQuery, CommandType SqlCommandType, SqlParameter[] SqlParameters)
        {
            int returnVALUE = 0;

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand Sqlcmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        Sqlcmd.CommandType = SqlCommandType;

                        Sqlcmd.CommandText = StrLocQuery;
                        Sqlcmd.Parameters.AddRange(SqlParameters);
                        Sqlcmd.CommandTimeout = 600;


                        Sqlcmd.Connection = Sqlconn;

                        Sqlcmd.ExecuteNonQuery();
                        returnVALUE = (int)Sqlcmd.Parameters["@return"].Value;


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return returnVALUE;
        }


        public async void FunExecuteNonQuery(string StrLocQuery, CommandType SqlCommandType, SqlTransaction SqlLocTransaction)
        {

            try
            {
                using (SqlConnection Sqlconn = new SqlConnection(Connectionstring))
                {
                    using (SqlCommand Sqlcmd = new SqlCommand())
                    {
                        await Sqlconn.OpenAsync();
                        Sqlcmd.CommandType = SqlCommandType;
                        Sqlcmd.Transaction = SqlLocTransaction;
                        Sqlcmd.CommandText = StrLocQuery;
                        Sqlcmd.CommandTimeout = 600;


                        Sqlcmd.Connection = Sqlconn;

                        Sqlcmd.ExecuteNonQuery();


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        private bool disposed;

        //  string ISqlConnection.ConnectionType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //connection.Dispose();
                }
                disposed = true;
            }

        }

        // Destructor
        ~ClSSqlConnection()
        {
            Dispose(false);
        }


    }

}