using System;
using System.IO;

namespace AssistantClient.Core.FileUtils
{

    class MyFile
    {
        private readonly string Name = "Configuration.txt";
        private readonly string Path = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ "\\Udovychenko\\");
        public bool CheckExists()
        {
           return File.Exists(Path + Name);
        }

        public void CreateFile(string text)
        {
            text = text.ToLower();
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            using (StreamWriter writer = File.CreateText(Path + Name))
            {
                writer.WriteLine(text);
            }
        }

        public string ReadFile()
        {
            var request = File.ReadAllText(Path + Name);
            return request.TrimEnd();
        }
    }
}
