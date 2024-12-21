namespace HappyJourney
{
    partial class UserProfile
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
            this.mnuUserProfile = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            this.imgProfile = new System.Windows.Forms.PictureBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.txtDateOfBirth = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.btnViewBookingHistory = new System.Windows.Forms.Button();
            this.mnuUserProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuUserProfile
            // 
            this.mnuUserProfile.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuUserProfile.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuUserProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuUserProfile.Location = new System.Drawing.Point(0, 0);
            this.mnuUserProfile.Name = "mnuUserProfile";
            this.mnuUserProfile.Size = new System.Drawing.Size(1472, 40);
            this.mnuUserProfile.TabIndex = 0;
            this.mnuUserProfile.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(99, 40);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(149, 40);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(102, 40);
            this.profileToolStripMenuItem.Text = "Profile";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // inboxToolStripMenuItem
            // 
            this.inboxToolStripMenuItem.Name = "inboxToolStripMenuItem";
            this.inboxToolStripMenuItem.Size = new System.Drawing.Size(93, 40);
            this.inboxToolStripMenuItem.Text = "Inbox";
            this.inboxToolStripMenuItem.Click += new System.EventHandler(this.inboxToolStripMenuItem_Click);
            // 
            // composeToolStripMenuItem
            // 
            this.composeToolStripMenuItem.Name = "composeToolStripMenuItem";
            this.composeToolStripMenuItem.Size = new System.Drawing.Size(135, 40);
            this.composeToolStripMenuItem.Text = "Compose";
            this.composeToolStripMenuItem.Click += new System.EventHandler(this.composeToolStripMenuItem_Click);
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(23, 82);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(44, 42);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 21;
            this.imgBackArrow.TabStop = false;
            this.imgBackArrow.Click += new System.EventHandler(this.imgBackArrow_Click);
            // 
            // imgProfile
            // 
            this.imgProfile.Image = global::HappyJourney.Properties.Resources.Profile_Pic;
            this.imgProfile.Location = new System.Drawing.Point(647, 119);
            this.imgProfile.Name = "imgProfile";
            this.imgProfile.Size = new System.Drawing.Size(200, 200);
            this.imgProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgProfile.TabIndex = 22;
            this.imgProfile.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(534, 523);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(418, 31);
            this.txtEmail.TabIndex = 28;
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(751, 468);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(200, 31);
            this.txtRole.TabIndex = 27;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(534, 470);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(200, 31);
            this.txtPhone.TabIndex = 26;
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(751, 417);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.ReadOnly = true;
            this.txtNationality.Size = new System.Drawing.Size(200, 31);
            this.txtNationality.TabIndex = 25;
            // 
            // txtDateOfBirth
            // 
            this.txtDateOfBirth.Location = new System.Drawing.Point(534, 417);
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.ReadOnly = true;
            this.txtDateOfBirth.Size = new System.Drawing.Size(200, 31);
            this.txtDateOfBirth.TabIndex = 24;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(659, 350);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(173, 37);
            this.lblFullName.TabIndex = 23;
            this.lblFullName.Text = "Full Name";
            // 
            // btnViewBookingHistory
            // 
            this.btnViewBookingHistory.BackColor = System.Drawing.Color.Black;
            this.btnViewBookingHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBookingHistory.ForeColor = System.Drawing.Color.White;
            this.btnViewBookingHistory.Location = new System.Drawing.Point(534, 578);
            this.btnViewBookingHistory.Name = "btnViewBookingHistory";
            this.btnViewBookingHistory.Size = new System.Drawing.Size(417, 42);
            this.btnViewBookingHistory.TabIndex = 29;
            this.btnViewBookingHistory.Text = "View Booking History";
            this.btnViewBookingHistory.UseVisualStyleBackColor = false;
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.btnViewBookingHistory);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.txtDateOfBirth);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.imgProfile);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.mnuUserProfile);
            this.MainMenuStrip = this.mnuUserProfile;
            this.Name = "UserProfile";
            this.Text = "User Profile";
            this.Load += new System.EventHandler(this.UserProfile_Load);
            this.mnuUserProfile.ResumeLayout(false);
            this.mnuUserProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuUserProfile;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.PictureBox imgBackArrow;
        private System.Windows.Forms.PictureBox imgProfile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.TextBox txtDateOfBirth;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Button btnViewBookingHistory;
    }
}