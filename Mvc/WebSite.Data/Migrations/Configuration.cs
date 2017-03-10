namespace WebSite.Data.Migrations
{
    using Infrastructure.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        private const string adminRoleName = "Administrator";
        private const string adminPassword = "mySecretPass";

        protected override void Seed(Context context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            if (!roleManager.RoleExists(adminRoleName))
            {
                var role = new IdentityRole()
                {
                    Name = adminRoleName
                };
                roleManager.Create(role);

                var user = new User()
                {
                    UserName = "asya@gmail.com",
                    Email = "asya@gmail.com"
                };

                IdentityResult createUserResult = userManager.Create(user, adminPassword);
                if (createUserResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, adminRoleName);
                }
            }

            TeamMember[] teamMembers = new TeamMember[]
            {
                new TeamMember()
                {
                    EmployedOn = DateTime.UtcNow,
                    Name = "Pesho",
                    Position = "web developer",
                    Description = "Pesho is very smart!",
                    Image = new Image
                    {
                        CreatedOn = DateTime.UtcNow,
                        OriginalFileName = "member.jpg",
                        SystemFileName = "member.jpg",
                        Location = PathConstants.TeamImagePath
                    }
                },
                new TeamMember()
                {
                    EmployedOn = DateTime.UtcNow,
                    Name = "Gosho",
                    Position = "designer",
                    Description = "Pesho is very smart!",
                    Image = new Image
                    {
                        CreatedOn = DateTime.UtcNow,
                        OriginalFileName = "member.jpg",
                        SystemFileName = "member.jpg",
                        Location = PathConstants.TeamImagePath
                    }
                },
                new TeamMember()
                {
                    EmployedOn = DateTime.UtcNow,
                    Name = "Georgi",
                    Position = "QA",
                    Description = "Pesho is very smart!",
                    Image = new Image
                    {
                        CreatedOn = DateTime.UtcNow,
                        OriginalFileName = "member.jpg",
                        SystemFileName = "member.jpg",
                        Location = PathConstants.TeamImagePath
                    }
                },
                new TeamMember()
                {
                    EmployedOn = DateTime.UtcNow,
                    Name = "Joro",
                    Position = "designer",
                    Description = "Pesho is very smart!",
                    Image = new Image
                    {
                        CreatedOn = DateTime.UtcNow,
                        OriginalFileName = "member.jpg",
                        SystemFileName = "member.jpg",
                        Location = PathConstants.TeamImagePath
                    }
                },
                new TeamMember()
                {
                    EmployedOn = DateTime.UtcNow,
                    Name = "Ivan",
                    Position = "web developer",
                    Description = "Pesho is very smart!",
                    Image = new Image
                    {
                        CreatedOn = DateTime.UtcNow,
                        OriginalFileName = "member.jpg",
                        SystemFileName = "member.jpg",
                        Location = PathConstants.TeamImagePath
                    }
                }
            };
        
            


            Article[] articles = new Article[]
                {
                new Article()
                {
                    Image = new Image()
                    {
                       CreatedOn = DateTime.UtcNow,
                       OriginalFileName = "programming1.jpg",
                       SystemFileName = "programming1.jpg",
                       Location = PathConstants.ArticlesImagePath
                    },
                    CreatedOn = DateTime.UtcNow,
                    Title = "Basic goals of computer programming",
                    Content = "When you are planning to create a computer program you should: Ensure your program fulfills the need it is addressing. Ensure that people can easily use your program. Ensure that it is easy to understand, fix, and improve your program without a major time investment."
                },
                new Article()
                {
                    Image = new Image()
                    {
                       CreatedOn = DateTime.UtcNow,
                       OriginalFileName = "programming2.png",
                       SystemFileName = "programming2.png",
                       Location = PathConstants.ArticlesImagePath
                    },
                    CreatedOn = DateTime.UtcNow,
                    Title = "Basic goals of computer programming",
                    Content = "When you are planning to create a computer program you should: Ensure your program fulfills the need it is addressing. Ensure that people can easily use your program. Ensure that it is easy to understand, fix, and improve your program without a major time investment."
                },
                new Article()
                {
                    Image = new Image()
                    {
                       CreatedOn = DateTime.UtcNow,
                       OriginalFileName = "programming.jpg",
                       SystemFileName = "programming.jpg",
                       Location = PathConstants.ArticlesImagePath
                    },
                    CreatedOn = DateTime.UtcNow,
                    Title = "Basic goals of computer programming",
                    Content = "When you are planning to create a computer program you should: Ensure your program fulfills the need it is addressing. Ensure that people can easily use your program. Ensure that it is easy to understand, fix, and improve your program without a major time investment."
                },
                new Article()
                {
                    Image = new Image()
                    {
                       CreatedOn = DateTime.UtcNow,
                       OriginalFileName = "programming2.png",
                       SystemFileName = "programming2.png",
                       Location = PathConstants.ArticlesImagePath
                    },
                    CreatedOn = DateTime.UtcNow,
                    Title = "Basic goals of computer programming",
                    Content = "When you are planning to create a computer program you should: Ensure your program fulfills the need it is addressing. Ensure that people can easily use your program. Ensure that it is easy to understand, fix, and improve your program without a major time investment."
                },
                new Article()
                {
                    Image = new Image()
                    {
                       CreatedOn = DateTime.UtcNow,
                       OriginalFileName = "programming.jpg",
                       SystemFileName = "programming.jpg",
                       Location = PathConstants.ArticlesImagePath
                    },
                    CreatedOn = DateTime.UtcNow,
                    Title = "Basic goals of computer programming",
                    Content = "When you are planning to create a computer program you should: Ensure your program fulfills the need it is addressing. Ensure that people can easily use your program. Ensure that it is easy to understand, fix, and improve your program without a major time investment."
                }
                };

            context.Articles.AddOrUpdate(articles);
            context.TeamMember.AddOrUpdate(teamMembers.ToArray());
            context.SaveChanges();
        }
    }
}