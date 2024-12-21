namespace HappyJourney
{
    partial class Home
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // Home
            // 

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flightsGridView = new System.Windows.Forms.DataGridView();
            this.originTextBox = new System.Windows.Forms.TextBox();
            this.destTextBox = new System.Windows.Forms.TextBox();
            this.arrivalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.departDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flightsGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.originLabel = new System.Windows.Forms.Label();
            this.dstLabel = new System.Windows.Forms.Label();
            this.departureLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.mnuHome = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.flightsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flightsGridView
            // 
            this.flightsGridView.AllowUserToAddRows = false;
            this.flightsGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.flightsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.flightsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightsGridView.Location = new System.Drawing.Point(37, 218);
            this.flightsGridView.Name = "flightsGridView";
            this.flightsGridView.RowHeadersWidth = 51;
            this.flightsGridView.RowTemplate.Height = 24;
            this.flightsGridView.ShowEditingIcon = false;
            this.flightsGridView.Size = new System.Drawing.Size(1079, 383);
            this.flightsGridView.TabIndex = 1;
            this.flightsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightsGridView_CellClick);
            this.flightsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // originTextBox
            // 
            this.originTextBox.Location = new System.Drawing.Point(37, 82);
            this.originTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.originTextBox.MinimumSize = new System.Drawing.Size(200, 30);
            this.originTextBox.Name = "originTextBox";
            this.originTextBox.Size = new System.Drawing.Size(200, 30);
            this.originTextBox.TabIndex = 2;
            // 
            // mnuHome
            // 
            this.mnuHome.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuHome.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuHome.Location = new System.Drawing.Point(0, 0);
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.Size = new System.Drawing.Size(1472, 48);
            this.mnuHome.TabIndex = 0;
            this.mnuHome.Text = "menuStrip1";
            // 
            // destTextBox
            // 
            this.destTextBox.Location = new System.Drawing.Point(313, 82);
            this.destTextBox.MinimumSize = new System.Drawing.Size(200, 30);
            this.destTextBox.Name = "destTextBox";
            this.destTextBox.Size = new System.Drawing.Size(200, 30);
            this.destTextBox.TabIndex = 3;
            // 
            // arrivalDateTimePicker
            // 
            this.arrivalDateTimePicker.Location = new System.Drawing.Point(871, 82);
            this.arrivalDateTimePicker.MinimumSize = new System.Drawing.Size(200, 30);
            this.arrivalDateTimePicker.Name = "arrivalDateTimePicker";
            this.arrivalDateTimePicker.Size = new System.Drawing.Size(200, 30);
            this.arrivalDateTimePicker.TabIndex = 5;
            // 
            // departDateTimePicker
            // 
            this.departDateTimePicker.Location = new System.Drawing.Point(587, 82);
            this.departDateTimePicker.MinimumSize = new System.Drawing.Size(200, 30);
            this.departDateTimePicker.Name = "departDateTimePicker";
            this.departDateTimePicker.Size = new System.Drawing.Size(200, 30);
            this.departDateTimePicker.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSearch.Location = new System.Drawing.Point(403, 151);
            this.btnSearch.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 33);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // originLabel
            // 
            this.originLabel.AutoSize = true;
            this.originLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originLabel.Location = new System.Drawing.Point(34, 47);
            this.originLabel.Name = "originLabel";
            this.originLabel.Size = new System.Drawing.Size(53, 18);
            this.originLabel.TabIndex = 8;
            this.originLabel.Text = "Origin";
            // 
            // dstLabel
            // 
            this.dstLabel.AutoSize = true;
            this.dstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dstLabel.Location = new System.Drawing.Point(310, 47);
            this.dstLabel.Name = "dstLabel";
            this.dstLabel.Size = new System.Drawing.Size(93, 18);
            this.dstLabel.TabIndex = 9;
            this.dstLabel.Text = "Destination";
            // 
            // departureLabel
            // 
            this.departureLabel.AutoSize = true;
            this.departureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureLabel.Location = new System.Drawing.Point(584, 47);
            this.departureLabel.Name = "departureLabel";
            this.departureLabel.Size = new System.Drawing.Size(124, 18);
            this.departureLabel.TabIndex = 10;
            this.departureLabel.Text = "Departure Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(868, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Arrival Time";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnClear.Location = new System.Drawing.Point(625, 151);
            this.btnClear.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 33);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Flights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 627);
            this.Name = "Home";
            this.Text = "Home";
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.departureLabel);
            this.Controls.Add(this.dstLabel);
            this.Controls.Add(this.originLabel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.departDateTimePicker);
            this.Controls.Add(this.arrivalDateTimePicker);
            this.Controls.Add(this.destTextBox);
            this.Controls.Add(this.originTextBox);
            this.Controls.Add(this.flightsGridView);
            this.Controls.Add(this.mnuHome);
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView flightsGridView;
        private System.Windows.Forms.TextBox originTextBox;
        private System.Windows.Forms.TextBox destTextBox;
        private System.Windows.Forms.DateTimePicker arrivalDateTimePicker;
        private System.Windows.Forms.DateTimePicker departDateTimePicker;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label originLabel;
        private System.Windows.Forms.Label dstLabel;
        private System.Windows.Forms.Label departureLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MenuStrip mnuHome;
    }
}