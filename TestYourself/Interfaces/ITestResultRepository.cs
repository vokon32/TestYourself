using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.Interfaces
{
    public interface ITestResultRepository
    {
        Task<IEnumerable<TestResult>> GetAll();
        Task<TestResult> GetByIdAsync(int id);
        Task<TestResult> GetByIdAsyncNoTracking(int id);
        Task<TestResult> GetByTestIdAndUserIdAsNoTracking(int testId, string userId);
        Task<IEnumerable<TestResult>> GetAllTestResultsByUserId(string Id);
        bool Add(TestResult test);
        bool Update(TestResult test);
        bool Delete(TestResult test);
        bool Save();
    }
}
