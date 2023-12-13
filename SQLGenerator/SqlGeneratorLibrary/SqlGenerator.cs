using System.Collections.Generic;
using System.IO;
using static SQLGeneratorLibrary.Enums;
using System.Linq;

namespace SqlGeneratorLibrary
{
    public class SqlGenerator
    {
        // Store CSV file info
        private List<string> _headers;
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
            var table = tableName ?? "MyTable";
            switch (operation)
            {
                case CrudOperation.Insert:
                    WriteFile(GenerateInsertLines(table));
                    break;

                case CrudOperation.Update:
                    WriteFile(GenerateUpdateLines(table));
                    break;

                case CrudOperation.Delete:
                    WriteFile(GenerateDeleteLines(table));
                    break;

                default:
                    return false;
            }
            return true;
        }

        private IEnumerable<string> GenerateDeleteLines(string table)
        {
            // todo: flesh out this method
            // just figure out what the csv should provide for generating this query
            var lines = new List<string>();
            lines.Add($"DELETE FROM {table} where ??? = ???");
            return lines;
        }

        private IEnumerable<string> GenerateUpdateLines(string table)
        {
            var lines = new List<string>();
            var columnIdIndex = _headers.IndexOf("Id");

            lines.Add($"UPDATE {table}");

            foreach (var row in _data)
            {
                var columns = GetColumnsFormatted(row).ToList();
                var columnValueList = new List<string>();

                var line = "SET ";
                for (int i = 0; i < _headers.Count(); i++)
                {
                    columnValueList.Add($"{_headers[i]}={columns[i]}");
                }

                line += string.Join(", ", columnValueList) + $" WHERE Id = {columns[columnIdIndex]};";
                lines.Add(line);
            }

            return lines;
        }

        private void WriteFile(IEnumerable<string> linesToWrite)
        {
            if (File.Exists(TargetFile.FullName))
            {
                File.Delete(TargetFile.FullName);
            }

            using StreamWriter file = new StreamWriter(TargetFile.FullName, true);
            file.WriteLine("BEGIN TRANSACTION");

            foreach(var line in linesToWrite)
            {
                file.WriteLine(line);
            }

            file.WriteLine("ROLLBACK");
            file.WriteLine("-- COMMIT TRANSACTION");
            file.WriteLine("-- Uncomment line above when ready to execute command indefinitely.");
            file.WriteLine("GO");
        }

        private IEnumerable<string> GenerateInsertLines(string table)
        {
            var lines = new List<string>();

            lines.Add($"INSERT INTO {table}({string.Join(", ", _headers)})");
            lines.Add("SET");

            foreach (var row in _data)
            {
                var columns = GetColumnsFormatted(row);
                lines.Add($"({string.Join(", ", columns)}),");
            }

            return lines;
        }

        private IEnumerable<string> GetColumnsFormatted(string row)
        {
            var formattedColumns = new List<string>();
            var columns = row.Split(',').ToList();

            for (int i = 0; i < columns.Count; i++)
            {
                var isNumeric = int.TryParse(columns[i], out _);

                if (!isNumeric)
                {
                    formattedColumns.Add($"'{columns[i]}'");
                }
                else
                {
                    formattedColumns.Add(columns[i]);
                }
            }

            return formattedColumns;
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
