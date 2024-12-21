namespace HappyJourney
{
    partial class AddAirport
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
            this.mnuAddAirport = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbCities = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblAddAirport = new System.Windows.Forms.Label();
            this.txtIataCode = new System.Windows.Forms.TextBox();
            this.txtIcaoCode = new System.Windows.Forms.TextBox();
            this.mnuAddAirport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuAddAirport
            // 
            this.mnuAddAirport.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuAddAirport.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuAddAirport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuAddAirport.Location = new System.Drawing.Point(0, 0);
            this.mnuAddAirport.Name = "mnuAddAirport";
            this.mnuAddAirport.Size = new System.Drawing.Size(1472, 40);
            this.mnuAddAirport.TabIndex = 0;
            this.mnuAddAirport.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(99, 36);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(149, 36);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(102, 36);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // inboxToolStripMenuItem
            // 
            this.inboxToolStripMenuItem.Name = "inboxToolStripMenuItem";
            this.inboxToolStripMenuItem.Size = new System.Drawing.Size(93, 36);
            this.inboxToolStripMenuItem.Text = "Inbox";
            // 
            // composeToolStripMenuItem
            // 
            this.composeToolStripMenuItem.Name = "composeToolStripMenuItem";
            this.composeToolStripMenuItem.Size = new System.Drawing.Size(135, 36);
            this.composeToolStripMenuItem.Text = "Compose";
            // 
            // cmbCities
            // 
            this.cmbCities.FormattingEnabled = true;
            this.cmbCities.Location = new System.Drawing.Point(537, 308);
            this.cmbCities.Name = "cmbCities";
            this.cmbCities.Size = new System.Drawing.Size(200, 33);
            this.cmbCities.TabIndex = 44;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(754, 310);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 31);
            this.txtName.TabIndex = 43;
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(24, 70);
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
            this.btnAdd.Location = new System.Drawing.Point(659, 419);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 45);
            this.btnAdd.TabIndex = 41;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblAddAirport
            // 
            this.lblAddAirport.AutoSize = true;
            this.lblAddAirport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddAirport.Location = new System.Drawing.Point(665, 241);
            this.lblAddAirport.Name = "lblAddAirport";
            this.lblAddAirport.Size = new System.Drawing.Size(191, 37);
            this.lblAddAirport.TabIndex = 40;
            this.lblAddAirport.Text = "Add Airport";
            // 
            // txtIataCode
            // 
            this.txtIataCode.Location = new System.Drawing.Point(537, 360);
            this.txtIataCode.Name = "txtIataCode";
            this.txtIataCode.Size = new System.Drawing.Size(200, 31);
            this.txtIataCode.TabIndex = 45;
            // 
            // txtIcaoCode
            // 
            this.txtIcaoCode.Location = new System.Drawing.Point(754, 360);
            this.txtIcaoCode.Name = "txtIcaoCode";
            this.txtIcaoCode.Size = new System.Drawing.Size(200, 31);
            this.txtIcaoCode.TabIndex = 46;
            // 
            // AddAirport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.txtIcaoCode);
            this.Controls.Add(this.txtIataCode);
            this.Controls.Add(this.cmbCities);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblAddAirport);
            this.Controls.Add(this.mnuAddAirport);
            this.MainMenuStrip = this.mnuAddAirport;
            this.Name = "AddAirport";
            this.Text = "Add Airport";
            this.Load += new System.EventHandler(this.AddAirport_Load);
            this.mnuAddAirport.ResumeLayout(false);
            this.mnuAddAirport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAddAirport;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbCities;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox imgBackArrow;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblAddAirport;
        private System.Windows.Forms.TextBox txtIataCode;
        private System.Windows.Forms.TextBox txtIcaoCode;
    }
}