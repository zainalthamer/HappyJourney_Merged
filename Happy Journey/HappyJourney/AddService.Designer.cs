namespace HappyJourney
{
    partial class AddService
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
            this.mnuAddService = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblAddService = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.mnuAddService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuAddService
            // 
            this.mnuAddService.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuAddService.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuAddService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuAddService.Location = new System.Drawing.Point(0, 0);
            this.mnuAddService.Name = "mnuAddService";
            this.mnuAddService.Size = new System.Drawing.Size(1472, 42);
            this.mnuAddService.TabIndex = 0;
            this.mnuAddService.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(99, 38);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(149, 38);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(102, 38);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // inboxToolStripMenuItem
            // 
            this.inboxToolStripMenuItem.Name = "inboxToolStripMenuItem";
            this.inboxToolStripMenuItem.Size = new System.Drawing.Size(93, 38);
            this.inboxToolStripMenuItem.Text = "Inbox";
            // 
            // composeToolStripMenuItem
            // 
            this.composeToolStripMenuItem.Name = "composeToolStripMenuItem";
            this.composeToolStripMenuItem.Size = new System.Drawing.Size(135, 38);
            this.composeToolStripMenuItem.Text = "Compose";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(753, 301);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 31);
            this.txtPrice.TabIndex = 43;
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(23, 61);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(44, 42);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 42;
            this.imgBackArrow.TabStop = false;
            this.imgBackArrow.Click += new System.EventHandler(this.imgBackArrow_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Black;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(658, 364);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 45);
            this.btnAdd.TabIndex = 41;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblAddService
            // 
            this.lblAddService.AutoSize = true;
            this.lblAddService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddService.Location = new System.Drawing.Point(664, 232);
            this.lblAddService.Name = "lblAddService";
            this.lblAddService.Size = new System.Drawing.Size(199, 37);
            this.lblAddService.TabIndex = 40;
            this.lblAddService.Text = "Add Service";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(537, 301);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 31);
            this.txtName.TabIndex = 45;
            // 
            // AddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAddService);
            this.Controls.Add(this.mnuAddService);
            this.MainMenuStrip = this.mnuAddService;
            this.Name = "AddService";
            this.Text = "Add Service";
            this.Load += new System.EventHandler(this.AddService_Load);
            this.mnuAddService.ResumeLayout(false);
            this.mnuAddService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAddService;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.PictureBox imgBackArrow;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblAddService;
        private System.Windows.Forms.TextBox txtName;
    }
}