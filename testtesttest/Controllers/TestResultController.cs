using Microsoft.AspNetCore.Mvc;
using testtesttest.Interfaces;

namespace testtesttest.Controllers
{
    public class TestResultController : Controller
    {
        private readonly ITestResultRepository _testResultRepository;

        public TestResultController(ITestResultRepository testResultRepository)
        {
            _testResultRepository = testResultRepository;
        }
        public async Task<IActionResult> Index(int Id)
        {
            var test = await _testResultRepository.GetByIdAsync(Id);
            return View(test);
        }
    }
}
