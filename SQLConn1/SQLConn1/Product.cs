using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConn1
{
    public class Product
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public string SupplierName { get; set;}
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public SqlMoney? UnitPrice { get; set; }
        public int? UnitsOnOrder { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get;  set; }
    }
}
