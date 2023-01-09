using Microsoft.AspNetCore.Mvc;
using testtesttest.Interfaces;
using testtesttest.Models;
using testtesttest.ViewModels;

namespace testtesttest.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestResultRepository _testResultRepository;
        private readonly ITestRepository _testRepository;
        private const int MinimalAmountOfQuestions = 5;

        public QuestionController(IQuestionRepository questionRepository, ITestResultRepository testResultRepository,
            ITestRepository testRepository)
        {
            _questionRepository = questionRepository;
            _testResultRepository = testResultRepository;
            _testRepository = testRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            var curUserId = User.GetUserId();
            var testResult = await _testResultRepository.GetByTestIdAndUserIdAsNoTracking(id, curUserId);
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

            var check = _questionRepository.GetByIdAsyncNoTracking(questionVM.Id).Result.CorrectAnswer;
            if (questionVM.ChosenAnswer == check)
            {
                questionVM.ResultScore++;
            }

            if (questionVM.CurrentIndex == questionVM.Questions.Count() - 1)
            {
                var curUserId = User.GetUserId();
                var testResult = new TestResult()
                {
                    testId = questionVM.testId,
                    AppUserId = curUserId.ToString(),
                    FinalScore = 100 / questionVM.Questions.Count() * questionVM.ResultScore,
                    isPassed = true
                };
                _testResultRepository.Add(testResult);
                return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "TestResult", Action = "Index", Id = testResult.Id }));
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
                var test = await _testRepository.GetByIdAsyncNoTracking(questionVM.testId);
                test.isPassed = true;
                _testRepository.Update(test);
            }
            return View(nextQuestionVM);
        }

        public async Task<IActionResult> Create(int id)
        {
            var createQuestionVM = new CreateQuestionVIewModel()
            {
                testId = id,
                CurrentAmountOfQuestions = 0
            };
            return View(createQuestionVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionVIewModel createQuestionVM)
        {
            
            if (ModelState.IsValid)
            {
                var question = new Question()
                {
                    FirstAnswer = createQuestionVM.FirstAnswer,
                    SecondAnswer = createQuestionVM.SecondAnswer,
                    CorrectAnswer = createQuestionVM.ChosenAnswer,
                    Contain = createQuestionVM.Contain,
                    testId = createQuestionVM.testId
                };
                createQuestionVM.CurrentAmountOfQuestions++;
                _questionRepository.Add(question);
                
                if (createQuestionVM.CurrentAmountOfQuestions >= MinimalAmountOfQuestions)
                {
                    var test = await _testRepository.GetByIdAsyncNoTracking(createQuestionVM.testId);
                    test.questionsAmount = createQuestionVM.CurrentAmountOfQuestions;
                    _testRepository.Update(test);
                    createQuestionVM.isFull = true;
                    
                }

                var nextCreateQuestionVM = new CreateQuestionVIewModel()
                {
                    testId = createQuestionVM.testId,
                    CurrentAmountOfQuestions = createQuestionVM.CurrentAmountOfQuestions,
                    isFull = createQuestionVM.isFull
                };
                return View(nextCreateQuestionVM);
            }
            return View(createQuestionVM);
        }

        public async Task<IActionResult> Finish(int id)
        {
            var finish = new FinishQuestionViewModel()
            {
                testId = id
            };
            return View(finish);
        }
        [HttpPost]
        public async Task<IActionResult> Finish(FinishQuestionViewModel finishQuestionVM)
        {
            if (ModelState.IsValid)
            {
                if (finishQuestionVM.ChosenAnswer == "Yes")
                {
                    var test = await _testRepository.GetByIdAsyncNoTracking(finishQuestionVM.testId);
                    test.CanBePassedAgain = true;
                    _testRepository.Update(test);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View(finishQuestionVM);
        }
    }
}
