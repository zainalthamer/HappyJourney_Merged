namespace HappyJourney
{
    partial class MessageDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageDetails));
            this.imgBackArrow = new System.Windows.Forms.PictureBox();
            this.mnuMessageDetails = new System.Windows.Forms.MenuStrip();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblSender = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSent = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMessageContent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBackArrow
            // 
            this.imgBackArrow.Image = ((System.Drawing.Image)(resources.GetObject("imgBackArrow.Image")));
            this.imgBackArrow.Location = new System.Drawing.Point(47, 76);
            this.imgBackArrow.Name = "imgBackArrow";
            this.imgBackArrow.Size = new System.Drawing.Size(44, 42);
            this.imgBackArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackArrow.TabIndex = 21;
            this.imgBackArrow.TabStop = false;
            this.imgBackArrow.Click += new System.EventHandler(this.imgBackArrow_Click);
            // 
            // mnuMessageDetails
            // 
            this.mnuMessageDetails.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuMessageDetails.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnuMessageDetails.Location = new System.Drawing.Point(0, 0);
            this.mnuMessageDetails.Name = "mnuMessageDetails";
            this.mnuMessageDetails.Size = new System.Drawing.Size(1472, 42);
            this.mnuMessageDetails.TabIndex = 22;
            this.mnuMessageDetails.Text = "menuStrip1";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFrom.Location = new System.Drawing.Point(117, 161);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(61, 25);
            this.lblFrom.TabIndex = 23;
            this.lblFrom.Text = "From";
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSender.ForeColor = System.Drawing.Color.Black;
            this.lblSender.Location = new System.Drawing.Point(117, 201);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(87, 25);
            this.lblSender.TabIndex = 24;
            this.lblSender.Text = "Sender";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(1246, 201);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(61, 25);
            this.lblDate.TabIndex = 26;
            this.lblDate.Text = "Date";
            // 
            // lblSent
            // 
            this.lblSent.AutoSize = true;
            this.lblSent.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSent.Location = new System.Drawing.Point(1245, 161);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(56, 25);
            this.lblSent.TabIndex = 25;
            this.lblSent.Text = "Sent";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMessage.Location = new System.Drawing.Point(117, 282);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(100, 25);
            this.lblMessage.TabIndex = 27;
            this.lblMessage.Text = "Message";
            // 
            // lblMessageContent
            // 
            this.lblMessageContent.AutoSize = true;
            this.lblMessageContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageContent.ForeColor = System.Drawing.Color.Black;
            this.lblMessageContent.Location = new System.Drawing.Point(117, 323);
            this.lblMessageContent.Name = "lblMessageContent";
            this.lblMessageContent.Size = new System.Drawing.Size(192, 25);
            this.lblMessageContent.TabIndex = 28;
            this.lblMessageContent.Text = "Message content";
            // 
            // MessageDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1472, 719);
            this.Controls.Add(this.lblMessageContent);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSent);
            this.Controls.Add(this.lblSender);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.imgBackArrow);
            this.Controls.Add(this.mnuMessageDetails);
            this.MainMenuStrip = this.mnuMessageDetails;
            this.Name = "MessageDetails";
            this.Text = "MessageDetails";
            this.Load += new System.EventHandler(this.MessageDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBackArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBackArrow;
        private System.Windows.Forms.MenuStrip mnuMessageDetails;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblMessageContent;
    }
}