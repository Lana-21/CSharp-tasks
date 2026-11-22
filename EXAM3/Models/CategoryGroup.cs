using System.Collections.Generic;

namespace EXAM3.Models
{
    public class CategoryGroup
    {
        public string Category { get; set; } = "";
        public List<Question> Questions { get; set; } = new();
    }
}