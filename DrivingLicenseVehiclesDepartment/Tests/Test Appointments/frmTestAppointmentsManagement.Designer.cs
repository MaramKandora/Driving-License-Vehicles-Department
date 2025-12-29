namespace DVLD_PresentationLayer.Tests
{
    partial class frmScheduleTestAppointment
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.pbHeaderImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.btnAddNewTestAppointment = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlLocalDrivingLicenseApplicationInfo1 = new DVLD_PresentationLayer.Applications.Controls.ctrlLocalDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeaderImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.cmsAppointments.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Purple;
            this.lblHeader.Location = new System.Drawing.Point(263, 91);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(525, 50);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Header Test Appointments";
            // 
            // pbHeaderImage
            // 
            this.pbHeaderImage.Image = global::DVLD_PresentationLayer.Properties.Resources.Vision_512;
            this.pbHeaderImage.Location = new System.Drawing.Point(416, 12);
            this.pbHeaderImage.Name = "pbHeaderImage";
            this.pbHeaderImage.Size = new System.Drawing.Size(115, 76);
            this.pbHeaderImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHeaderImage.TabIndex = 1;
            this.pbHeaderImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(42, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appointments List :";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToResizeRows = false;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmsAppointments;
            this.dgvAppointments.Location = new System.Drawing.Point(31, 598);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(846, 160);
            this.dgvAppointments.TabIndex = 4;
            // 
            // cmsAppointments
            // 
            this.cmsAppointments.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.cmsAppointments.Name = "cmsAppointments";
            this.cmsAppointments.Size = new System.Drawing.Size(144, 56);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Image = global::DVLD_PresentationLayer.Properties.Resources.Retake_Test_32;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.retakeTestToolStripMenuItem.Text = "Take Test";
            this.retakeTestToolStripMenuItem.Click += new System.EventHandler(this.TakeTestToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(42, 774);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "# Records :";
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsNum.Location = new System.Drawing.Point(155, 776);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(0, 20);
            this.lblRecordsNum.TabIndex = 6;
            // 
            // btnAddNewTestAppointment
            // 
            this.btnAddNewTestAppointment.BackgroundImage = global::DVLD_PresentationLayer.Properties.Resources.AddAppointment_32;
            this.btnAddNewTestAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewTestAppointment.Location = new System.Drawing.Point(818, 549);
            this.btnAddNewTestAppointment.Name = "btnAddNewTestAppointment";
            this.btnAddNewTestAppointment.Size = new System.Drawing.Size(50, 47);
            this.btnAddNewTestAppointment.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnAddNewTestAppointment, "Add New Appointment");
            this.btnAddNewTestAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewTestAppointment.Click += new System.EventHandler(this.btnAddNewTestAppointment_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_PresentationLayer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(748, 764);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 44);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlLocalDrivingLicenseApplicationInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(31, 161);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Name = "ctrlLocalDrivingLicenseApplicationInfo1";
            this.ctrlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(859, 385);
            this.ctrlLocalDrivingLicenseApplicationInfo1.TabIndex = 2;
            // 
            // frmScheduleTestAppointment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(908, 814);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewTestAppointment);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.pbHeaderImage);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmScheduleTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Appointments Management";
            this.Load += new System.EventHandler(this.frmVisionTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeaderImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmsAppointments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.PictureBox pbHeaderImage;
        private Applications.Controls.ctrlLocalDrivingLicenseApplicationInfo ctrlLocalDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.Button btnAddNewTestAppointment;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
    }
}