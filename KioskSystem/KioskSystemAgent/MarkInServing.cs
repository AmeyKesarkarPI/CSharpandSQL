using Entity;
using System.Net.Http;
using System;
using System.Net.Http.Json;

namespace KioskSystemAgent
{
    public class MarkInServing : Page
    {
        CommonResponseDTO<string> CommonResponseDTO;
        Customer customer = new Customer();
        public MarkInServing()
        {
            PageName = "Mark Serving";
        }

        public override void DisplayQuestions()
        {

            Console.WriteLine("Enter Token");
            customer.Token = GetReader.GetString("Enter Currect Token");
            Console.WriteLine("Enter Counter Number");
            customer.CounterID = GetReader.GetInteger("Enter Currect Counter Number");

            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Customer/", customer).Result.Content.ReadFromJsonAsync<CommonResponseDTO<string>>().Result;
            }

            Console.ReadLine();
            Console.WriteLine($"{CommonResponseDTO.Message}");
        }
    }
}
