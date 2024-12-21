namespace HappyJourney
{
    partial class ManageReports
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
            this.dataGridReport = new System.Windows.Forms.DataGridView();
            this.txtFlightId = new System.Windows.Forms.TextBox();
            this.btnGenerateManifest = new System.Windows.Forms.Button();
            this.btnGenerateSummary = new System.Windows.Forms.Button();
            this.mnuManageReports = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).BeginInit();
            this.mnuManageReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridReport
            // 
            this.dataGridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReport.Location = new System.Drawing.Point(23, 147);
            this.dataGridReport.Name = "dataGridReport";
            this.dataGridReport.RowHeadersWidth = 82;
            this.dataGridReport.RowTemplate.Height = 33;
            this.dataGridReport.Size = new System.Drawing.Size(1423, 572);
            this.dataGridReport.TabIndex = 33;
            // 
            // txtFlightId
            // 
            this.txtFlightId.Location = new System.Drawing.Point(899, 82);
            this.txtFlightId.Name = "txtFlightId";
            this.txtFlightId.Size = new System.Drawing.Size(164, 31);
            this.txtFlightId.TabIndex = 32;
            // 
            // btnGenerateManifest
            // 
            this.btnGenerateManifest.BackColor = System.Drawing.Color.Black;
            this.btnGenerateManifest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateManifest.ForeColor = System.Drawing.Color.White;
            this.btnGenerateManifest.Location = new System.Drawing.Point(1078, 72);
            this.btnGenerateManifest.Name = "btnGenerateManifest";
            this.btnGenerateManifest.Size = new System.Drawing.Size(368, 51);
            this.btnGenerateManifest.TabIndex = 31;
            this.btnGenerateManifest.Text = "Generate Passenger Manifest";
            this.btnGenerateManifest.UseVisualStyleBackColor = false;
            // 
            // btnGenerateSummary
            // 
            this.btnGenerateSummary.BackColor = System.Drawing.Color.Black;
            this.btnGenerateSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateSummary.ForeColor = System.Drawing.Color.White;
            this.btnGenerateSummary.Location = new System.Drawing.Point(23, 72);
            this.btnGenerateSummary.Name = "btnGenerateSummary";
            this.btnGenerateSummary.Size = new System.Drawing.Size(393, 51);
            this.btnGenerateSummary.TabIndex = 30;
            this.btnGenerateSummary.Text = "Generate Daily Flight Summary";
            this.btnGenerateSummary.UseVisualStyleBackColor = false;
            // 
            // mnuManageReports
            // 
            this.mnuManageReports.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuManageReports.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuManageReports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuManageReports.Location = new System.Drawing.Point(0, 0);
            this.mnuManageReports.Name = "mnuManageReports";
            this.mnuManageReports.Size = new System.Drawing.Size(1472, 40);
            this.mnuManageReports.TabIndex = 29;
            this.mnuManageReports.Text = "menuStrip1";
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
            // ManageReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.dataGridReport);
            this.Controls.Add(this.txtFlightId);
            this.Controls.Add(this.btnGenerateManifest);
            this.Controls.Add(this.btnGenerateSummary);
            this.Controls.Add(this.mnuManageReports);
            this.Name = "ManageReports";
            this.Text = "Manage Reports";
            this.Load += new System.EventHandler(this.ManageReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReport)).EndInit();
            this.mnuManageReports.ResumeLayout(false);
            this.mnuManageReports.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReport;
        private System.Windows.Forms.TextBox txtFlightId;
        private System.Windows.Forms.Button btnGenerateManifest;
        private System.Windows.Forms.Button btnGenerateSummary;
        private System.Windows.Forms.MenuStrip mnuManageReports;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
    }
}