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
            this.cartButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filteringFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.filteringFlowLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // profileButton
            // 
            this.profileButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.profileButton.Location = new System.Drawing.Point(133, 3);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(124, 45);
            this.profileButton.TabIndex = 0;
            this.profileButton.Text = "Profile";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // metalComboBox
            // 
            this.metalComboBox.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.metalComboBox.FormattingEnabled = true;
            this.metalComboBox.Location = new System.Drawing.Point(11, 100);
            this.metalComboBox.Name = "metalComboBox";
            this.metalComboBox.Size = new System.Drawing.Size(153, 29);
            this.metalComboBox.TabIndex = 1;
            this.metalComboBox.SelectedIndexChanged += new System.EventHandler(this.metalComboBox_SelectedIndexChanged);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(11, 156);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(153, 29);
            this.categoryComboBox.TabIndex = 2;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // newReleasesButton
            // 
            this.newReleasesButton.AutoSize = true;
            this.newReleasesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newReleasesButton.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.newReleasesButton.Location = new System.Drawing.Point(11, 36);
            this.newReleasesButton.Name = "newReleasesButton";
            this.newReleasesButton.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.newReleasesButton.Size = new System.Drawing.Size(146, 37);
            this.newReleasesButton.TabIndex = 3;
            this.newReleasesButton.Text = "New Releases!";
            this.newReleasesButton.UseVisualStyleBackColor = true;
            this.newReleasesButton.Click += new System.EventHandler(this.newReleasesButton_Click);
            // 
            // itemsFlowLayoutPanel
            // 
            this.itemsFlowLayoutPanel.AutoSize = true;
            this.itemsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.itemsFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsFlowLayoutPanel.Location = new System.Drawing.Point(352, 86);
            this.itemsFlowLayoutPanel.Name = "itemsFlowLayoutPanel";
            this.itemsFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.itemsFlowLayoutPanel.Size = new System.Drawing.Size(12, 12);
            this.itemsFlowLayoutPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Metal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.label3.Location = new System.Drawing.Point(11, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Category:";
            // 
            // cartButton
            // 
            this.cartButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.cartButton.Location = new System.Drawing.Point(3, 3);
            this.cartButton.Name = "cartButton";
            this.cartButton.Size = new System.Drawing.Size(124, 45);
            this.cartButton.TabIndex = 8;
            this.cartButton.Text = "Cart";
            this.cartButton.UseVisualStyleBackColor = true;
            this.cartButton.Click += new System.EventHandler(this.cartButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.usernameLabel.Location = new System.Drawing.Point(398, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(104, 25);
            this.usernameLabel.TabIndex = 9;
            this.usernameLabel.Text = "username";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.BackColor = System.Drawing.Color.FloralWhite;
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.15033F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.84967F));
            this.tableLayoutPanel.Controls.Add(this.filteringFlowLayoutPanel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.itemsFlowLayoutPanel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.17647F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.82353F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1176, 354);
            this.tableLayoutPanel.TabIndex = 10;
            // 
            // filteringFlowLayoutPanel
            // 
            this.filteringFlowLayoutPanel.AutoSize = true;
            this.filteringFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filteringFlowLayoutPanel.Controls.Add(this.label1);
            this.filteringFlowLayoutPanel.Controls.Add(this.newReleasesButton);
            this.filteringFlowLayoutPanel.Controls.Add(this.label2);
            this.filteringFlowLayoutPanel.Controls.Add(this.metalComboBox);
            this.filteringFlowLayoutPanel.Controls.Add(this.label3);
            this.filteringFlowLayoutPanel.Controls.Add(this.categoryComboBox);
            this.filteringFlowLayoutPanel.Controls.Add(this.button1);
            this.filteringFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.filteringFlowLayoutPanel.Location = new System.Drawing.Point(23, 91);
            this.filteringFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.filteringFlowLayoutPanel.Name = "filteringFlowLayoutPanel";
            this.filteringFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.filteringFlowLayoutPanel.Size = new System.Drawing.Size(181, 239);
            this.filteringFlowLayoutPanel.TabIndex = 11;
            this.filteringFlowLayoutPanel.WrapContents = false;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 10F);
            this.button1.Location = new System.Drawing.Point(11, 191);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.button1.Size = new System.Drawing.Size(159, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear All Filters";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clearAllFilters_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Freestyle Script", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(18, 15);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.label4.Size = new System.Drawing.Size(328, 53);
            this.label4.TabIndex = 12;
            this.label4.Text = "Blossom Jewelry Boutique";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Controls.Add(this.usernameLabel);
            this.panel1.Controls.Add(this.cartButton);
            this.panel1.Controls.Add(this.profileButton);
            this.panel1.Location = new System.Drawing.Point(352, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 51);
            this.panel1.TabIndex = 9;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.logoutBtn.Location = new System.Drawing.Point(262, 3);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(124, 45);
            this.logoutBtn.TabIndex = 10;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(999, 544);
            this.Controls.Add(this.tableLayoutPanel);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "CustomerForm";
            this.Text = "Blossom Jewerly";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.filteringFlowLayoutPanel.ResumeLayout(false);
            this.filteringFlowLayoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button cartButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel filteringFlowLayoutPanel;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button logoutBtn;
	}
}