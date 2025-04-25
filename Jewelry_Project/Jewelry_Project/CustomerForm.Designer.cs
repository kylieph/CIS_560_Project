namespace Jewelry_Project
{
    partial class CustomerForm
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
            this.profileButton = new System.Windows.Forms.Button();
            this.metalComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.newReleasesButton = new System.Windows.Forms.Button();
            this.itemsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // profileButton
            // 
            this.profileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.profileButton.Location = new System.Drawing.Point(645, 36);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(124, 45);
            this.profileButton.TabIndex = 0;
            this.profileButton.Text = "Profile";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // metalComboBox
            // 
            this.metalComboBox.FormattingEnabled = true;
            this.metalComboBox.Location = new System.Drawing.Point(47, 299);
            this.metalComboBox.Name = "metalComboBox";
            this.metalComboBox.Size = new System.Drawing.Size(153, 28);
            this.metalComboBox.TabIndex = 1;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(47, 392);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(153, 28);
            this.categoryComboBox.TabIndex = 2;
            // 
            // newReleasesButton
            // 
            this.newReleasesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.newReleasesButton.Location = new System.Drawing.Point(47, 200);
            this.newReleasesButton.Name = "newReleasesButton";
            this.newReleasesButton.Size = new System.Drawing.Size(153, 43);
            this.newReleasesButton.TabIndex = 3;
            this.newReleasesButton.Text = "New Releases!";
            this.newReleasesButton.UseVisualStyleBackColor = true;
            this.newReleasesButton.Click += new System.EventHandler(this.newReleasesButton_Click);
            // 
            // itemsFlowLayoutPanel
            // 
            this.itemsFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsFlowLayoutPanel.Location = new System.Drawing.Point(256, 110);
            this.itemsFlowLayoutPanel.Name = "itemsFlowLayoutPanel";
            this.itemsFlowLayoutPanel.Size = new System.Drawing.Size(513, 312);
            this.itemsFlowLayoutPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(31, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(42, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Metal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(43, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Category:";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemsFlowLayoutPanel);
            this.Controls.Add(this.newReleasesButton);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.metalComboBox);
            this.Controls.Add(this.profileButton);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.ComboBox metalComboBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button newReleasesButton;
        private System.Windows.Forms.FlowLayoutPanel itemsFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}