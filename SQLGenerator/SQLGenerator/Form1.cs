using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SQLGenerator.Enums;

namespace SQLGenerator
{
    public partial class SQLGeneratorForm : Form
    {
        // Import file fields
        private static string _targetFileName;
        private static string _targetFilePath;

        // Export file fields
        private static string _sourceFileName;
        private static string _sourceFilePath;

        private static List<string> _headers;

        private string _customExportFileName;
        private CrudOperation COMMAND;

        private SoundPlayer _fanfare = new SoundPlayer(Properties.Resources.fanfare);

        public SQLGeneratorForm()
        {
            InitializeComponent();
            ClearFields();
        }

        private void SourceFileSelectBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = "CSV Files (*.csv)|*.csv",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (selectFileDialog.CheckFileExists)
                    {
                        var filePath = selectFileDialog.FileName;
                        var fileName = selectFileDialog.SafeFileName;

                        _sourceFileName = fileName;
                        _sourceFilePath = filePath.Replace(fileName, "");
                    }

                    RefreshFormElements();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void TargetFileBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectFolderDialog = new FolderBrowserDialog();

            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                _targetFilePath = selectFolderDialog.SelectedPath + @"\";
                _targetFileName = _customExportFileName ?? _sourceFileName;
                _targetFileName = _targetFileName != null ? _targetFileName.Replace(".csv", ".sql") : _targetFileName;
                RefreshFormElements();
            }
        }

        private void RefreshFormElements()
        {
            switch (COMMAND)
            {
                case CrudOperation.Insert:

                    EnableSourceFileFormButton(true);
                    SourceFileTxt.Text = _sourceFilePath + _sourceFileName;

                    if (SameAsSourceCheckBox.Checked && !string.IsNullOrEmpty(SourceFileTxt.Text))
                    {
                        TargetFileTxt.Text = _sourceFilePath + (_customExportFileName ?? _sourceFileName);
                        TargetFileTxt.Text = TargetFileTxt.Text.Replace(".csv", ".sql");
                        SameAsSourceCheckBox.Enabled = true;
                    }
                    else
                    {
                        TargetFileTxt.Text = _targetFilePath + _customExportFileName ?? _sourceFileName.Replace(".csv", ".sql");

                        if (!string.IsNullOrEmpty(TargetFileTxt.Text))
                        {
                            EnableTargetFileFormElements(true);
                            SameAsSourceCheckBox.Enabled = true;
                        }
                        else
                        {
                            EnableTargetFileFormElements(false);
                            SameAsSourceCheckBox.Enabled = false;
                        }

                    }

                    GenerateBtn.Enabled = !string.IsNullOrEmpty(SourceFileTxt.Text) &&
                                          !string.IsNullOrEmpty(TargetFileTxt.Text);
                    break;

                case CrudOperation.Delete:

                    EnableSourceFileFormButton(false);
                    EnableTargetFileFormElements(true);

                    SameAsSourceCheckBox.Enabled = false;

                    SourceFileTxt.Text = null;
                    TargetFileTxt.Text = _targetFilePath + _customExportFileName ?? "Export.sql";

                    if (!string.IsNullOrEmpty(TargetFileTxt.Text))
                        GenerateBtn.Enabled = true;
                    else
                        GenerateBtn.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void SameAsSourceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SourceFileTxt.Text))
            {
                TargetFileTxt.Enabled = !TargetFileTxt.Enabled;
                TargetFileBtn.Enabled = !TargetFileBtn.Enabled;
                TargetFileTxt.Text = SourceFileTxt.Text.Replace(".csv", ".sql");
            }
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            switch (COMMAND)
            {
                case CrudOperation.Insert:
                    var data = ReadCSVFileAndReturnData();
                    WriteSQLFile(data);
                    break;

                case CrudOperation.Delete:
                    WriteSQLFile();
                    break;

                default:
                    MessageBox.Show("This command hasn't been programmed yet :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private IEnumerable<string> ReadCSVFileAndReturnData()
        {
            // Prep CSV reader
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            // Read all CSV lines & store headers
            var lines = File.ReadLines(SourceFileTxt.Text);
            _headers = lines.FirstOrDefault().Split(',').ToList();

            // Return data in csv
            return lines.Skip(1);
        }

        private bool WriteSQLFile(IEnumerable<string> data = null)
        {
            if (File.Exists(TargetFileTxt.Text))
                File.Delete(TargetFileTxt.Text);

            using (StreamWriter file = new StreamWriter(TargetFileTxt.Text, true))
            {
                switch (COMMAND)
                {
                    case CrudOperation.Insert:

                        file.WriteLine("BEGIN TRANSACTION");
                        file.WriteLine($"INSERT INTO {txtTableName.Text}({string.Join(", ", _headers)}) VALUES");

                        foreach (var row in data)
                        {
                            file.WriteLine($"({string.Join(", ", row.Split(',').ToList())}),");
                        }

                        file.WriteLine("ROLLBACK");
                        file.WriteLine("-- COMMIT TRANSACTION");

                        break;

                    case CrudOperation.Delete:
                        file.WriteLine($"DELETE FROM {txtTableName.Text} where ??? = ???");
                        break;

                    default:
                        MessageBox.Show("This command hasn't been programmed yet :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }

                file.WriteLine("GO");
            }

            _fanfare.Play();
            MessageBox.Show("Export Successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void ImportRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (ImportRadioBtn.Checked)
            {
                COMMAND = CrudOperation.Delete;
                RefreshFormElements();
            }
        }

        private void DeleteRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (DeleteRadioBtn.Checked)
            {
                COMMAND = CrudOperation.Delete;
                RefreshFormElements();
            }
        }

        private void ExportFileNameTxt_TextChanged(object sender, EventArgs e)
        {
            _customExportFileName = !string.IsNullOrEmpty(ExportFileNameTxt.Text) ? ExportFileNameTxt.Text + ".sql" : null;
            RefreshFormElements();
        }

        private void EnableSourceFileFormButton(bool value)
        {
            SourceFileBtn.Enabled = value;
            SourceFileTxt.Enabled = value;
        }

        private void EnableTargetFileFormElements(bool value)
        {
            TargetFileBtn.Enabled = value;
            TargetFileTxt.Enabled = value;
        }

        private void ClearFields()
        {
            _sourceFileName = null;
            _sourceFilePath = null;
            _targetFileName = null;
            _targetFilePath = null;
            _customExportFileName = null;
        }
    }
}
