using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private CustomerCartForm _cartForm = null;
		private static Image _cachedImage = null;

		public CustomerForm(string username)
        {
            InitializeComponent();
			this.FormClosing += new FormClosingEventHandler(CloseAll);

			_username = username;
            usernameLabel.Text = "Welcome, " + username + "!";

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
		private PictureBox CreateItemImageBox()
		{
			if (_cachedImage == null)
			{
				string imagePath = Path.Combine(Application.StartupPath, "Images", "Necklace.png");
				_cachedImage = Image.FromFile(imagePath);
			}


			PictureBox itemImageBox = new PictureBox()
			{
				Width = 100,
				Height = 100,
				Image = _cachedImage, 
				SizeMode = PictureBoxSizeMode.StretchImage, 
				Margin = new Padding(10)
			};

            itemImageBox.Click += item_Click;

			return itemImageBox;
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

                            Button viewInfoButton = new Button();
                            viewInfoButton.Text = "View Info";
                            viewInfoButton.Click += viewButton_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                            };

<<<<<<< Updated upstream
                            PictureBox itemImageBox = CreateItemImageBox();

                            flowLayoutPanel.Controls.Add(viewInfoButton);
                            flowLayoutPanel.Controls.Add(itemImageBox);
                            flowLayoutPanel.Controls.Add(nameLabel);
=======
							PictureBox itemImageBox = CreateItemImageBox();

							flowLayoutPanel.Controls.Add(itemImageBox);
							flowLayoutPanel.Controls.Add(nameLabel);
>>>>>>> Stashed changes
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            flowLayoutPanel.Margin = new Padding(16);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
                            itemPanel.Click += item_Click;

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
				MessageBox.Show(itemName + " added to cart successfully!");
<<<<<<< Updated upstream
                //_cartForm.CustomerCartForm_Load(null, null); // Refresh the cart form if it's open
=======
                if (_cartForm != null) _cartForm.CustomerCartForm_Load(null, null); // Refresh the cart form if it's open
>>>>>>> Stashed changes
			}
        }
        private void viewButton_Click(object sender, EventArgs e)
        {
            Button addButton = sender as Button;
            if (addButton?.Parent?.Parent is Panel itemPanel && itemPanel.Tag is Tuple<string, string, decimal> itemInfo)
            {
                string itemName = itemInfo.Item1;
                string description = itemInfo.Item2;
                decimal price = itemInfo.Item3;
                ItemInfoForm itemForm = new ItemInfoForm(itemName, description, price.ToString());
                itemForm.Show();
            }
        }

        private void item_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;

            // Traverse up the control hierarchy to find the Panel with the Tag
            Panel itemPanel = null;
            while (clickedControl != null && !(clickedControl is Panel))
            {
                clickedControl = clickedControl.Parent;
            }

            itemPanel = clickedControl as Panel;

            if (itemPanel != null && itemPanel.Tag is Tuple<string, string, decimal> itemInfo)
            {
                string name = itemInfo.Item1;
                string description = itemInfo.Item2;
                string price = itemInfo.Item3.ToString("F2");
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

                            Button viewInfoButton = new Button();
                            viewInfoButton.Text = "View Info";
                            viewInfoButton.Click += viewButton_Click;

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

							PictureBox itemImageBox = CreateItemImageBox();

                            flowLayoutPanel.Controls.Add(viewInfoButton);
							flowLayoutPanel.Controls.Add(itemImageBox);
							flowLayoutPanel.Controls.Add(nameLabel);
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
							itemPanel.BackColor = Color.Transparent;
							itemPanel.Click += item_Click;                          

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);                           
                        }
                    }
                }
            }
        }

        private void cartButton_Click(object sender, EventArgs e)
        {
            _cartForm = new CustomerCartForm(_userID);
            _cartForm.Show();
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

                            Button viewInfoButton = new Button();
                            viewInfoButton.Text = "View Info";
                            viewInfoButton.Click += viewButton_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                BorderStyle = BorderStyle.None,
                            };

                            PictureBox itemImageBox = CreateItemImageBox();

<<<<<<< Updated upstream
                            flowLayoutPanel.Controls.Add(viewInfoButton);
                            flowLayoutPanel.Controls.Add(itemImageBox);
                            flowLayoutPanel.Controls.Add(nameLabel);
=======
							PictureBox itemImageBox = CreateItemImageBox();

							flowLayoutPanel.Controls.Add(itemImageBox);
							flowLayoutPanel.Controls.Add(nameLabel);
>>>>>>> Stashed changes
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            flowLayoutPanel.Margin = new Padding(16);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
                            itemPanel.Click += item_Click;

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

                            Button viewInfoButton = new Button();
                            viewInfoButton.Text = "View Info";
                            viewInfoButton.Click += viewButton_Click;

                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel()
                            {
                                FlowDirection = FlowDirection.TopDown,
                                AutoSize = true,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Dock = DockStyle.Fill,
                                BackColor = Color.FloralWhite,
                                BorderStyle = BorderStyle.None,
                            };

<<<<<<< Updated upstream
                            PictureBox itemImageBox = CreateItemImageBox();

                            flowLayoutPanel.Controls.Add(viewInfoButton);
                            flowLayoutPanel.Controls.Add(itemImageBox);
                            flowLayoutPanel.Controls.Add(nameLabel);
=======
							PictureBox itemImageBox = CreateItemImageBox();

							flowLayoutPanel.Controls.Add(itemImageBox);
							flowLayoutPanel.Controls.Add(nameLabel);
>>>>>>> Stashed changes
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            flowLayoutPanel.Margin = new Padding(16);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
                            itemPanel.Click += item_Click;

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }
            }
        }

        private void clearAllFilters_Click(object sender, EventArgs e)
        {
            categoryComboBox.Text = " ";
            metalComboBox.Text = " ";
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
                                Margin = new Padding(16)
                            };

                            Label nameLabel = new Label { Text = itemName, Font = new Font("Mongolian Baiti", 10), AutoSize = true };
                            Label priceLabel = new Label { Text = "Price: $" + itemPrice.ToString("F2"), Font = new Font("Mongolian Baiti", 10), AutoSize = true };

                            Button addToCartButton = new Button() { Text = "Add to Cart", Font = new Font("Mongolian Baiti", 10), AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Margin = new Padding(6) };
                            addToCartButton.Click += addToCartButton_Click;

                            Button viewInfoButton = new Button();
                            viewInfoButton.Text = "View Info";
                            viewInfoButton.Click += viewButton_Click;

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

<<<<<<< Updated upstream
                            PictureBox itemImageBox = CreateItemImageBox();

                            flowLayoutPanel.Controls.Add(viewInfoButton);
                            flowLayoutPanel.Controls.Add(itemImageBox);
                            flowLayoutPanel.Controls.Add(nameLabel);
=======
							PictureBox itemImageBox = CreateItemImageBox();

							flowLayoutPanel.Controls.Add(itemImageBox);
							flowLayoutPanel.Controls.Add(nameLabel);
>>>>>>> Stashed changes
                            flowLayoutPanel.Controls.Add(priceLabel);
                            flowLayoutPanel.Controls.Add(addToCartButton);
                            itemPanel.Controls.Add(flowLayoutPanel);

                            itemPanel.Tag = Tuple.Create(itemName, description, itemPrice);
                            itemPanel.Click += item_Click;

                            itemsFlowLayoutPanel.Controls.Add(itemPanel);
                        }
                    }
                }

            }
        }

		private void logoutBtn_Click(object sender, EventArgs e)
		{
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
		}

        private void CloseAll(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
		}
	}
}