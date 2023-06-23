using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;

namespace KioskSystem
{
    public class CommonResponseDTO<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class Page
    {
        public string PageName { get; set; }
        public Page()
        {
            PageName = "Home";
        }

        string apiLink = "https://localhost:44373/api/";

        public int GetBranchID()
        {
            int Service_Branch_id=0;
            string s = "";
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ServicePin.txt";
            if (File.Exists(filepath))
            {
                s = File.ReadAllText(filepath);
            }
            if (s != "" || s != null)
            {
                string[] sarray = s.Split('=');
                Service_Branch_id = Convert.ToInt32(sarray[1]);
            }
            return Service_Branch_id;
        }
        public void DisplayBranch(int Service_Branch_id)
        {
            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO<ServiceBranch> res = client.GetFromJsonAsync<CommonResponseDTO<ServiceBranch>>
                    ("https://localhost:44373/Api/Branch/" + Service_Branch_id).Result;
                if (res.Success == true)
                {
                    ServiceBranch SB = res.Data;

                    Console.WriteLine("Welcome To " + SB.CompanyName + " Of " + SB.BranchName + " Branch");

                }
                else
                {
                    Console.WriteLine("Please check Branch Id is incorrect..");
                }
            }
        }
        public virtual void DisplayServices(int BranchID)
        {
            Console.WriteLine();
            Console.WriteLine("Please Enter Your Choice :- ");
            List<Service> serviceList = new List<Service>();
            apiLink = "https://localhost:44373/api/" + "Kiosk/" + BranchID;
            using (HttpClient client = new HttpClient())
            {
                var placeholder = client.GetFromJsonAsync<CommonResponseDTO<List<Service>>>(apiLink).Result;
                serviceList = placeholder.Data;
            }

            foreach (Service service in serviceList)
            {
                Console.WriteLine(serviceList.IndexOf(service) + 1 + " -- " + service.ServiceName);
            }
            //int choice = int.Parse(Console.ReadLine())-1;
            int choice = consolereader.getint("")-1;
            if (choice > serviceList.Count)
            {
                Console.Clear();
                this.DisplayServices(BranchID);
            }
            //serviceList[choice - 1].DisplayQuestions();
            DisplayQuestions(serviceList.ElementAt(choice).ServiceID, BranchID);
            Console.WriteLine();
        }
        public void DisplayQuestions(int serviceID, int branchID)
        {
            string apiLink = "https://localhost:44373/api/";
            List<Questions> questions = new List<Questions>();
            apiLink = "https://localhost:44373/api/" + "Question/" + serviceID;

            using (HttpClient client = new HttpClient())
            {
                var placeholder = client.GetFromJsonAsync<CommonResponseDTO<List<Questions>>>(apiLink).Result;
                questions = placeholder.Data;
            }
            Answer answer = new Answer();
            answer.BranchID = branchID;
            answer.ServiceID = serviceID;
            int count = 0;
            int[] QID = new int[questions.Count];
            string[] AnswerString = new string[questions.Count];
            foreach (Questions question in questions)
            {
                Console.WriteLine();
                Console.Write(question.Question);
                QID[count] = question.QuestionID;
                //AnswerString[count] = Console.ReadLine();
                AnswerString[count] = consolereader.getstring("");
                count++;
            }
            answer.QuestionsID = QID;
            answer.Answers = AnswerString;
            DisplayToken(answer);
            
        }

        private void DisplayToken(object answer)
        {
            Token token = new Token();
            apiLink = "https://localhost:44373/api/Answer";
                //"Asnwer/"; Answer
            using (HttpClient client = new HttpClient())
            {
                var placeholder = client.PutAsJsonAsync(apiLink, answer).Result.Content.ReadFromJsonAsync <CommonResponseDTO<Token>>().Result;
                token = placeholder.Data;
            }
            Console.WriteLine();
            Console.WriteLine("Your token ID is "+token.TokenID+". Please proceed to Counter: "+token.CounterID);
        }
    }
}