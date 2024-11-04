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
    public partial class FrmMovie : Form
    {
        public FrmMovie()
        {
            InitializeComponent();
        }
        MovieContext movieContext = new MovieContext();
        private void listData()
        {
            var value = movieContext.Movies.ToList();
            dgvMovie.DataSource = value;
        }
        private void applyCategoriesToCmb()
        {
            var values = movieContext.Categories.ToList();
            cmbMovieCategory.DisplayMember = "CategoryName";
            cmbMovieCategory.ValueMember = "CategoryID";
            cmbMovieCategory.DataSource = values;
        }
        
        private void FrmMovie_Load(object sender, EventArgs e)
        {
            listData();
            applyCategoriesToCmb();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            listData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = tbMovieName.Text;
            var value = movieContext.Movies.Where(x => x.MovieTitle.Contains(searchText)).ToList();
            dgvMovie.DataSource = value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            movie.MovieTitle = tbMovieName.Text;
            movie.Description = tbMovieDescription.Text;
            movie.CreatedDate = DateTime.Parse(mtbMovieDate.Text);
            movie.CategoryID = int.Parse(cmbMovieCategory.SelectedValue.ToString());
            movie.Duration = int.Parse(tbMovieDuration.Text);
            movieContext.Movies.Add(movie);
            movieContext.SaveChanges();
            MessageBox.Show(tbMovieName.Text + " başarıyla eklendi.");
            listData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbMovieId.Text);
            var value = movieContext.Movies.Find(id);
            value.MovieTitle = tbMovieName.Text;
            value.Description = tbMovieDescription.Text;
            value.CreatedDate = DateTime.Parse(mtbMovieDate.Text);
            value.CategoryID = int.Parse(cmbMovieCategory.SelectedIndex.ToString());
            value.Duration = int.Parse(tbMovieDuration.Text);
            movieContext.SaveChanges();
            MessageBox.Show(value.MovieTitle + " filmi başarıyla güncellendi.");
            listData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbMovieId.Text);
            var value = movieContext.Movies.Find(id);
            movieContext.Movies.Remove(value);
            movieContext.SaveChanges();
            MessageBox.Show(value.MovieTitle + " filmi başarıyla silindi.");
            listData();
        }
    }
}
