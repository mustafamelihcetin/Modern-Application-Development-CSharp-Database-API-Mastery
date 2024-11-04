using Project4_EntityFrameworkCodeFirstMovie.DAL.Context;
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
            dgvCategory.DataSource = value;
        }
        
        private void FrmMovie_Load(object sender, EventArgs e)
        {
            listData();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            listData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
