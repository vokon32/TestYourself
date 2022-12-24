using Microsoft.AspNetCore.Mvc;
using testtesttest.Data;
using testtesttest.Interfaces;
using testtesttest.Models;
using testtesttest.ViewModels;

namespace testtesttest.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;

        private readonly IPhotoService _photoService;

        public TestController(ITestRepository testRepository, IPhotoService photoService)
        {
            _testRepository = testRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Test> tests = await _testRepository.GetAll();
            return View(tests);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Test test = await _testRepository.GetByIdAsync(id);
            return View(test);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestViewModel testVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(testVM.Image);
                var test = new Test
                {
                    Title = testVM.Title,
                    Description = testVM.Description,
                    Image = result.Url.ToString(),
                    TestCategory = testVM.TestCategory
                };
                _testRepository.Add(test);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Photo upload failed");
            }
            return View(testVM);
        }
    }
}
