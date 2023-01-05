using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using testtesttest.Interfaces;
using testtesttest.Models;
using testtesttest.ViewModels;

namespace testtesttest.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestResultRepository _testRepository;


        public QuestionController(IQuestionRepository questionRepository, ITestResultRepository testRepository)
        {
            _questionRepository = questionRepository;
            _testRepository = testRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            var curUserId = User.GetUserId();
            var testResult = await _testRepository.GetByTestIdAndUserIdAsNoTracking(id, curUserId);
            if (testResult != null)
            {
                return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "TestResult", Action = "Index", Id = testResult.Id }));
            }
            
            var question = await _questionRepository.GetFirstQuestion(id);
            var questionVM = new QuestionAnswerViewModel()
            {
                Id = question.Id,
                Contain = question.Contain,
                FirstAnswer = question.FirstAnswer,
                SecondAnswer = question.SecondAnswer,
                CorrectAnswer = question.CorrectAnswer,
                testId = id,
                CurrentIndex = 0
            };
            return View(questionVM);
        }
        [HttpPost]
        public async Task<IActionResult> Index(QuestionAnswerViewModel questionVM)
        {
            questionVM.Questions = await _questionRepository.GetByTestId(questionVM.testId);
            
            if (questionVM.CurrentIndex == questionVM.Questions.Count()-1)
            {
                var curUserId = User.GetUserId();
                var testResult = new TestResult()
                {
                    testId = questionVM.testId,
                    AppUserId = curUserId.ToString(),
                    FinalScore = 100 / questionVM.Questions.Count() * questionVM.ResultScore,
                    isPassed = true,
                    QuestionId = questionVM.Id
                };
                _testRepository.Add(testResult);
                return RedirectToAction("Index", new RouteValueDictionary(new {Controller = "TestResult", Action = "Index", Id = testResult.Id }));
            }
           
            var check = _questionRepository.GetByIdAsyncNoTracking(questionVM.Id).Result.CorrectAnswer;
            if (questionVM.ChosenAnswer == check)
            {
                questionVM.ResultScore++;
            }
            
            questionVM.CurrentIndex++;
            var question = questionVM.Questions[questionVM.CurrentIndex];
            
            var nextQuestionVM = new QuestionAnswerViewModel()
            {
                Id = question.Id,
                Contain = question.Contain,
                FirstAnswer = question.FirstAnswer,
                SecondAnswer = question.SecondAnswer,
                CorrectAnswer = question.CorrectAnswer,
                testId = questionVM.testId,
                ResultScore = questionVM.ResultScore,
                CurrentIndex = questionVM.CurrentIndex
            };
           
            if (questionVM.CurrentIndex == questionVM.Questions.Count() - 1)
            {
                nextQuestionVM.isCorrect = true;
            }
            return View(nextQuestionVM);
        }
    }
}
