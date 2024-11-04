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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MovieContext movieContext = new MovieContext();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = movieContext.Categories.ToList();
            dgvCategory.DataSource = values;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var values = movieContext.Categories.ToList();
            dgvCategory.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }
    }
}
