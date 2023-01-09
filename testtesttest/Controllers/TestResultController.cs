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
        public async Task<IActionResult> Again(int Id)
        {
            var curUserId = User.GetUserId();
            var testResult = await _testResultRepository.GetByTestIdAndUserIdAsNoTracking(Id, curUserId);
            if (testResult != null)
            {
                _testResultRepository.Delete(testResult);
            }
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "Question", Action = "Index", Id = Id }));
        }
        public async Task<IActionResult> UserResults()
        {
            var curUserId = User.GetUserId();
            var testResults = await _testResultRepository.GetAllTestResultsByUserId(curUserId);
            return View(testResults);
        }
    }
}
