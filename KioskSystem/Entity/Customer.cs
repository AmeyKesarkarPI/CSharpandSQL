using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int BranchID { get; set; }
        public int ServiceType { get; set; }
        public int CounterID { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
        public int StatusID { get; set; }
        public string Answers { get; set; }
    }
}
