using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserDE
    {
        public string User_Name { get; set; }

        public string Password { get; set; }

        public string User_Type { get; set; }

        public int Entity_ID { get; set; }

        public string Entity_Name { get; set; }

        public string Mode { get; set; } = "A";
    }
}
