using testtesttest.Data.Enum;

namespace testtesttest.ViewModels
{
    public class EditTestViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public TestCategory TestCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
