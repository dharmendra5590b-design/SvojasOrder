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

    new SqlParameter("@Karat_Percent", SqlDbType.VarChar)
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
    new SqlParameter("@Quantity", SqlDbType.VarChar, 50)
    {
        Value = (object?)orderRequest.Quantity ?? DBNull.Value
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
    new SqlParameter("@Reorder_Type", SqlDbType.VarChar, 100)
    {
        Value = (object?)orderRequest.Reorder_Type ?? DBNull.Value
    },
    new SqlParameter("@Mode", SqlDbType.VarChar, 10)
    {
        Value = (object?)orderRequest.Mode ?? DBNull.Value
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

                responseDE.Message = objSqlParameter[27].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[28].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[28].Value)
                    : 0;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDCancelOrder(OrderCancelRequestDE orderCancelRequestDE)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
 {
    new SqlParameter("@Order_ID", SqlDbType.Int)
    {
        Value = (object?)orderCancelRequestDE.Order_ID ?? DBNull.Value
    },

    new SqlParameter("@User_ID", SqlDbType.Int)
    {
        Value = (object?)orderCancelRequestDE.User_ID ?? DBNull.Value
    },
    new SqlParameter("@Cancel_Reason", SqlDbType.VarChar, 250)
    {
        Value = (object?)orderCancelRequestDE.Cancel_Reason ?? DBNull.Value
    },

    new SqlParameter("@Cancelation_Charge", SqlDbType.Float)
    {
        Value = (object?)orderCancelRequestDE.Cancelation_Charge ?? DBNull.Value
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
                    "usp_CANCEL_Order",
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                responseDE.Message = objSqlParameter[4].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[5].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[5].Value)
                    : 0;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDAssignDesigner(OrderDesignRequestDE request)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
            new SqlParameter("@Order_ID", SqlDbType.BigInt)
            {
                Value = (object?)request.Order_ID ?? DBNull.Value
            },

            new SqlParameter("@Designer_ID", SqlDbType.Int)
            {
                Value = (object?)request.Designer_ID ?? DBNull.Value
            },

            new SqlParameter("@Admin_Specification", SqlDbType.VarChar)
            {
                Value = (object?)request.Admin_Specification ?? DBNull.Value
            },

            new SqlParameter("@Is_High_Priority", SqlDbType.Bit)
            {
                Value = (object?)request.Is_High_Priority ?? DBNull.Value
            },

            new SqlParameter("@Design_Expected_DT", SqlDbType.Date)
            {
                Value = (object?)request.Design_Expected_DT ?? DBNull.Value
            },
            new SqlParameter("@Committed_DT", SqlDbType.Date)
            {
                Value = (object?)request.Committed_DT ?? DBNull.Value
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
                    "usp_UPDATE_Order_Assign_To_Designer", // Replace with your SP name
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

        public async Task<ResponseDE> AMDOrderDesingUpload(OrderDesingUploadDE request)
        {
            ResponseDE responseDE = new ResponseDE();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                {
            new SqlParameter("@Order_ID", SqlDbType.BigInt)
            {
                Value = (object?)request.Order_ID ?? DBNull.Value
            },

            new SqlParameter("@CAD_Image_URL", SqlDbType.VarChar)
            {
                Value = (object?)request.CAD_Image_URL ?? DBNull.Value
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
                    "usp_UPDATE_Order_Design_Upload", // Replace with your SP name
                    CommandType.StoredProcedure,
                    objSqlParameter
                );

                responseDE.Message = objSqlParameter[2].Value?.ToString();

                responseDE.StatusCode =
                    objSqlParameter[3].Value != DBNull.Value
                    ? Convert.ToInt32(objSqlParameter[3].Value)
                    : 0;

                return responseDE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDOrderDesignApprove(OrderDesignApproveDE request)
        {
            try
            {
                SqlParameter[] parameters =
                {
            new SqlParameter("@Order_ID", SqlDbType.Int)
            {
                Value = request.Order_ID ?? (object)DBNull.Value
            },

            new SqlParameter("@Designer_Weight", SqlDbType.VarChar, 100)
            {
                Value = string.IsNullOrWhiteSpace(request.Designer_Weight)
                    ? DBNull.Value
                    : request.Designer_Weight
            },

            new SqlParameter("@Designer_Diamond_Weight", SqlDbType.VarChar, 100)
            {
                Value = string.IsNullOrWhiteSpace(request.Designer_Diamond_Weight)
                    ? DBNull.Value
                    : request.Designer_Diamond_Weight
            },

            new SqlParameter("@Designer_NoOf_Diamonds", SqlDbType.VarChar, 100)
            {
                Value = string.IsNullOrWhiteSpace(request.Designer_NoOf_Diamonds)
                    ? DBNull.Value
                    : request.Designer_NoOf_Diamonds
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
                    "usp_UPDATE_Order_Design_Approve",
                    CommandType.StoredProcedure,
                    parameters);

                return new ResponseDE
                {
                    Message = parameters[4].Value?.ToString(),
                    StatusCode = parameters[5].Value != DBNull.Value
                        ? Convert.ToInt32(parameters[5].Value)
                        : 0
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDCreateReOrder(ReOrderDE request)
        {
            try
            {
                SqlParameter[] parameters =
                {
            new SqlParameter("@Order_ID", SqlDbType.BigInt)
            {
                Value = request.Order_ID ?? (object)DBNull.Value
            },

            new SqlParameter("@Customer_ID", SqlDbType.Int)
            {
                Value = request.Customer_ID ?? (object)DBNull.Value
            },

            new SqlParameter("@Quantity", SqlDbType.VarChar, 50)
            {
                Value = string.IsNullOrWhiteSpace(request.Quantity)
                    ? DBNull.Value
                    : request.Quantity
            },

            new SqlParameter("@Delivery_Date", SqlDbType.Date)
            {
                Value = request.Delivery_Date ?? (object)DBNull.Value
            },

            new SqlParameter("@Mode", SqlDbType.Char, 1)
            {
                Value = string.IsNullOrWhiteSpace(request.Mode)
                    ? "A"
                    : request.Mode
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
                    "usp_CREATE_ReOrder_Mst",
                    CommandType.StoredProcedure,
                    parameters);

                return new ResponseDE
                {
                    Message = parameters[5].Value?.ToString(),
                    StatusCode = parameters[6].Value != DBNull.Value
                        ? Convert.ToInt32(parameters[6].Value)
                        : 0
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDOrderReworkDtl(OrderReworkDtlDE request)
        {
            try
            {
                SqlParameter[] parameters =
                {
            new SqlParameter("@Order_ID", SqlDbType.BigInt)
            {
                Value = request.Order_ID ?? (object)DBNull.Value
            },

            new SqlParameter("@SrNo", SqlDbType.Int)
            {
                Value = request.SrNo ?? 0
            },

            new SqlParameter("@Specification", SqlDbType.VarChar)
            {
                Value = string.IsNullOrWhiteSpace(request.Specification)
                    ? DBNull.Value
                    : request.Specification
            },

            new SqlParameter("@Rework_Image_URL", SqlDbType.VarChar, 250)
            {
                Value = string.IsNullOrWhiteSpace(request.Rework_Image_URL)
                    ? DBNull.Value
                    : request.Rework_Image_URL
            },

            //new SqlParameter("@User_ID", SqlDbType.Int)
            //{
            //    Value = request.User_ID ?? (object)DBNull.Value
            //},

            new SqlParameter("@Mode", SqlDbType.Char, 1)
            {
                Value = string.IsNullOrWhiteSpace(request.Mode)
                    ? "A"
                    : request.Mode
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
                    "usp_AMD_tbl_Order_Rework_Dtl",
                    CommandType.StoredProcedure,
                    parameters);

                return new ResponseDE
                {
                    Message = parameters[5].Value?.ToString(),
                    StatusCode = parameters[6].Value != DBNull.Value
                        ? Convert.ToInt32(parameters[6].Value)
                        : 0
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDCustomerOrderConfirm(OrderConfirmDE request)
        {
            try
            {
                SqlParameter[] parameters =
                {
            new SqlParameter("@Order_ID", SqlDbType.Int)
            {
                Value = request.Order_ID
            },

            new SqlParameter("@Action_Type", SqlDbType.VarChar, 50)
            {
                Value = string.IsNullOrWhiteSpace(request.Action_Type)
                    ? "CONFIRM"
                    : request.Action_Type
            },

            new SqlParameter("@Rework_Specification", SqlDbType.VarChar)
            {
                Value = string.IsNullOrWhiteSpace(request.Rework_Specification)
                    ? DBNull.Value
                    : request.Rework_Specification
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
                    "usp_UPDATE_Order_Confirm",
                    CommandType.StoredProcedure,
                    parameters);

                return new ResponseDE
                {
                    Message = parameters[3].Value?.ToString(),
                    StatusCode = parameters[4].Value != DBNull.Value
                        ? Convert.ToInt32(parameters[4].Value)
                        : 0
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDOrderAssignToProduction(OrderAssignToProductionDE request)
        {
            try
            {
                SqlParameter[] parameters =
                {
            new SqlParameter("@Order_ID", SqlDbType.BigInt)
            {
                Value = request.Order_ID ?? (object)DBNull.Value
            },

            new SqlParameter("@Production_Specification", SqlDbType.VarChar)
            {
                Value = string.IsNullOrWhiteSpace(request.Production_Specification)
                    ? DBNull.Value
                    : request.Production_Specification
            },

            new SqlParameter("@Data_Entry_Operater_Dtl", SqlDbType.VarChar, 200)
            {
                Value = string.IsNullOrWhiteSpace(request.Data_Entry_Operater_Dtl)
                    ? DBNull.Value
                    : request.Data_Entry_Operater_Dtl
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
                    "usp_UPDATE_Order_Assign_To_Production",
                    CommandType.StoredProcedure,
                    parameters);

                return new ResponseDE
                {
                    Message = parameters[3].Value?.ToString(),
                    StatusCode = parameters[4].Value != DBNull.Value
                        ? Convert.ToInt32(parameters[4].Value)
                        : 0
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseDE> AMDOrderComplete(OrderCompleteDE request)
        {
            try
            {
                var msgParam = new SqlParameter("@Msg", SqlDbType.VarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };

                var statusParam = new SqlParameter("@Status", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters =
                {
            new SqlParameter("@Order_ID", SqlDbType.Int)
            {
                Value = request.Order_ID ?? (object)DBNull.Value
            },

            new SqlParameter("@Production_KT", SqlDbType.Int)
            {
                Value = request.Production_KT ?? (object)DBNull.Value
            },

            new SqlParameter("@Final_Gross_Weight", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.Final_Gross_Weight ?? (object)DBNull.Value
            },

            new SqlParameter("@Final_Noof_Diamonds", SqlDbType.Int)
            {
                Value = request.Final_Noof_Diamonds ?? (object)DBNull.Value
            },

            new SqlParameter("@Final_Diamond_Weight", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.Final_Diamond_Weight ?? (object)DBNull.Value
            },

            new SqlParameter("@Diamond_Value", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 2,
                Value = request.Diamond_Value ?? (object)DBNull.Value
            },

            new SqlParameter("@NoOfColour_Stone", SqlDbType.Int)
            {
                Value = request.NoOfColour_Stone ?? (object)DBNull.Value
            },

            new SqlParameter("@ColourStone_Weight", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.ColourStone_Weight ?? (object)DBNull.Value
            },

            new SqlParameter("@ColourStone_Value", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 2,
                Value = request.Colour_Stone_Value ?? (object)DBNull.Value
            },

            new SqlParameter("@Others_NoOfColour_Stone", SqlDbType.Int)
            {
                Value = request.Other_NoOfColour_Stone ?? (object)DBNull.Value
            },

            new SqlParameter("@Others_Colour_Stone_Weight", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.Other_Colour_Stone_Weight ?? (object)DBNull.Value
            },

            new SqlParameter("@Other_Colour_Stone_Value", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 2,
                Value = request.Other_Colour_Stone_Value ?? (object)DBNull.Value
            },

            new SqlParameter("@Final_Net_Weight", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.Final_Net_Weight ?? (object)DBNull.Value
            },

            new SqlParameter("@Final_Net_Weight_24kt", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.Final_Net_Weight_24kt ?? (object)DBNull.Value
            },

            new SqlParameter("@Gold_Loss", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.Gold_Loss ?? (object)DBNull.Value
            },

            new SqlParameter("@Labour_Charge", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 2,
                Value = request.Labour_Charge ?? (object)DBNull.Value
            },

            new SqlParameter("@Gold_Loss_24kt", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.Gold_Loss_24kt ?? (object)DBNull.Value
            },

            new SqlParameter("@Certificate_Charge", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 2,
                Value = request.Certificate_Charge ?? (object)DBNull.Value
            },

            new SqlParameter("@Other_Charges", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 2,
                Value = request.Other_Charges ?? (object)DBNull.Value
            },

            new SqlParameter("@Final_Production_Cost", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.billAmount ?? (object)DBNull.Value
            },

            new SqlParameter("@Final_24KT_Gold_Weight", SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = 3,
                Value = request.gold24ktWeight ?? (object)DBNull.Value
            },

            msgParam,
            statusParam
        };

                await _sqlConnection.FunDataTable(
                    "usp_UPDATE_Order_Complete",
                    CommandType.StoredProcedure,
                    parameters);

                return new ResponseDE
                {
                    Message = msgParam.Value?.ToString(),
                    StatusCode = statusParam.Value != DBNull.Value
                        ? Convert.ToInt32(statusParam.Value)
                        : 0
                };
            }
            catch
            {
                throw;
            }
        }
        public async Task<DataSet> GetOrder(OrderSearchDE orderSearchDE)
        {
            DataSet dataSet =new DataSet();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
 {
    new SqlParameter("@Order_ID", SqlDbType.Int)
    {
        Value = orderSearchDE.order_ID
    },

    new SqlParameter("@Customer_ID", SqlDbType.Int)
    {
        Value = orderSearchDE.customer_ID
    },

    new SqlParameter("@Design_ID", SqlDbType.Int)
    {
        Value = orderSearchDE.design_ID
    },

    new SqlParameter("@Order_FromDT", SqlDbType.DateTime)
    {
        Value = orderSearchDE.order_FromDT
    },

    new SqlParameter("@Order_ToDT", SqlDbType.DateTime)
    {
        Value =orderSearchDE.order_ToDT
    },
     new SqlParameter("@Order_Status", SqlDbType.VarChar)
    {
        Value =orderSearchDE.Status
    },
    new SqlParameter("@PageSize", SqlDbType.Int)
    {
        Value = 500
    },


    new SqlParameter("@Mode", SqlDbType.VarChar, 200)
    {
        Value = orderSearchDE.mode
    },
 };


                dataSet = await _sqlConnection.FunDataSet(
                    "usp_GET_Order_For_Customer",
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

        public async Task<DataSet> GetOrderView(int OrderID, int? UserID)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
 {
    new SqlParameter("@Order_ID", SqlDbType.Int)
    {
        Value = OrderID
    },
    new SqlParameter("@User_ID", SqlDbType.Int)
    {
        Value = UserID
    }
 };


                dataSet = await _sqlConnection.FunDataSet(
                    "usp_GET_Order_For_View",
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

        public async Task<DataTable> GetOrderPrint(int OrderID)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
             {
                new SqlParameter("@Order_ID", SqlDbType.Int)
                {
                    Value = OrderID
                }
             };


                            dataTable = await _sqlConnection.FunDataTable(
                                "usp_GET_Order_For_Print",
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

        public async Task<DataSet> GetDesginerPrint(int OrderID)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
             {
                new SqlParameter("@Order_ID", SqlDbType.Int)
                {
                    Value = OrderID
                }
             };


                dataSet = await _sqlConnection.FunDataSet(
                    "usp_GET_Order_For_DesignerPrint",
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

        public async Task<DataSet> GetOrderEmail(int OrderID)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
             {
                new SqlParameter("@Order_ID", SqlDbType.Int)
                {
                    Value = OrderID
                }
             };


                dataSet = await _sqlConnection.FunDataSet(
                    "usp_GET_Order_For_Email",
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


        public async Task<DataTable> GetPendingDesingOrder()
        {
            DataTable dataTable = new DataTable();

            try
            {

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_Pending_Design_Order",
                    CommandType.StoredProcedure
                );


                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetDesingOrder(int DesignerID)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
 {
    new SqlParameter("@Designer_ID", SqlDbType.Int)
    {
        Value = DesignerID
    }
 };
                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_Designerwise_Order",
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

        public async Task<DataTable> GetDesingerOrderReport(int DesignerID)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
                     {
                        new SqlParameter("@Designer_ID", SqlDbType.Int)
                        {
                            Value = DesignerID
                        },

                        new SqlParameter("@PageSize", SqlDbType.Int)
                        {
                            Value = 500
                        }
                     };


                dataTable = await _sqlConnection.FunDataTable(
                    "usp_GET_Order_For_Designer",
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

        public async Task<DataTable> GetOperator(int OrderID)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
 {
    new SqlParameter("@Order_ID", SqlDbType.Int)
    {
        Value = OrderID
    }
 };
                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_DataEntry_Operator",
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

        public async Task<DataTable> GetReworkOrder()
        {
            DataTable dataTable = new DataTable();

            try
            {

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_New_Rework_Order",
                    CommandType.StoredProcedure
                );


                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetDesignUploadedOrder()
        {
            DataTable dataTable = new DataTable();

            try
            {

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_Design_Uploaded_Order",
                    CommandType.StoredProcedure
                );


                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetPendingOrderConfirmation(int? customerID)
        {
            DataTable dataTable = new DataTable();

            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[]
{
   new SqlParameter("@Customer_ID", SqlDbType.Int)
    {
        Value = customerID
    },

};
                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_Pending_Order_Confirmation",
                    CommandType.StoredProcedure, objSqlParameter
                );


                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetConfirmedOrder()
        {
            DataTable dataTable = new DataTable();

            try
            {

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_Confirmed_Order",
                    CommandType.StoredProcedure
                );


                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetUnderProductionOrder()
        {
            DataTable dataTable = new DataTable();

            try
            {

                dataTable = await _sqlConnection.FunDataTable(
                    "usp_Get_Order_Under_Production",
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
