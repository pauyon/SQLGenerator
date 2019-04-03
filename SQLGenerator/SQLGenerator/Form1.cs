using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLGenerator
{
    public partial class SQLGeneratorForm : Form
    {
        static private string _sourceFileName;
        static private string _sourceFilePath;

        static private string _targetFileName;
        static private string _targetFilePath;

        static private string _customFileName;

        private SoundPlayer _fanfare = new SoundPlayer(SQLGenerator.Properties.Resources.fanfare);

        static private string COMMAND;
        private const string INSERT = "insert";
        private const string DELETE = "delete";

        static private string DATATYPE;
        private const string EMPLOYEES = "employees";
        private const string GLCODES = "glcodes";
        private const string VENDORS = "vendors";

        public SQLGeneratorForm()
        {
            InitializeComponent();

            COMMAND = INSERT;
            DATATYPE = EMPLOYEES;
            _sourceFileName = null;
            _sourceFilePath = null;
            _targetFileName = null;
            _targetFilePath = null;
            _customFileName = null;
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

                    UpdateFields();
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
                _targetFileName = _customFileName ?? _sourceFileName;
                _targetFileName = _targetFileName != null ? _targetFileName.Replace(".csv", ".sql") : _targetFileName;
                UpdateFields();
            }
        }

        private void UpdateFields()
        {
            switch (COMMAND)
            {
                case INSERT:
                    SourceFileBtn.Enabled = true;
                    SourceFileTxt.Enabled = true;
                    
                    SourceFileTxt.Text = _sourceFilePath + _sourceFileName;

                    if (SameAsSourceCheckBox.Checked && !string.IsNullOrEmpty(SourceFileTxt.Text))
                    {
                        TargetFileTxt.Text = _sourceFilePath + (_customFileName ?? _sourceFileName);
                        TargetFileTxt.Text = TargetFileTxt.Text.Replace(".csv", ".sql");
                        SameAsSourceCheckBox.Enabled = true;
                    }
                    else
                    {
                        TargetFileTxt.Text = _targetFilePath + _customFileName ?? _sourceFileName.Replace(".csv", ".sql");

                        if (!string.IsNullOrEmpty(TargetFileTxt.Text))
                        {
                            TargetFileBtn.Enabled = true;
                            TargetFileTxt.Enabled = true;
                            SameAsSourceCheckBox.Enabled = true;

                        }
                        else
                        {
                            TargetFileBtn.Enabled = false;
                            TargetFileTxt.Enabled = false;
                            SameAsSourceCheckBox.Enabled = false;
                        }
                        
                    }

                    if (!string.IsNullOrEmpty(SourceFileTxt.Text) && !string.IsNullOrEmpty(TargetFileTxt.Text))
                        GenerateBtn.Enabled = true;
                    else
                        GenerateBtn.Enabled = false;
                    break;
                case DELETE:
                    SourceFileBtn.Enabled = false;
                    SourceFileTxt.Enabled = false;

                    TargetFileBtn.Enabled = true;
                    TargetFileTxt.Enabled = true;

                    SameAsSourceCheckBox.Enabled = false;

                    SourceFileTxt.Text = null;
                    TargetFileTxt.Text = _targetFilePath + _customFileName ?? "Export.sql";

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
                case INSERT:
                    var data = ReadCSVFile();
                    WriteSQLFile(data);
                    break;

                case DELETE:
                    WriteSQLFile();
                    break;

                default:
                    MessageBox.Show("This command hasn't been programmed yet :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private List<Dictionary<string, string>> ReadCSVFile()
        {
            var data = new List<Dictionary<string, string>>();
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            var lines = File.ReadLines(SourceFileTxt.Text);
            var headers = lines.FirstOrDefault().Split(',');

            foreach (string line in lines.Skip(1))
            {
                int col = 0;
                var cells = CSVParser.Split(line);
                Dictionary<string, string> row = new Dictionary<string, string>();
                foreach (string cell in cells)
                {
                    var cellTrim = Regex.Replace(cell, @",[ \t]+", ", ").Replace("\"", string.Empty).Replace("'", "''").Trim();
                    row.Add(headers[col], cellTrim);
                    col++;
                }
                data.Add(row);
            }

            return data;
        }

        private void ReadExcelFile()
        {
            // need to implement
        }

        private bool WriteSQLFile(List<Dictionary<string, string>> data = null)
        {
            if (File.Exists(TargetFileTxt.Text))
                File.Delete(TargetFileTxt.Text);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(TargetFileTxt.Text, true))
            {
                file.WriteLine("DECLARE @CompanyId varchar(255)");
                file.WriteLine("SET @CompanyId = '" + CompanyIDTxt.Text + "'");

                switch (COMMAND)
                {
                    case INSERT:
                        if (DATATYPE == VENDORS)
                            file.WriteLine("insert into Vendstage([VendName], [companyNo], [VendNo], [Address1], [Address2], [City], [State], [Zip]) values");

                        if (DATATYPE == GLCODES)
                            file.WriteLine("insert into GLACCTSTAGE([CompanyNo], [GLAccount], [Description], [Key]) values");

                        foreach (var row in data)
                        {
                            switch (DATATYPE)
                            {
                                case VENDORS:
                                    file.WriteLine("('" + row["VendorName"] + "', @CompanyId, '" + row["VendorID"] + "', '" + row["Address1"] + "', '" + row["Address 2"] + "', '" + row["City"] + "', '" + row["State"] + "', '" + row["Zip Code"] + "'),");
                                    break;
                                case GLCODES:
                                    file.WriteLine("(@CompanyId, '" + row["AccountNumber"] + "', '" + row["AccountDescription"] + "', NEWID()),");
                                    break;
                            }
                        }
                        break;

                    case DELETE:
                        file.WriteLine("delete from GLACCTSTAGE where companyNo = @CompanyId");
                        break;

                    default:
                        MessageBox.Show("This command hasn't been programmed yet :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }

                if (UpdateSummitCheckBox.Checked)
                {
                    file.WriteLine("Update Companies SET summit_id = @CompanyId Where id = @CompanyId;");
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
                COMMAND = INSERT;
                UpdateFields();
            }
        }

        private void DeleteRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (DeleteRadioBtn.Checked)
            {
                COMMAND = DELETE;
                UpdateFields();
            }
        }

        private void EmployeeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            DATATYPE = EMPLOYEES;
            UpdateFields();
        }

        private void GLCodesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            DATATYPE = GLCODES;
            UpdateFields();
        }

        private void VendorsRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            DATATYPE = VENDORS;
            UpdateFields();
        }

        private void ExportFileNameTxt_TextChanged(object sender, EventArgs e)
        {
            _customFileName = !string.IsNullOrEmpty(ExportFileNameTxt.Text) ? ExportFileNameTxt.Text + ".sql" : null;
            UpdateFields();
        }
    }
}
