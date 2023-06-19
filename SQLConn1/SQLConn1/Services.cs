using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SQLConn1
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }

        public void DisplayQuestion()
        {
            string xml = "";
            Page page = new Page();
            SqlCommand cmd ;  
            SqlDataReader reader ;
            string sql = String.Format("EXEC KioskGetQuestions {0}", ServiceID);
            cmd = new SqlCommand(sql, page.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Question"]);
                xml += String.Format("<root><Answer>{0}</Answer></root>", Console.ReadLine().ToString().Trim());
                
            }
            InsertAnswers(xml);
            reader.Close();
            cmd.Dispose();
            page.conn.Close();
        }

        public void InsertAnswers(string xml)
        {
            Page p = new Page();
            MainPage m = new MainPage();
            SqlCommand cmd;
            SqlDataReader reader;
            string output = "";
            string sql = String.Format("EXEC KioskInsertAnswers {0},{1},'{2}'", ServiceID, p.BranchID, xml);
            cmd = new SqlCommand(sql, p.conn);
            reader = cmd.ExecuteReader();

            string sql2 = ("Select Top 1 Token,CounterID from Amey_KioskCustomer order BY CustomerID DESC");
            reader.Close ();
            cmd.Dispose ();
            cmd = new SqlCommand(sql2, p.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                output = String.Format("Your TokenID is {0} and CounterID is {1}", reader["Token"], reader["CounterID"]);
            }

            Console.WriteLine(output);
            Console.ReadLine();
            reader.Close();
            cmd.Dispose ();
            p.conn.Close();
            Console.Clear();
            m.Displaydata();
        }
    }
}
