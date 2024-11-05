using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project5_DapperNorthwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnCategoryList_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Categories";
            var connection = "Server=DPCM; initial catalog=Db5Project20; integrated security=true";
        }
    }
}
