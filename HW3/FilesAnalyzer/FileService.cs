using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAnalyzer
{
    public class FileService
    {
        public async Task<string> MoveFiles(string source, string destination)
        {
            string report = "";

            foreach (var file in Directory.GetFiles(@$"{source}")) 
            { 
                if (! await IsDuplicate(file, destination))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    File.Move(file, destination + $"\\{fileInfo.Name}");
                    report += $"{fileInfo.Name} moved\n";
                }
            }

            return report;
        }

        public async Task<bool> IsDuplicate(string file, string destination)
        {
            var fileBytes = await File.ReadAllBytesAsync(file);
            var destinationFiles = Directory.GetFiles(@$"{destination}");

            foreach (var destinationFile in destinationFiles) 
            { 
                var dfBytes = await File.ReadAllBytesAsync(destinationFile);

                if (fileBytes.SequenceEqual(dfBytes))
                {
                    return true;
                }
            
            }

            return false;
        }
    }
}
