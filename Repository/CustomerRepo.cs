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
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ISqlConnection _sqlConnection;

        public CustomerRepo(ISqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<ResponseDE> AMDCustomer(CustomerDE customerDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Customer_ID", SqlDbType.Int)
                {
                    Value = customerDE.Customer_ID
                },

                new SqlParameter("@Customer_Name", SqlDbType.VarChar)
                {
                    Value = customerDE.Customer_Name
                },

                new SqlParameter("@Customer_Code", SqlDbType.VarChar)
                {
                    Value = customerDE.Customer_Code
                },

                new SqlParameter("@Company_Name", SqlDbType.VarChar)
                {
                    Value = customerDE.Company_Name
                },

                new SqlParameter("@Mobile_Number", SqlDbType.VarChar)
                {
                    Value = customerDE.Mobile_Number
                },

                new SqlParameter("@Gold_OpeningBalance", SqlDbType.Decimal)
                {
                    Value = customerDE.Gold_OpeningBalance
                },

                new SqlParameter("@Amount_OpeningBalance", SqlDbType.Decimal)
                {
                    Value = customerDE.Amount_OpeningBalance
                },

                new SqlParameter("@Mode", SqlDbType.Char)
                {
                    Value = customerDE.Mode
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
                    "usp_AMD_Customer_Mst",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                responseDE.Message = objSqlParameter[8].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[9].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[9].Value)
                    : 0;

                responseDE.data = dataTable;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetCustomer(CustomerDE customerDE)
        {
           DataTable dataTable=new DataTable();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Customer_ID", SqlDbType.Int)
                {
                    Value = customerDE.Customer_ID
                } };                

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_GET_Customer_Mst",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetEmployee(EmployeeDE employeeDE)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Employee_ID", SqlDbType.Int)
                {
                    Value = employeeDE.Employee_ID
                },
                new SqlParameter("@Mode", SqlDbType.Int)
                {
                    Value = employeeDE.Mode
                }};

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_GET_Employee_Mst",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );


                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDCustomerMapping(CustomerMappingDE customerMappingDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Customer_ID", SqlDbType.Int)
                {
                    Value = customerMappingDE.Customer_ID
                },

                new SqlParameter("@Customer_ID", SqlDbType.Int)
                {
                    Value = customerMappingDE.Employee_List
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
                    "usp_AMD_Customer_Mapping_Dtl",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                responseDE.Message = objSqlParameter[8].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[9].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[9].Value)
                    : 0;

                responseDE.data = dataTable;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetCustomerMapping()
        {
            DataTable dataTable = new DataTable();

            try
            {
                
                dataTable = await _sqlConnection.FunDataTable(
                    "usp_GETLIST_Customer_Mapping",
                    CommandType.StoredProcedure
                );


                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetCustomerMappingDtl(CustomerDE customerDE)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Customer_ID", SqlDbType.Int)
                {
                    Value = customerDE.Customer_ID
                } };

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_GET_Customer_Mapping_Dtl",
                    CommandType.StoredProcedure,
                    objSqlParameter
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
