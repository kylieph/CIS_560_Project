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
    public partial class AddingItemForm : Form
    {
		public event EventHandler ItemAdded;
		public AddingItemForm()
        {
            InitializeComponent();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            decimal itemPrice = 0;
            int goldsmithID = 0;
            int categoryID = 0;
            int metalID = 0;
            int stockQuantity = 0;

            // Checking item name, price, and description
            if (string.IsNullOrEmpty (itemNameTextBox.Text))
            {
                MessageBox.Show ("Item Name required.");
                return;
            }
            else if (string.IsNullOrEmpty (itemPriceTextBox.Text))
            {
                MessageBox.Show("Item Price required.");
                return;
            }
            else if (!decimal.TryParse(itemPriceTextBox.Text, out itemPrice))
            {
                MessageBox.Show("Item Price not valid.");
                return;
            }
            else if (itemPrice < 0)
            {
                MessageBox.Show("Item Price not valid.");
                return;
            }
            else if (string.IsNullOrEmpty(itemDescriptionTextBox.Text))
            {
                MessageBox.Show("Item Description required.");
                return;
            }

            // Checking stock quantity
            else if (string.IsNullOrEmpty(stockQuantityTextBox.Text))
            {
                MessageBox.Show("Stock Quantity not valid.");
                return;
            }
            else if (!int.TryParse(stockQuantityTextBox.Text, out stockQuantity))
            {
                MessageBox.Show("Stock Quantity not valid.");
                return;
            }
            else if (stockQuantity < 0)
            {
                MessageBox.Show("Stock Quantity not valid.");
                return;
            }

            // Checking goldsmithID
            else if (string.IsNullOrEmpty(goldsmithIDTextBox.Text))
            {
                MessageBox.Show("GoldsmithID required.");
                return;
            }
            else if (!int.TryParse(goldsmithIDTextBox.Text, out goldsmithID))
            {
                MessageBox.Show("GoldsmithID not valid. Must be (1-4).");
                return;
            }
            else if (!(goldsmithID == 0 || goldsmithID == 1 || goldsmithID == 2 || goldsmithID == 3 || goldsmithID == 4))
            {
                MessageBox.Show("GoldsmithID not valid. Must be (1-4).");
                return;
            }

            // Checking categoryID
            else if (string.IsNullOrEmpty(categoryIDTextBox.Text))
            {
                MessageBox.Show("CategoryID required.");
                return;
            }
            else if (!int.TryParse(categoryIDTextBox.Text, out categoryID))
            {
                MessageBox.Show("CategoryID not valid. Must be (1-5).");
                return;
            }
            else if (!(categoryID == 0 || categoryID == 1 || categoryID == 2 || categoryID == 3 || categoryID == 4 || categoryID == 5))
            {
                MessageBox.Show("CategoryID not valid. Must be (1-5).");
                return;
            }

            // Checking metalID
            else if (string.IsNullOrEmpty (metalIDTextBox.Text))
            {
                MessageBox.Show("MetalID required.");
                return;
            }
            else if (!int.TryParse(metalIDTextBox.Text, out metalID))
            {
                MessageBox.Show("MetalID not valid. Must be (1-4).");
                return;
            }
            else if (!(metalID == 0 || metalID == 1 || metalID == 2 || metalID == 3 || metalID == 4))
            {
                MessageBox.Show("MetalID not valid. Must be (1-4).");
                return;
            }


            // Adding Item
            else
            {
                string connString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string sql = "Store.AddNewItem";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@GoldsmithID", goldsmithID);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        cmd.Parameters.AddWithValue("@MetalID", metalID);
                        cmd.Parameters.AddWithValue("@ItemName", itemNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@ItemPrice", itemPrice);
                        cmd.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                        cmd.Parameters.AddWithValue("@Description", itemDescriptionTextBox.Text);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteReader();
                    }
                }
                MessageBox.Show("Product Added.");
				this.Close();
            }
			ItemAdded?.Invoke(this, EventArgs.Empty);

        }
    }
}
