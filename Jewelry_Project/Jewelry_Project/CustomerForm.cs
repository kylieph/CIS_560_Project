using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry_Project
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm();
            profileForm.Show();
        }

        private void newReleasesButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Store.GetAllMetalTypes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string metalName = reader["MetalName"].ToString();
                            metalComboBox.Items.Add(metalName);
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("Store.GetAllCategoryTypes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string categoryName = reader["CategoryName"].ToString();
                            categoryComboBox.Items.Add(categoryName);
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("Store.GetAllProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["ItemName"].ToString();
                            string description = reader["Description"].ToString();
                            decimal itemPrice = (decimal)reader["ItemPrice"];

                            Panel itemPanel = new Panel()
                            {
                                Width = 50,
                                Height = 50,
                                Margin = new Padding(3)
                            };

                            Label nameLabel = new Label { Text = itemName, AutoSize = true };
                            Label priceLabel = new Label { Text = "Price: $" + itemPrice.ToString("F2"), AutoSize = true };
                            Label descLabel = new Label { Text = description, AutoSize = true };

                            itemPanel.Controls.Add(nameLabel);
                            itemPanel.Controls.Add(priceLabel);
                            itemPanel.Controls.Add(descLabel);

                            // Stack labels vertically
                            /*
                            nameLabel.Location = new Point(5, 5);
                            priceLabel.Location = new Point(5, 25);
                            descLabel.Location = new Point(5, 45);
                            */

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }
            }
        }
    }
}
