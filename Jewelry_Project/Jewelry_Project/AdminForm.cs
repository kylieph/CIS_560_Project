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
    public partial class AdminForm : Form
    {
        public AdminForm(string username)
        {
            InitializeComponent();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}

        public void AdminForm_Load(object sender, EventArgs e)
        {
            filteringFlowLayoutPanel.AutoSize = true;
            filteringFlowLayoutPanel.Margin = new Padding(5);

            itemsFlowLayoutPanel.Controls.Clear();
            itemsFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            itemsFlowLayoutPanel.WrapContents = true;
            itemsFlowLayoutPanel.AutoScroll = true;
            itemsFlowLayoutPanel.Dock = DockStyle.Fill;

            Label header1 = new Label { Text = "Customer", Font = new Font("Mongolian Baiti", 10, FontStyle.Italic), AutoSize = true, Margin = new Padding(3) };
            Label header2 = new Label { Text = "Total Spent", Font = new Font("Mongolian Baiti", 10, FontStyle.Italic), AutoSize = true, Anchor = AnchorStyles.Right, Margin = new Padding(3) };

            customersTableLayoutPanel.RowCount = 0;
            customersTableLayoutPanel.ColumnCount = 2;
            customersTableLayoutPanel.Controls.Clear();
            customersTableLayoutPanel.ColumnStyles.Clear();
            customersTableLayoutPanel.RowStyles.Clear();
            customersTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            customersTableLayoutPanel.RowCount++;
            customersTableLayoutPanel.Controls.Add(header1, 0, 0);
            customersTableLayoutPanel.Controls.Add(header2, 1, 0);

			Label header3 = new Label { Text = "Goldsmith", Font = new Font("Mongolian Baiti", 10, FontStyle.Italic), AutoSize = true, Margin = new Padding(3) };
			Label header4 = new Label { Text = "Total Sales", Font = new Font("Mongolian Baiti", 10, FontStyle.Italic), AutoSize = true, Anchor = AnchorStyles.Right, Margin = new Padding(3) };

			popularGoldsmithLayout.RowCount = 0;
			popularGoldsmithLayout.ColumnCount = 2;
			popularGoldsmithLayout.Controls.Clear();
			popularGoldsmithLayout.ColumnStyles.Clear();
			popularGoldsmithLayout.RowStyles.Clear();
			popularGoldsmithLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

			popularGoldsmithLayout.RowCount++;
			popularGoldsmithLayout.Controls.Add(header3, 0, 0);
			popularGoldsmithLayout.Controls.Add(header4, 1, 0);


			string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
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
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                BackColor = Color.White,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(8),
                            };

                            Label nameLabel = new Label { Text = itemName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = "$" + itemPrice.ToString("F2"), Font = new Font("Mongolian Baiti", 10), AutoSize = true };

                            Button deleteItem = new Button();
                            deleteItem.Text = "Delete Product";
                            deleteItem.Click += deleteItem_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                Margin = new Padding(10),
                            };

                            flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(deleteItem);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("Store.GetHighestSpendingCustomers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int rowCount = 1;
                        while (reader.Read())
                        {
                            string userName = reader["Username"].ToString();
                            string itemPrice = reader["TotalSpent"].ToString();

                            customersTableLayoutPanel.RowCount++;
                            customersTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                            Label nameLabel = new Label { Text = userName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = $"${itemPrice}", Font = new Font("Mongolian Baiti", 10), TextAlign = ContentAlignment.MiddleRight, AutoSize = true, Anchor = AnchorStyles.Right };
                            
                            customersTableLayoutPanel.Controls.Add(nameLabel, 0, rowCount);
                            customersTableLayoutPanel.Controls.Add(priceLabel, 1, rowCount);

                            rowCount++;
                        }
                    }
                }

				using (SqlCommand cmd = new SqlCommand("Store.GetPopularGoldsmith", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						int rowCount = 1;
						while (reader.Read())
						{
							string userName = reader["GoldsmithName"].ToString();
							string totalSales = reader["TotalSales"].ToString();

							popularGoldsmithLayout.RowCount++;
							popularGoldsmithLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

							Label nameLabel = new Label { Text = userName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
							Label totalSalesLabel = new Label { Text = "$ " + totalSales, Font = new Font("Mongolian Baiti", 10), TextAlign = ContentAlignment.MiddleRight, AutoSize = true, Anchor = AnchorStyles.Right };

							popularGoldsmithLayout.Controls.Add(nameLabel, 0, rowCount);
							popularGoldsmithLayout.Controls.Add(totalSalesLabel, 1, rowCount);

							rowCount++;
						}
					}
				}
			}
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            AddingItemForm addingItemForm = new AddingItemForm();
            addingItemForm.ItemAdded += AdminForm_Load;
			addingItemForm.Show();
		}

        private void deleteItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                Button addButton = sender as Button;
                if (addButton?.Parent?.Parent is Panel itemPanel && itemPanel.Tag is Tuple<string, string, decimal> itemInfo)
                {
                    string itemName = itemInfo.Item1;
                    int itemID = 0;
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

                        using (SqlCommand cmd = new SqlCommand("Store.DeleteItem", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("StockItemID", itemID);
                            cmd.ExecuteReader();
                        }
                    }
                }
                AdminForm_Load(null, null);
            }
            else
            {
                MessageBox.Show("Deletion Cancelled.");
            }
            
        }

        private void popularItemsButton_Click(object sender, EventArgs e)
        {
            itemsFlowLayoutPanel.Controls.Clear();
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Store.GetPopularItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["ItemName"].ToString();
                            string totalQuantity = reader["TotalQuantity"].ToString();
                            string itemPrice = reader["ItemPrice"].ToString();

                            Panel itemPanel = new Panel()
                            {
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Margin = new Padding(8)
                            };

                            Label nameLabel = new Label { Text = itemName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label totalQuantityLabel = new Label { Text = $"Total Sales: {totalQuantity}", Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = "Price: $" + itemPrice, Font = new Font("Mongolian Baiti", 10), AutoSize = true };

                            Button deleteItem = new Button();
                            deleteItem.Text = "Delete Product";
                            deleteItem.Click += deleteItem_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(10),
                            };


                            flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(totalQuantityLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(deleteItem);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }
            }
        }

        private void highestPriceButton_Click(object sender, EventArgs e)
        {
            itemsFlowLayoutPanel.Controls.Clear();
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Store.GetHighestPriceItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["ItemName"].ToString();
                            string totalQuantity = reader["TotalQuantity"].ToString();
                            string itemPrice = reader["ItemPrice"].ToString();

                            Panel itemPanel = new Panel()
                            {
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Margin = new Padding(8)
                            };

                            Label nameLabel = new Label { Text = itemName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label totalQuantityLabel = new Label { Text = $"Total Sales: {totalQuantity}", Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = "Price: $" + itemPrice, Font = new Font("Mongolian Baiti", 10), AutoSize = true };

                            Button deleteItem = new Button();
                            deleteItem.Text = "Delete Product";
                            deleteItem.Click += deleteItem_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(10),
                            };

                            flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(totalQuantityLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(deleteItem);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }
            }
        }

        private void ClearAllFilter_Click(object sender, EventArgs e)
        {
			itemsFlowLayoutPanel.Controls.Clear();
			string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
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
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                BackColor = Color.White,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(8),
                            };

                            Label nameLabel = new Label { Text = itemName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = "$" + itemPrice.ToString("F2"), Font = new Font("Mongolian Baiti", 10), AutoSize = true };

                            Button deleteItem = new Button();
                            deleteItem.Text = "Delete Product";
                            deleteItem.Click += deleteItem_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                Margin = new Padding(10),
                            };

                            flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(deleteItem);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }
            }
        }

		private void logoutBtn_Click(object sender, EventArgs e)
		{
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
		}
		private void CloseAll(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
	}
}