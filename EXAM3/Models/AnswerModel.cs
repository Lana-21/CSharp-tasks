using System.Collections.Generic;

namespace EXAM3.Models
{
    public class AnswerModel
    {
        public AnswerModel() { }
        public int QuestionId { get; set; }
        public List<string> CorrectOptions { get; set; } = new();
    }
}