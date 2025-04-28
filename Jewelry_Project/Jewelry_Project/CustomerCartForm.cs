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
    public partial class CustomerCartForm : Form
    {
        private int _userID;

        public CustomerCartForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Thank you for your purchase!\nOrder ID number: \nItems Ordered: \nSubtotal: {totalDisplayLabel.Text}\nExpect your order within 3-5 business days.");
            flowLayoutPanel.Controls.Clear();
        }

        private void CustomerCartForm_Load(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Store.GetCartItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", _userID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["ItemName"].ToString();
                            Label nameLabel = new Label() { Text = itemName };
                            string price = reader["ItemPrice"].ToString();
                            Label priceLabel = new Label() { Text = price };
                            string quantity = reader["Quantity"].ToString();
                            Label quantityLabel = new Label() { Text = quantity };
                            string totalPrice = reader["TotalPrice"].ToString();
                            Label totalPriceLabel = new Label() { Text = totalPrice };
                            FlowLayoutPanel innerPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.LeftToRight,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            };
                            innerPanel.Controls.Add(nameLabel);
                            innerPanel.Controls.Add(priceLabel);
                            innerPanel.Controls.Add(quantityLabel);
                            innerPanel.Controls.Add(totalPriceLabel);

                        }
                    }
                }
            }
        }
    }
}
