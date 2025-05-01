namespace Jewelry_Project
{
    partial class CustomerCartForm
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
            this.cartLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.totalDisplayLabel = new System.Windows.Forms.Label();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // cartLabel
            // 
            this.cartLabel.AutoSize = true;
            this.cartLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14F);
            this.cartLabel.Location = new System.Drawing.Point(334, 31);
            this.cartLabel.Name = "cartLabel";
            this.cartLabel.Size = new System.Drawing.Size(125, 30);
            this.cartLabel.TabIndex = 1;
            this.cartLabel.Text = "Your Cart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.label1.Location = new System.Drawing.Point(182, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total:";
            // 
            // totalDisplayLabel
            // 
            this.totalDisplayLabel.AutoSize = true;
            this.totalDisplayLabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.totalDisplayLabel.Location = new System.Drawing.Point(260, 373);
            this.totalDisplayLabel.Name = "totalDisplayLabel";
            this.totalDisplayLabel.Size = new System.Drawing.Size(24, 25);
            this.totalDisplayLabel.TabIndex = 3;
            this.totalDisplayLabel.Text = "$";
            // 
            // checkoutButton
            // 
            this.checkoutButton.AutoSize = true;
            this.checkoutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkoutButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.checkoutButton.Location = new System.Drawing.Point(507, 362);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Padding = new System.Windows.Forms.Padding(5);
            this.checkoutButton.Size = new System.Drawing.Size(125, 45);
            this.checkoutButton.TabIndex = 4;
            this.checkoutButton.Text = "Checkout";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(129, 103);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(538, 218);
            this.flowLayoutPanel.TabIndex = 5;
            // 
            // CustomerCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.checkoutButton);
            this.Controls.Add(this.totalDisplayLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cartLabel);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "CustomerCartForm";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.CustomerCartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cartLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalDisplayLabel;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}