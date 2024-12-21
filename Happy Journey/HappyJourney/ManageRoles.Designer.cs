namespace HappyJourney
{
    partial class ManageRoles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuManageRoles = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridRoles = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.happy_journeyDataSet5 = new HappyJourney.happy_journeyDataSet5();
            this.userRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userRoleTableAdapter = new HappyJourney.happy_journeyDataSet5TableAdapters.UserRoleTableAdapter();
            this.roleidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuManageRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.happy_journeyDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuManageRoles
            // 
            this.mnuManageRoles.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuManageRoles.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuManageRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuManageRoles.Location = new System.Drawing.Point(0, 0);
            this.mnuManageRoles.Name = "mnuManageRoles";
            this.mnuManageRoles.Size = new System.Drawing.Size(1472, 40);
            this.mnuManageRoles.TabIndex = 0;
            this.mnuManageRoles.Text = "menuStrip1";
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
            // dataGridRoles
            // 
            this.dataGridRoles.AutoGenerateColumns = false;
            this.dataGridRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridRoles.ColumnHeadersHeight = 30;
            this.dataGridRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roleidDataGridViewTextBoxColumn,
            this.rolenameDataGridViewTextBoxColumn});
            this.dataGridRoles.DataSource = this.userRoleBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridRoles.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridRoles.EnableHeadersVisualStyles = false;
            this.dataGridRoles.Location = new System.Drawing.Point(29, 208);
            this.dataGridRoles.Name = "dataGridRoles";
            this.dataGridRoles.RowHeadersWidth = 82;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dataGridRoles.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridRoles.RowTemplate.Height = 33;
            this.dataGridRoles.Size = new System.Drawing.Size(1419, 511);
            this.dataGridRoles.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1280, 138);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(168, 51);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Location = new System.Drawing.Point(29, 148);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(1245, 31);
            this.txtSearchBar.TabIndex = 6;
            // 
            // btnAddRole
            // 
            this.btnAddRole.BackColor = System.Drawing.Color.Black;
            this.btnAddRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRole.ForeColor = System.Drawing.Color.White;
            this.btnAddRole.Location = new System.Drawing.Point(25, 73);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(168, 51);
            this.btnAddRole.TabIndex = 5;
            this.btnAddRole.Text = "Add User";
            this.btnAddRole.UseVisualStyleBackColor = false;
            // 
            // happy_journeyDataSet5
            // 
            this.happy_journeyDataSet5.DataSetName = "happy_journeyDataSet5";
            this.happy_journeyDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userRoleBindingSource
            // 
            this.userRoleBindingSource.DataMember = "UserRole";
            this.userRoleBindingSource.DataSource = this.happy_journeyDataSet5;
            // 
            // userRoleTableAdapter
            // 
            this.userRoleTableAdapter.ClearBeforeFill = true;
            // 
            // roleidDataGridViewTextBoxColumn
            // 
            this.roleidDataGridViewTextBoxColumn.DataPropertyName = "role_id";
            this.roleidDataGridViewTextBoxColumn.HeaderText = "Role ID";
            this.roleidDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.roleidDataGridViewTextBoxColumn.Name = "roleidDataGridViewTextBoxColumn";
            this.roleidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rolenameDataGridViewTextBoxColumn
            // 
            this.rolenameDataGridViewTextBoxColumn.DataPropertyName = "role_name";
            this.rolenameDataGridViewTextBoxColumn.HeaderText = "Role Name";
            this.rolenameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.rolenameDataGridViewTextBoxColumn.Name = "rolenameDataGridViewTextBoxColumn";
            // 
            // ManageRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.dataGridRoles);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.mnuManageRoles);
            this.MainMenuStrip = this.mnuManageRoles;
            this.Name = "ManageRoles";
            this.Text = " ";
            this.Load += new System.EventHandler(this.ManageRoles_Load);
            this.mnuManageRoles.ResumeLayout(false);
            this.mnuManageRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.happy_journeyDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuManageRoles;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridRoles;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.Button btnAddRole;
        private happy_journeyDataSet5 happy_journeyDataSet5;
        private System.Windows.Forms.BindingSource userRoleBindingSource;
        private happy_journeyDataSet5TableAdapters.UserRoleTableAdapter userRoleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolenameDataGridViewTextBoxColumn;
    }
}