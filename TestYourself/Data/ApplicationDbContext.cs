using CloudinaryDotNet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testtesttest.Models;

namespace testtesttest.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Test> Tests { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<TestResult> TestResults { get; set; } = null!;

    }
}
