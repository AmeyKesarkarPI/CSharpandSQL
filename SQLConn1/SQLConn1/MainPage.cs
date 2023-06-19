using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SQLConn1
{
    public class Page
    {
        public int BranchID = 0;
        public SqlConnection conn;
        public Page()
        {
            string file = @"C:\Users\Amey.Kesarkar\Documents\BranchID.txt";
            if (File.Exists(file))
            {
                string str = File.ReadAllText(file);
                BranchID = Convert.ToInt32(str.Substring(10).Trim());
            }

            string constr;
            constr = @"Data Source = PC-227\SQL2016EXPRESS; Initial Catalog = Northwind; User ID = sagar; Password = aa";

            conn = new SqlConnection(constr);
            conn.Open();
        }
        
    }

    public class MainPage
    {
        public List<Service> ServiceList = new List<Service>();
        public Service ServiceClass { get; set; }
        public void Displaydata()
        {
            Page p = new Page();
            

            SqlCommand cmd;
            SqlDataReader reader;
            string sql;
            sql = String.Format("EXEC GetAllServices {0}" , p.BranchID);
            cmd = new SqlCommand(sql, p.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ServiceClass = new Service();
                ServiceClass.ServiceID = reader.GetInt32(0);
                ServiceClass.ServiceName = reader.GetString(1);
                ServiceList.Add(ServiceClass);
            }

            foreach (Service ser in ServiceList)
            {
                Console.WriteLine(ServiceList.IndexOf(ser) + 1 + " -- " + ser.ServiceName);
            }

            int choice  = int.Parse(Console.ReadLine());

            if (choice >= ServiceList.Count + 1)
            {
                Console.Clear();
                this.Displaydata();
            }

            Console.Clear();
            ServiceList[choice - 1].DisplayQuestion();
            reader.Close();
            cmd.Dispose();
            p.conn.Close();
            Console.ReadLine();
        }
    }
}
