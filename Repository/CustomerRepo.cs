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
                },
                 new SqlParameter("@Mode", SqlDbType.VarChar)
                {
                    Value = (customerDE.Mode==null || customerDE.Mode=="A"?"S":customerDE.Mode)
                }
                };                

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

        public async Task<ResponseDE> AMDEmployee(EmployeeDE employeeDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Employee_ID", SqlDbType.Int)
                {
                    Value = employeeDE.Employee_ID
                },

                new SqlParameter("@Employee_Name", SqlDbType.VarChar)
                {
                    Value = employeeDE.Employee_Name
                },

                new SqlParameter("@Email_ID", SqlDbType.VarChar)
                {
                    Value = employeeDE.Email_ID
                },

                new SqlParameter("@Mobile_Number", SqlDbType.VarChar)
                {
                    Value = employeeDE.Mobile_Number
                },

                new SqlParameter("@Designation", SqlDbType.VarChar)
                {
                    Value = employeeDE.Designation
                },
                 new SqlParameter("@Mode", SqlDbType.VarChar)
                {
                    Value = employeeDE.Mode
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

                 await _sqlConnection.FunDataTable(
                    "usp_AMD_Employee_Mst",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                responseDE.Message = objSqlParameter[6].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[7].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[7].Value)
                    : 0;

                return responseDE;
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

                new SqlParameter("@Employee_List", SqlDbType.VarChar)
                {
                    Value = customerMappingDE.Employee_List
                },
                new SqlParameter("@Mode", SqlDbType.VarChar)
                {
                    Value = customerMappingDE.Mode
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

                responseDE.Message = objSqlParameter[3].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[4].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[4].Value)
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

        public async Task<ResponseDE> AMDCustomerLedgerCredit(CustomerLedgerDE customerLedgerDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Customer_ID", SqlDbType.Int)
                {
                    Value = customerLedgerDE.Customer_ID
                },

                new SqlParameter("@Voucher", SqlDbType.VarChar)
                {
                    Value = customerLedgerDE.Voucher
                },

                new SqlParameter("@Particular", SqlDbType.VarChar)
                {
                    Value = customerLedgerDE.Particular
                },

                new SqlParameter("@GoldIn", SqlDbType.Decimal)
                {
                    Value = customerLedgerDE.GoldIn
                },

                new SqlParameter("@AmountIn", SqlDbType.Decimal)
                {
                    Value = customerLedgerDE.AmountIn
                },
                new SqlParameter("@Mode", SqlDbType.VarChar)
                {
                    Value = customerLedgerDE.Mode
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

                 await _sqlConnection.FunDataTable(
                    "usp_AMD_Customer_Ledger_CreditEntry",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                responseDE.Message = objSqlParameter[6].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[7].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[7].Value)
                    : 0;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDCustomerLedgerDebit(CustomerLedgerDE customerLedgerDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Customer_ID", SqlDbType.Int)
                {
                    Value = customerLedgerDE.Customer_ID
                },

                new SqlParameter("@Voucher", SqlDbType.VarChar)
                {
                    Value = customerLedgerDE.Voucher
                },

                new SqlParameter("@Particular", SqlDbType.VarChar)
                {
                    Value = customerLedgerDE.Particular
                },

                new SqlParameter("@GoldIn", SqlDbType.Decimal)
                {
                    Value = customerLedgerDE.GoldIn
                },

                new SqlParameter("@AmountIn", SqlDbType.Decimal)
                {
                    Value = customerLedgerDE.AmountIn
                },
                new SqlParameter("@Mode", SqlDbType.VarChar)
                {
                    Value = customerLedgerDE.Mode
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

                await _sqlConnection.FunDataTable(
                   "usp_AMD_Customer_Ledger_DebitEntry",
                   CommandType.StoredProcedure,
                   objSqlParameter
               );

                responseDE.Message = objSqlParameter[7].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[8].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[9].Value)
                    : 0;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataSet> GetCustomerLedger(CustomerDE customerDE)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
                new SqlParameter("@Customer_ID", SqlDbType.Int)
                {
                    Value = customerDE.Customer_ID
                } };

                dataSet = await _sqlConnection.FunDataSet(
                    "usp_Get_Customer_Ledger",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );


                return dataSet;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
