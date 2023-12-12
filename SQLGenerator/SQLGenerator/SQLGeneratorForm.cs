using SqlGeneratorLibrary;
using System;
using System.Media;
using System.Security;
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

            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (selectFileDialog.CheckFileExists)
                    {
                        _sqlGenerator.SetSourceFile(selectFileDialog.FileName);
                        _sqlGenerator.SetTargetFile(_sqlGenerator.SourceFile.Directory.FullName);

                        txtTargetFile.Text = _sqlGenerator.TargetFile.FullName;
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
                MessageBox.Show("Export Successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This command hasn't been programmed yet :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _sqlGenerator.SetTargetFile(_sqlGenerator.TargetFile.Directory.FullName);
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
    }
}