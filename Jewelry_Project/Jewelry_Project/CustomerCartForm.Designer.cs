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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartLabel
            // 
            this.cartLabel.AutoSize = true;
            this.cartLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14F);
            this.cartLabel.Location = new System.Drawing.Point(236, 22);
            this.cartLabel.Name = "cartLabel";
            this.cartLabel.Size = new System.Drawing.Size(125, 30);
            this.cartLabel.TabIndex = 1;
            this.cartLabel.Text = "Your Cart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.label1.Location = new System.Drawing.Point(27, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total:";
            // 
            // totalDisplayLabel
            // 
            this.totalDisplayLabel.AutoSize = true;
            this.totalDisplayLabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.totalDisplayLabel.Location = new System.Drawing.Point(134, 322);
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
            this.checkoutButton.Location = new System.Drawing.Point(474, 312);
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
            this.flowLayoutPanel.Location = new System.Drawing.Point(32, 76);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(538, 218);
            this.flowLayoutPanel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.totalDisplayLabel);
            this.panel1.Controls.Add(this.checkoutButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel);
            this.panel1.Controls.Add(this.cartLabel);
            this.panel1.Location = new System.Drawing.Point(101, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 370);
            this.panel1.TabIndex = 6;
            // 
            // CustomerCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "CustomerCartForm";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.CustomerCartForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cartLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalDisplayLabel;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel1;
    }
}