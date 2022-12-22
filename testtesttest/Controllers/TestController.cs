﻿using Microsoft.AspNetCore.Mvc;
using testtesttest.Data;
using testtesttest.Interfaces;
using testtesttest.Models;

namespace testtesttest.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
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
        public async Task<IActionResult> Create(Test test)
        {
            if (!ModelState.IsValid)
            {
                return View(test);
            }
            _testRepository.Add(test);
            return RedirectToAction("Index");
        }
    }
}
