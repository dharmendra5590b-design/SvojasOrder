using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICustomerService
    {
        Task<ResponseDE> GetCustomer(CustomerDE pobjCustomerDE);
        Task<ResponseDE> SaveCustomer(CustomerDE pobjCustomerDE);
        Task<ResponseDE> GetEmployee(EmployeeDE employeeDE);
        Task<ResponseDE> GetCustomerMapping();
        Task<ResponseDE> GetCustomerMappingDtl(CustomerDE customerDE);
        Task<ResponseDE> SaveCustomerMapping(CustomerMappingDE customerMappingDE);
        Task<ResponseDE> SaveEmployee(EmployeeDE pobjEmployeeDE);

        Task<ResponseDE> SaveCustomerLedgerCredit(CustomerLedgerDE customerLedgerDE);
        Task<ResponseDE> SaveCustomerLedgerDebit(CustomerLedgerDE customerLedgerDE);
        Task<ResponseDE> GetCustomerLedger(CustomerDE customerDE);
        Task<List<DesignerDE>> GetDesigner();
    }
}
