using Microsoft.AspNetCore.Mvc;
using testtesttest.Data;
using testtesttest.Interfaces;
using testtesttest.ViewModels;

namespace testtesttest.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userTests = await _dashboardRepository.GetAllUserTests();
            var dashboardVM = new DashboardViewModel()
            {
                Tests = userTests
            };
            return View(dashboardVM);
        }
    }
}
