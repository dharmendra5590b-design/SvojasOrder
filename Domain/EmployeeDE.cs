using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EmployeeDE
    {
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Email_ID { get; set; }
        public string Mobile_Number { get; set; }
        public string Designation { get; set; }
        public bool Is_Mapped { get; set; } = false;
        public string Mode { get; set; }
        public string Password { get; set; } 

    }
}
