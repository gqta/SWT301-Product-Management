using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SalesManagement.BL;

namespace SalesManagement.PL
{
    public partial class ActionForm : Form
    {

        private bool addMode = true;

        public bool AddMode { get => addMode; set => addMode = value; }

        public ActionForm()
        {
            InitializeComponent();
        }

        private void ActionForm_Load(object sender, EventArgs e)
        {
            
            cbx_category.DataSource = Category.GetAllCategory().Select<Category, string>(el => el.CategoryName).ToList();
        }

        private void ActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void SetData(object product)
        {
            Product p = product as Product;

            txt_id.Enabled = false;

            txt_id.Text = p.Id;
            txt_price.Text = p.Price.ToString();
            txt_unit.Text = p.Unit.ToString();
            txt_quantity.Text = p.Quantity.ToString();
            txt_name.Text = p.Name;
            cbx_discontinued.Checked = p.Discontinued;
            List<string> categories = Category.GetAllCategory().Select<Category, string>(el => el.CategoryName).ToList();

            cbx_category.SelectedItem = p.Category;


        }

        public void PrepareAddForm()
        {
            txt_id.Enabled = true;

            txt_id.Text = "";
            txt_price.Text = "";
            txt_unit.Text = "";
            txt_quantity.Text = "";
            txt_name.Text = "";
            cbx_discontinued.Checked = false;
            cbx_category.SelectedItem = 0;
        }




        public object GetProduct()
        {
            string id = this.txt_id.Text;
            string name = txt_name.Text;
            string category = Category.GetAllCategory().Where<Category>(el => el.CategoryName.Equals(cbx_category.SelectedItem.ToString())).ToList()[0].CategoryId;

            string quantity = this.txt_quantity.Text;
            string unit = this.txt_unit.Text;
            string price = txt_price.Text;
            Regex regx = new Regex(@"^P\d{4}$");
            Regex regNum = new Regex(@"^\d+$");



            if (regx.IsMatch(id) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(category) && !String.IsNullOrEmpty(unit) && regNum.IsMatch(quantity) && regNum.IsMatch(price))
            {
                return new Product(id, name, category, unit, int.Parse(price), int.Parse(quantity), cbx_discontinued.Checked, DateTime.Now);
            }

            return null;
            
        }



        private void btn_save_Click(object sender, EventArgs e)
        {
           
            if (GetProduct() != null)
            {
                Product pro = GetProduct() as Product;



                if (addMode)
                {
                    if (!Product.IsExist(pro.Id))
                    {
                        if(Product.Add(pro) > 0)
                        {
                            MessageBox.Show("Added to database!!!");
                        }
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Id is Existed!!");
                    }

                }
                else
                {
                    if (Product.Save(pro) > 0)
                    {
                        MessageBox.Show("Data is updated!!");
                    }
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Check your input!!!");
            }
            



        }
    }
}
