using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testtesttest.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public int testId { get; set; }
        [ForeignKey("Tests")]
        public Test? Test { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserResult")]
        public AppUser? AppUser { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public double FinalScore { get; set; }
        public bool isPassed { get; set; }
    }
}
