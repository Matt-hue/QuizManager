using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuizManager.EntityFramework.Models;
using QuizManager.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        readonly IOptions<UserDataSeed> _seedData;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<UserDataSeed> seedData)
            : base(options)
        {
            _seedData = seedData ?? throw new ArgumentNullException(nameof(seedData));
        }
        public DbSet<ApplicationQuiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = _seedData.Value.ConfigUsers.Select(u =>
                    new ApplicationUser
                    {
                        Id = u.Id,
                        Email = u.Email,
                        NormalizedEmail = u.Email.ToUpper(),
                        UserName = u.Email,
                        NormalizedUserName = u.Email.ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = u.PasswordHash
                    }
                );
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
                {
                  new IdentityRole {
                    Id = "1",
                    Name = "Restricted",
                    NormalizedName = "RESTRICTED"
                  },
                  new IdentityRole {
                    Id = "2",
                    Name = "View",
                    NormalizedName = "VIEW"
                  },
                    new IdentityRole {
                    Id = "3",
                    Name = "Edit",
                    NormalizedName = "EDIT"
                  },
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>>
                {
                    new IdentityUserRole<string>
                    {
                        RoleId = "1",
                        UserId = "A35C587A-F790-436B-B480-FBA89D0C1C13"
                    },
                        new IdentityUserRole<string>
                    {
                        RoleId = "2",
                        UserId = "3C2F4A0C-8B17-4B26-B061-48EFDAD23DCE"
                    },
                        new IdentityUserRole<string>
                    {
                        RoleId = "3",
                        UserId = "912620D3-0481-401C-8DB4-5E127DB0D4A7"
                    }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
