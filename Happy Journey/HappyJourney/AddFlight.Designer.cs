namespace HappyJourney
{
    partial class AddFlight
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
            this.mnuAddFlight = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtArrival = new System.Windows.Forms.TextBox();
            this.txtDeparture = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.lblAddFlight = new System.Windows.Forms.Label();
            this.txtAvailableSeats = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            this.mnuAddFlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuAddFlight
            // 
            this.mnuAddFlight.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuAddFlight.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuAddFlight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuAddFlight.Location = new System.Drawing.Point(0, 0);
            this.mnuAddFlight.Name = "mnuAddFlight";
            this.mnuAddFlight.Size = new System.Drawing.Size(1472, 40);
            this.mnuAddFlight.TabIndex = 0;
            this.mnuAddFlight.Text = "menuStrip1";
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
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Black;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(660, 446);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 45);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtArrival
            // 
            this.txtArrival.Location = new System.Drawing.Point(744, 335);
            this.txtArrival.Name = "txtArrival";
            this.txtArrival.Size = new System.Drawing.Size(200, 31);
            this.txtArrival.TabIndex = 15;
            // 
            // txtDeparture
            // 
            this.txtDeparture.Location = new System.Drawing.Point(527, 337);
            this.txtDeparture.Name = "txtDeparture";
            this.txtDeparture.Size = new System.Drawing.Size(200, 31);
            this.txtDeparture.TabIndex = 14;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(744, 284);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(200, 31);
            this.txtDestination.TabIndex = 13;
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(527, 284);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(200, 31);
            this.txtOrigin.TabIndex = 12;
            // 
            // lblAddFlight
            // 
            this.lblAddFlight.AutoSize = true;
            this.lblAddFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddFlight.Location = new System.Drawing.Point(666, 217);
            this.lblAddFlight.Name = "lblAddFlight";
            this.lblAddFlight.Size = new System.Drawing.Size(173, 37);
            this.lblAddFlight.TabIndex = 11;
            this.lblAddFlight.Text = "Add Flight";
            // 
            // txtAvailableSeats
            // 
            this.txtAvailableSeats.Location = new System.Drawing.Point(527, 391);
            this.txtAvailableSeats.Name = "txtAvailableSeats";
            this.txtAvailableSeats.Size = new System.Drawing.Size(200, 31);
            this.txtAvailableSeats.TabIndex = 20;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(744, 391);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 31);
            this.txtPrice.TabIndex = 21;
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(25, 76);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(44, 42);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 22;
            this.imgBackArrow.TabStop = false;
            this.imgBackArrow.Click += new System.EventHandler(this.imgBackArrow_Click);
            // 
            // AddFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtAvailableSeats);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtArrival);
            this.Controls.Add(this.txtDeparture);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.lblAddFlight);
            this.Controls.Add(this.mnuAddFlight);
            this.MainMenuStrip = this.mnuAddFlight;
            this.Name = "AddFlight";
            this.Text = "Add Flight";
            this.Load += new System.EventHandler(this.AddFlight_Load);
            this.mnuAddFlight.ResumeLayout(false);
            this.mnuAddFlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAddFlight;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtArrival;
        private System.Windows.Forms.TextBox txtDeparture;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.Label lblAddFlight;
        private System.Windows.Forms.TextBox txtAvailableSeats;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.PictureBox imgBackArrow;
    }
}