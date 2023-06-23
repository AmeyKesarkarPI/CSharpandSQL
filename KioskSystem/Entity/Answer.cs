using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Answer
    {
        public string[] Answers { get; set; }
        public int[] QuestionsID { get; set; }
        public int ServiceID { get; set; }
        public int BranchID { get; set; }
    }
}
