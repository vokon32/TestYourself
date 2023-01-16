using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetAll();
        Task<Test> GetByIdAsync(int id);
        Task<Test> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Test>> GetTestByCountry(string country);
        Task<Test> GetQuestionsInTestById(int id);
        bool Add(Test test);
        bool Update(Test test);
        bool Delete(Test test);
        bool Save();

    }
}
