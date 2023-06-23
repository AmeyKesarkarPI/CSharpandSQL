using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystemAgent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Page p = new Page();
                p.AgentLogin();
            }while (true);
        }
    }
}
