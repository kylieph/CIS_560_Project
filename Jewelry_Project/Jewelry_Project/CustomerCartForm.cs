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
	/// <summary>
	/// Contains all the items that a ccustomer has added to their cart.
	/// </summary>
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

		/// <summary>
		/// Allows to user checkout with the items that is in their cart.
		/// </summary>
		private void checkoutButton_Click(object sender, EventArgs e)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            if (flowLayoutPanel.Controls.Count > 0)
            {
                MessageBox.Show($"Thank you for your purchase!\nItems Ordered: {_itemCount}\nSubtotal: ${_subtotal}\nExpect your order within 3-5 business days.");
                flowLayoutPanel.Controls.Clear();
                totalDisplayLabel.Text = "$";                
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    int orderID = 0;
                    conn.Open();
                    string sql = "INSERT INTO Store.[Orders] (UserID) VALUES (@UserID)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", _userID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orderID = Convert.ToInt32(reader["OrderID"]);
                            }
                        }
                    }

                    using (SqlCommand cmd3 = new SqlCommand("Store.DeleteCartItems", conn))
                    {
                        cmd3.CommandType = CommandType.StoredProcedure;
                        cmd3.Parameters.AddWithValue("@UserID", _userID);
                        cmd3.ExecuteReader();
                    }

                    
                }
            }
            else
            {
                MessageBox.Show("No items in your cart.");
            }

            
        }

		/// <summary>
		/// User is able to add a quantity of 1, if allowed, to the item in their cart.
		/// </summary>
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

                    int quantity = 0;
                    string checkQtySql = "SELECT Quantity FROM Store.[Cart] WHERE UserID = @UserID AND StockItemID = @StockItemID";
                    using (SqlCommand cmd = new SqlCommand(checkQtySql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", _userID);
                        cmd.Parameters.AddWithValue("@StockItemID", itemID);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            quantity = Convert.ToInt32(result);
                    }
                    int quantityMax = 0;
                    string checkMaxSql = "SELECT StockQuantity FROM Store.[Items] WHERE StockItemID = @StockItemID";
                    using (SqlCommand cmd = new SqlCommand(checkMaxSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@StockItemID", itemID);
                        quantityMax = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    if (quantity >= quantityMax)
                    {
                        MessageBox.Show("Out of stock.");
                        return;
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

		/// <summary>
		/// User is able to remove a quantity of 1, if allowed, to the item in their cart.
		/// </summary>
		private void minusButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b == null || b.Tag == null) return;

            string itemName = b.Tag.ToString();
            int itemID = 0;

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // Get item ID
                string getIDSql = "SELECT StockItemID FROM Store.[Items] WHERE ItemName = @ItemName";
                using (SqlCommand cmd = new SqlCommand(getIDSql, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        itemID = Convert.ToInt32(result);
                }

                // Call procedure to decrease quantity
                using (SqlCommand cmd = new SqlCommand("Store.DecreaseCartQuantity", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", _userID);
                    cmd.Parameters.AddWithValue("@StockItemID", itemID);
                    cmd.ExecuteNonQuery();
                }

                // Check if quantity is now 0 or less
                int quantity = 0;
                string checkQtySql = "SELECT Quantity FROM Store.[Cart] WHERE UserID = @UserID AND StockItemID = @StockItemID";
                using (SqlCommand cmd = new SqlCommand(checkQtySql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", _userID);
                    cmd.Parameters.AddWithValue("@StockItemID", itemID);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        quantity = Convert.ToInt32(result);
                }

                // If quantity <= 0, delete the row
                if (quantity <= 0)
                {
                    string deleteSql = "DELETE FROM Store.[Cart] WHERE UserID = @UserID AND StockItemID = @StockItemID";
                    using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", _userID);
                        cmd.Parameters.AddWithValue("@StockItemID", itemID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Refresh cart display
            CustomerCartForm_Load(null, null);
        }

		/// <summary>
		/// Loads the cart items for the customer.
		/// </summary>
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
    }
}
