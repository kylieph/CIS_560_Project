﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace Jewelry_Project
{
    /// <summary>
    /// Allows user to login or create a new account
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// User is able to login
        /// </summary>
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text != null && passwordTextBox.Text != null)
            {
                Login(usernameTextBox.Text, passwordTextBox.Text);
            }
			else
			{
				MessageBox.Show("Please enter a username and password.");
			}
		}

        /// <summary>
        /// Decides whether to open up one of the forms or deny the user access
        /// </summary>
        private void Login(string usernameAttempt, string passwordAttempt)
        {
            bool formOpen = false;
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT HashPassword, IsAdmin FROM Store.[User] WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", usernameAttempt);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader["HashPassword"].ToString().Trim();
                            bool isAdmin = Convert.ToBoolean(reader["IsAdmin"]);

                            bool valid = BCrypt.Net.BCrypt.Verify(passwordAttempt, hashedPassword);

                            if (valid)
                            {
                                formOpen = true;
                                if (isAdmin)
                                {
                                    formOpen = true;
                                    AdminForm adminForm = new AdminForm(usernameAttempt);
                                    adminForm.Show();
                                }
                                else
                                {
                                    formOpen = true;
                                    CustomerForm customerForm = new CustomerForm(usernameAttempt);
                                    customerForm.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid password.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username not found.");
                        }
                    }
                }
            }
			if (formOpen)
			{
				this.Hide();
			}

		}

		/// <summary>
		/// Enables the password text box when the user enters a username
		/// </summary>
		private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.Enabled = true;
        }

		/// <summary>
		/// Opens up the create account form
		/// </summary>
		private void newAccountButton_Click(object sender, EventArgs e)
        {
			CreateForm createForm = new CreateForm();
            createForm.Show();
		}
    }
}