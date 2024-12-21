namespace HappyJourney
{
    partial class EditUser
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
            this.mnuEditUser = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            this.lblEditUser = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.userRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.happy_journeyDataSet4 = new HappyJourney.happy_journeyDataSet4();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.userRoleTableAdapter = new HappyJourney.happy_journeyDataSet4TableAdapters.UserRoleTableAdapter();
            this.mnuEditUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.happy_journeyDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuEditUser
            // 
            this.mnuEditUser.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuEditUser.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuEditUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuEditUser.Location = new System.Drawing.Point(0, 0);
            this.mnuEditUser.Name = "mnuEditUser";
            this.mnuEditUser.Size = new System.Drawing.Size(1472, 40);
            this.mnuEditUser.TabIndex = 0;
            this.mnuEditUser.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(99, 36);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(149, 36);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(102, 36);
            this.profileToolStripMenuItem.Text = "Profile";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // inboxToolStripMenuItem
            // 
            this.inboxToolStripMenuItem.Name = "inboxToolStripMenuItem";
            this.inboxToolStripMenuItem.Size = new System.Drawing.Size(93, 36);
            this.inboxToolStripMenuItem.Text = "Inbox";
            this.inboxToolStripMenuItem.Click += new System.EventHandler(this.inboxToolStripMenuItem_Click);
            // 
            // composeToolStripMenuItem
            // 
            this.composeToolStripMenuItem.Name = "composeToolStripMenuItem";
            this.composeToolStripMenuItem.Size = new System.Drawing.Size(135, 36);
            this.composeToolStripMenuItem.Text = "Compose";
            this.composeToolStripMenuItem.Click += new System.EventHandler(this.composeToolStripMenuItem_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.Black;
            this.btnSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(631, 425);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(223, 45);
            this.btnSaveChanges.TabIndex = 41;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(26, 81);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(44, 42);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 33;
            this.imgBackArrow.TabStop = false;
            this.imgBackArrow.Click += new System.EventHandler(this.imgBackArrow_Click);
            // 
            // lblEditUser
            // 
            this.lblEditUser.AutoSize = true;
            this.lblEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditUser.Location = new System.Drawing.Point(663, 229);
            this.lblEditUser.Name = "lblEditUser";
            this.lblEditUser.Size = new System.Drawing.Size(157, 37);
            this.lblEditUser.TabIndex = 32;
            this.lblEditUser.Text = "Edit User";
            // 
            // cmbRole
            // 
            this.cmbRole.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.userRoleBindingSource, "role_name", true));
            this.cmbRole.DataSource = this.userRoleBindingSource;
            this.cmbRole.DisplayMember = "role_name";
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(744, 303);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(200, 33);
            this.cmbRole.TabIndex = 44;
            this.cmbRole.ValueMember = "role_id";
            // 
            // userRoleBindingSource
            // 
            this.userRoleBindingSource.DataMember = "UserRole";
            this.userRoleBindingSource.DataSource = this.happy_journeyDataSet4;
            // 
            // happy_journeyDataSet4
            // 
            this.happy_journeyDataSet4.DataSetName = "happy_journeyDataSet4";
            this.happy_journeyDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(527, 358);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(418, 31);
            this.txtEmail.TabIndex = 43;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(527, 303);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 31);
            this.txtPhone.TabIndex = 42;
            // 
            // userRoleTableAdapter
            // 
            this.userRoleTableAdapter.ClearBeforeFill = true;
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.lblEditUser);
            this.Controls.Add(this.mnuEditUser);
            this.MainMenuStrip = this.mnuEditUser;
            this.Name = "EditUser";
            this.Text = "Edit User";
            this.Load += new System.EventHandler(this.EditUser_Load);
            this.mnuEditUser.ResumeLayout(false);
            this.mnuEditUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.happy_journeyDataSet4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuEditUser;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.PictureBox imgBackArrow;
        private System.Windows.Forms.Label lblEditUser;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private happy_journeyDataSet4 happy_journeyDataSet4;
        private System.Windows.Forms.BindingSource userRoleBindingSource;
        private happy_journeyDataSet4TableAdapters.UserRoleTableAdapter userRoleTableAdapter;
    }
}