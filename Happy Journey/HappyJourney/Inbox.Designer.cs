namespace HappyJourney
{
    partial class Inbox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuInbox = new System.Windows.Forms.MenuStrip();
            this.lblInbox = new System.Windows.Forms.Label();
            this.pnlInbox = new System.Windows.Forms.Panel();
            this.dataGridInbox = new System.Windows.Forms.DataGridView();
            this.pnlInbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInbox)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuInbox
            // 
            this.mnuInbox.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuInbox.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuInbox.Location = new System.Drawing.Point(0, 0);
            this.mnuInbox.Name = "mnuInbox";
            this.mnuInbox.Size = new System.Drawing.Size(1472, 24);
            this.mnuInbox.TabIndex = 0;
            this.mnuInbox.Text = "menuStrip1";
            // 
            // lblInbox
            // 
            this.lblInbox.AutoSize = true;
            this.lblInbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInbox.Location = new System.Drawing.Point(672, 89);
            this.lblInbox.Name = "lblInbox";
            this.lblInbox.Size = new System.Drawing.Size(99, 37);
            this.lblInbox.TabIndex = 2;
            this.lblInbox.Text = "Inbox";
            // 
            // pnlInbox
            // 
            this.pnlInbox.Controls.Add(this.dataGridInbox);
            this.pnlInbox.Location = new System.Drawing.Point(88, 184);
            this.pnlInbox.Name = "pnlInbox";
            this.pnlInbox.Size = new System.Drawing.Size(1292, 537);
            this.pnlInbox.TabIndex = 3;
            // 
            // dataGridInbox
            // 
            this.dataGridInbox.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridInbox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridInbox.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridInbox.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridInbox.EnableHeadersVisualStyles = false;
            this.dataGridInbox.Location = new System.Drawing.Point(0, 0);
            this.dataGridInbox.Name = "dataGridInbox";
            this.dataGridInbox.RowHeadersWidth = 82;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridInbox.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridInbox.RowTemplate.Height = 33;
            this.dataGridInbox.Size = new System.Drawing.Size(1292, 537);
            this.dataGridInbox.TabIndex = 0;
            // 
            // Inbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.pnlInbox);
            this.Controls.Add(this.lblInbox);
            this.Controls.Add(this.mnuInbox);
            this.MainMenuStrip = this.mnuInbox;
            this.Name = "Inbox";
            this.Text = "Inbox";
            this.Load += new System.EventHandler(this.Inbox_Load);
            this.pnlInbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuInbox;
        private System.Windows.Forms.Label lblInbox;
        private System.Windows.Forms.Panel pnlInbox;
        private System.Windows.Forms.DataGridView dataGridInbox;
    }
}