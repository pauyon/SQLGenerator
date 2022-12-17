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
            this.SoftwareNameLabel = new System.Windows.Forms.Label();
            this.lblExportGroupBox = new System.Windows.Forms.GroupBox();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.SameAsSourceCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportFileNameLabel = new System.Windows.Forms.Label();
            this.ExportFileNameTxt = new System.Windows.Forms.TextBox();
            this.TargetFileBtn = new System.Windows.Forms.Button();
            this.SourceFileBtn = new System.Windows.Forms.Button();
            this.TargetFileLabel = new System.Windows.Forms.Label();
            this.TargetFileTxt = new System.Windows.Forms.TextBox();
            this.SourceFileLabel = new System.Windows.Forms.Label();
            this.SourceFileTxt = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblCrudActionBox = new System.Windows.Forms.GroupBox();
            this.DeleteRadioBtn = new System.Windows.Forms.RadioButton();
            this.ImportRadioBtn = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblExportGroupBox.SuspendLayout();
            this.lblCrudActionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SoftwareNameLabel
            // 
            this.SoftwareNameLabel.AutoSize = true;
            this.SoftwareNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SoftwareNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoftwareNameLabel.Location = new System.Drawing.Point(218, 9);
            this.SoftwareNameLabel.Name = "SoftwareNameLabel";
            this.SoftwareNameLabel.Size = new System.Drawing.Size(216, 33);
            this.SoftwareNameLabel.TabIndex = 0;
            this.SoftwareNameLabel.Text = "SQLGenerator";
            // 
            // lblExportGroupBox
            // 
            this.lblExportGroupBox.Controls.Add(this.GenerateBtn);
            this.lblExportGroupBox.Controls.Add(this.SameAsSourceCheckBox);
            this.lblExportGroupBox.Controls.Add(this.ExportFileNameLabel);
            this.lblExportGroupBox.Controls.Add(this.ExportFileNameTxt);
            this.lblExportGroupBox.Controls.Add(this.TargetFileBtn);
            this.lblExportGroupBox.Controls.Add(this.SourceFileBtn);
            this.lblExportGroupBox.Controls.Add(this.TargetFileLabel);
            this.lblExportGroupBox.Controls.Add(this.TargetFileTxt);
            this.lblExportGroupBox.Controls.Add(this.SourceFileLabel);
            this.lblExportGroupBox.Controls.Add(this.SourceFileTxt);
            this.lblExportGroupBox.Location = new System.Drawing.Point(19, 183);
            this.lblExportGroupBox.Name = "lblExportGroupBox";
            this.lblExportGroupBox.Size = new System.Drawing.Size(614, 207);
            this.lblExportGroupBox.TabIndex = 10;
            this.lblExportGroupBox.TabStop = false;
            this.lblExportGroupBox.Text = "Export Options";
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Enabled = false;
            this.GenerateBtn.Location = new System.Drawing.Point(269, 170);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(75, 23);
            this.GenerateBtn.TabIndex = 13;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // SameAsSourceCheckBox
            // 
            this.SameAsSourceCheckBox.AutoSize = true;
            this.SameAsSourceCheckBox.Checked = true;
            this.SameAsSourceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SameAsSourceCheckBox.Enabled = false;
            this.SameAsSourceCheckBox.Location = new System.Drawing.Point(74, 108);
            this.SameAsSourceCheckBox.Name = "SameAsSourceCheckBox";
            this.SameAsSourceCheckBox.Size = new System.Drawing.Size(105, 17);
            this.SameAsSourceCheckBox.TabIndex = 19;
            this.SameAsSourceCheckBox.Text = "Same As Source";
            this.SameAsSourceCheckBox.UseVisualStyleBackColor = true;
            this.SameAsSourceCheckBox.Click += new System.EventHandler(this.SameAsSourceCheckBox_CheckedChanged);
            // 
            // ExportFileNameLabel
            // 
            this.ExportFileNameLabel.AutoSize = true;
            this.ExportFileNameLabel.Location = new System.Drawing.Point(334, 103);
            this.ExportFileNameLabel.Name = "ExportFileNameLabel";
            this.ExportFileNameLabel.Size = new System.Drawing.Size(52, 13);
            this.ExportFileNameLabel.TabIndex = 16;
            this.ExportFileNameLabel.Text = "Filename:";
            // 
            // ExportFileNameTxt
            // 
            this.ExportFileNameTxt.Location = new System.Drawing.Point(392, 99);
            this.ExportFileNameTxt.Name = "ExportFileNameTxt";
            this.ExportFileNameTxt.Size = new System.Drawing.Size(134, 20);
            this.ExportFileNameTxt.TabIndex = 14;
            this.ExportFileNameTxt.TextChanged += new System.EventHandler(this.ExportFileNameTxt_TextChanged);
            // 
            // TargetFileBtn
            // 
            this.TargetFileBtn.Enabled = false;
            this.TargetFileBtn.Location = new System.Drawing.Point(532, 123);
            this.TargetFileBtn.Name = "TargetFileBtn";
            this.TargetFileBtn.Size = new System.Drawing.Size(75, 23);
            this.TargetFileBtn.TabIndex = 18;
            this.TargetFileBtn.Text = "Select";
            this.TargetFileBtn.UseVisualStyleBackColor = true;
            this.TargetFileBtn.Click += new System.EventHandler(this.TargetFileBtn_Click);
            // 
            // SourceFileBtn
            // 
            this.SourceFileBtn.Location = new System.Drawing.Point(532, 43);
            this.SourceFileBtn.Name = "SourceFileBtn";
            this.SourceFileBtn.Size = new System.Drawing.Size(75, 23);
            this.SourceFileBtn.TabIndex = 17;
            this.SourceFileBtn.Text = "Select";
            this.SourceFileBtn.UseVisualStyleBackColor = true;
            this.SourceFileBtn.Click += new System.EventHandler(this.SourceFileSelectBtn_Click);
            // 
            // TargetFileLabel
            // 
            this.TargetFileLabel.AutoSize = true;
            this.TargetFileLabel.Location = new System.Drawing.Point(7, 108);
            this.TargetFileLabel.Name = "TargetFileLabel";
            this.TargetFileLabel.Size = new System.Drawing.Size(60, 13);
            this.TargetFileLabel.TabIndex = 15;
            this.TargetFileLabel.Text = "Destination";
            // 
            // TargetFileTxt
            // 
            this.TargetFileTxt.Enabled = false;
            this.TargetFileTxt.Location = new System.Drawing.Point(10, 125);
            this.TargetFileTxt.Name = "TargetFileTxt";
            this.TargetFileTxt.ReadOnly = true;
            this.TargetFileTxt.Size = new System.Drawing.Size(516, 20);
            this.TargetFileTxt.TabIndex = 12;
            // 
            // SourceFileLabel
            // 
            this.SourceFileLabel.AutoSize = true;
            this.SourceFileLabel.Location = new System.Drawing.Point(7, 29);
            this.SourceFileLabel.Name = "SourceFileLabel";
            this.SourceFileLabel.Size = new System.Drawing.Size(60, 13);
            this.SourceFileLabel.TabIndex = 11;
            this.SourceFileLabel.Text = "Source File";
            // 
            // SourceFileTxt
            // 
            this.SourceFileTxt.Location = new System.Drawing.Point(10, 45);
            this.SourceFileTxt.Name = "SourceFileTxt";
            this.SourceFileTxt.ReadOnly = true;
            this.SourceFileTxt.Size = new System.Drawing.Size(516, 20);
            this.SourceFileTxt.TabIndex = 10;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(139, 90);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(134, 20);
            this.txtTableName.TabIndex = 22;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(136, 74);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(65, 13);
            this.lblTableName.TabIndex = 21;
            this.lblTableName.Text = "Table Name";
            // 
            // lblCrudActionBox
            // 
            this.lblCrudActionBox.Controls.Add(this.DeleteRadioBtn);
            this.lblCrudActionBox.Controls.Add(this.ImportRadioBtn);
            this.lblCrudActionBox.Location = new System.Drawing.Point(16, 65);
            this.lblCrudActionBox.Name = "lblCrudActionBox";
            this.lblCrudActionBox.Size = new System.Drawing.Size(109, 100);
            this.lblCrudActionBox.TabIndex = 20;
            this.lblCrudActionBox.TabStop = false;
            this.lblCrudActionBox.Text = "CRUD Action";
            // 
            // DeleteRadioBtn
            // 
            this.DeleteRadioBtn.AutoSize = true;
            this.DeleteRadioBtn.Location = new System.Drawing.Point(7, 43);
            this.DeleteRadioBtn.Name = "DeleteRadioBtn";
            this.DeleteRadioBtn.Size = new System.Drawing.Size(56, 17);
            this.DeleteRadioBtn.TabIndex = 1;
            this.DeleteRadioBtn.Text = "Delete";
            this.DeleteRadioBtn.UseVisualStyleBackColor = true;
            // 
            // ImportRadioBtn
            // 
            this.ImportRadioBtn.AutoSize = true;
            this.ImportRadioBtn.Checked = true;
            this.ImportRadioBtn.Location = new System.Drawing.Point(7, 20);
            this.ImportRadioBtn.Name = "ImportRadioBtn";
            this.ImportRadioBtn.Size = new System.Drawing.Size(56, 17);
            this.ImportRadioBtn.TabIndex = 0;
            this.ImportRadioBtn.TabStop = true;
            this.ImportRadioBtn.Text = "Create";
            this.ImportRadioBtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(579, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // SQLGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.lblExportGroupBox);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.SoftwareNameLabel);
            this.Controls.Add(this.lblCrudActionBox);
            this.Name = "SQLGeneratorForm";
            this.Text = "SQLGenerator";
            this.lblExportGroupBox.ResumeLayout(false);
            this.lblExportGroupBox.PerformLayout();
            this.lblCrudActionBox.ResumeLayout(false);
            this.lblCrudActionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SoftwareNameLabel;
        private System.Windows.Forms.GroupBox lblExportGroupBox;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.CheckBox SameAsSourceCheckBox;
        private System.Windows.Forms.Label ExportFileNameLabel;
        private System.Windows.Forms.TextBox ExportFileNameTxt;
        private System.Windows.Forms.Button TargetFileBtn;
        private System.Windows.Forms.Button SourceFileBtn;
        private System.Windows.Forms.Label TargetFileLabel;
        private System.Windows.Forms.TextBox TargetFileTxt;
        private System.Windows.Forms.Label SourceFileLabel;
        private System.Windows.Forms.TextBox SourceFileTxt;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.GroupBox lblCrudActionBox;
        private System.Windows.Forms.RadioButton DeleteRadioBtn;
        private System.Windows.Forms.RadioButton ImportRadioBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

