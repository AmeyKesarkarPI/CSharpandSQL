using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConn1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                MainPage mainPage = new MainPage();
                mainPage.Displaydata();
            } while (true);
        }
    }
}
