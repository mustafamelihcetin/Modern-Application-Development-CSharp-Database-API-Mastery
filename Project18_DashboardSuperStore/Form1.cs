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

namespace Project18_DashboardSuperStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=DPCM; initial catalog=Db17Project20;integrated security=true");
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd1 = new SqlCommand("Select count(*) from superstore", sqlConnection);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                lblTotalProduct.Text = reader[0].ToString();
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand cmd2 = new SqlCommand("Select count(Distinct(City)) from superstore", sqlConnection);
            SqlDataReader reader1 = cmd2.ExecuteReader();
            while(reader1.Read())
            {
                lblTotalCity.Text = reader1[0].ToString();
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand cmd3 = new SqlCommand("Select Sum(Quantity) from superstore", sqlConnection);
            SqlDataReader reader2 = cmd3.ExecuteReader();
            while(reader2.Read())
            {
                lblTotalOrder.Text = reader2[0].ToString();
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand cmd4 = new SqlCommand("Select count(*) from superstore where country='Turkey'", sqlConnection);
            SqlDataReader reader3 = cmd4.ExecuteReader();
            while (reader3.Read())
            {
                lblOrderFromTurkiye.Text = reader3[0].ToString();
            }
            sqlConnection.Close();

        }
    }
}
