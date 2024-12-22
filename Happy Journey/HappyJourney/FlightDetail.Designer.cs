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
            this.flightsGridView.Location = new System.Drawing.Point(62, 105);
            this.flightsGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flightsGridView.Name = "flightsGridView";
            this.flightsGridView.RowHeadersWidth = 51;
            this.flightsGridView.RowTemplate.Height = 24;
            this.flightsGridView.Size = new System.Drawing.Size(1335, 191);
            this.flightsGridView.TabIndex = 0;
            this.flightsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightsGridView_CellContentClick);
            // 
            // seatCategoryGridView
            // 
            this.seatCategoryGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.seatCategoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seatCategoryGridView.Location = new System.Drawing.Point(411, 352);
            this.seatCategoryGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.seatCategoryGridView.Name = "seatCategoryGridView";
            this.seatCategoryGridView.RowHeadersWidth = 51;
            this.seatCategoryGridView.RowTemplate.Height = 24;
            this.seatCategoryGridView.Size = new System.Drawing.Size(644, 333);
            this.seatCategoryGridView.TabIndex = 1;
            this.seatCategoryGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seatCategoryGridView_CellContentClick);
            // 
            // btnBookFlight
            // 
            this.btnBookFlight.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBookFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookFlight.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBookFlight.Location = new System.Drawing.Point(634, 717);
            this.btnBookFlight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBookFlight.Name = "btnBookFlight";
            this.btnBookFlight.Size = new System.Drawing.Size(186, 59);
            this.btnBookFlight.TabIndex = 2;
            this.btnBookFlight.Text = "Book Flight";
            this.btnBookFlight.UseVisualStyleBackColor = false;
            this.btnBookFlight.Click += new System.EventHandler(this.btnBookFlight_Click);
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = global::HappyJourney.Properties.Resources.Back_arrow;
            this.imgBackArrow.Location = new System.Drawing.Point(62, 36);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(44, 42);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 21;
            this.imgBackArrow.TabStop = false;
            this.imgBackArrow.Click += new System.EventHandler(this.imgBackArrow_Click);
            // 
            // FlightDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 798);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.btnBookFlight);
            this.Controls.Add(this.seatCategoryGridView);
            this.Controls.Add(this.flightsGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FlightDetail";
            this.Text = "FlightDetail";
            this.Load += new System.EventHandler(this.FlightDetail_Load);
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