using System;

namespace EXAM3.Models
{
    public class QuizResult
    {
        public QuizResult() { }
        public string Username { get; set; } = "";
        public string Category { get; set; } = "";
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public QuizResult(string username, string category, int score, DateTime date)
        {
            Username = username;
            Category = category;
            Score = score;
            Date = date;
        }
    }
}