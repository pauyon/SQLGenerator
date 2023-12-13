using System.Collections.Generic;
using System.IO;
using static SQLGeneratorLibrary.Enums;
using System.Linq;

namespace SqlGeneratorLibrary
{
    public class SqlGenerator
    {
        // Keep track of export filename 
        private string _customExportFileName = string.Empty;
        private string _originalExportFileName = string.Empty;

        // Store CSV file info
        private IEnumerable<string> _headers;
        private IEnumerable<string> _data;

        // Holds information on source and target files 
        public FileInfo TargetFile { get; private set; }
        public FileInfo SourceFile { get; private set; }

        public string ExportFileName
        {
            get
            {
                return string.IsNullOrEmpty(_customExportFileName) ? _originalExportFileName : _customExportFileName;
            }
        }

        public void SetSourceFile(string filePath)
        {
            SourceFile = new FileInfo(filePath);
            _originalExportFileName = SourceFile.Name;
        }

        public bool WriteSqlFile(CrudOperation operation, string tableName = "[MyTable]")
        {
            if (File.Exists(TargetFile.FullName))
            {
                File.Delete(TargetFile.FullName);
            }

            using (StreamWriter file = new StreamWriter(TargetFile.FullName, true))
            {
                switch (operation)
                {
                    case CrudOperation.Insert:

                        file.WriteLine("BEGIN TRANSACTION");
                        file.WriteLine($"INSERT INTO {tableName}({string.Join(", ", _headers)}) VALUES");

                        foreach (var row in _data)
                        {
                            file.WriteLine($"({string.Join(", ", row.Split(',').ToList())}),");
                        }

                        file.WriteLine("ROLLBACK");
                        file.WriteLine("-- COMMIT TRANSACTION");
                        file.WriteLine("-- Uncomment line above when ready to execute command indefinitely.");

                        break;

                    case CrudOperation.Delete:
                        file.WriteLine($"DELETE FROM {tableName} where ??? = ???");
                        break;

                    default:
                        return false;
                }

                file.WriteLine("GO");
                return true;
            }
        }

        public void SetTargetFile(string filePath)
        {
            TargetFile = GenerateFileInfo(filePath);
        }

        public void ReadCSVFile(string text)
        {
            // Read all CSV lines & store headers
            var lines = File.ReadLines(text);

            _headers = lines.First().Split(',').ToList();
            _data = lines.Skip(1);
        }

        public void ClearParameters()
        {
            TargetFile = new FileInfo(".");
            SourceFile = new FileInfo(".");
            _customExportFileName = string.Empty;
        }

        public void SetCustomExportFileName(string text)
        {
            _customExportFileName = !string.IsNullOrEmpty(text) ? text + ".sql" : _originalExportFileName;
            TargetFile = GenerateFileInfo(TargetFile.Directory.FullName);
        }

        private FileInfo GenerateFileInfo(string basePath)
        {
            return new FileInfo(Path.Combine(basePath, ExportFileName.Replace(".csv", ".sql")));
        }
    }
}
