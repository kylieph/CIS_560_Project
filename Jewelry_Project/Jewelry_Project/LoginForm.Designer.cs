namespace Jewelry_Project
{
    partial class LoginForm
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
			this.loginButton = new System.Windows.Forms.Button();
			this.newAccountButton = new System.Windows.Forms.Button();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.usernameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// loginButton
			// 
			this.loginButton.AutoSize = true;
			this.loginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.loginButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loginButton.Location = new System.Drawing.Point(497, 365);
			this.loginButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.loginButton.Name = "loginButton";
			this.loginButton.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
			this.loginButton.Size = new System.Drawing.Size(139, 74);
			this.loginButton.TabIndex = 4;
			this.loginButton.Text = "Login";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// newAccountButton
			// 
			this.newAccountButton.AutoSize = true;
			this.newAccountButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.newAccountButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.newAccountButton.Location = new System.Drawing.Point(458, 497);
			this.newAccountButton.Margin = new System.Windows.Forms.Padding(4);
			this.newAccountButton.Name = "newAccountButton";
			this.newAccountButton.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
			this.newAccountButton.Size = new System.Drawing.Size(342, 74);
			this.newAccountButton.TabIndex = 5;
			this.newAccountButton.Text = "Create New Account";
			this.newAccountButton.UseVisualStyleBackColor = true;
			this.newAccountButton.Click += new System.EventHandler(this.newAccountButton_Click);
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Enabled = false;
			this.passwordTextBox.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordTextBox.ForeColor = System.Drawing.Color.DimGray;
			this.passwordTextBox.Location = new System.Drawing.Point(468, 275);
			this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(251, 38);
			this.passwordTextBox.TabIndex = 3;
			this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14F);
			this.passwordLabel.Location = new System.Drawing.Point(253, 269);
			this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(184, 40);
			this.passwordLabel.TabIndex = 1;
			this.passwordLabel.Text = "Password: ";
			// 
			// usernameLabel
			// 
			this.usernameLabel.AutoSize = true;
			this.usernameLabel.Font = new System.Drawing.Font("Mongolian Baiti", 14F);
			this.usernameLabel.Location = new System.Drawing.Point(244, 192);
			this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(193, 40);
			this.usernameLabel.TabIndex = 0;
			this.usernameLabel.Text = "Username: ";
			// 
			// usernameTextBox
			// 
			this.usernameTextBox.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.usernameTextBox.ForeColor = System.Drawing.Color.DimGray;
			this.usernameTextBox.Location = new System.Drawing.Point(468, 194);
			this.usernameTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.usernameTextBox.Name = "usernameTextBox";
			this.usernameTextBox.Size = new System.Drawing.Size(251, 38);
			this.usernameTextBox.TabIndex = 2;
			this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14F);
			this.label1.Location = new System.Drawing.Point(253, 512);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(179, 40);
			this.label1.TabIndex = 6;
			this.label1.Text = "New user?";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 14F);
			this.label2.Location = new System.Drawing.Point(221, 76);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(640, 40);
			this.label2.TabIndex = 7;
			this.label2.Text = "Welcome to Blossom Jewelry Boutique!";
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FloralWhite;
			this.ClientSize = new System.Drawing.Size(1067, 651);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.newAccountButton);
			this.Controls.Add(this.loginButton);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.usernameTextBox);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.usernameLabel);
			this.ForeColor = System.Drawing.Color.DimGray;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "LoginForm";
			this.Text = "Login";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.Button newAccountButton;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.TextBox usernameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}