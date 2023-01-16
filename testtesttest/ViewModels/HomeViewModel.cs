using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Test> Tests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
