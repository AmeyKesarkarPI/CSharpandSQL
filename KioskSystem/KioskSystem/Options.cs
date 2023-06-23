using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystem
{
    public class Options: Page
    {
        string apiLink = "https://localhost:44373/api/";
        public Options()
        {
            PageName = "Option";
        }
        public override void DisplayServices(int ServiceID)
        {
            List<Service> serviceList = new List<Service>();
            ServiceID = 1;
            apiLink = "https://localhost:44373/api/" + "Services/" + ServiceID;
            using (HttpClient client = new HttpClient())
            {
                var placeholder = client.GetFromJsonAsync<CommonResponseDTO<List<Service>>>(apiLink).Result;
                serviceList = placeholder.Data;
            }

            foreach (Service service in serviceList)
            {
                Console.WriteLine(serviceList.IndexOf(service) + 1 + " -- " + service.ServiceName);
            }
            int choice = int.Parse(Console.ReadLine());

            if (choice >= serviceList.Count)
            {
                Console.Clear();
                this.DisplayServices(ServiceID);
            }

            //serviceList[choice - 1].DisplayQuestions();
            Console.WriteLine();
        }
    }
}
