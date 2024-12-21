namespace HappyJourney
{
    partial class EditService
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
            this.mnuEditService = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.lblEditService = new System.Windows.Forms.Label();
            this.mnuEditService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuEditService
            // 
            this.mnuEditService.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuEditService.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuEditService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuEditService.Location = new System.Drawing.Point(0, 0);
            this.mnuEditService.Name = "mnuEditService";
            this.mnuEditService.Size = new System.Drawing.Size(1472, 40);
            this.mnuEditService.TabIndex = 0;
            this.mnuEditService.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(99, 44);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(149, 44);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(102, 44);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // inboxToolStripMenuItem
            // 
            this.inboxToolStripMenuItem.Name = "inboxToolStripMenuItem";
            this.inboxToolStripMenuItem.Size = new System.Drawing.Size(93, 44);
            this.inboxToolStripMenuItem.Text = "Inbox";
            // 
            // composeToolStripMenuItem
            // 
            this.composeToolStripMenuItem.Name = "composeToolStripMenuItem";
            this.composeToolStripMenuItem.Size = new System.Drawing.Size(135, 44);
            this.composeToolStripMenuItem.Text = "Compose";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(537, 304);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 31);
            this.txtName.TabIndex = 50;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(753, 304);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 31);
            this.txtPrice.TabIndex = 49;
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(23, 64);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(44, 42);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 48;
            this.imgBackArrow.TabStop = false;
            this.imgBackArrow.Click += new System.EventHandler(this.imgBackArrow_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.Black;
            this.btnSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(650, 367);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(210, 45);
            this.btnSaveChanges.TabIndex = 47;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            // 
            // lblEditService
            // 
            this.lblEditService.AutoSize = true;
            this.lblEditService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditService.Location = new System.Drawing.Point(664, 235);
            this.lblEditService.Name = "lblEditService";
            this.lblEditService.Size = new System.Drawing.Size(197, 37);
            this.lblEditService.TabIndex = 46;
            this.lblEditService.Text = "Edit Service";
            // 
            // EditService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.lblEditService);
            this.Controls.Add(this.mnuEditService);
            this.MainMenuStrip = this.mnuEditService;
            this.Name = "EditService";
            this.Text = "Edit Service";
            this.Load += new System.EventHandler(this.EditService_Load);
            this.mnuEditService.ResumeLayout(false);
            this.mnuEditService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuEditService;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.PictureBox imgBackArrow;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label lblEditService;
    }
}