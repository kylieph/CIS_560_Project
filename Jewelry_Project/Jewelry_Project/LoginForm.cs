using System;
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
    public partial class LoginForm : Form
    {
        private bool _loginCheck = false;
        public LoginForm()
        {
            InitializeComponent();
            loginButton.Click -= loginButton_Click;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!_loginCheck)
            {
                if (usernameTextBox.Text != null && passwordTextBox.Text != null)
                {
                    Login(usernameTextBox.Text, passwordTextBox.Text);
                }
            }
        }

        private void Login(string usernameAttempt, string passwordAttempt)
        {
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

							Console.WriteLine("Stored hash: '" + hashedPassword + "'");
							bool valid = BCrypt.Net.BCrypt.Verify(passwordAttempt, hashedPassword);
                            /*bool valid = false;
                            if (passwordAttempt.Equals(hashedPassword))
                            {
                                valid = true;
                            }*/


                            if (valid)
                            {
                                if (isAdmin)
                                {
                                    AdminForm adminForm = new AdminForm(usernameAttempt);
                                    adminForm.Show();
                                }
                                else
                                {
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
			_loginCheck = true;
            this.Hide();
		}

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.Enabled = true;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            loginButton.Click += loginButton_Click;
        }

        private void newAccountButton_Click(object sender, EventArgs e)
        {
			/*int count;
            string usernameAttempt = usernameTextBox.Text;
            string emailAttempt = emailTextBox.Text;
            string passwordAttempt = passwordTextBox.Text;

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Store.[User] WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", usernameAttempt);
                    count = (int)cmd.ExecuteScalar();
                }
                if (count > 0)
                {
                    MessageBox.Show("Username taken.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(emailAttempt) || string.IsNullOrWhiteSpace(usernameAttempt) || string.IsNullOrWhiteSpace(passwordAttempt))
                {
                    MessageBox.Show("All fields are required.");
                    return;
                }
                using (SqlCommand cmdInsert = new SqlCommand("Store.CreateUser", conn))
                {
                    cmdInsert.CommandType = CommandType.StoredProcedure;

                    cmdInsert.Parameters.AddWithValue("@Email", emailAttempt);
                    cmdInsert.Parameters.AddWithValue("@Username", usernameAttempt);
                    cmdInsert.Parameters.AddWithValue("@NormPassword", passwordAttempt);
                    cmdInsert.Parameters.AddWithValue("@IsAdmin", 0);
                    cmdInsert.Parameters.AddWithValue("@AccountOpenedDate", DateTime.Now);

                    cmdInsert.ExecuteNonQuery();
                }

                MessageBox.Show("Account created successfully!");
                if (usernameTextBox.Text != null && passwordTextBox.Text != null)
                {
                    Login(usernameTextBox.Text, passwordTextBox.Text);
                }
            }           */
			CreateForm createForm = new CreateForm();
            createForm.Show();
		}
    }
}
