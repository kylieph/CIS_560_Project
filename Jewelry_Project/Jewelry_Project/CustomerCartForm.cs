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

        private void plusButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string itemName;
            int itemID = 0;
            if (b != null && b.Tag != null)
            {
                itemName = b.Tag.ToString();
                string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT StockItemID FROM Store.[Items] WHERE ItemName = @ItemName";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", itemName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemID = Convert.ToInt32(reader["StockItemID"]);
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("Store.IncreaseCartQuantity", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", _userID);
                        cmd.Parameters.AddWithValue("@StockItemID", itemID);
                        cmd.ExecuteReader();
                    }
				}
            }
            CustomerCartForm_Load(null, null);
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string itemName;
            int itemID = 0;
            if (b != null && b.Tag != null)
            {
                itemName = b.Tag.ToString();
                string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT StockItemID FROM Store.[Items] WHERE ItemName = @ItemName";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", itemName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemID = Convert.ToInt32(reader["StockItemID"]);
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("Store.DecreaseCartQuantity", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", _userID);
                        cmd.Parameters.AddWithValue("@StockItemID", itemID);
                        cmd.ExecuteReader();
                    }
                }
            }
            CustomerCartForm_Load(null, null);
        }

        public void CustomerCartForm_Load(object sender, EventArgs e)
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

                            DataGridViewRow row = new DataGridViewRow();

                            string itemName = reader["ItemName"].ToString();
                            Label nameLabel = new Label() { Text = itemName, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Margin = new Padding(5) };

                            string stringQuantity = reader["Quantity"].ToString();
                            Label quantityLabel = new Label() { Text = stringQuantity, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Margin = new Padding(5) };
                            int quantity = Convert.ToInt32(stringQuantity);
                            itemCount += quantity;

                            string stringPrice = reader["ItemPrice"].ToString();
                            Label priceLabel = new Label() { Text = stringPrice, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Margin = new Padding(5) };
                            decimal price = Convert.ToDecimal(stringPrice);
                            subtotal += (price * quantity);

                            string totalPrice = reader["TotalPrice"].ToString();
                            Label totalPriceLabel = new Label() { Text = totalPrice, AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Margin = new Padding(5) };

                            TableLayoutPanel innerPanel = new TableLayoutPanel()
                            {
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                ColumnCount = 6,
                                RowCount = 1,
                                Margin = new Padding(3),
                                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                            };

                            Button minusButton = new Button() { Text = "-", AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(5) };
                            minusButton.Tag = itemName;
                            minusButton.Click += minusButton_Click;
                            Button plusButton = new Button() { Text = "+", AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(5) };
                            plusButton.Tag = itemName;
                            plusButton.Click += plusButton_Click;

                            innerPanel.Controls.Add(nameLabel, 0, 0);
                            innerPanel.Controls.Add(priceLabel, 1, 0);
                            innerPanel.Controls.Add(minusButton, 2, 0);
                            innerPanel.Controls.Add(quantityLabel, 3, 0);
                            innerPanel.Controls.Add(plusButton, 4, 0);
                            innerPanel.Controls.Add(totalPriceLabel, 5, 0);

                            flowLayoutPanel.Controls.Add(innerPanel);
                            if (itemCount == 0)
                            {
                                minusButton.Enabled = false;
							}
                        }
                    }
                }
            }
            totalDisplayLabel.Text = $"${subtotal}";
            _subtotal = subtotal;
            _itemCount = itemCount;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
