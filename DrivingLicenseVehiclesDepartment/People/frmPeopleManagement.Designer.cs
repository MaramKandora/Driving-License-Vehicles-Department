namespace DVLD_PresentationLayer
{
    partial class frmPeopleManagement
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
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.cmsPeopleList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_ShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_NewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_SendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_PhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPeopleFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.txtPeopleFilter = new System.Windows.Forms.MaskedTextBox();
            this.btnClosePeopleManagement = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.cmsPeopleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label1.Location = new System.Drawing.Point(545, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "People Management";
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.cmsPeopleList;
            this.dgvPeople.Location = new System.Drawing.Point(3, 273);
            this.dgvPeople.MultiSelect = false;
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvPeople.RowTemplate.Height = 24;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(1498, 558);
            this.dgvPeople.TabIndex = 2;
            // 
            // cmsPeopleList
            // 
            this.cmsPeopleList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPeopleList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ShowDetails,
            this.toolStripSeparator1,
            this.toolStripMenuItem_NewPerson,
            this.toolStripMenuItem_Edit,
            this.toolStripMenuItem_Delete,
            this.toolStripSeparator2,
            this.toolStripMenuItem_SendEmail,
            this.toolStripMenuItem_PhoneCall});
            this.cmsPeopleList.Name = "cmsPeopleList";
            this.cmsPeopleList.Size = new System.Drawing.Size(215, 200);
            // 
            // toolStripMenuItem_ShowDetails
            // 
            this.toolStripMenuItem_ShowDetails.Image = global::DVLD_PresentationLayer.Properties.Resources.PersonDetails_32;
            this.toolStripMenuItem_ShowDetails.Name = "toolStripMenuItem_ShowDetails";
            this.toolStripMenuItem_ShowDetails.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuItem_ShowDetails.Text = "Show Details";
            this.toolStripMenuItem_ShowDetails.Click += new System.EventHandler(this.toolStripMenuItem_ShowDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItem_NewPerson
            // 
            this.toolStripMenuItem_NewPerson.Image = global::DVLD_PresentationLayer.Properties.Resources.Add_Person_40;
            this.toolStripMenuItem_NewPerson.Name = "toolStripMenuItem_NewPerson";
            this.toolStripMenuItem_NewPerson.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuItem_NewPerson.Text = "Add New Person";
            this.toolStripMenuItem_NewPerson.Click += new System.EventHandler(this.toolStripMenuItem_NewPerson_Click);
            // 
            // toolStripMenuItem_Edit
            // 
            this.toolStripMenuItem_Edit.Image = global::DVLD_PresentationLayer.Properties.Resources.edit_32;
            this.toolStripMenuItem_Edit.Name = "toolStripMenuItem_Edit";
            this.toolStripMenuItem_Edit.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuItem_Edit.Text = "Edit";
            this.toolStripMenuItem_Edit.Click += new System.EventHandler(this.toolStripMenuItem_Edit_Click);
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Image = global::DVLD_PresentationLayer.Properties.Resources.Delete_32;
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuItem_Delete.Text = "Delete";
            this.toolStripMenuItem_Delete.Click += new System.EventHandler(this.toolStripMenuItem_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItem_SendEmail
            // 
            this.toolStripMenuItem_SendEmail.Image = global::DVLD_PresentationLayer.Properties.Resources.send_email_32;
            this.toolStripMenuItem_SendEmail.Name = "toolStripMenuItem_SendEmail";
            this.toolStripMenuItem_SendEmail.Size = new System.Drawing.Size(214, 26);
            this.toolStripMenuItem_SendEmail.Text = "Send Email";
            this.toolStripMenuItem_SendEmail.Click += new System.EventHandler(this.toolStripMenuItem_SendEmail_Click);
            // 
            // toolStripMenuItem_PhoneCall
            // 
            this.toolStripMenuItem_PhoneCall.Image = global::DVLD_PresentationLayer.Properties.Resources.call_32;
            this.toolStripMenuItem_PhoneCall.Name = "toolStripMenuItem_PhoneCall";
            this.toolStripMenuItem_PhoneCall.Size = new System.Drawing.Size(214, 26);
            this.toolStripMenuItem_PhoneCall.Text = "Phone Call";
            this.toolStripMenuItem_PhoneCall.Click += new System.EventHandler(this.toolStripMenuItem_PhoneCall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By :";
            // 
            // cbPeopleFilter
            // 
            this.cbPeopleFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbPeopleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeopleFilter.FormattingEnabled = true;
            this.cbPeopleFilter.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "NationalNo",
            "First Name ",
            "Second Name",
            "Third Name",
            "Last Name",
            "Country Name",
            "Gender Caption",
            "Phone",
            "Email"});
            this.cbPeopleFilter.Location = new System.Drawing.Point(106, 243);
            this.cbPeopleFilter.Name = "cbPeopleFilter";
            this.cbPeopleFilter.Size = new System.Drawing.Size(159, 24);
            this.cbPeopleFilter.TabIndex = 4;
            this.cbPeopleFilter.SelectedIndexChanged += new System.EventHandler(this.cbPeopleFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 848);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Records : ";
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRecordsNum.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.Location = new System.Drawing.Point(144, 848);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(0, 24);
            this.lblRecordsNum.TabIndex = 8;
            // 
            // txtPeopleFilter
            // 
            this.txtPeopleFilter.HidePromptOnLeave = true;
            this.txtPeopleFilter.Location = new System.Drawing.Point(301, 243);
            this.txtPeopleFilter.Name = "txtPeopleFilter";
            this.txtPeopleFilter.Size = new System.Drawing.Size(151, 22);
            this.txtPeopleFilter.TabIndex = 10;
            this.txtPeopleFilter.TextChanged += new System.EventHandler(this.txtPeopleFilter_TextChanged);
            this.txtPeopleFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeopleFilter_KeyPress);
            // 
            // btnClosePeopleManagement
            // 
            this.btnClosePeopleManagement.BackgroundImage = global::DVLD_PresentationLayer.Properties.Resources.Close_32;
            this.btnClosePeopleManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClosePeopleManagement.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClosePeopleManagement.FlatAppearance.BorderSize = 4;
            this.btnClosePeopleManagement.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosePeopleManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClosePeopleManagement.Location = new System.Drawing.Point(1363, 837);
            this.btnClosePeopleManagement.Name = "btnClosePeopleManagement";
            this.btnClosePeopleManagement.Size = new System.Drawing.Size(139, 46);
            this.btnClosePeopleManagement.TabIndex = 6;
            this.btnClosePeopleManagement.Text = "close";
            this.btnClosePeopleManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClosePeopleManagement.UseVisualStyleBackColor = true;
            this.btnClosePeopleManagement.Click += new System.EventHandler(this.btnClosePeopleManagement_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::DVLD_PresentationLayer.Properties.Resources.Add_Person_72;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1442, 215);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(59, 52);
            this.btnAddNewPerson.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnAddNewPerson, "Add New Person");
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD_PresentationLayer.Properties.Resources.People_400;
            this.pictureBox1.Location = new System.Drawing.Point(680, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPeopleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1514, 895);
            this.Controls.Add(this.txtPeopleFilter);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClosePeopleManagement);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.cbPeopleFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPeopleManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People Management";
            this.Load += new System.EventHandler(this.frmPeopleManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.cmsPeopleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPeopleFilter;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnClosePeopleManagement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.MaskedTextBox txtPeopleFilter;
        private System.Windows.Forms.ContextMenuStrip cmsPeopleList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowDetails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_NewPerson;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SendEmail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PhoneCall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}