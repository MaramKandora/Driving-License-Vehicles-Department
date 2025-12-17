namespace DVLD_PresentationLayer.Users
{
    partial class frmChangePassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbCurrentPasswordPeek = new System.Windows.Forms.PictureBox();
            this.pbNewPasswordPeek = new System.Windows.Forms.PictureBox();
            this.pbConfirmPasswordPeek = new System.Windows.Forms.PictureBox();
            this.ctrlUserInformationCard1 = new DVLD_PresentationLayer.Users.Controls.ctrlUserInformationCard();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentPasswordPeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewPasswordPeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmPasswordPeek)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 529);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(167, 569);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(136, 607);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Confirm Password :";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(327, 531);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(173, 22);
            this.txtCurrentPassword.TabIndex = 6;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            this.txtCurrentPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrentPassword_Validating);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(327, 571);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(173, 22);
            this.txtNewPassword.TabIndex = 7;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPassword_Validating);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(327, 609);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(173, 22);
            this.txtConfirmPassword.TabIndex = 8;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_PresentationLayer.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(813, 669);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 43);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_PresentationLayer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(673, 669);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 43);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pbCurrentPasswordPeek
            // 
            this.pbCurrentPasswordPeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCurrentPasswordPeek.Image = global::DVLD_PresentationLayer.Properties.Resources.password_12048844__1_;
            this.pbCurrentPasswordPeek.Location = new System.Drawing.Point(506, 527);
            this.pbCurrentPasswordPeek.Name = "pbCurrentPasswordPeek";
            this.pbCurrentPasswordPeek.Size = new System.Drawing.Size(41, 32);
            this.pbCurrentPasswordPeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCurrentPasswordPeek.TabIndex = 11;
            this.pbCurrentPasswordPeek.TabStop = false;
            this.pbCurrentPasswordPeek.Click += new System.EventHandler(this.pbCurrentPasswordPeek_Click);
            // 
            // pbNewPasswordPeek
            // 
            this.pbNewPasswordPeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNewPasswordPeek.Image = global::DVLD_PresentationLayer.Properties.Resources.password_12048844__1_;
            this.pbNewPasswordPeek.Location = new System.Drawing.Point(506, 569);
            this.pbNewPasswordPeek.Name = "pbNewPasswordPeek";
            this.pbNewPasswordPeek.Size = new System.Drawing.Size(41, 32);
            this.pbNewPasswordPeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNewPasswordPeek.TabIndex = 12;
            this.pbNewPasswordPeek.TabStop = false;
            this.pbNewPasswordPeek.Click += new System.EventHandler(this.pbNewPasswordPeek_Click);
            // 
            // pbConfirmPasswordPeek
            // 
            this.pbConfirmPasswordPeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbConfirmPasswordPeek.Image = global::DVLD_PresentationLayer.Properties.Resources.password_12048844__1_;
            this.pbConfirmPasswordPeek.Location = new System.Drawing.Point(506, 607);
            this.pbConfirmPasswordPeek.Name = "pbConfirmPasswordPeek";
            this.pbConfirmPasswordPeek.Size = new System.Drawing.Size(41, 32);
            this.pbConfirmPasswordPeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbConfirmPasswordPeek.TabIndex = 13;
            this.pbConfirmPasswordPeek.TabStop = false;
            this.pbConfirmPasswordPeek.Click += new System.EventHandler(this.pbConfirmPasswordPeek_Click);
            // 
            // ctrlUserInformationCard1
            // 
            this.ctrlUserInformationCard1.Location = new System.Drawing.Point(15, 12);
            this.ctrlUserInformationCard1.Name = "ctrlUserInformationCard1";
            this.ctrlUserInformationCard1.Size = new System.Drawing.Size(969, 472);
            this.ctrlUserInformationCard1.TabIndex = 14;
            // 
            // frmChangePassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(994, 741);
            this.Controls.Add(this.ctrlUserInformationCard1);
            this.Controls.Add(this.pbConfirmPasswordPeek);
            this.Controls.Add(this.pbNewPasswordPeek);
            this.Controls.Add(this.pbCurrentPasswordPeek);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentPasswordPeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewPasswordPeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirmPasswordPeek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbConfirmPasswordPeek;
        private System.Windows.Forms.PictureBox pbNewPasswordPeek;
        private System.Windows.Forms.PictureBox pbCurrentPasswordPeek;
        private Controls.ctrlUserInformationCard ctrlUserInformationCard1;
    }
}