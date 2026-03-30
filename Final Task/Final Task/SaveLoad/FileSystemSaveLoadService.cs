using System.IO;

namespace Final_Task.SaveLoad
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _path;

        public FileSystemSaveLoadService(string path)
        {
            _path = path;

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        public void SaveData(string data, string identifier)
        {
            var fullPath = Path.Combine(_path, identifier + ".txt");

            File.WriteAllText(fullPath, data);
        }

        public string LoadData(string identifier)
        {
            var fullPath = Path.Combine(_path, identifier + ".txt");

            if (!File.Exists(fullPath))
                return null;

            return File.ReadAllText(fullPath);
        }
    }
}
