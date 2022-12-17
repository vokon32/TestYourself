using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using testtesttest.Data.Enum;

namespace testtesttest.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int questionsAmount { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public TestCategory TestCategory { get; set; }
        [ForeignKey("Questions")]
        public List<Question> Questions = new();
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
