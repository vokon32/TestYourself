using AspNetCore;
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
        private readonly ITestRepository _testRepository;
        private static List<Question>? Questions;
        private static int currentListIndex = 0;

        public QuestionController(IQuestionRepository questionRepository, ITestRepository testRepository)
        {
            _questionRepository = questionRepository;
            _testRepository = testRepository;
        }


        [HttpPost]

        public async Task<IActionResult> Index(QuestionAnswerViewModel questionVM, int Id)
        {
            if (questionVM.ChosenAnswer != null)
            {
                var check = await _questionRepository.GetByIdAsyncNoTracking(questionVM.Id);
                if (check.CorrectAnswer.ToLower() == questionVM.ChosenAnswer.ToLower())
                {
                    questionVM.ResultScore++;
                }
            }
            if (Questions == null)
            {
                Questions = await _questionRepository.GetByTestId(Id);
            }
            if (currentListIndex != Questions.Count)
            {

                var question = Questions[currentListIndex];
                currentListIndex++;
                var nextQuestionVM = new QuestionAnswerViewModel()
                {
                    Id = question.Id,
                    FirstAnswer = question.FirstAnswer,
                    SecondAnswer = question.SecondAnswer,
                    CorrectAnswer = question.CorrectAnswer,
                    Contain = question.Contain,
                    isCorrect = question.isCorrect,
                    testId = question.testId,
                    ResultScore = questionVM.ResultScore
                };
                return View("Index", nextQuestionVM);
            }
            else
            {
                var test = await _testRepository.GetByIdAsyncNoTracking(Id);
                questionVM.ResultScore = (100 / Questions.Count() * questionVM.ResultScore) + 1;
                test.questionsAmount = Questions.Count();
                test.Result = questionVM.ResultScore;
                currentListIndex = 0;
                Questions = null;
                return RedirectToAction("TestResult", "Test", questionVM);
            }
        }
    }
}
