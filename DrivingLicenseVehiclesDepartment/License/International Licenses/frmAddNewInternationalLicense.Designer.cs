namespace DVLD_PresentationLayer.License.International_Licenses
{
    partial class frmAddNewInternationalLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.llblLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llblLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.ctrlInternationalApplicationInfo1 = new DVLD_PresentationLayer.License.International_Licenses.Controls.ctrlInternationalApplicationInfo();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_PresentationLayer.License.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(259, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(634, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "International License Application";
            // 
            // llblLicensesHistory
            // 
            this.llblLicensesHistory.AutoSize = true;
            this.llblLicensesHistory.Enabled = false;
            this.llblLicensesHistory.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblLicensesHistory.Location = new System.Drawing.Point(42, 776);
            this.llblLicensesHistory.Name = "llblLicensesHistory";
            this.llblLicensesHistory.Size = new System.Drawing.Size(175, 19);
            this.llblLicensesHistory.TabIndex = 3;
            this.llblLicensesHistory.TabStop = true;
            this.llblLicensesHistory.Text = "Show Licenses History";
            this.llblLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLicensesHistory_LinkClicked);
            // 
            // llblLicenseInfo
            // 
            this.llblLicenseInfo.AutoSize = true;
            this.llblLicenseInfo.Enabled = false;
            this.llblLicenseInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblLicenseInfo.Location = new System.Drawing.Point(228, 778);
            this.llblLicenseInfo.Name = "llblLicenseInfo";
            this.llblLicenseInfo.Size = new System.Drawing.Size(145, 19);
            this.llblLicenseInfo.TabIndex = 4;
            this.llblLicenseInfo.TabStop = true;
            this.llblLicenseInfo.Text = "Show License Info";
            this.llblLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLicenseInfo_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_PresentationLayer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(691, 761);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 49);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVLD_PresentationLayer.Properties.Resources.IssueDrivingLicense_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(849, 761);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(144, 49);
            this.btnIssue.TabIndex = 42;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // ctrlInternationalApplicationInfo1
            // 
            this.ctrlInternationalApplicationInfo1.Location = new System.Drawing.Point(31, 546);
            this.ctrlInternationalApplicationInfo1.Name = "ctrlInternationalApplicationInfo1";
            this.ctrlInternationalApplicationInfo1.Size = new System.Drawing.Size(970, 211);
            this.ctrlInternationalApplicationInfo1.TabIndex = 44;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            this.ctrlDriverLicenseInfoWithFilter1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(26, 64);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(981, 491);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 43;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelection += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelection);
            // 
            // frmAddNewInternationalLicense
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 822);
            this.Controls.Add(this.ctrlInternationalApplicationInfo1);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.llblLicenseInfo);
            this.Controls.Add(this.llblLicensesHistory);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New International License";
            this.Load += new System.EventHandler(this.frmAddNewInternationalLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llblLicensesHistory;
        private System.Windows.Forms.LinkLabel llblLicenseInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private Controls.ctrlInternationalApplicationInfo ctrlInternationalApplicationInfo1;
    }
}