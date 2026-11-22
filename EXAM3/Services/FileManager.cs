using EXAM3.Data;
using EXAM3.Interfaces;
using EXAM3.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EXAM3.Services
{
    public class FileManager(DataStore store) : IFileManager
    {
        private JsonSerializerOptions options = new() { WriteIndented = true };
        public void LoadData()
        {
            store.Users = Read<List<User>>("users.json") ?? new();
            store.Categories = Read<List<CategoryGroup>>("questions.json") ?? new();
            store.Answers = Read<List<AnswerModel>>("answers.json") ?? new();
            store.Results = Read<List<QuizResult>>("results.json") ?? new();
            Log.Information(
                "Data load completed: {UsersCount} users, {CategoriesCount} categories, {AnswersCount} answers, {ResultsCount} results",
                store.Users.Count, store.Categories.Count, store.Answers.Count, store.Results.Count);
        }
        public void SaveUsers() => Write("users.json", store.Users);
        public void SaveQuestionsAndAnswers()
        {
            Write("questions.json", store.Categories);
            Write("answers.json", store.Answers);
        }
        public void AppendResult(QuizResult result)
        {
            store.Results.Add(result);
            Write("results.json", store.Results);
            Log.Information("Result for user {User} appended and saved to JSON.", result.Username);
        }
        private T? Read<T>(string path)
        {
            try
            {
                if (!File.Exists(path)) return default;
                using FileStream stream = File.OpenRead(path);
                return JsonSerializer.Deserialize<T>(stream);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error reading file {Path}: {Message}", path, ex.Message);
                return default;
            }
        }
        private void Write<T>(string path, T data)
        {
            try
            {
                using FileStream stream = File.Create(path);
                JsonSerializer.Serialize(stream, data, options);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error saving file {Path}: {Message}", path, ex.Message);
            }
        }
    }
}

