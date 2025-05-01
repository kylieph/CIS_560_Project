using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Jewelry_Project
{
    public partial class CustomerForm : Form
    {
        private string _username;
        private int _userID;
        private List<(string Name, int Quantity, string Price)> cartItems = new List<(string Name, int Quantity, string Price)>();

        public CustomerForm(string username)
        {
            InitializeComponent();

            _username = username;
            usernameLabel.Text = username;

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT UserID FROM Store.[User] WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _userID = Convert.ToInt32(reader["UserID"]);
                        }
                    }
                }
            }

            filteringFlowLayoutPanel.Margin = new Padding(15);
            itemsFlowLayoutPanel.Margin = new Padding(15);
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(_username);
            profileForm.Show();
        }

        private void newReleasesButton_Click(object sender, EventArgs e)
        {
            categoryComboBox.Text = " ";
            metalComboBox.Text = " ";
            itemsFlowLayoutPanel.Controls.Clear();

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Store.GetNewestReleases", conn))
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
                                Margin = new Padding(3)
                            };

                            Label nameLabel = new Label { Text = itemName, AutoSize = true };
                            Label priceLabel = new Label { Text = "Price: $" + itemPrice.ToString("F2"), AutoSize = true };

                            Button addToCartButton = new Button();
                            addToCartButton.Text = "Add to Cart";
                            addToCartButton.Click += addToCartButton_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                            };


                            flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            flowLayoutPanel.Margin = new Padding(16);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
                            itemPanel.Click += panel_Click;

                            nameLabel.Location = new Point(5, 5);
                            priceLabel.Location = new Point(5, 25);
                            addToCartButton.Location = new Point(5, 50);

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }
            }
        }
        private void addToCartButton_Click(object sender, EventArgs e)
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


                    using (SqlCommand cmd = new SqlCommand("Store.AddToCart", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", _userID);
                        cmd.Parameters.AddWithValue("@StockItemID", itemID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel != null && clickedPanel.Tag is Tuple<string, string, string> itemInfo)
            {
                string name = itemInfo.Item1;
                string description = itemInfo.Item2;
                string price = itemInfo.Item3;
                ItemInfoForm itemInfoForm = new ItemInfoForm(name, description, price);
                itemInfoForm.Show();
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowStyles[0] = new RowStyle(SizeType.AutoSize);
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            filteringFlowLayoutPanel.Dock = DockStyle.Fill;
            filteringFlowLayoutPanel.Margin = new Padding(10);

            itemsFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            itemsFlowLayoutPanel.WrapContents = true;
            itemsFlowLayoutPanel.AutoScroll = true;
            itemsFlowLayoutPanel.Dock = DockStyle.Fill;
            itemsFlowLayoutPanel.Margin = new Padding(15);

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
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Margin = new Padding(16)                               
                            };

                            Label nameLabel = new Label { Text = itemName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = "Price: $" + itemPrice.ToString("F2"), Font = new Font("Mongolian Baiti", 10), AutoSize = true };

                            Button addToCartButton = new Button() { Text = "Add to Cart", Font = new Font("Mongolian Baiti", 10), AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(6) };
                            addToCartButton.Click += addToCartButton_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(15),
                            };                            

                            flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
                            itemPanel.Click += panel_Click;                          

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);                           
                        }
                    }
                }
            }
        }

        private void cartButton_Click(object sender, EventArgs e)
        {
            CustomerCartForm cartForm = new CustomerCartForm(_userID);
            cartForm.Show();
        }

        private void metalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryComboBox.Text = " ";
            string metalType = metalComboBox.SelectedItem.ToString();
            int metalID = 0;
            if (!(metalType == "Gold" || metalType == "Silver" || (metalType == "Bronze" || metalType == "Rose Gold")))
            {
                return;
            }
            itemsFlowLayoutPanel.Controls.Clear();

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT MetalID FROM Store.[MetalTypes] WHERE MetalName = @MetalName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MetalName", metalType);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            metalID = Convert.ToInt32(reader["MetalID"]);
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("Store.GetAllProductsMetal", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MetalID", metalID);
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
                                Margin = new Padding(3)


                            };

                            Label nameLabel = new Label { Text = itemName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = "Price: $" + itemPrice.ToString("F2"), Font = new Font("Mongolian Baiti", 10), AutoSize = true };

                            Button addToCartButton = new Button();
                            addToCartButton.Text = "Add to Cart";
                            addToCartButton.Click += addToCartButton_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                BorderStyle = BorderStyle.None,
                            };


                            flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            flowLayoutPanel.Margin = new Padding(16);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
                            itemPanel.Click += panel_Click;

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            metalComboBox.Text = " ";
            string categoryType = categoryComboBox.SelectedItem.ToString();
            int categoryID = 0;
            if (!(categoryType == "Rings" || categoryType == "Earrings" || (categoryType == "Bracelets" || categoryType == "Necklaces" || categoryType == "Anklets")))
            {
                return;
            }
            itemsFlowLayoutPanel.Controls.Clear();

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT CategoryID FROM Store.[Categories] WHERE CategoryName = @CategoryName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", categoryType);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryID = Convert.ToInt32(reader["CategoryID"]);
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("Store.GetAllProductsCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
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
                                Margin = new Padding(3)


                            };

                            Label nameLabel = new Label { Text = itemName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = "Price: $" + itemPrice.ToString("F2"), Font = new Font("Mongolian Baiti", 10), AutoSize = true };

                            Button addToCartButton = new Button();
                            addToCartButton.Text = "Add to Cart";   
                            addToCartButton.Click += addToCartButton_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                BorderStyle = BorderStyle.None,
                            };


                            flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            flowLayoutPanel.Margin = new Padding(16);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
                            itemPanel.Click += panel_Click;

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }
            }
        }
    }
}
