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
            this.SoftwareNameLabel = new System.Windows.Forms.Label();
            this.ActionGroupBoxLabel = new System.Windows.Forms.GroupBox();
            this.DeleteRadioBtn = new System.Windows.Forms.RadioButton();
            this.ImportRadioBtn = new System.Windows.Forms.RadioButton();
            this.SourceFileTxt = new System.Windows.Forms.TextBox();
            this.FileSelectPanel = new System.Windows.Forms.Panel();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.SameAsSourceCheckBox = new System.Windows.Forms.CheckBox();
            this.TargetFileBtn = new System.Windows.Forms.Button();
            this.SourceFileBtn = new System.Windows.Forms.Button();
            this.TargetFileLabel = new System.Windows.Forms.Label();
            this.TargetFileTxt = new System.Windows.Forms.TextBox();
            this.SourceFileLabel = new System.Windows.Forms.Label();
            this.CommandsPanel = new System.Windows.Forms.Panel();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.ExportFileNameLabel = new System.Windows.Forms.Label();
            this.ExportFileNameTxt = new System.Windows.Forms.TextBox();
            this.ActionGroupBoxLabel.SuspendLayout();
            this.FileSelectPanel.SuspendLayout();
            this.CommandsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SoftwareNameLabel
            // 
            this.SoftwareNameLabel.AutoSize = true;
            this.SoftwareNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SoftwareNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoftwareNameLabel.Location = new System.Drawing.Point(20, 9);
            this.SoftwareNameLabel.Name = "SoftwareNameLabel";
            this.SoftwareNameLabel.Size = new System.Drawing.Size(216, 33);
            this.SoftwareNameLabel.TabIndex = 0;
            this.SoftwareNameLabel.Text = "SQLGenerator";
            // 
            // ActionGroupBoxLabel
            // 
            this.ActionGroupBoxLabel.Controls.Add(this.DeleteRadioBtn);
            this.ActionGroupBoxLabel.Controls.Add(this.ImportRadioBtn);
            this.ActionGroupBoxLabel.Location = new System.Drawing.Point(10, 7);
            this.ActionGroupBoxLabel.Name = "ActionGroupBoxLabel";
            this.ActionGroupBoxLabel.Size = new System.Drawing.Size(109, 100);
            this.ActionGroupBoxLabel.TabIndex = 1;
            this.ActionGroupBoxLabel.TabStop = false;
            this.ActionGroupBoxLabel.Text = "CRUD Action";
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
            this.DeleteRadioBtn.CheckedChanged += new System.EventHandler(this.DeleteRadioBtn_CheckedChanged);
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
            this.ImportRadioBtn.CheckedChanged += new System.EventHandler(this.ImportRadioBtn_CheckedChanged);
            // 
            // SourceFileTxt
            // 
            this.SourceFileTxt.Location = new System.Drawing.Point(10, 28);
            this.SourceFileTxt.Name = "SourceFileTxt";
            this.SourceFileTxt.ReadOnly = true;
            this.SourceFileTxt.Size = new System.Drawing.Size(516, 20);
            this.SourceFileTxt.TabIndex = 3;
            // 
            // FileSelectPanel
            // 
            this.FileSelectPanel.Controls.Add(this.GenerateBtn);
            this.FileSelectPanel.Controls.Add(this.SameAsSourceCheckBox);
            this.FileSelectPanel.Controls.Add(this.TargetFileBtn);
            this.FileSelectPanel.Controls.Add(this.SourceFileBtn);
            this.FileSelectPanel.Controls.Add(this.TargetFileLabel);
            this.FileSelectPanel.Controls.Add(this.TargetFileTxt);
            this.FileSelectPanel.Controls.Add(this.SourceFileLabel);
            this.FileSelectPanel.Controls.Add(this.SourceFileTxt);
            this.FileSelectPanel.Location = new System.Drawing.Point(16, 183);
            this.FileSelectPanel.Name = "FileSelectPanel";
            this.FileSelectPanel.Size = new System.Drawing.Size(614, 159);
            this.FileSelectPanel.TabIndex = 4;
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Enabled = false;
            this.GenerateBtn.Location = new System.Drawing.Point(268, 133);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(75, 23);
            this.GenerateBtn.TabIndex = 6;
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
            this.SameAsSourceCheckBox.Location = new System.Drawing.Point(74, 67);
            this.SameAsSourceCheckBox.Name = "SameAsSourceCheckBox";
            this.SameAsSourceCheckBox.Size = new System.Drawing.Size(105, 17);
            this.SameAsSourceCheckBox.TabIndex = 9;
            this.SameAsSourceCheckBox.Text = "Same As Source";
            this.SameAsSourceCheckBox.UseVisualStyleBackColor = true;
            this.SameAsSourceCheckBox.CheckedChanged += new System.EventHandler(this.SameAsSourceCheckBox_CheckedChanged);
            // 
            // TargetFileBtn
            // 
            this.TargetFileBtn.Enabled = false;
            this.TargetFileBtn.Location = new System.Drawing.Point(532, 82);
            this.TargetFileBtn.Name = "TargetFileBtn";
            this.TargetFileBtn.Size = new System.Drawing.Size(75, 23);
            this.TargetFileBtn.TabIndex = 8;
            this.TargetFileBtn.Text = "Select";
            this.TargetFileBtn.UseVisualStyleBackColor = true;
            this.TargetFileBtn.Click += new System.EventHandler(this.TargetFileBtn_Click);
            // 
            // SourceFileBtn
            // 
            this.SourceFileBtn.Location = new System.Drawing.Point(532, 26);
            this.SourceFileBtn.Name = "SourceFileBtn";
            this.SourceFileBtn.Size = new System.Drawing.Size(75, 23);
            this.SourceFileBtn.TabIndex = 7;
            this.SourceFileBtn.Text = "Select";
            this.SourceFileBtn.UseVisualStyleBackColor = true;
            this.SourceFileBtn.Click += new System.EventHandler(this.SourceFileSelectBtn_Click);
            // 
            // TargetFileLabel
            // 
            this.TargetFileLabel.AutoSize = true;
            this.TargetFileLabel.Location = new System.Drawing.Point(7, 68);
            this.TargetFileLabel.Name = "TargetFileLabel";
            this.TargetFileLabel.Size = new System.Drawing.Size(60, 13);
            this.TargetFileLabel.TabIndex = 6;
            this.TargetFileLabel.Text = "Destination";
            // 
            // TargetFileTxt
            // 
            this.TargetFileTxt.Enabled = false;
            this.TargetFileTxt.Location = new System.Drawing.Point(10, 84);
            this.TargetFileTxt.Name = "TargetFileTxt";
            this.TargetFileTxt.ReadOnly = true;
            this.TargetFileTxt.Size = new System.Drawing.Size(516, 20);
            this.TargetFileTxt.TabIndex = 5;
            // 
            // SourceFileLabel
            // 
            this.SourceFileLabel.AutoSize = true;
            this.SourceFileLabel.Location = new System.Drawing.Point(7, 12);
            this.SourceFileLabel.Name = "SourceFileLabel";
            this.SourceFileLabel.Size = new System.Drawing.Size(60, 13);
            this.SourceFileLabel.TabIndex = 4;
            this.SourceFileLabel.Text = "Source File";
            // 
            // CommandsPanel
            // 
            this.CommandsPanel.Controls.Add(this.txtTableName);
            this.CommandsPanel.Controls.Add(this.lblTableName);
            this.CommandsPanel.Controls.Add(this.ExportFileNameLabel);
            this.CommandsPanel.Controls.Add(this.ExportFileNameTxt);
            this.CommandsPanel.Controls.Add(this.ActionGroupBoxLabel);
            this.CommandsPanel.Location = new System.Drawing.Point(16, 56);
            this.CommandsPanel.Name = "CommandsPanel";
            this.CommandsPanel.Size = new System.Drawing.Size(614, 121);
            this.CommandsPanel.TabIndex = 5;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(133, 32);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(134, 20);
            this.txtTableName.TabIndex = 9;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(130, 16);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(65, 13);
            this.lblTableName.TabIndex = 8;
            this.lblTableName.Text = "Table Name";
            // 
            // ExportFileNameLabel
            // 
            this.ExportFileNameLabel.AutoSize = true;
            this.ExportFileNameLabel.Location = new System.Drawing.Point(130, 67);
            this.ExportFileNameLabel.Name = "ExportFileNameLabel";
            this.ExportFileNameLabel.Size = new System.Drawing.Size(82, 13);
            this.ExportFileNameLabel.TabIndex = 7;
            this.ExportFileNameLabel.Text = "Export Filename";
            // 
            // ExportFileNameTxt
            // 
            this.ExportFileNameTxt.Location = new System.Drawing.Point(133, 83);
            this.ExportFileNameTxt.Name = "ExportFileNameTxt";
            this.ExportFileNameTxt.Size = new System.Drawing.Size(134, 20);
            this.ExportFileNameTxt.TabIndex = 6;
            this.ExportFileNameTxt.TextChanged += new System.EventHandler(this.ExportFileNameTxt_TextChanged);
            // 
            // SQLGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 354);
            this.Controls.Add(this.CommandsPanel);
            this.Controls.Add(this.FileSelectPanel);
            this.Controls.Add(this.SoftwareNameLabel);
            this.Name = "SQLGeneratorForm";
            this.Text = "SQLGenerator";
            this.ActionGroupBoxLabel.ResumeLayout(false);
            this.ActionGroupBoxLabel.PerformLayout();
            this.FileSelectPanel.ResumeLayout(false);
            this.FileSelectPanel.PerformLayout();
            this.CommandsPanel.ResumeLayout(false);
            this.CommandsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SoftwareNameLabel;
        private System.Windows.Forms.GroupBox ActionGroupBoxLabel;
        private System.Windows.Forms.RadioButton DeleteRadioBtn;
        private System.Windows.Forms.RadioButton ImportRadioBtn;
        private System.Windows.Forms.TextBox SourceFileTxt;
        private System.Windows.Forms.Panel FileSelectPanel;
        private System.Windows.Forms.Label TargetFileLabel;
        private System.Windows.Forms.TextBox TargetFileTxt;
        private System.Windows.Forms.Label SourceFileLabel;
        private System.Windows.Forms.Panel CommandsPanel;
        private System.Windows.Forms.Button TargetFileBtn;
        private System.Windows.Forms.Button SourceFileBtn;
        private System.Windows.Forms.CheckBox SameAsSourceCheckBox;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.Label ExportFileNameLabel;
        private System.Windows.Forms.TextBox ExportFileNameTxt;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
    }
}

