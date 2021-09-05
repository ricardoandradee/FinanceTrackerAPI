using System.IO;

namespace FinanceTracker.Application.Utils
{
    public class FileHandler : IFileHandler
    {
        public string ReadFile(string FileName)
        {
            using (StreamReader reader = File.OpenText(FileName))
            {
                string fileContent = reader.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(fileContent))
                {
                    return fileContent;
                }
            }
            return string.Empty;
        }
    }
}
