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

        /// <summary>
        /// Sets the source file.
        /// </summary>
        /// <param name="filePath">Full path of source file.</param>
        public void SetSourceFile(string filePath)
        {
            SourceFile = new FileInfo(filePath);
            OriginalExportFileName = GetCleanSqlFileName(SourceFile.Name);
        }

        /// <summary>
        /// Generates file contents and writes to file.
        /// </summary>
        /// <param name="operation">Operation to denote the type of sql script to write.</param>
        /// <param name="table">Name of db table to insert data to.</param>
        /// <returns>A bool indicating the writing was successful (true) or not (false).</returns>
        public bool WriteSqlFile(CrudOperation operation, string? tableName = null)
        {
            var table = tableName ?? "MyTable";
            switch (operation)
            {
                case CrudOperation.Insert:
                    WriteFile(GenerateInsertLines(table));
                    break;

                case CrudOperation.Update:
                    WriteFile(GetUpdateScriptContents(table));
                    break;

                case CrudOperation.Delete:
                    WriteFile(GetDeleteScriptContents(table));
                    break;

                default:
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Gets a list of lines representing the contents of a delete file.
        /// </summary>
        /// <param name="table">Name of db table to insert data to.</param>
        /// <returns>All line contents of the delete script to write.</returns>
        private IEnumerable<string> GetDeleteScriptContents(string table)
        {
            // todo: flesh out this method
            // just figure out what the csv should provide for generating this query
            var lines = new List<string>();
            lines.Add($"DELETE FROM {table} where ??? = ???");
            return lines;
        }

        /// <summary>
        /// Gets a list of lines representing the contents of an update file.
        /// </summary>
        /// <param name="table">Name of db table to insert data to.</param>
        /// <returns>All line contents of the update script to write.</returns>
        private IEnumerable<string> GetUpdateScriptContents(string table)
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

        /// <summary>
        /// Writes a list of string representing contents of file to a file.
        /// </summary>
        /// <param name="linesToWrite">List of rows to write to file.</param>
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

        /// <summary>
        /// Gets a list of lines representing the contents of an insert file.
        /// </summary>
        /// <param name="table">Name of db table to insert data to.</param>
        /// <returns>All line contents of the insert script to write.</returns>
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

        /// <summary>
        /// Returns a row of formatted data.
        /// Non-numeric values are surrounded with single quotes.
        /// </summary>
        /// <param name="row">String value of csv file row.</param>
        /// <returns>List of values where non-numeric values are surrounded with single quotes.</returns>
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

        /// <summary>
        /// Sets the target file. Will use the same name as source file for export file name.
        /// Otherwise, it will use the custom filename if available.
        /// </summary>
        /// <param name="filePath">Path of target file.</param>
        public void SetTargetFile(string filePath)
        {
            TargetFile = GenerateFileInfo(filePath, ExportFileName);
        }

        /// <summary>
        /// Read and store csv header and rows.
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        public void ReadCSVFile(string filePath)
        {
            // Read all CSV lines & store headers
            var lines = File.ReadLines(filePath);

            _headers = lines.First().Split(',').ToList();
            _data = lines.Skip(1);
        }

        /// <summary>
        /// Resets all file properties.
        /// </summary>
        public void ClearParameters()
        {
            TargetFile = null;
            SourceFile = null;
            CustomExportFileName = null;
            OriginalExportFileName = string.Empty;
        }

        /// <summary>
        /// Sets the custom filename for export. Will default to original file if filename is empty.
        /// </summary>
        /// <param name="customFilename">Custom filename to use for export.</param>
        public void SetCustomExportFileName(string customFilename)
        {
            CustomExportFileName = !string.IsNullOrEmpty(customFilename) ? customFilename : null;

            if (TargetFile != null && !string.IsNullOrEmpty(CustomExportFileName))
            {
                TargetFile = GenerateFileInfo(TargetFile.Directory.FullName, GetCleanSqlFileName(customFilename));
            }
            else if (TargetFile != null)
            {
                    TargetFile = GenerateFileInfo(TargetFile.Directory.FullName, GetCleanSqlFileName(ExportFileName));
            }
        }

        /// <summary>
        /// Gets a new instance of FileInfo.
        /// Will use Source file name if no custom filename is used.
        /// </summary>
        /// <param name="basePath">Base path of file</param>
        /// <param name="customFileName">Custom filename</param>
        /// <returns></returns>
        private FileInfo GenerateFileInfo(string basePath, string? customFileName = null)
        {
            if (customFileName != null && customFileName.Trim().Length > 0)
            {
                return new FileInfo(Path.Combine(basePath, GetCleanSqlFileName(customFileName)));
            }

            return new FileInfo(Path.Combine(basePath, GetCleanSqlFileName(ExportFileName)));
        }

        /// <summary>
        /// Format string with the extension ".sql"
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        /// <returns>Filename with ".sql" extension.</returns>
        private string GetCleanSqlFileName(string filename)
        {
            filename = filename == string.Empty ? "Export" : filename;

            return filename.Trim().Replace(".csv", "").Replace(".sql", "") + ".sql";
        }
    }
}
