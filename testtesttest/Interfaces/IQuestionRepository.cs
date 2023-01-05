using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAll();
        Task<Question> GetByIdAsync(int id);
        Task<Question> GetByIdAsyncNoTracking(int id);
        Task<Question> GetFirstQuestion(int id);
        bool Add(Question question);
        bool Update(Question question);
        bool Delete(Question question);
        bool Save();
        Task<List<Question>> GetByTestId(int id);
    }
}
