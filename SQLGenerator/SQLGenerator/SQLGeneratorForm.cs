using SqlGeneratorLibrary;
using System;
using System.Media;
using System.Windows.Forms;
using static SQLGeneratorLibrary.Enums;

namespace SQLGenerator
{
    public partial class SQLGeneratorForm : Form
    {
        private SqlGenerator _sqlGenerator = new SqlGenerator();
        private CrudOperation _operation;
        private SoundPlayer _fanfare = new SoundPlayer(Properties.Resources.fanfare);

        public SQLGeneratorForm()
        {
            InitializeComponent();
        }

        private void btnSourceFileSelect_Click(object sender, EventArgs e)
        {
            var selectFileDialog = Constants.Dialog.SelectFileDialog;
            var dialogResult = selectFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK && selectFileDialog.CheckFileExists)
            {
                _sqlGenerator.SetSourceFile(selectFileDialog.FileName);
                _sqlGenerator.SetTargetFile(_sqlGenerator.SourceFile.Directory.FullName);
                RefreshFormState();
            }
            else if (dialogResult != DialogResult.Cancel)
            {
                MessageBox.Show("There was an issue selecting file", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTargetFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectFolderDialog = new FolderBrowserDialog();

            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                _sqlGenerator.SetTargetFile(selectFolderDialog.SelectedPath);
                RefreshFormState();
            }
        }

        private void RefreshFormState()
        {
            switch (_operation)
            {
                case CrudOperation.Insert:
                case CrudOperation.Update:
                    SetToInsertUpdateMode();
                    break;

                case CrudOperation.Delete:
                    SetToDeleteMode();
                    break;
            }

            // Refresh text fields with paths
            txtSourceFile.Text = _sqlGenerator.SourcePath;
            txtTargetFile.Text = _sqlGenerator.TargetPath;
            txtExportFileName.Text = _sqlGenerator.CustomExportFileName ?? string.Empty;
            txtExportFileName.Enabled = !string.IsNullOrEmpty(txtTargetFile.Text);
        }

        private void SetToInsertUpdateMode()
        {
            EnableSourceFileFormElements();
            EnableTargetFileFormElements(!chkBoxSameAsSource.Checked);
            
            chkBoxSameAsSource.Enabled = _sqlGenerator.SourceFile != null;

            if (_sqlGenerator.SourceFile == null || _sqlGenerator.TargetFile == null)
            {
                _sqlGenerator.SetCustomExportFileName(string.Empty);
            }

            btnGenerate.Enabled = _sqlGenerator.SourceFile != null && 
                                  _sqlGenerator.TargetPath != null;
        }

        private void SetToDeleteMode()
        {
            EnableSourceFileFormElements(false);
            EnableTargetFileFormElements();

            chkBoxSameAsSource.Enabled = false;
            txtExportFileName.Enabled = _sqlGenerator.TargetFile != null;
            
            btnGenerate.Enabled = _sqlGenerator.TargetFile != null;
        }

        private void chkBoxSameAsSource_CheckedChanged(object sender, EventArgs e)
        {
            if (_sqlGenerator.SourceFile != null)
            {
                EnableTargetFileFormElements(!txtTargetFile.Enabled);
                _sqlGenerator.SetTargetFile(_sqlGenerator.SourceFile.Directory.FullName);
                RefreshFormState();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case CrudOperation.Insert:
                case CrudOperation.Update:
                    _sqlGenerator.ReadCsvFile(txtSourceFile.Text);
                    break;
            }

            var tableName = !string.IsNullOrEmpty(txtTableName.Text) ? txtTableName.Text : null;
            var fileWasWritten = _sqlGenerator.WriteSqlFile(_operation, tableName);

            if (!fileWasWritten)
            {
                MessageBox.Show("There was an error exporting file", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            _fanfare.Play();
            MessageBox.Show($"Export Successful!{Environment.NewLine}Location:{Environment.NewLine}{_sqlGenerator.TargetFile.FullName}", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInsertRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (btnInsertRadio.Checked)
            {
                _operation = CrudOperation.Insert;
                _sqlGenerator.ClearParameters();
                RefreshFormState();
            }
        }

        private void btnDeleteRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDeleteRadio.Checked)
            {
                _operation = CrudOperation.Delete;
                _sqlGenerator.ClearParameters();
                RefreshFormState();
            }
        }

        private void txtExportFileName_TextChanged(object sender, EventArgs e)
        {
            _sqlGenerator.SetCustomExportFileName(txtExportFileName.Text);
            txtExportFileName.Text = _sqlGenerator.CustomExportFileName ?? string.Empty;
            txtTargetFile.Text = _sqlGenerator.TargetPath;
        }

        private void EnableSourceFileFormElements(bool value = true)
        {
            btnSourceFile.Enabled = value;
            txtSourceFile.Enabled = value;
        }

        private void EnableTargetFileFormElements(bool value = true)
        {
            btnTargetFile.Enabled = value;
            txtTargetFile.Enabled = value;
        }

        private void btnUpdateRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (btnUpdateRadio.Checked)
            {
                _operation = CrudOperation.Update;
                _sqlGenerator.ClearParameters();
                RefreshFormState();
            }
        }
    }
}