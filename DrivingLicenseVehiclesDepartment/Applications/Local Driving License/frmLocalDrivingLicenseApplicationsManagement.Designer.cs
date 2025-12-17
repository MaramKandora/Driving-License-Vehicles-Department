namespace DVLD_PresentationLayer.Applications
{
    partial class frmLocalDrivingLicenseApplicationsManagement
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLDLApplications = new System.Windows.Forms.DataGridView();
            this.cmsLDLApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonsLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilterLDLApplications = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterLDLApplications = new System.Windows.Forms.ComboBox();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddNewLDLApp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApplications)).BeginInit();
            this.cmsLDLApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(217, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(914, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Driving License Applications Management";
            // 
            // dgvLDLApplications
            // 
            this.dgvLDLApplications.AllowUserToAddRows = false;
            this.dgvLDLApplications.AllowUserToDeleteRows = false;
            this.dgvLDLApplications.AllowUserToResizeRows = false;
            this.dgvLDLApplications.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLDLApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLApplications.ContextMenuStrip = this.cmsLDLApplications;
            this.dgvLDLApplications.Location = new System.Drawing.Point(12, 320);
            this.dgvLDLApplications.MultiSelect = false;
            this.dgvLDLApplications.Name = "dgvLDLApplications";
            this.dgvLDLApplications.ReadOnly = true;
            this.dgvLDLApplications.RowHeadersWidth = 51;
            this.dgvLDLApplications.RowTemplate.Height = 24;
            this.dgvLDLApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLDLApplications.Size = new System.Drawing.Size(1352, 408);
            this.dgvLDLApplications.TabIndex = 1;
            // 
            // cmsLDLApplications
            // 
            this.cmsLDLApplications.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLDLApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLDLApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripSeparator3,
            this.scheduleTestToolStripMenuItem,
            this.toolStripSeparator4,
            this.issueDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator5,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator6,
            this.showPersonsLicenseHistoryToolStripMenuItem});
            this.cmsLDLApplications.Name = "contextMenuStrip1";
            this.cmsLDLApplications.Size = new System.Drawing.Size(304, 276);
            this.cmsLDLApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLDLApplications_Opening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(300, 6);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.PersonDetails_32;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.showApplicationDetailsToolStripMenuItem.Text = "show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(300, 6);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(300, 6);
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.scheduleTestToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.Schedule_Test_32;
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.scheduleTestToolStripMenuItem.Text = "Schedule Tests";
            this.scheduleTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleTestToolStripMenuItem_Click);
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.Vision_Test_Schdule;
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.Written_Test_32_Sechdule;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(300, 6);
            // 
            // issueDrivingLicenseToolStripMenuItem
            // 
            this.issueDrivingLicenseToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseToolStripMenuItem.Name = "issueDrivingLicenseToolStripMenuItem";
            this.issueDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.issueDrivingLicenseToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(300, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(300, 6);
            // 
            // showPersonsLicenseHistoryToolStripMenuItem
            // 
            this.showPersonsLicenseHistoryToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonsLicenseHistoryToolStripMenuItem.Name = "showPersonsLicenseHistoryToolStripMenuItem";
            this.showPersonsLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.showPersonsLicenseHistoryToolStripMenuItem.Text = "Show Person`s License History";
            // 
            // txtFilterLDLApplications
            // 
            this.txtFilterLDLApplications.Location = new System.Drawing.Point(300, 278);
            this.txtFilterLDLApplications.Name = "txtFilterLDLApplications";
            this.txtFilterLDLApplications.Size = new System.Drawing.Size(182, 22);
            this.txtFilterLDLApplications.TabIndex = 12;
            this.txtFilterLDLApplications.Visible = false;
            this.txtFilterLDLApplications.TextChanged += new System.EventHandler(this.txtFilterLDLApplications_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filter By :";
            // 
            // cbFilterLDLApplications
            // 
            this.cbFilterLDLApplications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterLDLApplications.FormattingEnabled = true;
            this.cbFilterLDLApplications.Items.AddRange(new object[] {
            "None",
            "L.D.L AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilterLDLApplications.Location = new System.Drawing.Point(121, 278);
            this.cbFilterLDLApplications.Name = "cbFilterLDLApplications";
            this.cbFilterLDLApplications.Size = new System.Drawing.Size(151, 24);
            this.cbFilterLDLApplications.TabIndex = 10;
            this.cbFilterLDLApplications.SelectedIndexChanged += new System.EventHandler(this.cbFilterLDLApplications_SelectedIndexChanged);
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.Location = new System.Drawing.Point(164, 755);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(0, 24);
            this.lblRecordsNum.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 755);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "# Records : ";
            // 
            // btnAddNewLDLApp
            // 
            this.btnAddNewLDLApp.BackgroundImage = global::DVLD_PresentationLayer.Properties.Resources.New_Application_64;
            this.btnAddNewLDLApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewLDLApp.Location = new System.Drawing.Point(1283, 247);
            this.btnAddNewLDLApp.Name = "btnAddNewLDLApp";
            this.btnAddNewLDLApp.Size = new System.Drawing.Size(74, 67);
            this.btnAddNewLDLApp.TabIndex = 16;
            this.btnAddNewLDLApp.UseVisualStyleBackColor = true;
            this.btnAddNewLDLApp.Click += new System.EventHandler(this.btnAddNewLDLApp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_PresentationLayer.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(571, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_PresentationLayer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1201, 740);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 49);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_PresentationLayer.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(675, 117);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 59);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // frmLocalDrivingLicenseApplicationsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 801);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddNewLDLApp);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilterLDLApplications);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterLDLApplications);
            this.Controls.Add(this.dgvLDLApplications);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocalDrivingLicenseApplicationsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Applications Management";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplicationsManagement_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLocalDrivingLicenseApplicationsManagement_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApplications)).EndInit();
            this.cmsLDLApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLDLApplications;
        private System.Windows.Forms.TextBox txtFilterLDLApplications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterLDLApplications;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddNewLDLApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsLDLApplications;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem showPersonsLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}