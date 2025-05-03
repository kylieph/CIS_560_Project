using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry_Project
{
    /// <summary>
    /// Consists of details regarding a product
    /// </summary>
    public partial class ItemInfoForm : Form
    {
		/// <summary>
		/// Loads in the information about the product
		/// </summary>
		public ItemInfoForm(string name, string description, string price)
        {
            InitializeComponent();
            itemNameLabel.Text = name;
            descriptionLabel.Text = description;
            priceLabel.Text = "$" + price;

            flowLayoutPanel1.Margin = new Padding(20);
        }
    }
}
