using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.ViewModels
{
    public class FinishQuestionViewModel
    {
        public bool CanBePassedAgain { get; set; }
        public string ChosenAnswer { get; set; }
        public int testId { get; set; }
        public Test? Test { get; set; }
    }
}
