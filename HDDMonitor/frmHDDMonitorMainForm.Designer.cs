namespace HDDMonitor
{
    partial class frmHDDMonitorMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHDDMonitorMainForm));
            this.lblOnFileChange = new System.Windows.Forms.Label();
            this.lblMainFormDescription = new System.Windows.Forms.Label();
            this.txtFileChangeLetter = new System.Windows.Forms.TextBox();
            this.lblIconLetterChange = new System.Windows.Forms.Label();
            this.lblOnFileDelete = new System.Windows.Forms.Label();
            this.lblIconLetterDelete = new System.Windows.Forms.Label();
            this.txtFileDeleteLetter = new System.Windows.Forms.TextBox();
            this.lblIconLetterCreate = new System.Windows.Forms.Label();
            this.txtFileCreateLetter = new System.Windows.Forms.TextBox();
            this.lblOnFileCreate = new System.Windows.Forms.Label();
            this.lblIconLetterRename = new System.Windows.Forms.Label();
            this.txtFileRenameLetter = new System.Windows.Forms.TextBox();
            this.lblOnFileRename = new System.Windows.Forms.Label();
            this.lblIconLetterInactivity = new System.Windows.Forms.Label();
            this.txtInactivityLetter = new System.Windows.Forms.TextBox();
            this.lblOnInactivity = new System.Windows.Forms.Label();
            this.lblCurrentCreateIcon = new System.Windows.Forms.Label();
            this.lblCurrentChangeIcon = new System.Windows.Forms.Label();
            this.lblCurrentDeleteIcon = new System.Windows.Forms.Label();
            this.lblCurrentRenameIcon = new System.Windows.Forms.Label();
            this.lblCurrentInactivityIcon = new System.Windows.Forms.Label();
            this.picCurrentFileCreateIcon = new System.Windows.Forms.PictureBox();
            this.picCurrentFileChangedIcon = new System.Windows.Forms.PictureBox();
            this.picCurrentFileDeleteIcon = new System.Windows.Forms.PictureBox();
            this.picCurrentFileRenameIcon = new System.Windows.Forms.PictureBox();
            this.picCurrentFileInactivityIcon = new System.Windows.Forms.PictureBox();
            this.lblWatchDirectory = new System.Windows.Forms.Label();
            this.txtWatchPath = new System.Windows.Forms.TextBox();
            this.lblBadPathErr = new System.Windows.Forms.Label();
            this.lblBadPathErrMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileCreateIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileChangedIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileDeleteIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileRenameIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileInactivityIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOnFileChange
            // 
            this.lblOnFileChange.AutoSize = true;
            this.lblOnFileChange.Location = new System.Drawing.Point(12, 116);
            this.lblOnFileChange.Name = "lblOnFileChange";
            this.lblOnFileChange.Size = new System.Drawing.Size(83, 13);
            this.lblOnFileChange.TabIndex = 1;
            this.lblOnFileChange.Text = "On File Change:";
            // 
            // lblMainFormDescription
            // 
            this.lblMainFormDescription.Location = new System.Drawing.Point(12, 9);
            this.lblMainFormDescription.Name = "lblMainFormDescription";
            this.lblMainFormDescription.Size = new System.Drawing.Size(310, 42);
            this.lblMainFormDescription.TabIndex = 2;
            this.lblMainFormDescription.Text = "Each of the options corresponds to the icon in the system tray. Whatever letter y" +
    "ou type in the (Letter) box will be the new icon for that action.";
            // 
            // txtFileChangeLetter
            // 
            this.txtFileChangeLetter.Location = new System.Drawing.Point(173, 113);
            this.txtFileChangeLetter.MaxLength = 1;
            this.txtFileChangeLetter.Name = "txtFileChangeLetter";
            this.txtFileChangeLetter.Size = new System.Drawing.Size(25, 20);
            this.txtFileChangeLetter.TabIndex = 2;
            // 
            // lblIconLetterChange
            // 
            this.lblIconLetterChange.AutoSize = true;
            this.lblIconLetterChange.Location = new System.Drawing.Point(103, 116);
            this.lblIconLetterChange.Name = "lblIconLetterChange";
            this.lblIconLetterChange.Size = new System.Drawing.Size(64, 13);
            this.lblIconLetterChange.TabIndex = 4;
            this.lblIconLetterChange.Text = "Icon (Letter)";
            // 
            // lblOnFileDelete
            // 
            this.lblOnFileDelete.AutoSize = true;
            this.lblOnFileDelete.Location = new System.Drawing.Point(12, 142);
            this.lblOnFileDelete.Name = "lblOnFileDelete";
            this.lblOnFileDelete.Size = new System.Drawing.Size(77, 13);
            this.lblOnFileDelete.TabIndex = 5;
            this.lblOnFileDelete.Text = "On File Delete:";
            // 
            // lblIconLetterDelete
            // 
            this.lblIconLetterDelete.AutoSize = true;
            this.lblIconLetterDelete.Location = new System.Drawing.Point(103, 142);
            this.lblIconLetterDelete.Name = "lblIconLetterDelete";
            this.lblIconLetterDelete.Size = new System.Drawing.Size(64, 13);
            this.lblIconLetterDelete.TabIndex = 7;
            this.lblIconLetterDelete.Text = "Icon (Letter)";
            // 
            // txtFileDeleteLetter
            // 
            this.txtFileDeleteLetter.Location = new System.Drawing.Point(173, 139);
            this.txtFileDeleteLetter.MaxLength = 1;
            this.txtFileDeleteLetter.Name = "txtFileDeleteLetter";
            this.txtFileDeleteLetter.Size = new System.Drawing.Size(25, 20);
            this.txtFileDeleteLetter.TabIndex = 3;
            // 
            // lblIconLetterCreate
            // 
            this.lblIconLetterCreate.AutoSize = true;
            this.lblIconLetterCreate.Location = new System.Drawing.Point(103, 90);
            this.lblIconLetterCreate.Name = "lblIconLetterCreate";
            this.lblIconLetterCreate.Size = new System.Drawing.Size(64, 13);
            this.lblIconLetterCreate.TabIndex = 10;
            this.lblIconLetterCreate.Text = "Icon (Letter)";
            // 
            // txtFileCreateLetter
            // 
            this.txtFileCreateLetter.Location = new System.Drawing.Point(173, 87);
            this.txtFileCreateLetter.MaxLength = 1;
            this.txtFileCreateLetter.Name = "txtFileCreateLetter";
            this.txtFileCreateLetter.Size = new System.Drawing.Size(25, 20);
            this.txtFileCreateLetter.TabIndex = 1;
            // 
            // lblOnFileCreate
            // 
            this.lblOnFileCreate.AutoSize = true;
            this.lblOnFileCreate.Location = new System.Drawing.Point(12, 90);
            this.lblOnFileCreate.Name = "lblOnFileCreate";
            this.lblOnFileCreate.Size = new System.Drawing.Size(77, 13);
            this.lblOnFileCreate.TabIndex = 8;
            this.lblOnFileCreate.Text = "On File Create:";
            // 
            // lblIconLetterRename
            // 
            this.lblIconLetterRename.AutoSize = true;
            this.lblIconLetterRename.Location = new System.Drawing.Point(103, 168);
            this.lblIconLetterRename.Name = "lblIconLetterRename";
            this.lblIconLetterRename.Size = new System.Drawing.Size(64, 13);
            this.lblIconLetterRename.TabIndex = 13;
            this.lblIconLetterRename.Text = "Icon (Letter)";
            // 
            // txtFileRenameLetter
            // 
            this.txtFileRenameLetter.Location = new System.Drawing.Point(173, 165);
            this.txtFileRenameLetter.MaxLength = 1;
            this.txtFileRenameLetter.Name = "txtFileRenameLetter";
            this.txtFileRenameLetter.Size = new System.Drawing.Size(25, 20);
            this.txtFileRenameLetter.TabIndex = 4;
            // 
            // lblOnFileRename
            // 
            this.lblOnFileRename.AutoSize = true;
            this.lblOnFileRename.Location = new System.Drawing.Point(12, 168);
            this.lblOnFileRename.Name = "lblOnFileRename";
            this.lblOnFileRename.Size = new System.Drawing.Size(86, 13);
            this.lblOnFileRename.TabIndex = 11;
            this.lblOnFileRename.Text = "On File Rename:";
            // 
            // lblIconLetterInactivity
            // 
            this.lblIconLetterInactivity.AutoSize = true;
            this.lblIconLetterInactivity.Location = new System.Drawing.Point(103, 194);
            this.lblIconLetterInactivity.Name = "lblIconLetterInactivity";
            this.lblIconLetterInactivity.Size = new System.Drawing.Size(64, 13);
            this.lblIconLetterInactivity.TabIndex = 16;
            this.lblIconLetterInactivity.Text = "Icon (Letter)";
            // 
            // txtInactivityLetter
            // 
            this.txtInactivityLetter.Location = new System.Drawing.Point(173, 191);
            this.txtInactivityLetter.MaxLength = 1;
            this.txtInactivityLetter.Name = "txtInactivityLetter";
            this.txtInactivityLetter.Size = new System.Drawing.Size(25, 20);
            this.txtInactivityLetter.TabIndex = 5;
            // 
            // lblOnInactivity
            // 
            this.lblOnInactivity.AutoSize = true;
            this.lblOnInactivity.Location = new System.Drawing.Point(12, 194);
            this.lblOnInactivity.Name = "lblOnInactivity";
            this.lblOnInactivity.Size = new System.Drawing.Size(69, 13);
            this.lblOnInactivity.TabIndex = 15;
            this.lblOnInactivity.Text = "On Inactivity:";
            // 
            // lblCurrentCreateIcon
            // 
            this.lblCurrentCreateIcon.AutoSize = true;
            this.lblCurrentCreateIcon.Location = new System.Drawing.Point(204, 90);
            this.lblCurrentCreateIcon.Name = "lblCurrentCreateIcon";
            this.lblCurrentCreateIcon.Size = new System.Drawing.Size(44, 13);
            this.lblCurrentCreateIcon.TabIndex = 17;
            this.lblCurrentCreateIcon.Text = "Current:";
            // 
            // lblCurrentChangeIcon
            // 
            this.lblCurrentChangeIcon.AutoSize = true;
            this.lblCurrentChangeIcon.Location = new System.Drawing.Point(204, 116);
            this.lblCurrentChangeIcon.Name = "lblCurrentChangeIcon";
            this.lblCurrentChangeIcon.Size = new System.Drawing.Size(44, 13);
            this.lblCurrentChangeIcon.TabIndex = 18;
            this.lblCurrentChangeIcon.Text = "Current:";
            // 
            // lblCurrentDeleteIcon
            // 
            this.lblCurrentDeleteIcon.AutoSize = true;
            this.lblCurrentDeleteIcon.Location = new System.Drawing.Point(204, 142);
            this.lblCurrentDeleteIcon.Name = "lblCurrentDeleteIcon";
            this.lblCurrentDeleteIcon.Size = new System.Drawing.Size(44, 13);
            this.lblCurrentDeleteIcon.TabIndex = 19;
            this.lblCurrentDeleteIcon.Text = "Current:";
            // 
            // lblCurrentRenameIcon
            // 
            this.lblCurrentRenameIcon.AutoSize = true;
            this.lblCurrentRenameIcon.Location = new System.Drawing.Point(204, 168);
            this.lblCurrentRenameIcon.Name = "lblCurrentRenameIcon";
            this.lblCurrentRenameIcon.Size = new System.Drawing.Size(44, 13);
            this.lblCurrentRenameIcon.TabIndex = 20;
            this.lblCurrentRenameIcon.Text = "Current:";
            // 
            // lblCurrentInactivityIcon
            // 
            this.lblCurrentInactivityIcon.AutoSize = true;
            this.lblCurrentInactivityIcon.Location = new System.Drawing.Point(204, 194);
            this.lblCurrentInactivityIcon.Name = "lblCurrentInactivityIcon";
            this.lblCurrentInactivityIcon.Size = new System.Drawing.Size(44, 13);
            this.lblCurrentInactivityIcon.TabIndex = 21;
            this.lblCurrentInactivityIcon.Text = "Current:";
            // 
            // picCurrentFileCreateIcon
            // 
            this.picCurrentFileCreateIcon.Location = new System.Drawing.Point(255, 90);
            this.picCurrentFileCreateIcon.Name = "picCurrentFileCreateIcon";
            this.picCurrentFileCreateIcon.Size = new System.Drawing.Size(16, 16);
            this.picCurrentFileCreateIcon.TabIndex = 22;
            this.picCurrentFileCreateIcon.TabStop = false;
            // 
            // picCurrentFileChangedIcon
            // 
            this.picCurrentFileChangedIcon.Location = new System.Drawing.Point(255, 116);
            this.picCurrentFileChangedIcon.Name = "picCurrentFileChangedIcon";
            this.picCurrentFileChangedIcon.Size = new System.Drawing.Size(16, 16);
            this.picCurrentFileChangedIcon.TabIndex = 23;
            this.picCurrentFileChangedIcon.TabStop = false;
            // 
            // picCurrentFileDeleteIcon
            // 
            this.picCurrentFileDeleteIcon.Location = new System.Drawing.Point(255, 142);
            this.picCurrentFileDeleteIcon.Name = "picCurrentFileDeleteIcon";
            this.picCurrentFileDeleteIcon.Size = new System.Drawing.Size(16, 16);
            this.picCurrentFileDeleteIcon.TabIndex = 24;
            this.picCurrentFileDeleteIcon.TabStop = false;
            // 
            // picCurrentFileRenameIcon
            // 
            this.picCurrentFileRenameIcon.Location = new System.Drawing.Point(255, 168);
            this.picCurrentFileRenameIcon.Name = "picCurrentFileRenameIcon";
            this.picCurrentFileRenameIcon.Size = new System.Drawing.Size(16, 16);
            this.picCurrentFileRenameIcon.TabIndex = 25;
            this.picCurrentFileRenameIcon.TabStop = false;
            // 
            // picCurrentFileInactivityIcon
            // 
            this.picCurrentFileInactivityIcon.Location = new System.Drawing.Point(255, 194);
            this.picCurrentFileInactivityIcon.Name = "picCurrentFileInactivityIcon";
            this.picCurrentFileInactivityIcon.Size = new System.Drawing.Size(16, 16);
            this.picCurrentFileInactivityIcon.TabIndex = 26;
            this.picCurrentFileInactivityIcon.TabStop = false;
            // 
            // lblWatchDirectory
            // 
            this.lblWatchDirectory.AutoSize = true;
            this.lblWatchDirectory.Location = new System.Drawing.Point(12, 64);
            this.lblWatchDirectory.Name = "lblWatchDirectory";
            this.lblWatchDirectory.Size = new System.Drawing.Size(87, 13);
            this.lblWatchDirectory.TabIndex = 27;
            this.lblWatchDirectory.Text = "Watch Directory:";
            // 
            // txtWatchPath
            // 
            this.txtWatchPath.Location = new System.Drawing.Point(106, 61);
            this.txtWatchPath.MaxLength = 248;
            this.txtWatchPath.Name = "txtWatchPath";
            this.txtWatchPath.Size = new System.Drawing.Size(165, 20);
            this.txtWatchPath.TabIndex = 0;
            // 
            // lblBadPathErr
            // 
            this.lblBadPathErr.AutoSize = true;
            this.lblBadPathErr.ForeColor = System.Drawing.Color.Red;
            this.lblBadPathErr.Location = new System.Drawing.Point(278, 64);
            this.lblBadPathErr.Name = "lblBadPathErr";
            this.lblBadPathErr.Size = new System.Drawing.Size(39, 13);
            this.lblBadPathErr.TabIndex = 28;
            this.lblBadPathErr.Text = "*Oops!";
            this.lblBadPathErr.Visible = false;
            // 
            // lblBadPathErrMsg
            // 
            this.lblBadPathErrMsg.AutoSize = true;
            this.lblBadPathErrMsg.ForeColor = System.Drawing.Color.Red;
            this.lblBadPathErrMsg.Location = new System.Drawing.Point(12, 240);
            this.lblBadPathErrMsg.Name = "lblBadPathErrMsg";
            this.lblBadPathErrMsg.Size = new System.Drawing.Size(93, 13);
            this.lblBadPathErrMsg.TabIndex = 29;
            this.lblBadPathErrMsg.Text = "* Invalid Directory!";
            this.lblBadPathErrMsg.Visible = false;
            // 
            // frmHDDMonitorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(334, 262);
            this.Controls.Add(this.lblBadPathErrMsg);
            this.Controls.Add(this.lblBadPathErr);
            this.Controls.Add(this.txtWatchPath);
            this.Controls.Add(this.lblWatchDirectory);
            this.Controls.Add(this.picCurrentFileInactivityIcon);
            this.Controls.Add(this.picCurrentFileRenameIcon);
            this.Controls.Add(this.picCurrentFileDeleteIcon);
            this.Controls.Add(this.picCurrentFileChangedIcon);
            this.Controls.Add(this.picCurrentFileCreateIcon);
            this.Controls.Add(this.lblCurrentInactivityIcon);
            this.Controls.Add(this.lblCurrentRenameIcon);
            this.Controls.Add(this.lblCurrentDeleteIcon);
            this.Controls.Add(this.lblCurrentChangeIcon);
            this.Controls.Add(this.lblCurrentCreateIcon);
            this.Controls.Add(this.lblIconLetterInactivity);
            this.Controls.Add(this.txtInactivityLetter);
            this.Controls.Add(this.lblOnInactivity);
            this.Controls.Add(this.lblIconLetterRename);
            this.Controls.Add(this.txtFileRenameLetter);
            this.Controls.Add(this.lblOnFileRename);
            this.Controls.Add(this.lblIconLetterCreate);
            this.Controls.Add(this.txtFileCreateLetter);
            this.Controls.Add(this.lblOnFileCreate);
            this.Controls.Add(this.lblIconLetterDelete);
            this.Controls.Add(this.txtFileDeleteLetter);
            this.Controls.Add(this.lblOnFileDelete);
            this.Controls.Add(this.lblIconLetterChange);
            this.Controls.Add(this.txtFileChangeLetter);
            this.Controls.Add(this.lblMainFormDescription);
            this.Controls.Add(this.lblOnFileChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHDDMonitorMainForm";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileCreateIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileChangedIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileDeleteIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileRenameIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentFileInactivityIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOnFileChange;
        private System.Windows.Forms.Label lblMainFormDescription;
        private System.Windows.Forms.TextBox txtFileChangeLetter;
        private System.Windows.Forms.Label lblIconLetterChange;
        private System.Windows.Forms.Label lblOnFileDelete;
        private System.Windows.Forms.Label lblIconLetterDelete;
        private System.Windows.Forms.TextBox txtFileDeleteLetter;
        private System.Windows.Forms.Label lblIconLetterCreate;
        private System.Windows.Forms.TextBox txtFileCreateLetter;
        private System.Windows.Forms.Label lblOnFileCreate;
        private System.Windows.Forms.Label lblIconLetterRename;
        private System.Windows.Forms.TextBox txtFileRenameLetter;
        private System.Windows.Forms.Label lblOnFileRename;
        private System.Windows.Forms.Label lblIconLetterInactivity;
        private System.Windows.Forms.TextBox txtInactivityLetter;
        private System.Windows.Forms.Label lblOnInactivity;
        private System.Windows.Forms.Label lblCurrentCreateIcon;
        private System.Windows.Forms.Label lblCurrentChangeIcon;
        private System.Windows.Forms.Label lblCurrentDeleteIcon;
        private System.Windows.Forms.Label lblCurrentRenameIcon;
        private System.Windows.Forms.Label lblCurrentInactivityIcon;
        private System.Windows.Forms.PictureBox picCurrentFileCreateIcon;
        private System.Windows.Forms.PictureBox picCurrentFileChangedIcon;
        private System.Windows.Forms.PictureBox picCurrentFileDeleteIcon;
        private System.Windows.Forms.PictureBox picCurrentFileRenameIcon;
        private System.Windows.Forms.PictureBox picCurrentFileInactivityIcon;
        private System.Windows.Forms.Label lblWatchDirectory;
        private System.Windows.Forms.TextBox txtWatchPath;
        private System.Windows.Forms.Label lblBadPathErr;
        private System.Windows.Forms.Label lblBadPathErrMsg;
    }
}