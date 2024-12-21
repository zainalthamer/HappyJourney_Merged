namespace HappyJourney
{
    partial class ManageFlights
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuManageFlights = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridFlights = new System.Windows.Forms.DataGridView();
            this.flight_id = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flightBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.happy_journeyDataSet6 = new HappyJourney.happy_journeyDataSet6();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.flightTableAdapter = new HappyJourney.happy_journeyDataSet6TableAdapters.FlightTableAdapter();
            this.mnuManageFlights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.happy_journeyDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuManageFlights
            // 
            this.mnuManageFlights.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuManageFlights.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuManageFlights.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.inboxToolStripMenuItem,
            this.composeToolStripMenuItem});
            this.mnuManageFlights.Location = new System.Drawing.Point(0, 0);
            this.mnuManageFlights.Name = "mnuManageFlights";
            this.mnuManageFlights.Size = new System.Drawing.Size(1472, 40);
            this.mnuManageFlights.TabIndex = 0;
            this.mnuManageFlights.Text = "menuStrip1";
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
            // dataGridFlights
            // 
            this.dataGridFlights.AutoGenerateColumns = false;
            this.dataGridFlights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFlights.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridFlights.ColumnHeadersHeight = 30;
            this.dataGridFlights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flight_id});
            this.dataGridFlights.DataSource = this.flightBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridFlights.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridFlights.EnableHeadersVisualStyles = false;
            this.dataGridFlights.Location = new System.Drawing.Point(28, 208);
            this.dataGridFlights.Name = "dataGridFlights";
            this.dataGridFlights.RowHeadersWidth = 82;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridFlights.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridFlights.RowTemplate.Height = 33;
            this.dataGridFlights.Size = new System.Drawing.Size(1419, 512);
            this.dataGridFlights.TabIndex = 8;
            // 
            // flight_id
            // 
            this.flight_id.DataPropertyName = "flight_id";
            this.flight_id.HeaderText = "Flight ID";
            this.flight_id.MinimumWidth = 10;
            this.flight_id.Name = "flight_id";
            this.flight_id.ReadOnly = true;
            this.flight_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.flight_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // flightBindingSource
            // 
            this.flightBindingSource.DataMember = "Flight";
            this.flightBindingSource.DataSource = this.happy_journeyDataSet6;
            // 
            // happy_journeyDataSet6
            // 
            this.happy_journeyDataSet6.DataSetName = "happy_journeyDataSet6";
            this.happy_journeyDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1279, 138);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(168, 51);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Location = new System.Drawing.Point(28, 148);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(1245, 31);
            this.txtSearchBar.TabIndex = 6;
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.BackColor = System.Drawing.Color.Black;
            this.btnAddFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFlight.ForeColor = System.Drawing.Color.White;
            this.btnAddFlight.Location = new System.Drawing.Point(24, 73);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Size = new System.Drawing.Size(168, 51);
            this.btnAddFlight.TabIndex = 5;
            this.btnAddFlight.Text = "Add Flight";
            this.btnAddFlight.UseVisualStyleBackColor = false;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // flightTableAdapter
            // 
            this.flightTableAdapter.ClearBeforeFill = true;
            // 
            // ManageFlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.dataGridFlights);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.btnAddFlight);
            this.Controls.Add(this.mnuManageFlights);
            this.MainMenuStrip = this.mnuManageFlights;
            this.Name = "ManageFlights";
            this.Text = "Manage Flights";
            this.Load += new System.EventHandler(this.ManageFlights_Load);
            this.mnuManageFlights.ResumeLayout(false);
            this.mnuManageFlights.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.happy_journeyDataSet6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuManageFlights;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridFlights;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.Button btnAddFlight;
        private happy_journeyDataSet6 happy_journeyDataSet6;
        private System.Windows.Forms.BindingSource flightBindingSource;
        private happy_journeyDataSet6TableAdapters.FlightTableAdapter flightTableAdapter;
        private System.Windows.Forms.DataGridViewButtonColumn flight_id;
    }
}