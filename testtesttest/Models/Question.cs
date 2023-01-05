using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testtesttest.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public string? ChosenAnswer { get; set; }
        public string Contain { get; set; }
        public bool? isCorrect { get; set; }
        [ForeignKey("Test")]
        public int testId { get; set; }
        public Test Test { get; set; }
        public TestResult? TestResult { get; set; }
    }
}
