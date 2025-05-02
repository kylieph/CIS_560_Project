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

namespace Jewelry_Project
{
	public partial class CreateForm : Form
	{
		public CreateForm()
		{
			InitializeComponent();
			passwordTextBox.Enabled = true;
			phoneNumberBox.Enabled = true;
			this.MinimumSize = new Size(500, 600);
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}

		private void newAccountButton_Click(object sender, EventArgs e)
		{
			int usernameCount;
			int emailCount;

			string usernameAttempt = usernameTextBox.Text;
			string emailAttempt = emailTextBox.Text;
			string passwordAttempt = passwordTextBox.Text;
			string nameAttempt = nameTextBox.Text;
			string phoneAttempt = phoneNumberBox.Text;
			string addressAttempt = addressTextBox.Text;
			string cityAttempt = cityBox.Text;
			string stateAttempt = stateBox.Text;
			int zipAttempt;
			bool zB = int.TryParse(zipcodeBox.Text, out zipAttempt);

			if (string.IsNullOrWhiteSpace(emailAttempt) || string.IsNullOrWhiteSpace(usernameAttempt) || string.IsNullOrWhiteSpace(passwordAttempt))
			{
				MessageBox.Show("All fields are required.");
				return;
			}

			string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Store.[User] WHERE Username = @Username", conn))
				{
					cmd.Parameters.AddWithValue("@Username", usernameAttempt);
					usernameCount = (int)cmd.ExecuteScalar();
				}
				if (usernameCount > 0)
				{
					MessageBox.Show("Username taken.");
					return;
				}
				using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Store.[User] WHERE Email = @Email", conn))
				{
					cmd.Parameters.AddWithValue("@Email", emailAttempt);
					emailCount = (int)cmd.ExecuteScalar();
				}
				if (emailCount > 0)
				{
					MessageBox.Show("Email is already registered.");
					return;
				}

				string hashedPassword = BCrypt.Net.BCrypt.HashPassword(passwordAttempt);
				using (SqlCommand cmdInsert = new SqlCommand("Store.CreateUserInfo", conn))
				{
					cmdInsert.CommandType = CommandType.StoredProcedure;

					cmdInsert.Parameters.AddWithValue("@Email", emailAttempt);
					cmdInsert.Parameters.AddWithValue("@Username", usernameAttempt);
					cmdInsert.Parameters.AddWithValue("@NormPassword", passwordAttempt);
					cmdInsert.Parameters.AddWithValue("@HashPassword", hashedPassword);
					cmdInsert.Parameters.AddWithValue("@Name", nameAttempt);
					cmdInsert.Parameters.AddWithValue("@PhoneNumber", phoneAttempt);
					cmdInsert.Parameters.AddWithValue("@IsAdmin", 0);
					cmdInsert.Parameters.AddWithValue("@AccountOpenedDate", DateTime.Now);
					cmdInsert.Parameters.AddWithValue("@AddressLine", addressAttempt);
					cmdInsert.Parameters.AddWithValue("@City", cityAttempt);
					cmdInsert.Parameters.AddWithValue("@State", stateAttempt);
					cmdInsert.Parameters.AddWithValue("@Zipcode", zipAttempt);

					cmdInsert.ExecuteNonQuery();
				}

				MessageBox.Show("Account created successfully! You can now use your username & password to login on the login form.");
				this.Close();
			}
		}
	}
}