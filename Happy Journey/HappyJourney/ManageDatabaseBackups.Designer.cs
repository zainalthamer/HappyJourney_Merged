namespace HappyJourney
{
    partial class ManageDatabaseBackups
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuManageDatabaseBackups = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridBackupLogs = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.btnInitiateBackup = new System.Windows.Forms.Button();
            this.mnuManageDatabaseBackups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackupLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuManageDatabaseBackups
            // 
            this.mnuManageDatabaseBackups.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuManageDatabaseBackups.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuManageDatabaseBackups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuManageDatabaseBackups.Location = new System.Drawing.Point(0, 0);
            this.mnuManageDatabaseBackups.Name = "mnuManageDatabaseBackups";
            this.mnuManageDatabaseBackups.Size = new System.Drawing.Size(1472, 40);
            this.mnuManageDatabaseBackups.TabIndex = 0;
            this.mnuManageDatabaseBackups.Text = "menuStrip1";
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
            // dataGridBackupLogs
            // 
            this.dataGridBackupLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridBackupLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridBackupLogs.ColumnHeadersHeight = 30;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridBackupLogs.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridBackupLogs.EnableHeadersVisualStyles = false;
            this.dataGridBackupLogs.Location = new System.Drawing.Point(27, 208);
            this.dataGridBackupLogs.Name = "dataGridBackupLogs";
            this.dataGridBackupLogs.RowHeadersWidth = 82;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.dataGridBackupLogs.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridBackupLogs.RowTemplate.Height = 33;
            this.dataGridBackupLogs.Size = new System.Drawing.Size(1419, 511);
            this.dataGridBackupLogs.TabIndex = 20;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1278, 138);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(168, 51);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Location = new System.Drawing.Point(27, 148);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(1245, 31);
            this.txtSearchBar.TabIndex = 18;
            // 
            // btnInitiateBackup
            // 
            this.btnInitiateBackup.BackColor = System.Drawing.Color.Black;
            this.btnInitiateBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitiateBackup.ForeColor = System.Drawing.Color.White;
            this.btnInitiateBackup.Location = new System.Drawing.Point(23, 73);
            this.btnInitiateBackup.Name = "btnInitiateBackup";
            this.btnInitiateBackup.Size = new System.Drawing.Size(274, 51);
            this.btnInitiateBackup.TabIndex = 17;
            this.btnInitiateBackup.Text = "Initiate New Backup";
            this.btnInitiateBackup.UseVisualStyleBackColor = false;
            this.btnInitiateBackup.Click += new System.EventHandler(this.btnInitiateBackup_Click);
            // 
            // ManageDatabaseBackups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.dataGridBackupLogs);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.btnInitiateBackup);
            this.Controls.Add(this.mnuManageDatabaseBackups);
            this.MainMenuStrip = this.mnuManageDatabaseBackups;
            this.Name = "ManageDatabaseBackups";
            this.Text = "Manage Database Backup Logs";
            this.Load += new System.EventHandler(this.ManageDatabaseBackups_Load);
            this.mnuManageDatabaseBackups.ResumeLayout(false);
            this.mnuManageDatabaseBackups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackupLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuManageDatabaseBackups;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridBackupLogs;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.Button btnInitiateBackup;
    }
}