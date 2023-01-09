using CloudinaryDotNet.Actions;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestController(ITestRepository testRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _testRepository = testRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
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
        [HttpPost, ActionName("Detail")]
        public async Task<IActionResult> DetailCheck(int id )
        {
            return RedirectToAction("Index", "Question", id);
        }

        public IActionResult Create()
        {
            var curUserId = User.GetUserId();
            var createTestViewModel = new CreateTestViewModel()
            {
                AppUserId = curUserId
            };
            return View(createTestViewModel);
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
                    TestCategory = testVM.TestCategory,
                    AppUserId = testVM.AppUserId
                };
                _testRepository.Add(test);
                return RedirectToAction("Create", new RouteValueDictionary(new { Controller = "Question", Action = "Create", id = test.Id }));
            }
            else
            {
                ModelState.AddModelError("","Photo upload failed");
            }
            return View(testVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var curUserId = User.GetUserId();
            var test = await _testRepository.GetByIdAsync(id);
            if (test == null) return View("Error");
            var testVM = new EditTestViewModel
            {
                Title = test.Title,
                Description = test.Description,
                URL = test.Image,
                TestCategory = test.TestCategory,
                AppUserId = curUserId
            };
            return View(testVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, EditTestViewModel testVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit",testVM);
            }
            var userTest = await _testRepository.GetByIdAsyncNoTracking(Id);
            if (userTest != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userTest.Image);
                }
                catch 
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(testVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(testVM.Image);

                var test = new Test
                {
                    Id = Id,
                    Title = testVM.Title,
                    Description = testVM.Description,
                    Image = photoResult.Url.ToString(),
                    TestCategory = testVM.TestCategory,
                    AppUserId = testVM.AppUserId
                };
                _testRepository.Update(test);

                return RedirectToAction("Index");
            }
            else
            {
                return View(testVM);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var testDetails = await _testRepository.GetByIdAsync(Id);
            if (testDetails == null) return View("Error");
            return View(testDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            var testDetails = await _testRepository.GetByIdAsync(id);
            if (testDetails == null) return View("Error");

            _testRepository.Delete(testDetails);
            return RedirectToAction("Index");
        }


    }
}
