using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystemAgent
{
    public class MainMenu : Page
    {
        public MainMenu()
        {
            pages.Add(new GetCustomerInfo());
            pages.Add(new MarkInServing());
            pages.Add(new MarkInServed());
        }
    }
}
