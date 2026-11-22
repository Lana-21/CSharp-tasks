using EXAM3.Models;

namespace EXAM3.Interfaces
{
    public interface IFileManager
    {
        void LoadData();
        void SaveUsers();
        void SaveQuestionsAndAnswers();
        void AppendResult(QuizResult result);
    }
}