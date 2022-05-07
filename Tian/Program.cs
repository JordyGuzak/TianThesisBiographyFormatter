using System;
using System.Linq;
using System.IO;
using System.Text;

namespace Tian
{
    internal class Program
    {
        public const string FILE_NAME = "biography.txt";
        public const string RESULT_FILE_NAME = "biography_result.txt";
        
        public static void Main(string[] args)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, FILE_NAME);
            var resultFilePath = Path.Combine(Environment.CurrentDirectory, RESULT_FILE_NAME);
            
            var content = File.ReadAllText(filePath);
            var lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (File.Exists(resultFilePath))
                File.Delete(resultFilePath);
            
            using (var fs = File.Open(resultFilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                foreach (var line in lines.OrderBy(l => l))
                {
                    var bytes = new UTF8Encoding(true).GetBytes(line + Environment.NewLine);
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}