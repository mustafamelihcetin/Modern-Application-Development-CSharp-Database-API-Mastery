using Project4_EntityFrameworkCodeFirstMovie.DAL.Context;
using Project4_EntityFrameworkCodeFirstMovie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4_EntityFrameworkCodeFirstMovie
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        MovieContext movieContext = new MovieContext();

        private void btnList_Click(object sender, EventArgs e)
        {
            listCategories();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = tbCategoryName.Text;
            movieContext.Categories.Add(category);
            movieContext.SaveChanges();
            MessageBox.Show("İşlem başarılı.");
            listCategories();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbCategoryId.Text);
            var value = movieContext.Categories.Find(id);
            if (value != null)
            {
                movieContext.Categories.Remove(value);
                movieContext.SaveChanges();
                MessageBox.Show("ID: " + id + " başarıyla silindi.");
                listCategories();
            }
        }
        private void listCategories()
        {
            var values = movieContext.Categories.ToList();
            dgvCategory.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            int id = int.Parse(tbCategoryId.Text);
            var value = movieContext.Categories.Find(id);
            value.CategoryName = tbCategoryName.Text;
            movieContext.SaveChanges();
            MessageBox.Show("ID: " + value.CategoryID + " başarıyla güncellendi.");
            listCategories();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = tbCategoryName.Text;
            var value = movieContext.Categories.Where(x => x.CategoryName.Contains(searchText)).ToList();
            dgvCategory.DataSource= value;          
        }
    }
}
