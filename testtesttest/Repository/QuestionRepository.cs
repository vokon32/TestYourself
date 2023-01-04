using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Data;
using testtesttest.Interfaces;
using testtesttest.Models;

namespace testtesttest.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Question question)
        {
            _context.Add(question);
            return Save();
        }

        public bool Delete(Question question)
        {
            _context.Remove(question);
            return Save();
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<Question>> GetByTestId(int id)
        {
            return await _context.Questions.AsNoTracking().Include(q=>q.Test).Where(t => t.testId == id).ToListAsync();
        }
        public async Task<Question> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Questions.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Question question)
        {
            _context.Update(question);
            return Save();
        }
    }
}
