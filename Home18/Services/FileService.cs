using Practice18.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Practice18.Services
{
    public static class FileService
    {
        private static string path = "usersList.json";
        private static JsonSerializerOptions options = new() { WriteIndented = true };
        public static void SaveUsers(List<User> users)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, users, options);
            }
        }
        public static List<User>? LoadUsers()
        {
            if (!File.Exists(path)) return null;

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                return JsonSerializer.Deserialize<List<User>>(fileStream, options);
            }
        }
    }
}
