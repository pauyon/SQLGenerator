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

                txtTargetFile.Text = _sqlGenerator.TargetFile.FullName;
                
                RefreshFormElements();
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
                txtTargetFile.Text = _sqlGenerator.TargetFile.FullName;

                RefreshFormElements();
            }
        }

        private void RefreshFormElements()
        {
            txtSourceFile.Text = _sqlGenerator.SourceFile.FullName;
            txtTargetFile.Text = _sqlGenerator.TargetFile.FullName;

            txtExportFileName.Enabled = !string.IsNullOrEmpty(txtTargetFile.Text);

            switch (_operation)
            {
                case CrudOperation.Insert:
                    SetFormToInsertState();
                    break;

                case CrudOperation.Delete:
                    SetFormToDeleteState();
                    break;

                default:
                    break;
            }
        }

        private void SetFormToInsertState()
        {
            EnableSourceFileFormElements(true);
            SetExportSameAsSourceState();

            btnGenerate.Enabled = !string.IsNullOrEmpty(txtSourceFile.Text) && !string.IsNullOrEmpty(txtTargetFile.Text);
        }

        private void SetExportSameAsSourceState()
        {
            if (chkBoxSameAsSource.Checked && !string.IsNullOrEmpty(txtSourceFile.Text))
            {
                chkBoxSameAsSource.Enabled = true;
            }
            else
            {
                var targetFileIsNotEmpty = !string.IsNullOrEmpty(txtTargetFile.Text);

                EnableTargetFileFormElements(targetFileIsNotEmpty);
                chkBoxSameAsSource.Enabled = targetFileIsNotEmpty;
            }
        }

        private void SetFormToDeleteState()
        {
            EnableSourceFileFormElements(false);
            EnableTargetFileFormElements(true);

            chkBoxSameAsSource.Enabled = false;
            txtSourceFile.Text = null;
            btnGenerate.Enabled = !string.IsNullOrEmpty(txtTargetFile.Text);
        }

        private void chkBoxSameAsSource_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSourceFile.Text))
            {
                txtTargetFile.Enabled = !txtTargetFile.Enabled;
                btnTargetFile.Enabled = !btnTargetFile.Enabled;

                _sqlGenerator.SetTargetFile(_sqlGenerator.SourceFile.Directory.FullName);
                txtTargetFile.Text = _sqlGenerator.TargetFile.FullName;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _sqlGenerator.ReadCSVFile(txtSourceFile.Text);

            if (_sqlGenerator.WriteSqlFile(_operation, txtTableName.Text))
            {
                _fanfare.Play();
                MessageBox.Show($"Export Successful!{Environment.NewLine}Location:{Environment.NewLine}{_sqlGenerator.TargetFile.FullName}", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There was an error exporting file", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (btnImportRadio.Checked)
            {
                _operation = CrudOperation.Delete;
                RefreshFormElements();
            }
        }

        private void btnDeleteRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDeleteRadio.Checked)
            {
                _operation = CrudOperation.Delete;
                RefreshFormElements();
            }
        }

        private void txtExportFileName_TextChanged(object sender, EventArgs e)
        {
            _sqlGenerator.SetCustomExportFileName(txtExportFileName.Text);
            RefreshFormElements();
        }

        private void EnableSourceFileFormElements(bool value)
        {
            btnSourceFile.Enabled = value;
            txtSourceFile.Enabled = value;
        }

        private void EnableTargetFileFormElements(bool value)
        {
            btnTargetFile.Enabled = value;
            txtTargetFile.Enabled = value;
        }
    }
}