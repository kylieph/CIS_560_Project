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
    public partial class CustomerCartForm : Form
    {
        public CustomerCartForm()
        {
            InitializeComponent();
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Thank you for your purchase!\nOrder ID number: \nItems Ordered: \nSubtotal: {totalDisplayLabel.Text}\nExpect your order within 3-5 business days.");
            dataGridView.Controls.Clear();
        }
    }
}
