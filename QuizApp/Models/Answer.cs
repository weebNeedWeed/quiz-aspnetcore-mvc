using System;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public bool Correct { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
