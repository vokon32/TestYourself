using Microsoft.AspNetCore.Identity;
using System.Net;
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

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "admin@gmai.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                      
                    };
                    await userManager.CreateAsync(newAdminUser, "coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                       
                    };
                    await userManager.CreateAsync(newAppUser, "coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

