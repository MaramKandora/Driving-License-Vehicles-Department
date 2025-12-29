namespace DVLD_PresentationLayer.Drivers
{
    partial class frmDriversList
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClosePeopleManagement = new System.Windows.Forms.Button();
            this.cbDriversFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDrivers = new System.Windows.Forms.DataGridView();
            this.txtDriversFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_PresentationLayer.Properties.Resources.Driver_Main;
            this.pictureBox1.Location = new System.Drawing.Point(581, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(560, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drivers List";
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRecordsNum.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.Location = new System.Drawing.Point(135, 814);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(0, 24);
            this.lblRecordsNum.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 814);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "# Records : ";
            // 
            // btnClosePeopleManagement
            // 
            this.btnClosePeopleManagement.BackgroundImage = global::DVLD_PresentationLayer.Properties.Resources.Close_32;
            this.btnClosePeopleManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClosePeopleManagement.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClosePeopleManagement.FlatAppearance.BorderSize = 4;
            this.btnClosePeopleManagement.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosePeopleManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClosePeopleManagement.Location = new System.Drawing.Point(1204, 803);
            this.btnClosePeopleManagement.Name = "btnClosePeopleManagement";
            this.btnClosePeopleManagement.Size = new System.Drawing.Size(139, 46);
            this.btnClosePeopleManagement.TabIndex = 14;
            this.btnClosePeopleManagement.Text = "close";
            this.btnClosePeopleManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClosePeopleManagement.UseVisualStyleBackColor = true;
            this.btnClosePeopleManagement.Click += new System.EventHandler(this.btnClosePeopleManagement_Click);
            // 
            // cbDriversFilter
            // 
            this.cbDriversFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbDriversFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDriversFilter.FormattingEnabled = true;
            this.cbDriversFilter.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Person ID",
            "National No",
            "Full Name",
            "Active Licenses Count"});
            this.cbDriversFilter.Location = new System.Drawing.Point(129, 284);
            this.cbDriversFilter.Name = "cbDriversFilter";
            this.cbDriversFilter.Size = new System.Drawing.Size(159, 24);
            this.cbDriversFilter.TabIndex = 13;
            this.cbDriversFilter.SelectedIndexChanged += new System.EventHandler(this.cbDriversFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filter By :";
            // 
            // dgvDrivers
            // 
            this.dgvDrivers.AllowUserToAddRows = false;
            this.dgvDrivers.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrivers.Location = new System.Drawing.Point(12, 323);
            this.dgvDrivers.MultiSelect = false;
            this.dgvDrivers.Name = "dgvDrivers";
            this.dgvDrivers.ReadOnly = true;
            this.dgvDrivers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvDrivers.RowTemplate.Height = 24;
            this.dgvDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrivers.Size = new System.Drawing.Size(1340, 474);
            this.dgvDrivers.TabIndex = 11;
            // 
            // txtDriversFilter
            // 
            this.txtDriversFilter.Location = new System.Drawing.Point(314, 284);
            this.txtDriversFilter.Name = "txtDriversFilter";
            this.txtDriversFilter.Size = new System.Drawing.Size(226, 22);
            this.txtDriversFilter.TabIndex = 17;
            this.txtDriversFilter.TextChanged += new System.EventHandler(this.txtDriversFilter_TextChanged);
            this.txtDriversFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDriversFilter_KeyPress);
            // 
            // frmDriversList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 859);
            this.Controls.Add(this.txtDriversFilter);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClosePeopleManagement);
            this.Controls.Add(this.cbDriversFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDrivers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDriversList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drivers List";
            this.Load += new System.EventHandler(this.frmDriversList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrivers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClosePeopleManagement;
        private System.Windows.Forms.ComboBox cbDriversFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDrivers;
        private System.Windows.Forms.TextBox txtDriversFilter;
    }
}