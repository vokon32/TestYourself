using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Tests.Any())
                {
                    context.Tests.AddRange(new List<Test>()
                    {
                        new Test()
                        {
                            Title = "MathTest",
                            questionsAmount = 2,
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "Really funny test",
                            TestCategory = Enum.TestCategory.Math
                         },
                        new Test()
                        {
                            Title = "LiteratureTest",
                            questionsAmount = 2,
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "Really funny test",
                            TestCategory = Enum.TestCategory.Literature
                        },
                        new Test()
                        {
                            Title = "EnglishTest",
                            questionsAmount = 2,
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "Really funny test",
                            TestCategory = Enum.TestCategory.English
                        }
                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Questions.Any())
                {
                    context.Questions.AddRange(new List<Question>()
                    {
                        new Question()
                        {
                          Contain = "test Math1",
                          isCorrect = false,
                          testId = 1

                        },
                        new Question()
                        {
                          Contain = "test Math2",
                          isCorrect = false,
                          testId = 1
                        },
                      new Question()
                        {
                          Contain = "test Literature1",
                          isCorrect = false,
                          testId = 2

                        },
                      new Question()
                        {
                          Contain = "test English",
                          isCorrect = false,
                          testId = 3
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
