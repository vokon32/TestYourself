using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Data.Enum;

namespace testtesttest.ViewModels
{
    public class CreateTestViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public TestCategory TestCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
