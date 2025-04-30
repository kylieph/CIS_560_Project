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

        private decimal _subtotal;

        private int _itemCount;

        public CustomerCartForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel.Controls.Count > 0)
            {
                MessageBox.Show($"Thank you for your purchase!\nItems Ordered: {_itemCount}\nSubtotal: ${_subtotal}\nExpect your order within 3-5 business days.");
                flowLayoutPanel.Controls.Clear();
                totalDisplayLabel.Text = "$";
                string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Store.DeleteCartItems", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", _userID);
                        using (SqlDataReader reader = cmd.ExecuteReader()) { }
                    }
                }
            }
            else
            {
                MessageBox.Show("No items in your cart.");
            }
        }

        private void CustomerCartForm_Load(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();

            decimal subtotal = 0;
            int itemCount = 0;
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
                            Label nameLabel = new Label() { Text = itemName, AutoSize = true };
                            string stringPrice = reader["ItemPrice"].ToString();
                            Label priceLabel = new Label() { Text = stringPrice, AutoSize = true };
                            decimal price = Convert.ToDecimal(stringPrice);
                            subtotal += price;
                            string stringQuantity = reader["Quantity"].ToString();
                            Label quantityLabel = new Label() { Text = stringQuantity, AutoSize = true };
                            int quantity = Convert.ToInt32(stringQuantity);
                            itemCount += quantity;
                            string totalPrice = reader["TotalPrice"].ToString();
                            Label totalPriceLabel = new Label() { Text = totalPrice, AutoSize = true };
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

                            flowLayoutPanel.Controls.Add(innerPanel);                         
                        }
                    }
                }
            }
            totalDisplayLabel.Text = $"${subtotal}";
            _subtotal = subtotal;
            _itemCount = itemCount;
        }
    }
}
