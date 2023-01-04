using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.ViewModels
{
    public class QuestionAnswerViewModel
    {
        public int Id { get; set; }
        public string Contain { get; set; }
        public string? FirstAnswer { get; set; }
        public string? SecondAnswer { get; set; }
        public string? ChosenAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public int ResultScore { get; set; }
        public bool? isCorrect { get; set; }
        [ForeignKey("Test")]
        public int testId { get; set; }
        public Test Test { get; set; }
    }
}
