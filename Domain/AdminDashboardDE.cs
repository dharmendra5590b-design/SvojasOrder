using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AdminDashboardDE
    {
        public int NewOrderCount { get; set; }
        public int PendingDesignCount { get; set; }
        public int DesignUploadedCount { get; set; }
        public int PendingOrderConfirmedCount { get; set; }
        public int OrderConfirmedCount { get; set; }
        public int OrderUnderProductionCount { get; set; }
    }
}
