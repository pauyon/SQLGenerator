using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Security;
using System.Windows.Forms;
using static SQLGeneratorLibrary.Enums;

namespace SQLGenerator
{
    public partial class SQLGeneratorForm : Form
    {
        // Keep track of export filename 
        private string _customExportFileName = string.Empty;
        private string _originalExportFileName = string.Empty;

        // Holds information on target and source files 
        private FileInfo _targetFile;
        private FileInfo _sourceFile;

        // Additional information
        private List<string> _headers;
        private CrudOperation COMMAND;
        private SoundPlayer _fanfare = new SoundPlayer(Properties.Resources.fanfare);

        public string ExportFileName
        {
            get
            {
                return _customExportFileName ?? _originalExportFileName;
            }
        }

        public SQLGeneratorForm()
        {
            InitializeComponent();
            ClearFields();
        }

        private void btnSourceFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\Desktop",
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
                        _sourceFile = new FileInfo(selectFileDialog.FileName);
                        _originalExportFileName = _sourceFile.Name;

                        _targetFile = GenerateTargetFile(_sourceFile.Directory.FullName);
                        txtTargetFile.Text = _targetFile.FullName;
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

        private void btnTargetFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectFolderDialog = new FolderBrowserDialog();

            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                _targetFile = GenerateTargetFile(selectFolderDialog.SelectedPath);
                txtTargetFile.Text = _targetFile.FullName;

                RefreshFormElements();
            }
        }

        private void RefreshFormElements()
        {
            txtSourceFile.Text = _sourceFile.FullName;
            txtTargetFile.Text = _targetFile.FullName;

            txtExportFileName.Enabled = !string.IsNullOrEmpty(txtTargetFile.Text);

            switch (COMMAND)
            {
                case CrudOperation.Insert:

                    EnableSourceFileFormButton(true);

                    if (chkBoxSameAsSource.Checked && !string.IsNullOrEmpty(txtSourceFile.Text))
                    {
                        chkBoxSameAsSource.Enabled = true;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtTargetFile.Text))
                        {
                            EnableTargetFileFormElements(true);
                            chkBoxSameAsSource.Enabled = true;
                        }
                        else
                        {
                            EnableTargetFileFormElements(false);
                            chkBoxSameAsSource.Enabled = false;
                        }
                    }

                    btnGenerate.Enabled = !string.IsNullOrEmpty(txtSourceFile.Text) &&
                                          !string.IsNullOrEmpty(txtTargetFile.Text);
                    break;

                case CrudOperation.Delete:

                    EnableSourceFileFormButton(false);
                    EnableTargetFileFormElements(true);

                    chkBoxSameAsSource.Enabled = false;
                    txtSourceFile.Text = null;
                    btnGenerate.Enabled = !string.IsNullOrEmpty(txtTargetFile.Text);

                    break;

                default:
                    break;
            }
        }

        private void chkBoxSameAsSource_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSourceFile.Text))
            {
                txtTargetFile.Enabled = !txtTargetFile.Enabled;
                btnTargetFile.Enabled = !btnTargetFile.Enabled;

                _targetFile = GenerateTargetFile(_sourceFile.Directory.FullName);
                txtTargetFile.Text = _targetFile.FullName;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
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
            // Read all CSV lines & store headers
            var lines = File.ReadLines(txtSourceFile.Text);
            _headers = lines.First().Split(',').ToList();

            // Return only data in CSV
            return lines.Skip(1);
        }

        private void WriteSQLFile(IEnumerable<string> data = null)
        {
            if (File.Exists(txtTargetFile.Text))
                File.Delete(txtTargetFile.Text);

            using (StreamWriter file = new StreamWriter(txtTargetFile.Text, true))
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
                        file.WriteLine("-- Uncomment line above when ready to execute command indefinitely.");

                        break;

                    case CrudOperation.Delete:
                        file.WriteLine($"DELETE FROM {txtTableName.Text} where ??? = ???");
                        break;

                    default:
                        MessageBox.Show("This command hasn't been programmed yet :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                file.WriteLine("GO");
            }

            _fanfare.Play();
            MessageBox.Show("Export Successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImportRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (btnImportRadio.Checked)
            {
                COMMAND = CrudOperation.Delete;
                RefreshFormElements();
            }
        }

        private void btnDeleteRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDeleteRadio.Checked)
            {
                COMMAND = CrudOperation.Delete;
                RefreshFormElements();
            }
        }

        private void txtExportFileName_TextChanged(object sender, EventArgs e)
        {
            _customExportFileName = !string.IsNullOrEmpty(txtExportFileName.Text) ? txtExportFileName.Text + ".sql" : _originalExportFileName;
            _targetFile = GenerateTargetFile(_targetFile.Directory.FullName);
            RefreshFormElements();
        }

        private void EnableSourceFileFormButton(bool value)
        {
            btnSourceFile.Enabled = value;
            txtSourceFile.Enabled = value;
        }

        private void EnableTargetFileFormElements(bool value)
        {
            btnTargetFile.Enabled = value;
            txtTargetFile.Enabled = value;
        }

        private void ClearFields()
        {
            _targetFile = new FileInfo(".");
            _sourceFile = new FileInfo(".");
            _customExportFileName = null;
        }

        private FileInfo GenerateTargetFile(string basePath)
        {
            return new FileInfo(Path.Combine(basePath, ExportFileName.Replace(".csv", ".sql")));
        }
    }
}