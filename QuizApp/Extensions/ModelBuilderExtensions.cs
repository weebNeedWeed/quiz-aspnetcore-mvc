using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
                );

            // Seed Quizzes
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Title = "Test 1",
                    Description = "Bai kiem tra 1"
                },
                new Quiz
                {
                    Id = 2,
                    Title = "Test 2",
                    Description = "Bai kiem tra 2"
                }
                );

            // Seed Questions for Quiz
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Title = "1 + 1 = ?",
                    QuizId=1
                },
                new Question
                {
                    Id = 3,
                    Title = "9*9 = ?",
                    QuizId=1
                },
                new Question
                {
                    Id = 2,
                    Title = "5 * 4 = ?",
                    QuizId = 2
                }
                );

            // Seed Answers for Question
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 1,
                    Title="1",
                    Correct= false,
                    QuestionId=1
                },
                new Answer
                {
                    Id = 2,
                    Title="2",
                    Correct= true,
                    QuestionId=1
                },
                new Answer
                {
                    Id = 3,
                    Title="3",
                    Correct= false,
                    QuestionId=1
                },
                new Answer
                {
                    Id = 4,
                    Title="20",
                    Correct= true,
                    QuestionId=2
                },
                new Answer
                {
                    Id = 5,
                    Title="9",
                    Correct= false,
                    QuestionId=2
                },
                new Answer
                {
                    Id = 6,
                    Title="324",
                    Correct= false,
                    QuestionId=3
                },
                new Answer
                {
                    Id = 7,
                    Title="81",
                    Correct= true,
                    QuestionId=3
                }
                );
        }
    }
}
