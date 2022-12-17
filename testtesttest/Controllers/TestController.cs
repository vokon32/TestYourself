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
    }
}
