using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystem
{
    public class Program
    {
      
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Page p = new Page();
                int BranchId=p.GetBranchID();
                p.DisplayBranch(BranchId);
                p.DisplayServices(BranchId);

                Console.ReadLine();
          } while (true);
        }
    }
}
