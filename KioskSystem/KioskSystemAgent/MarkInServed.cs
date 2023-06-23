using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KioskSystemAgent
{
    public class MarkInServed : Page
    {
        CommonResponseDTO<string> CommonResponseDTO;
        Customer customer = new Customer();
        public MarkInServed()
        {
            PageName = "Mark Served";
        }

        public override void DisplayQuestions()
        {
            Console.WriteLine("Enter Token");
            customer.Token = GetReader.GetString("Enter Currect Token");
            Console.WriteLine("Enter Counter Number");
            customer.CounterID = GetReader.GetInteger("Enter Currect Counter Number");

            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Served/", customer).Result.Content.ReadFromJsonAsync<CommonResponseDTO<string>>().Result;
            }

            Console.WriteLine($"{CommonResponseDTO.Message}");
            Console.ReadLine();
        }
    }
}
