namespace Jewelry_Project
{
    partial class AdminForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addItemButton = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.itemsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.filteringFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.popularItemsButton = new System.Windows.Forms.Button();
            this.highestPriceButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.customersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.popularGoldsmithLayout = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.filteringFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.15033F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.84967F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.15033F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.84967F));
            this.tableLayoutPanel.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.itemsFlowLayoutPanel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.filteringFlowLayoutPanel, 0, 1);
            this.tableLayoutPanel.Font = new System.Drawing.Font("Mongolian Baiti", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel.ForeColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.17647F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.82353F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.17647F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.82353F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1018, 369);
            this.tableLayoutPanel.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.addItemButton);
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Location = new System.Drawing.Point(306, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 49);
            this.panel1.TabIndex = 9;
            // 
            // addItemButton
            // 
            this.addItemButton.AutoSize = true;
            this.addItemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addItemButton.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemButton.Location = new System.Drawing.Point(3, 9);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.addItemButton.Size = new System.Drawing.Size(128, 37);
            this.addItemButton.TabIndex = 8;
            this.addItemButton.Text = "Add Product";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.AutoSize = true;
            this.logoutBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logoutBtn.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.Location = new System.Drawing.Point(177, 9);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.logoutBtn.Size = new System.Drawing.Size(84, 37);
            this.logoutBtn.TabIndex = 9;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // itemsFlowLayoutPanel
            // 
            this.itemsFlowLayoutPanel.AutoSize = true;
            this.itemsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.itemsFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsFlowLayoutPanel.Location = new System.Drawing.Point(306, 89);
            this.itemsFlowLayoutPanel.Name = "itemsFlowLayoutPanel";
            this.itemsFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.itemsFlowLayoutPanel.Size = new System.Drawing.Size(12, 12);
            this.itemsFlowLayoutPanel.TabIndex = 4;
            // 
            // filteringFlowLayoutPanel
            // 
            this.filteringFlowLayoutPanel.AutoScroll = true;
            this.filteringFlowLayoutPanel.AutoSize = true;
            this.filteringFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filteringFlowLayoutPanel.Controls.Add(this.label1);
            this.filteringFlowLayoutPanel.Controls.Add(this.popularItemsButton);
            this.filteringFlowLayoutPanel.Controls.Add(this.highestPriceButton);
            this.filteringFlowLayoutPanel.Controls.Add(this.label2);
            this.filteringFlowLayoutPanel.Controls.Add(this.customersTableLayoutPanel);
            this.filteringFlowLayoutPanel.Controls.Add(this.label3);
            this.filteringFlowLayoutPanel.Controls.Add(this.popularGoldsmithLayout);
            this.filteringFlowLayoutPanel.Controls.Add(this.button1);
            this.filteringFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.filteringFlowLayoutPanel.Location = new System.Drawing.Point(18, 89);
            this.filteringFlowLayoutPanel.Name = "filteringFlowLayoutPanel";
            this.filteringFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.filteringFlowLayoutPanel.Size = new System.Drawing.Size(282, 261);
            this.filteringFlowLayoutPanel.TabIndex = 11;
            this.filteringFlowLayoutPanel.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter Items:";
            // 
            // popularItemsButton
            // 
            this.popularItemsButton.AutoSize = true;
            this.popularItemsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.popularItemsButton.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popularItemsButton.Location = new System.Drawing.Point(15, 36);
            this.popularItemsButton.Name = "popularItemsButton";
            this.popularItemsButton.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.popularItemsButton.Size = new System.Drawing.Size(213, 58);
            this.popularItemsButton.TabIndex = 3;
            this.popularItemsButton.Text = "Most Popular Items in \r\nthe Last 3 Months";
            this.popularItemsButton.UseVisualStyleBackColor = true;
            this.popularItemsButton.Click += new System.EventHandler(this.popularItemsButton_Click);
            // 
            // highestPriceButton
            // 
            this.highestPriceButton.AutoSize = true;
            this.highestPriceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.highestPriceButton.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highestPriceButton.Location = new System.Drawing.Point(15, 100);
            this.highestPriceButton.Name = "highestPriceButton";
            this.highestPriceButton.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.highestPriceButton.Size = new System.Drawing.Size(136, 37);
            this.highestPriceButton.TabIndex = 12;
            this.highestPriceButton.Text = "Highest Price";
            this.highestPriceButton.UseVisualStyleBackColor = true;
            this.highestPriceButton.Click += new System.EventHandler(this.highestPriceButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Highest Spending Customers:";
            // 
            // customersTableLayoutPanel
            // 
            this.customersTableLayoutPanel.AutoScroll = true;
            this.customersTableLayoutPanel.AutoSize = true;
            this.customersTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customersTableLayoutPanel.ColumnCount = 2;
            this.customersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.53226F));
            this.customersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.46774F));
            this.customersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.53226F));
            this.customersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.46774F));
            this.customersTableLayoutPanel.Location = new System.Drawing.Point(15, 164);
            this.customersTableLayoutPanel.Name = "customersTableLayoutPanel";
            this.customersTableLayoutPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.customersTableLayoutPanel.RowCount = 2;
            this.customersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customersTableLayoutPanel.Size = new System.Drawing.Size(6, 6);
            this.customersTableLayoutPanel.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Most Popular Goldsmith";
            // 
            // popularGoldsmithLayout
            // 
            this.popularGoldsmithLayout.AutoScroll = true;
            this.popularGoldsmithLayout.AutoSize = true;
            this.popularGoldsmithLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.popularGoldsmithLayout.ColumnCount = 2;
            this.popularGoldsmithLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.53226F));
            this.popularGoldsmithLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.46774F));
            this.popularGoldsmithLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.53226F));
            this.popularGoldsmithLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.46774F));
            this.popularGoldsmithLayout.Location = new System.Drawing.Point(15, 197);
            this.popularGoldsmithLayout.Name = "popularGoldsmithLayout";
            this.popularGoldsmithLayout.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.popularGoldsmithLayout.RowCount = 2;
            this.popularGoldsmithLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.popularGoldsmithLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.popularGoldsmithLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.popularGoldsmithLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.popularGoldsmithLayout.Size = new System.Drawing.Size(6, 6);
            this.popularGoldsmithLayout.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 209);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.button1.Size = new System.Drawing.Size(159, 37);
            this.button1.TabIndex = 14;
            this.button1.Text = "Clear All Filters";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearAllFilter_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(948, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.filteringFlowLayoutPanel.ResumeLayout(false);
            this.filteringFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel filteringFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button popularItemsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button highestPriceButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button logoutBtn;
		private System.Windows.Forms.TableLayoutPanel customersTableLayoutPanel;
		private System.Windows.Forms.FlowLayoutPanel itemsFlowLayoutPanel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TableLayoutPanel popularGoldsmithLayout;
	}
}