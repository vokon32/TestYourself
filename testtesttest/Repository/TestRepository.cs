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
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _context;

        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Test test)
        {
            _context.Add(test);
            return Save();
        }

        public bool Delete(Test test)
        {
            _context.Remove(test);
            return Save();
        }

        public async Task<IEnumerable<Test>> GetAll()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await _context.Tests.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Test> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Tests.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Test> GetQuestionsInTestById(int id)
        {
            return await _context.Tests.Include(t => t.Questions).Where(t => t.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Test>> GetTestByCountry(string country)
        {
            return await _context.Tests.Where(c => c.AppUser.State.Contains(country)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Test test)
        {
            _context.Update(test);
            return Save();
        }
    }
}
