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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
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
            this.metalComboBox.Location = new System.Drawing.Point(52, 254);
            this.metalComboBox.Name = "metalComboBox";
            this.metalComboBox.Size = new System.Drawing.Size(153, 28);
            this.metalComboBox.TabIndex = 1;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(52, 356);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(153, 28);
            this.categoryComboBox.TabIndex = 2;
            // 
            // newReleasesButton
            // 
            this.newReleasesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.newReleasesButton.Location = new System.Drawing.Point(52, 155);
            this.newReleasesButton.Name = "newReleasesButton";
            this.newReleasesButton.Size = new System.Drawing.Size(153, 43);
            this.newReleasesButton.TabIndex = 3;
            this.newReleasesButton.Text = "New Releases!";
            this.newReleasesButton.UseVisualStyleBackColor = true;
            this.newReleasesButton.Click += new System.EventHandler(this.newReleasesButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(256, 110);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(513, 312);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.newReleasesButton);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.metalComboBox);
            this.Controls.Add(this.profileButton);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.ComboBox metalComboBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button newReleasesButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}