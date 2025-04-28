namespace Jewelry_Project
{
    partial class ProfileForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.numberDisplayLabel = new System.Windows.Forms.Label();
            this.emailDisplayLabel = new System.Windows.Forms.Label();
            this.usernameDisplayabel = new System.Windows.Forms.Label();
            this.numberDisplayLabel2 = new System.Windows.Forms.Label();
            this.emailDisplayLabel2 = new System.Windows.Forms.Label();
            this.usernameDisplayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.nameLabel.Location = new System.Drawing.Point(88, 87);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(89, 32);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.emailLabel.Location = new System.Drawing.Point(88, 252);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(86, 29);
            this.emailLabel.TabIndex = 1;
            this.emailLabel.Text = "Email: ";
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.phoneNumberLabel.Location = new System.Drawing.Point(88, 319);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(182, 29);
            this.phoneNumberLabel.TabIndex = 2;
            this.phoneNumberLabel.Text = "Phone Number:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameLabel.Location = new System.Drawing.Point(88, 181);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(130, 29);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // numberDisplayLabel
            // 
            this.numberDisplayLabel.AutoSize = true;
            this.numberDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numberDisplayLabel.Location = new System.Drawing.Point(331, 319);
            this.numberDisplayLabel.Name = "numberDisplayLabel";
            this.numberDisplayLabel.Size = new System.Drawing.Size(0, 29);
            this.numberDisplayLabel.TabIndex = 4;
            // 
            // emailDisplayLabel
            // 
            this.emailDisplayLabel.AutoSize = true;
            this.emailDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.emailDisplayLabel.Location = new System.Drawing.Point(331, 252);
            this.emailDisplayLabel.Name = "emailDisplayLabel";
            this.emailDisplayLabel.Size = new System.Drawing.Size(0, 29);
            this.emailDisplayLabel.TabIndex = 5;
            // 
            // usernameDisplayabel
            // 
            this.usernameDisplayabel.AutoSize = true;
            this.usernameDisplayabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameDisplayabel.Location = new System.Drawing.Point(331, 181);
            this.usernameDisplayabel.Name = "usernameDisplayabel";
            this.usernameDisplayabel.Size = new System.Drawing.Size(0, 29);
            this.usernameDisplayabel.TabIndex = 6;
            // 
            // numberDisplayLabel2
            // 
            this.numberDisplayLabel2.AutoSize = true;
            this.numberDisplayLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numberDisplayLabel2.Location = new System.Drawing.Point(378, 319);
            this.numberDisplayLabel2.Name = "numberDisplayLabel2";
            this.numberDisplayLabel2.Size = new System.Drawing.Size(176, 29);
            this.numberDisplayLabel2.TabIndex = 7;
            this.numberDisplayLabel2.Text = "Phone Number";
            // 
            // emailDisplayLabel2
            // 
            this.emailDisplayLabel2.AutoSize = true;
            this.emailDisplayLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.emailDisplayLabel2.Location = new System.Drawing.Point(378, 252);
            this.emailDisplayLabel2.Name = "emailDisplayLabel2";
            this.emailDisplayLabel2.Size = new System.Drawing.Size(74, 29);
            this.emailDisplayLabel2.TabIndex = 8;
            this.emailDisplayLabel2.Text = "Email";
            // 
            // usernameDisplayLabel
            // 
            this.usernameDisplayLabel.AutoSize = true;
            this.usernameDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameDisplayLabel.Location = new System.Drawing.Point(378, 181);
            this.usernameDisplayLabel.Name = "usernameDisplayLabel";
            this.usernameDisplayLabel.Size = new System.Drawing.Size(124, 29);
            this.usernameDisplayLabel.TabIndex = 9;
            this.usernameDisplayLabel.Text = "Username";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usernameDisplayLabel);
            this.Controls.Add(this.emailDisplayLabel2);
            this.Controls.Add(this.numberDisplayLabel2);
            this.Controls.Add(this.usernameDisplayabel);
            this.Controls.Add(this.emailDisplayLabel);
            this.Controls.Add(this.numberDisplayLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label numberDisplayLabel;
        private System.Windows.Forms.Label emailDisplayLabel;
        private System.Windows.Forms.Label usernameDisplayabel;
        private System.Windows.Forms.Label numberDisplayLabel2;
        private System.Windows.Forms.Label emailDisplayLabel2;
        private System.Windows.Forms.Label usernameDisplayLabel;
    }
}