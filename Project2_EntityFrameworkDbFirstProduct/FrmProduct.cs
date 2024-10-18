using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_EntityFrameworkDbFirstProduct
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        Db2Project20Entities db = new Db2Project20Entities();
        void ListProduct()
        {
            dataGridView1.DataSource = db.TblProduct.ToList();
        }
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            ListProduct();
            var values = db.TblCategory.ToList();
            cmbProductCategory.DisplayMember = "CategoryName";
            cmbProductCategory.ValueMember = "CategoryID";
            cmbProductCategory.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListProduct();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            TblProduct tblproduct = new TblProduct();
            tblproduct.ProductName = txtProductName.Text;
            tblproduct.ProductPrice = decimal.Parse(txtProductPrice.Text);
            tblproduct.ProductStock = int.Parse(txtProductStock.Text);
            tblproduct.CategoryID = int.Parse(cmbProductCategory.SelectedValue.ToString());
            db.TblProduct.Add(tblproduct);
            db.SaveChanges();
            ListProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductID.Text);
            var value = db.TblProduct.Find(id);
            db.TblProduct.Remove(value);
            db.SaveChanges();
            ListProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductID.Text);
            var value = db.TblProduct.Find(id);
            value.ProductName = txtProductID.Text;
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductStock = int.Parse(txtProductStock.Text);
            value.CategoryID = int.Parse(cmbProductCategory.SelectedIndex.ToString());
            db.SaveChanges();
            ListProduct();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = db.TblProduct.Where(x => x.ProductName == txtProductName.Text).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnProductListWithCategory_Click(object sender, EventArgs e)
        {
            var values = db.TblProduct
                .Join(db.TblCategory,
                product => product.CategoryID,
                category => category.CategoryID,
                (product,category)=>new
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductStock = product.ProductStock,
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                }).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
