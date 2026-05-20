using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ResponseDE
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object data { get; set; }
    }
}
