using System.Collections.Generic;

namespace EXAM3.Models
{
    public class Question
    {
        public Question() { }
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public Dictionary<string, string> Options { get; set; } = new();
        public List<string> CorrectOptions { get; set; } = new();
        public bool IsMultipleChoice => CorrectOptions.Count > 1;
    }
}