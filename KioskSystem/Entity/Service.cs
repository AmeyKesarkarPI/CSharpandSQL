using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Service
    {
        public int ServiceID { get; set; }
        public int BranchID { get; set; }
        public string ServiceName { get; set; }
        public int[] Questions { get; set; }
        List<Questions> questions { get; set; }

        
    }
}
