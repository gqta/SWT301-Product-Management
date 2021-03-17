
namespace SalesManagement
{
    partial class ProductGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_product = new System.Windows.Forms.DataGridView();
            this.p_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_cat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.q_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_discontinued = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(408, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Management";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgv_product
            // 
            this.dgv_product.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_id,
            this.p_name,
            this.p_cat,
            this.p_unit,
            this.p_price,
            this.q_quantity,
            this.p_discontinued,
            this.p_date});
            this.dgv_product.Location = new System.Drawing.Point(12, 113);
            this.dgv_product.Name = "dgv_product";
            this.dgv_product.RowHeadersWidth = 51;
            this.dgv_product.RowTemplate.Height = 24;
            this.dgv_product.Size = new System.Drawing.Size(994, 465);
            this.dgv_product.TabIndex = 1;
            this.dgv_product.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_product_CellContentClick);
            // 
            // p_id
            // 
            this.p_id.DataPropertyName = "Id";
            this.p_id.HeaderText = "ID";
            this.p_id.MinimumWidth = 6;
            this.p_id.Name = "p_id";
            // 
            // p_name
            // 
            this.p_name.DataPropertyName = "Name";
            this.p_name.HeaderText = "Name";
            this.p_name.MinimumWidth = 6;
            this.p_name.Name = "p_name";
            // 
            // p_cat
            // 
            this.p_cat.DataPropertyName = "category";
            this.p_cat.HeaderText = "Category";
            this.p_cat.MinimumWidth = 6;
            this.p_cat.Name = "p_cat";
            // 
            // p_unit
            // 
            this.p_unit.DataPropertyName = "Unit";
            this.p_unit.HeaderText = "Unit";
            this.p_unit.MinimumWidth = 6;
            this.p_unit.Name = "p_unit";
            // 
            // p_price
            // 
            this.p_price.DataPropertyName = "Price";
            this.p_price.HeaderText = "Price";
            this.p_price.MinimumWidth = 6;
            this.p_price.Name = "p_price";
            // 
            // q_quantity
            // 
            this.q_quantity.DataPropertyName = "Quantity";
            this.q_quantity.HeaderText = "Quantity";
            this.q_quantity.MinimumWidth = 6;
            this.q_quantity.Name = "q_quantity";
            // 
            // p_discontinued
            // 
            this.p_discontinued.DataPropertyName = "discontinued";
            this.p_discontinued.HeaderText = "Discontinued";
            this.p_discontinued.MinimumWidth = 6;
            this.p_discontinued.Name = "p_discontinued";
            this.p_discontinued.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.p_discontinued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // p_date
            // 
            this.p_date.DataPropertyName = "Date";
            this.p_date.HeaderText = "Create Date";
            this.p_date.MinimumWidth = 6;
            this.p_date.Name = "p_date";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(929, 78);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(77, 29);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(794, 22);
            this.textBox1.TabIndex = 5;
            // 
            // ProductGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 603);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dgv_product);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProductGUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_product;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_cat;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn q_quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_discontinued;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_date;
    }
}

