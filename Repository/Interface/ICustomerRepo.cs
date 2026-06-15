using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICustomerRepo
    {
        Task<ResponseDE> AMDCustomer(CustomerDE customerDE);
        Task<DataTable> GetCustomer(CustomerDE customerDE);
        Task<DataTable> GetEmployee(EmployeeDE employeeDE);
        Task<ResponseDE> AMDCustomerMapping(CustomerMappingDE customerMappingDE);
        Task<DataTable> GetCustomerMappingDtl(CustomerDE customerDE);
        Task<DataTable> GetCustomerMapping();
        Task<ResponseDE> AMDCustomerLedgerCredit(CustomerLedgerDE customerLedgerDE);
        Task<ResponseDE> AMDCustomerLedgerDebit(CustomerLedgerDE customerLedgerDE);
        Task<DataSet> GetCustomerLedger(CustomerDE customerDE);
        Task<ResponseDE> AMDEmployee(EmployeeDE employeeDE);

        Task<DataTable> GetDesigner();
    }
}
