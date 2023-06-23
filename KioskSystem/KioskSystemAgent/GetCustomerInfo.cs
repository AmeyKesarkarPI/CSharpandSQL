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
    public class GetCustomerInfo:Page
    {
        CommonResponseDTO<List<Customer>> CommonResponseDTO;
        public GetCustomerInfo()
        {
            PageName = "Get Customer Information";
        }

        public override void DisplayQuestions()
        {
            Console.WriteLine("Enter Token");
            string Token = GetReader.GetString("Enter Currect Token");
            Console.WriteLine("Enter Counter Number");
            int Counter = GetReader.GetInteger("Enter Currect Counter Number");

            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.GetFromJsonAsync<CommonResponseDTO<List<Customer>>>($"https://localhost:44373/Api/Customer/{Counter}?Token={Token}").Result;
            }

            Console.WriteLine("Customer Information ");
            foreach (var item in CommonResponseDTO.Data)
            {
                Console.WriteLine(String.Format("CustomerID: {0,-10}", item.CustomerId));
                Console.WriteLine(String.Format("BranchID: {0,-10}", item.BranchID));
                Console.WriteLine(String.Format("Service Type: {0,-10}", item.ServiceType));
                Console.WriteLine(String.Format("CounterID: {0,-10}", item.CounterID));
                Console.WriteLine(String.Format("Status: {0,-10}", item.Status));
                Console.WriteLine(String.Format("Token: {0,-10}", item.Token));
                Console.WriteLine(String.Format("StatusID: {0,-10}", item.StatusID));
                Console.WriteLine(String.Format("Answers: {0,-10}", item.Answers));
            }
            Console.ReadLine();
        }
    }
}
