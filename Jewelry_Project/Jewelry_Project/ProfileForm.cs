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
    public partial class ProfileForm : Form
    {
		private string _username;

		public ProfileForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT Email, Username, CustomerName, PhoneNumber FROM Store.[User] WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", _username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["CustomerName"].ToString();
                            nameLabel.Text = name;
                            string email = reader["Email"].ToString();
                            emailDisplayLabel2.Text = email;
                            string username = reader["Username"].ToString();
                            usernameDisplayLabel.Text = username;
                            string phoneNumber = reader["PhoneNumber"].ToString();
                            numberDisplayLabel2.Text = phoneNumber;
                        }
                    }
                }
            }
        }
    }
}
