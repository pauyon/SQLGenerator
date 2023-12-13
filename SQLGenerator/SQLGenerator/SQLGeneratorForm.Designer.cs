namespace SQLGenerator
{
    partial class SQLGeneratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLGeneratorForm));
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblExportGroupBox = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkBoxSameAsSource = new System.Windows.Forms.CheckBox();
            this.lblExportFileName = new System.Windows.Forms.Label();
            this.txtExportFileName = new System.Windows.Forms.TextBox();
            this.btnTargetFile = new System.Windows.Forms.Button();
            this.btnSourceFile = new System.Windows.Forms.Button();
            this.lblTargetFile = new System.Windows.Forms.Label();
            this.txtTargetFile = new System.Windows.Forms.TextBox();
            this.lblSourceFile = new System.Windows.Forms.Label();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblCrudActionBox = new System.Windows.Forms.GroupBox();
            this.btnDeleteRadio = new System.Windows.Forms.RadioButton();
            this.btnImportRadio = new System.Windows.Forms.RadioButton();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.lblExportGroupBox.SuspendLayout();
            this.lblCrudActionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.Location = new System.Drawing.Point(291, 11);
            this.lblAppTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(273, 42);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "SQLGenerator";
            // 
            // lblExportGroupBox
            // 
            this.lblExportGroupBox.Controls.Add(this.btnGenerate);
            this.lblExportGroupBox.Controls.Add(this.chkBoxSameAsSource);
            this.lblExportGroupBox.Controls.Add(this.lblExportFileName);
            this.lblExportGroupBox.Controls.Add(this.txtExportFileName);
            this.lblExportGroupBox.Controls.Add(this.btnTargetFile);
            this.lblExportGroupBox.Controls.Add(this.btnSourceFile);
            this.lblExportGroupBox.Controls.Add(this.lblTargetFile);
            this.lblExportGroupBox.Controls.Add(this.txtTargetFile);
            this.lblExportGroupBox.Controls.Add(this.lblSourceFile);
            this.lblExportGroupBox.Controls.Add(this.txtSourceFile);
            this.lblExportGroupBox.Location = new System.Drawing.Point(25, 225);
            this.lblExportGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblExportGroupBox.Name = "lblExportGroupBox";
            this.lblExportGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblExportGroupBox.Size = new System.Drawing.Size(819, 255);
            this.lblExportGroupBox.TabIndex = 10;
            this.lblExportGroupBox.TabStop = false;
            this.lblExportGroupBox.Text = "Export Options";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(359, 209);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 28);
            this.btnGenerate.TabIndex = 13;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkBoxSameAsSource
            // 
            this.chkBoxSameAsSource.AutoSize = true;
            this.chkBoxSameAsSource.Checked = true;
            this.chkBoxSameAsSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxSameAsSource.Enabled = false;
            this.chkBoxSameAsSource.Location = new System.Drawing.Point(99, 133);
            this.chkBoxSameAsSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBoxSameAsSource.Name = "chkBoxSameAsSource";
            this.chkBoxSameAsSource.Size = new System.Drawing.Size(130, 20);
            this.chkBoxSameAsSource.TabIndex = 19;
            this.chkBoxSameAsSource.Text = "Same As Source";
            this.chkBoxSameAsSource.UseVisualStyleBackColor = true;
            this.chkBoxSameAsSource.CheckedChanged += new System.EventHandler(this.chkBoxSameAsSource_CheckedChanged);
            // 
            // lblExportFileName
            // 
            this.lblExportFileName.AutoSize = true;
            this.lblExportFileName.Location = new System.Drawing.Point(445, 127);
            this.lblExportFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExportFileName.Name = "lblExportFileName";
            this.lblExportFileName.Size = new System.Drawing.Size(66, 16);
            this.lblExportFileName.TabIndex = 16;
            this.lblExportFileName.Text = "Filename:";
            // 
            // txtExportFileName
            // 
            this.txtExportFileName.Enabled = false;
            this.txtExportFileName.Location = new System.Drawing.Point(523, 122);
            this.txtExportFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExportFileName.Name = "txtExportFileName";
            this.txtExportFileName.Size = new System.Drawing.Size(177, 22);
            this.txtExportFileName.TabIndex = 14;
            this.txtExportFileName.TextChanged += new System.EventHandler(this.txtExportFileName_TextChanged);
            // 
            // btnTargetFile
            // 
            this.btnTargetFile.Enabled = false;
            this.btnTargetFile.Location = new System.Drawing.Point(709, 151);
            this.btnTargetFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTargetFile.Name = "btnTargetFile";
            this.btnTargetFile.Size = new System.Drawing.Size(100, 28);
            this.btnTargetFile.TabIndex = 18;
            this.btnTargetFile.Text = "Select";
            this.btnTargetFile.UseVisualStyleBackColor = true;
            this.btnTargetFile.Click += new System.EventHandler(this.btnTargetFile_Click);
            // 
            // btnSourceFile
            // 
            this.btnSourceFile.Location = new System.Drawing.Point(709, 53);
            this.btnSourceFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSourceFile.Name = "btnSourceFile";
            this.btnSourceFile.Size = new System.Drawing.Size(100, 28);
            this.btnSourceFile.TabIndex = 17;
            this.btnSourceFile.Text = "Select";
            this.btnSourceFile.UseVisualStyleBackColor = true;
            this.btnSourceFile.Click += new System.EventHandler(this.btnSourceFileSelect_Click);
            // 
            // lblTargetFile
            // 
            this.lblTargetFile.AutoSize = true;
            this.lblTargetFile.Location = new System.Drawing.Point(9, 133);
            this.lblTargetFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetFile.Name = "lblTargetFile";
            this.lblTargetFile.Size = new System.Drawing.Size(74, 16);
            this.lblTargetFile.TabIndex = 15;
            this.lblTargetFile.Text = "Destination";
            // 
            // txtTargetFile
            // 
            this.txtTargetFile.Enabled = false;
            this.txtTargetFile.Location = new System.Drawing.Point(13, 154);
            this.txtTargetFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTargetFile.Name = "txtTargetFile";
            this.txtTargetFile.ReadOnly = true;
            this.txtTargetFile.Size = new System.Drawing.Size(687, 22);
            this.txtTargetFile.TabIndex = 12;
            // 
            // lblSourceFile
            // 
            this.lblSourceFile.AutoSize = true;
            this.lblSourceFile.Location = new System.Drawing.Point(9, 36);
            this.lblSourceFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSourceFile.Name = "lblSourceFile";
            this.lblSourceFile.Size = new System.Drawing.Size(75, 16);
            this.lblSourceFile.TabIndex = 11;
            this.lblSourceFile.Text = "Source File";
            // 
            // txtSourceFile
            // 
            this.txtSourceFile.Location = new System.Drawing.Point(13, 55);
            this.txtSourceFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.ReadOnly = true;
            this.txtSourceFile.Size = new System.Drawing.Size(687, 22);
            this.txtSourceFile.TabIndex = 10;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(185, 111);
            this.txtTableName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(177, 22);
            this.txtTableName.TabIndex = 22;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(181, 91);
            this.lblTableName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(83, 16);
            this.lblTableName.TabIndex = 21;
            this.lblTableName.Text = "Table Name";
            // 
            // lblCrudActionBox
            // 
            this.lblCrudActionBox.Controls.Add(this.btnDeleteRadio);
            this.lblCrudActionBox.Controls.Add(this.btnImportRadio);
            this.lblCrudActionBox.Location = new System.Drawing.Point(21, 80);
            this.lblCrudActionBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCrudActionBox.Name = "lblCrudActionBox";
            this.lblCrudActionBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCrudActionBox.Size = new System.Drawing.Size(145, 123);
            this.lblCrudActionBox.TabIndex = 20;
            this.lblCrudActionBox.TabStop = false;
            this.lblCrudActionBox.Text = "Action";
            // 
            // btnDeleteRadio
            // 
            this.btnDeleteRadio.AutoSize = true;
            this.btnDeleteRadio.Location = new System.Drawing.Point(9, 53);
            this.btnDeleteRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteRadio.Name = "btnDeleteRadio";
            this.btnDeleteRadio.Size = new System.Drawing.Size(68, 20);
            this.btnDeleteRadio.TabIndex = 1;
            this.btnDeleteRadio.Text = "Delete";
            this.btnDeleteRadio.UseVisualStyleBackColor = true;
            // 
            // btnImportRadio
            // 
            this.btnImportRadio.AutoSize = true;
            this.btnImportRadio.Checked = true;
            this.btnImportRadio.Location = new System.Drawing.Point(9, 25);
            this.btnImportRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImportRadio.Name = "btnImportRadio";
            this.btnImportRadio.Size = new System.Drawing.Size(75, 25);
            this.btnImportRadio.TabIndex = 0;
            this.btnImportRadio.TabStop = true;
            this.btnImportRadio.Text = "Insert";
            this.btnImportRadio.UseVisualStyleBackColor = true;
            // 
            // imgLogo
            // 
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgLogo.InitialImage")));
            this.imgLogo.Location = new System.Drawing.Point(772, 11);
            this.imgLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(79, 64);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 23;
            this.imgLogo.TabStop = false;
            // 
            // SQLGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 495);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.lblExportGroupBox);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.lblAppTitle);
            this.Controls.Add(this.lblCrudActionBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SQLGeneratorForm";
            this.Text = "SQLGenerator";
            this.lblExportGroupBox.ResumeLayout(false);
            this.lblExportGroupBox.PerformLayout();
            this.lblCrudActionBox.ResumeLayout(false);
            this.lblCrudActionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.GroupBox lblExportGroupBox;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkBoxSameAsSource;
        private System.Windows.Forms.Label lblExportFileName;
        private System.Windows.Forms.TextBox txtExportFileName;
        private System.Windows.Forms.Button btnTargetFile;
        private System.Windows.Forms.Button btnSourceFile;
        private System.Windows.Forms.Label lblTargetFile;
        private System.Windows.Forms.TextBox txtTargetFile;
        private System.Windows.Forms.Label lblSourceFile;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.GroupBox lblCrudActionBox;
        private System.Windows.Forms.RadioButton btnDeleteRadio;
        private System.Windows.Forms.RadioButton btnImportRadio;
        private System.Windows.Forms.PictureBox imgLogo;
    }
}

