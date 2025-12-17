namespace DVLD_PresentationLayer.People.Controls
{
    partial class ctrlPersonCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.txtFindBy = new System.Windows.Forms.TextBox();
            this.cbFindPersonBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ctrlPersonCard1 = new DVLD_PresentationLayer.ctrlPersonCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindPerson);
            this.gbFilter.Controls.Add(this.btnAddNewPerson);
            this.gbFilter.Controls.Add(this.txtFindBy);
            this.gbFilter.Controls.Add(this.cbFindPersonBy);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(952, 88);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindPerson.Image = global::DVLD_PresentationLayer.Properties.Resources.SearchPerson;
            this.btnFindPerson.Location = new System.Drawing.Point(554, 25);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(65, 47);
            this.btnFindPerson.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnFindPerson, "Search");
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewPerson.Image = global::DVLD_PresentationLayer.Properties.Resources.Add_Person_40;
            this.btnAddNewPerson.Location = new System.Drawing.Point(635, 26);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(65, 47);
            this.btnAddNewPerson.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnAddNewPerson, "Add New Person");
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // txtFindBy
            // 
            this.txtFindBy.Location = new System.Drawing.Point(317, 36);
            this.txtFindBy.Name = "txtFindBy";
            this.txtFindBy.Size = new System.Drawing.Size(215, 27);
            this.txtFindBy.TabIndex = 2;
            this.txtFindBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindBy_KeyPress);
            this.txtFindBy.Validating += new System.ComponentModel.CancelEventHandler(this.txtFindBy_Validating);
            // 
            // cbFindPersonBy
            // 
            this.cbFindPersonBy.FormattingEnabled = true;
            this.cbFindPersonBy.Items.AddRange(new object[] {
            "National No",
            "Person ID"});
            this.cbFindPersonBy.Location = new System.Drawing.Point(133, 36);
            this.cbFindPersonBy.Name = "cbFindPersonBy";
            this.cbFindPersonBy.Size = new System.Drawing.Size(164, 28);
            this.cbFindPersonBy.TabIndex = 1;
            this.cbFindPersonBy.SelectedIndexChanged += new System.EventHandler(this.cbFindPersonBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By : ";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 97);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(960, 346);
            this.ctrlPersonCard1.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.gbFilter);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(966, 446);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.ComboBox cbFindPersonBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.TextBox txtFindBy;
        private System.Windows.Forms.ToolTip toolTip1;
        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
