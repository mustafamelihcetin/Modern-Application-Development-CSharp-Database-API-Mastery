using Dapper;
using Project5_DapperNorthwind.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project5_DapperNorthwind
{
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Server=DPCM; initial catalog=Db5Project20; integrated security=true");

        private async void btnCategoryList_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Categories";
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            dataGridView1.DataSource = values;
        }

        private async void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO dbo.Categories (CategoryName, Description) VALUES (@categoryName, @description)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", tbCategoryName.Text);
            parameters.Add("@description", rtbDescription.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Successfully.");
        }

        private async void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string query = "UPDATE dbo.Categories SET CategoryName=@categoryName, Description=@description WHERE CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", tbCategoryId.Text);
            parameters.Add("@categoryName", tbCategoryName.Text);
            parameters.Add("@description", rtbDescription.Text);
            await connection.ExecuteAsync(query,parameters);
            MessageBox.Show("Successfully");
        }

        private async void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM dbo.Categories WHERE CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", tbCategoryId.Text);
            await connection.ExecuteAsync(query,parameters);
            MessageBox.Show("Successfully");
        }

        private async void FrmCategories_Load(object sender, EventArgs e)
        {
            //Number of Categories
            string categoryQuery = "SELECT Count(*) FROM Categories";
            var countCategories = await connection.ExecuteScalarAsync<int>(categoryQuery);
            lblCategoryCount.Text = "Total number of categories: "+ countCategories;

            //Number of Products
            string productQuery = "SELECT Count(*) FROM Products";
            var countProducts = await connection.ExecuteScalarAsync<int?>(productQuery);
            lblProductCount.Text = "Total number of products: "+ countProducts;

            //Average number of products in stock
            string productsInStockQuery = "SELECT AVG(UnitsInStock) FROM Products";
            var countProductsInStock= await connection.ExecuteScalarAsync(productsInStockQuery);
            lblProductAvgInStock.Text = "Average number of products in stock: " + countProductsInStock;

            //lblSeafoodProductTotalPrice cid8
            string seafoodProductTotalPriceQuery = "SELECT SUM(UnitPrice) FROM Products WHERE CategoryID=8";
            var countSeafoodProductTotalPriceQuery = await connection.ExecuteScalarAsync<decimal>(seafoodProductTotalPriceQuery);
            lblSeafoodProductTotalPrice.Text = "Total price of seafood: " + countSeafoodProductTotalPriceQuery;

        }
    }
}
