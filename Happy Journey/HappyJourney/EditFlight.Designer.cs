namespace HappyJourney
{
    partial class EditFlight
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
            this.mnuEditFlight = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtAvailableSeats = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.txtArrival = new System.Windows.Forms.TextBox();
            this.txtDeparture = new System.Windows.Forms.TextBox();
            this.lblEditFlight = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.mnuEditFlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuEditFlight
            // 
            this.mnuEditFlight.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuEditFlight.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuEditFlight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuEditFlight.Location = new System.Drawing.Point(0, 0);
            this.mnuEditFlight.Name = "mnuEditFlight";
            this.mnuEditFlight.Size = new System.Drawing.Size(1472, 40);
            this.mnuEditFlight.TabIndex = 0;
            this.mnuEditFlight.Text = "menuStrip1";
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
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(27, 63);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(44, 42);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 31;
            this.imgBackArrow.TabStop = false;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(746, 349);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 31);
            this.txtPrice.TabIndex = 30;
            // 
            // txtAvailableSeats
            // 
            this.txtAvailableSeats.Location = new System.Drawing.Point(529, 349);
            this.txtAvailableSeats.Name = "txtAvailableSeats";
            this.txtAvailableSeats.Size = new System.Drawing.Size(200, 31);
            this.txtAvailableSeats.TabIndex = 29;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.Black;
            this.btnSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(638, 460);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(221, 45);
            this.btnSaveChanges.TabIndex = 28;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // txtArrival
            // 
            this.txtArrival.Location = new System.Drawing.Point(746, 293);
            this.txtArrival.Name = "txtArrival";
            this.txtArrival.Size = new System.Drawing.Size(200, 31);
            this.txtArrival.TabIndex = 27;
            // 
            // txtDeparture
            // 
            this.txtDeparture.Location = new System.Drawing.Point(529, 295);
            this.txtDeparture.Name = "txtDeparture";
            this.txtDeparture.Size = new System.Drawing.Size(200, 31);
            this.txtDeparture.TabIndex = 26;
            // 
            // lblEditFlight
            // 
            this.lblEditFlight.AutoSize = true;
            this.lblEditFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditFlight.Location = new System.Drawing.Point(668, 218);
            this.lblEditFlight.Name = "lblEditFlight";
            this.lblEditFlight.Size = new System.Drawing.Size(171, 37);
            this.lblEditFlight.TabIndex = 23;
            this.lblEditFlight.Text = "Edit Flight";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(529, 405);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(417, 33);
            this.cmbStatus.TabIndex = 32;
            // 
            // EditFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtAvailableSeats);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.txtArrival);
            this.Controls.Add(this.txtDeparture);
            this.Controls.Add(this.lblEditFlight);
            this.Controls.Add(this.mnuEditFlight);
            this.MainMenuStrip = this.mnuEditFlight;
            this.Name = "EditFlight";
            this.Text = "Edit Flight";
            this.Load += new System.EventHandler(this.EditFlight_Load);
            this.mnuEditFlight.ResumeLayout(false);
            this.mnuEditFlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuEditFlight;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.PictureBox imgBackArrow;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtAvailableSeats;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.TextBox txtArrival;
        private System.Windows.Forms.TextBox txtDeparture;
        private System.Windows.Forms.Label lblEditFlight;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}