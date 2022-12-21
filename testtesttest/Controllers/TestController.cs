using Microsoft.AspNetCore.Mvc;
using testtesttest.Data;
using testtesttest.Models;

namespace testtesttest.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Test> tests = _context.Tests.ToList();
            return View(tests);
        }

        public IActionResult Detail(int id)
        {
            Test test = _context.Tests.FirstOrDefault(t => t.Id == id);
            return View(test);
        }
    }
}
