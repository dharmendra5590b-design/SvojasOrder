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
    public class OrderRepo: IOrderRepo
    {
        private readonly ISqlConnection _sqlConnection;

        public OrderRepo(ISqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<DataSet> GetListCustomerOrder()
        {
            DataSet dataSet = new DataSet();

            try
            {
                
                dataSet = await _sqlConnection.FunDataSet(
                    "usp_GETLIST_Customer_Order",
                    CommandType.StoredProcedure
                );


                return dataSet;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDOrderRequest(OrderRequestDE orderRequest)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
 {
    new SqlParameter("@Order_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Order_ID ?? DBNull.Value
    },

    new SqlParameter("@Customer_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Customer_ID ?? DBNull.Value
    },

    new SqlParameter("@Design_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Design_ID ?? DBNull.Value
    },

    new SqlParameter("@Karat_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Karat_ID ?? DBNull.Value
    },

    new SqlParameter("@Karat_Percent", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Karat_Percent ?? DBNull.Value
    },

    new SqlParameter("@Design_Type_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Design_Type_ID ?? DBNull.Value
    },

    new SqlParameter("@Gold_Colour_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Gold_Colour_ID ?? DBNull.Value
    },

    new SqlParameter("@Size", SqlDbType.VarChar, 50)
    {
        Value = (object?)orderRequest.Size ?? DBNull.Value
    },

    new SqlParameter("@Weight", SqlDbType.VarChar, 50)
    {
        Value = (object?)orderRequest.Weight ?? DBNull.Value
    },

    new SqlParameter("@Stone_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Stone_ID ?? DBNull.Value
    },

    new SqlParameter("@Is_Colour_Required", SqlDbType.Bit)
    {
        Value = (object?)orderRequest.Is_Colour_Required ?? DBNull.Value
    },

    new SqlParameter("@Colour_Stone_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Colour_Stone_ID ?? DBNull.Value
    },

    new SqlParameter("@Colour_Stone", SqlDbType.VarChar, 50)
    {
        Value = (object?)orderRequest.Colour_Stone ?? DBNull.Value
    },

    new SqlParameter("@Is_Certificate_Required", SqlDbType.Bit)
    {
        Value = (object?)orderRequest.Is_Certificate_Required ?? DBNull.Value
    },

    new SqlParameter("@Cretificate_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Cretificate_ID ?? DBNull.Value
    },

    new SqlParameter("@Diamond_Quality_ID", SqlDbType.Int)
    {
        Value = (object?)orderRequest.Diamond_Quality_ID ?? DBNull.Value
    },

    new SqlParameter("@Diamond_Weight", SqlDbType.VarChar, 50)
    {
        Value = (object?)orderRequest.Diamond_Weight ?? DBNull.Value
    },

    new SqlParameter("@NoOf_Diamonds", SqlDbType.VarChar, 50)
    {
        Value = (object?)orderRequest.NoOf_Diamonds ?? DBNull.Value
    },

    new SqlParameter("@Delivery_Date", SqlDbType.Date)
    {
        Value = (object?)orderRequest.Delivery_Date ?? DBNull.Value
    },

    new SqlParameter("@Specification", SqlDbType.VarChar)
    {
        Value = (object?)orderRequest.Specification ?? DBNull.Value
    },

    new SqlParameter("@Front_Image_URL", SqlDbType.VarChar, 200)
    {
        Value = (object?)orderRequest.Front_Image_URL ?? DBNull.Value
    },

    new SqlParameter("@Top_Image_URL", SqlDbType.VarChar, 200)
    {
        Value = (object?)orderRequest.Top_Image_URL ?? DBNull.Value
    },

    new SqlParameter("@Side_Image_URL", SqlDbType.VarChar, 200)
    {
        Value = (object?)orderRequest.Side_Image_URL ?? DBNull.Value
    },

    new SqlParameter("@Back_Image_URL", SqlDbType.VarChar, 200)
    {
        Value = (object?)orderRequest.Back_Image_URL ?? DBNull.Value
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
                    "usp_AMD_Order_Mst", 
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                responseDE.Message = objSqlParameter[24].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[25].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[25].Value)
                    : 0;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
