using EXAM3.Models;
using System.Collections.Generic;

namespace EXAM3.Data
{
    public class DataStore
    {
        public List<User> Users { get; set; } = new();
        public List<QuizResult> Results { get; set; } = new();
        public List<CategoryGroup> Categories { get; set; } = new();
        public List<AnswerModel> Answers { get; set; } = new();
    }
}