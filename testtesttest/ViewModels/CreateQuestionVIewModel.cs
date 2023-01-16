using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.ViewModels
{
    public class CreateQuestionVIewModel
    {
        public int Id { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? ChosenAnswer { get; set; }
        public string Contain { get; set; }
        public int? CurrentAmountOfQuestions { get; set; }
        public bool isFull { get; set; } = false;
        public int testId { get; set; }
        public Test? Test { get; set; }
    }
}
