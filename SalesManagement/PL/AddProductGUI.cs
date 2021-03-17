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
    public partial class AddProductGUI : Form
    {
        public AddProductGUI()
        {
            InitializeComponent();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryID";
            cbxCategoryId.DataSource = Category.GetAllCategory();
            cbxCategoryId.SelectedIndex = 1;
        }

        private bool ValidProduct()
        {
            int count = 0;
            List<Product> categories = new List<Product>();
            DataTable dataTable = ProductDAL.GetAllProduct();
            foreach (DataRow dr in dataTable.Rows)
            {

                if (txtProductId.Text.Equals(dr["ProductId"].ToString()))
                {
                    count++;
                }


            }
            if (count > 0)
            {
                MessageBox.Show("ProductId has been signed, please check !");
                txtProductId.Focus();
                return false;
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidProduct()) return;
            ArrayList arrayList = new ArrayList() { txtProductId.Text, txtProductName.Text, cbxCategoryId.SelectedValue.ToString(),txtUnit.Text,txtPrice.Text
            ,txtQuantity.Text,cbxDiscontinued.Checked,txtCreateDate.Text};
            // Thuc hien them moi du lieu vao bang Product
            if (Product.AddProduct(arrayList) > 0)
            {
                MessageBox.Show("Add successfully !");               
            }
            this.Close();
        }

        private void AddProductGUI_Load(object sender, EventArgs e)
        {
            txtCreateDate.Text = DateTime.Now.ToString();
            txtCreateDate.Enabled = false;
        }
    }
}
