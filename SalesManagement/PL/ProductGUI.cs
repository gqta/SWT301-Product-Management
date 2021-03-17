using SalesManagement.BL;
using SalesManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesManagement.PL
{
    public partial class ProductGUI : Form
    {
        public ProductGUI()
        {
            InitializeComponent();
        }

        private void RefreshProduct()
        {
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = Product.GetAllProduct();
        }
        private void ProductGUI_Load(object sender, EventArgs e)
        {
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = ProductDAL.GetAllProduct();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            AddProductGUI addProduct = new AddProductGUI();
            addProduct.ShowDialog();
            RefreshProduct();
            this.Visible = true;
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable data = ProductDAL.GetAllProduct();
            if (dgvProduct.Columns[e.ColumnIndex].Name.Equals("Edit"))
            {

                this.Visible = false;
                Product x = new Product(data.Rows[e.RowIndex]["ProductId"].ToString(),
                    data.Rows[e.RowIndex]["ProductName"].ToString(),
                    data.Rows[e.RowIndex]["CategoryId"].ToString(),
                    data.Rows[e.RowIndex]["Unit"].ToString(),
                    int.Parse(data.Rows[e.RowIndex]["Price"].ToString()),
                    int.Parse(data.Rows[e.RowIndex]["Quantity"].ToString()),
                    bool.Parse(data.Rows[e.RowIndex]["Discontinued"].ToString()),
                    DateTime.Parse(data.Rows[e.RowIndex]["CreateDate"].ToString()));

                this.Visible = false;
                EditProductGUI editProductGUI = new EditProductGUI(x);
                editProductGUI.ShowDialog();
                RefreshProduct();
                this.Visible = true;

                
                
            }
            if (dgvProduct.Columns[e.ColumnIndex].Name.Equals("Delete"))
            {
                if (MessageBox.Show("Do you want delete the this row?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    ProductDAL.DeleteProduct(data.Rows[e.RowIndex]["ProductId"].ToString());
                    RefreshProduct();
                }
                else
                    MessageBox.Show("Delete false.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            //dgvProduct.DataSource = null;
            //dgvProduct.DataSource = ProductDAL.Search(keyword.Trim());
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = Product.GetAllProduct().Where(el => el.ProductName.ToLower().Contains(keyword.Trim().ToLower())).ToList();

        }
    }
}
