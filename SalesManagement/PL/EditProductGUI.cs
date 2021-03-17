using SalesManagement.BL;
using SalesManagement.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SalesManagement.PL
{
    public partial class EditProductGUI : Form
    {
        public EditProductGUI(object a)
        {
            InitializeComponent();
            Product x = a as Product;
            txtProductId.Text = x.ProductId;
            txtProductId.Enabled = false;
            txtProductName.Text = x.ProductName;
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryID";
            cbxCategoryId.DataSource = Category.GetAllCategory();
            cbxCategoryId.SelectedIndex = 1;
            txtUnit.Text = x.Unit;
            txtPrice.Text = x.Price.ToString();
            txtQuantity.Text = x.Quantity.ToString();
            cbxDiscontinued.Checked = x.Discontinued;
            txtCreateDate.Text = x.CreateDate.ToString();
            txtCreateDate.Enabled = false;

        }

        private void EditProductGUI_Load(object sender, EventArgs e)
        {
           
        }
        private bool ValidProduct()
        {
            
            if (txtProductId.Text.Length == 0)
            {
                MessageBox.Show("CategoryId not empty.");
                txtProductId.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtProductId.Text, @"^P\d{4}$"))
            {
                MessageBox.Show("Invalid CategoryId ! ex : P0000");
                txtProductId.Focus();
                return false;
            }
            return true;

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidProduct()) return;

            ArrayList arrayList = new ArrayList() { txtProductId.Text, txtProductName.Text, cbxCategoryId.SelectedValue.ToString(),txtUnit.Text,txtPrice.Text
            ,txtQuantity.Text,cbxDiscontinued.Checked,txtCreateDate.Text};
            if (Product.UpdateProduct(arrayList) > 0)
            {
                MessageBox.Show("Update successfully !");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
