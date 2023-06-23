using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public static class GetReader
    {
        public static string GetString(string msg)
        {
            bool TryAgain = false;
            string output = "";
            while (!TryAgain)
            {
                output = Console.ReadLine();
                TryAgain = true;
                if(output == "")
                {
                    TryAgain = false;
                    Console.WriteLine(msg);
                }
            }
            return output;
        }

        public static int GetInteger(string msg)
        {
            bool TryAgain = false;
            int output = 0;
            while (!TryAgain)
            {
                TryAgain = int.TryParse(Console.ReadLine(), out output);
                if (!TryAgain)
                {
                    Console.WriteLine(msg);
                }
            }
            return  output;
        }
    }
}
