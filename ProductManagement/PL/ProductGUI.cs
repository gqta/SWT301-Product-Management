using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManagement.BL;
using SalesManagement.DAL;
using SalesManagement.PL;

namespace SalesManagement
{
    public partial class ProductGUI : Form
    {
        ActionForm action = new ActionForm();
        public ProductGUI()
        {
            InitializeComponent();
            

            action.FormClosing += new FormClosingEventHandler((object se, FormClosingEventArgs fe) =>
            {
                fe.Cancel = true;
                action.Hide();

                RefeshData();
                this.Show();
                
                
            });

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv_product.AutoGenerateColumns = false;
            DataGridViewLinkColumn link_edit = new DataGridViewLinkColumn()
            {
                HeaderText = "",
                Name = "btn_edit",
                Text = "Edit",
                UseColumnTextForLinkValue = true

            };

            DataGridViewLinkColumn link_delete = new DataGridViewLinkColumn()
            {
                HeaderText = "",
                Name = "btn_delete",
                Text = "Delete",
                UseColumnTextForLinkValue = true,
            };
            dgv_product.Columns.Add(link_edit);
            dgv_product.Columns.Add(link_delete);
            

            dgv_product.DataSource = Product.GetAllProducts();


        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            action.PrepareAddForm();
            action.AddMode = true;
            this.Hide();
            action.Show();
            
        }

        private void dgv_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_product.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Edit"))
            {
                action.AddMode = false;
                action.SetData(Product.GetAllProducts()[e.RowIndex]);
                this.Hide();
                action.Show();
            }else if (dgv_product.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Delete"))
            {
                string id = dgv_product.Rows[e.RowIndex].Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show("Do you want to Delete?", "Alert", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (result.Equals(DialogResult.Yes))
                {
                    Product.Delete(id);
                    RefeshData();
                }
            }
        }

        private void RefeshData()
        {
            this.dgv_product.DataSource = null;
            this.dgv_product.DataSource = Product.GetAllProducts();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;

            dgv_product.DataSource = null;
            dgv_product.DataSource = Product.GetAllProducts().Where(el => el.Name.ToLower().Contains(keyword.ToLower())).ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
