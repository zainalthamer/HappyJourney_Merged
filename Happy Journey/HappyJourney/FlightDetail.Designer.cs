namespace HappyJourney
{
    partial class FlightDetail
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
            this.flightsGridView = new System.Windows.Forms.DataGridView();
            this.seatCategoryGridView = new System.Windows.Forms.DataGridView();
            this.btnBookFlight = new System.Windows.Forms.Button();
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.flightsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatCategoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // flightsGridView
            // 
            this.flightsGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.flightsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightsGridView.Location = new System.Drawing.Point(41, 67);
            this.flightsGridView.Name = "flightsGridView";
            this.flightsGridView.RowHeadersWidth = 51;
            this.flightsGridView.RowTemplate.Height = 24;
            this.flightsGridView.Size = new System.Drawing.Size(890, 122);
            this.flightsGridView.TabIndex = 0;
            this.flightsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightsGridView_CellContentClick);
            // 
            // seatCategoryGridView
            // 
            this.seatCategoryGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.seatCategoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seatCategoryGridView.Location = new System.Drawing.Point(274, 225);
            this.seatCategoryGridView.Name = "seatCategoryGridView";
            this.seatCategoryGridView.RowHeadersWidth = 51;
            this.seatCategoryGridView.RowTemplate.Height = 24;
            this.seatCategoryGridView.Size = new System.Drawing.Size(429, 213);
            this.seatCategoryGridView.TabIndex = 1;
            this.seatCategoryGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seatCategoryGridView_CellContentClick);
            // 
            // btnBookFlight
            // 
            this.btnBookFlight.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBookFlight.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBookFlight.Location = new System.Drawing.Point(423, 459);
            this.btnBookFlight.Name = "btnBookFlight";
            this.btnBookFlight.Size = new System.Drawing.Size(124, 38);
            this.btnBookFlight.TabIndex = 2;
            this.btnBookFlight.Text = "Book Flight";
            this.btnBookFlight.UseVisualStyleBackColor = false;
            this.btnBookFlight.Click += new System.EventHandler(this.btnBookFlight_Click);
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(41, 23);
            this.imgBackArrow.Margin = new System.Windows.Forms.Padding(2);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(29, 27);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 21;
            this.imgBackArrow.TabStop = false;
            this.imgBackArrow.Click += new System.EventHandler(this.imgBackArrow_Click);
            // 
            // FlightDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 519);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.btnBookFlight);
            this.Controls.Add(this.seatCategoryGridView);
            this.Controls.Add(this.flightsGridView);
            this.Name = "FlightDetail";
            this.Text = "FlightDetail";
            ((System.ComponentModel.ISupportInitialize)(this.flightsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatCategoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flightsGridView;
        private System.Windows.Forms.DataGridView seatCategoryGridView;
        private System.Windows.Forms.Button btnBookFlight;
        private System.Windows.Forms.PictureBox imgBackArrow;
    }
}