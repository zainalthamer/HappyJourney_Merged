namespace HappyJourney
{
    partial class Profile
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
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.txtDob = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnuProfile = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSignOut.Location = new System.Drawing.Point(483, 606);
            this.btnSignOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(487, 50);
            this.btnSignOut.TabIndex = 18;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEdit.Location = new System.Drawing.Point(483, 534);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(487, 50);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Edit Profile";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(483, 479);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(487, 31);
            this.txtEmail.TabIndex = 16;
            // 
            // txtRole
            // 
            this.txtRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRole.Location = new System.Drawing.Point(737, 429);
            this.txtRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(233, 31);
            this.txtRole.TabIndex = 15;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(483, 429);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(240, 31);
            this.txtPhone.TabIndex = 14;
            // 
            // txtNationality
            // 
            this.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNationality.Location = new System.Drawing.Point(737, 379);
            this.txtNationality.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.ReadOnly = true;
            this.txtNationality.Size = new System.Drawing.Size(233, 31);
            this.txtNationality.TabIndex = 13;
            // 
            // txtDob
            // 
            this.txtDob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDob.Location = new System.Drawing.Point(483, 379);
            this.txtDob.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDob.Name = "txtDob";
            this.txtDob.ReadOnly = true;
            this.txtDob.Size = new System.Drawing.Size(240, 31);
            this.txtDob.TabIndex = 12;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(520, 305);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.MinimumSize = new System.Drawing.Size(450, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(450, 37);
            this.labelName.TabIndex = 11;
            this.labelName.Text = "Name Name Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HappyJourney.Properties.Resources.Profile_Pic;
            this.pictureBox1.Location = new System.Drawing.Point(633, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // mnuProfile
            // 
            this.mnuProfile.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuProfile.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuProfile.Location = new System.Drawing.Point(0, 0);
            this.mnuProfile.Name = "mnuProfile";
            this.mnuProfile.Size = new System.Drawing.Size(1472, 42);
            this.mnuProfile.TabIndex = 24;
            this.mnuProfile.Text = "menuStrip1";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.txtDob);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.mnuProfile);
            this.MainMenuStrip = this.mnuProfile;
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.TextBox txtDob;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip mnuProfile;
    }
}