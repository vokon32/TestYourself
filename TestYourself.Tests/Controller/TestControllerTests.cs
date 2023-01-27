using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Controllers;
using testtesttest.Interfaces;
using testtesttest.Models;

namespace TestYourself.Tests.Controller
{
    public class TestControllerTests
    {
        private ITestRepository _testRepository;
        private IPhotoService _photoService;
        private TestController _testController;

        public TestControllerTests()
        {
            _testRepository = A.Fake<ITestRepository>();
            _photoService = A.Fake<IPhotoService>();

            _testController = new TestController(_testRepository, _photoService);
        }

        [Fact]
        public  void TestController_Index_ReturnsSuccess()
        {
            var tests = A.Fake<IEnumerable<Test>>();
            A.CallTo(() => _testRepository.GetAll()).Returns(tests);

            var result = _testController.Index();

            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Fact]
        public void TestController_Detail_ReturnsSuccess()
        {
            var id = 1;
            var test = A.Fake<Test>();
            A.CallTo(() => _testRepository.GetByIdAsync(id)).Returns(test);
           

            var result = _testController.Detail(id);

            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
