using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManagement.BL;
using System.Text.RegularExpressions;
using System.Collections;
using System.Runtime.InteropServices;

namespace SalesManagement
{
    public partial class Form1 : Form
    {
        bool addNew = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void RefeshCategory()
        {
            dgvCategory.DataSource = null;
            dgvCategory.DataSource = Category.GetAllCategory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCategory.DataSource = Category.GetAllCategory();
            txtCategoryId.Enabled = false;
            txtCategoryName.Enabled = false;
            txtCategoryDescription.Enabled = false;

            //MessageBox.Show(Category.FindCategoryById("C").ToString());

            List < Category > tab = Category.GetAllCategory();
            bool flag = true;
            foreach(Category row in tab)
            {
                flag = flag && row.CategoryId.Equals(txtCategoryId.Text);
            }
            // dung flag
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCategory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvCategory.CurrentRow.Selected = true;
                txtCategoryId.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryId"].Value.ToString();
                txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                txtCategoryDescription.Text = dgvCategory.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                txtCategoryName.Enabled = txtCategoryDescription.Enabled = true;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtCategoryId.Text = "";
            txtCategoryName.Text = "";
            txtCategoryDescription.Text = "";
            txtCategoryId.Focus();
            txtCategoryId.Enabled = true;
            txtCategoryName.Enabled = true;
            txtCategoryDescription.Enabled = true;
            addNew = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(addNew)
            {
                // thuc them 1 category

                if (ValidCategory())
                {
                    ArrayList lst = new ArrayList() { 
                        txtCategoryId.Text, txtCategoryName.Text, txtCategoryDescription.Text
                    };

                    if(!Category.FindCategoryById(txtCategoryId.Text) && Category.AddCategory(lst) > 0)
                    {
                        MessageBox.Show("A Category Added!!!");
                        txtCategoryId.Text = "";
                        txtCategoryName.Text = "";
                        txtCategoryDescription.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Category ID is Existed!!!");
                        txtCategoryId.Focus();

                    }
                }
            }
            else
            {
                // tien hanh cap nhat

                if (ValidCategory())
                {
                    //Category cat = new Category(txtCategoryId.Text, txtCategoryName.Text, txtCategoryDescription.Text);

                    ArrayList lst = new ArrayList() {
                        txtCategoryId.Text, txtCategoryName.Text, txtCategoryDescription.Text
                    };

                    if (Category.UpdateCategory(lst) > 0)
                    {
                        MessageBox.Show("Updated!!!!");
                        txtCategoryId.Text = "";
                        txtCategoryName.Text = "";
                        txtCategoryDescription.Text = "";
                    }
                }
                
            }

            RefeshCategory();
        }

        private bool ValidCategory()
        {

            string id = txtCategoryId.Text;
            string name = txtCategoryName.Text;
            string description = txtCategoryId.Text;

            if (String.IsNullOrEmpty(id))
            {
                MessageBox.Show("Id must be not Empty");
                txtCategoryId.Focus();
                return false;
            }

            if (!new Regex(@"^C\d{4}$").IsMatch(id))
            {
                MessageBox.Show("Id Must be [ C0000 - C9999]");
                txtCategoryId.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Id must be not Empty");
                txtCategoryName.Focus();
                return false;
            }

            return true;
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {


                if (Category.FindCategoryById(txtCategoryId.Text) && Category.DeleteCategory(txtCategoryId.Text) > 0)
                {
                    MessageBox.Show("Deleted");
                    txtCategoryId.Text = "";
                    txtCategoryName.Text = "";
                    txtCategoryDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Category ID is Not Existed!!!");
                    txtCategoryId.Focus();

                }
            RefeshCategory();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            dgvCategory.DataSource = Category.GetAllCategory().Where<Category>(el => el.CategoryName.StartsWith(keyword)).ToList();
            //List<Category> lst = Category.FindCategory(keyword);
        }
    }
}
