using System.Collections.Generic;
using System.IO;
using static SQLGeneratorLibrary.Enums;
using System.Linq;
using System.Runtime.InteropServices;

namespace SqlGeneratorLibrary
{
    public class SqlGenerator
    {
        // Store CSV file info
        private IEnumerable<string> _headers;
        private IEnumerable<string> _data;

        // Keep track of export filename 
        public string? CustomExportFileName { get; private set; } = null;
        public string  OriginalExportFileName { get; private set; } = string.Empty;

        // Holds information on source and target files 
        public FileInfo? TargetFile { get; private set; }
        public FileInfo? SourceFile { get; private set; }

        public string SourcePath
        {
            get
            {
                return SourceFile != null ? SourceFile.FullName : string.Empty;
            }
        }

        public string TargetPath
        {
            get
            {
                return TargetFile != null ? TargetFile.FullName : string.Empty;
            }
        }

        public string ExportFileName
        {
            get
            {
                return string.IsNullOrEmpty(CustomExportFileName) ? OriginalExportFileName : CustomExportFileName;
            }
        }

        public void SetSourceFile(string filePath)
        {
            SourceFile = new FileInfo(filePath);
            OriginalExportFileName = GetCleanSqlFileName(SourceFile.Name);
        }

        public bool WriteSqlFile(CrudOperation operation, string? tableName = null)
        {
            if (File.Exists(TargetFile.FullName))
            {
                File.Delete(TargetFile.FullName);
            }

            var table = tableName ?? "MyTable";

            using StreamWriter file = new StreamWriter(TargetFile.FullName, true);
            switch (operation)
            {
                case CrudOperation.Insert:

                    file.WriteLine("BEGIN TRANSACTION");
                    file.WriteLine($"INSERT INTO {table}({string.Join(", ", _headers)}) VALUES");

                    foreach (var row in _data)
                    {
                        file.WriteLine($"({string.Join(", ", row.Split(',').ToList())}),");
                    }

                    file.WriteLine("ROLLBACK");
                    file.WriteLine("-- COMMIT TRANSACTION");
                    file.WriteLine("-- Uncomment line above when ready to execute command indefinitely.");

                    break;

                case CrudOperation.Delete:
                    file.WriteLine($"DELETE FROM {table} where ??? = ???");
                    break;

                default:
                    return false;
            }

            file.WriteLine("GO");
            return true;
        }

        public void SetTargetFile(string filePath)
        {
            TargetFile = GenerateFileInfo(filePath, ExportFileName);
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
            TargetFile = null;
            SourceFile = null;
            CustomExportFileName = null;
            OriginalExportFileName = string.Empty;
        }

        public void SetCustomExportFileName(string text)
        {
            CustomExportFileName = !string.IsNullOrEmpty(text) ? text : null;

            if (TargetFile != null && !string.IsNullOrEmpty(CustomExportFileName))
            {
                TargetFile = GenerateFileInfo(TargetFile.Directory.FullName, GetCleanSqlFileName(text));
            }
            else if (TargetFile != null)
            {
                    TargetFile = GenerateFileInfo(TargetFile.Directory.FullName, GetCleanSqlFileName(ExportFileName));
            }
        }

        private FileInfo GenerateFileInfo(string basePath, string? customFileName = null)
        {
            if (customFileName != null && customFileName.Trim().Length > 0)
            {
                return new FileInfo(Path.Combine(basePath, GetCleanSqlFileName(customFileName)));
            }

            return new FileInfo(Path.Combine(basePath, GetCleanSqlFileName(ExportFileName)));
        }

        private string GetCleanSqlFileName(string text)
        {
            text = text == string.Empty ? "Export" : text;

            return text.Trim().Replace(".csv", "").Replace(".sql", "") + ".sql";
        }
    }
}
