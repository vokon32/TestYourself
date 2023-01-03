using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Implementation;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using testtesttest.Helpers;
using testtesttest.Interfaces;
using testtesttest.Models;
using testtesttest.ViewModels;

namespace testtesttest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestRepository _testRepository;

        public HomeController(ILogger<HomeController> logger, ITestRepository testRepository)
        {
            _logger = logger;
            _testRepository = testRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IPInfo();
            var homeViewModel = new HomeViewModel();
            try
            {
                string url = "https://ipinfo.io?token=59e27c269afe04";
                var info = new WebClient().DownloadString(url);
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
                homeViewModel.City = ipInfo.City;
                homeViewModel.Country = ipInfo.Country;
                if (homeViewModel != null)
                {
                    homeViewModel.Tests = await _testRepository.GetTestByCity(homeViewModel.City);
                }
                else
                {
                    homeViewModel.Tests = null;
                }
                return View(homeViewModel);
            }
            catch
            {
                homeViewModel.Tests = null;
            }
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}