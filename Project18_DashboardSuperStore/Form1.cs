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
            #region Widgets
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
            while (reader1.Read())
            {
                lblTotalCity.Text = reader1[0].ToString();
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand cmd3 = new SqlCommand("Select Sum(Quantity) from superstore", sqlConnection);
            SqlDataReader reader2 = cmd3.ExecuteReader();
            while (reader2.Read())
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
            #endregion
            #region Charts

            sqlConnection.Open();
            SqlCommand cmd5 = new SqlCommand("Select Top(7) Country, Count(*) From superstore Group By Country Order By Count(*) Desc", sqlConnection);
            SqlDataReader reader4 = cmd5.ExecuteReader();
            while (reader4.Read())
            {
                chart1.Series["Series1"].Points.AddXY(reader4[0], reader4[1]);
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand cmd6 = new SqlCommand("Select Top(4) Country, Sum(Quantity) From superstore Group By Country Order By Sum(Quantity) Desc", sqlConnection);
            SqlDataReader reader5 = cmd6.ExecuteReader();
            while (reader5.Read())
            {
                chart2.Series["Series1"].Points.AddXY(reader5[0], reader5[1]);
            }
            sqlConnection.Close();

            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand cmd7 = new SqlCommand("Select Order_Priority, Count(*) From superstore Group By Order_Priority Order By Order_Priority Desc", sqlConnection);
            SqlDataReader reader6 = cmd7.ExecuteReader();
            while (reader6.Read())
            {
                chart3.Series["Series1"].Points.AddXY(reader6[0], reader6[1]);
            }
            sqlConnection.Close();
            #endregion
        }
    }
}
