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

namespace Project1_AdoNetCustomer
{
    public partial class FrmCity : Form
    {
        public FrmCity()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection("Server=DPCM;initial catalog=DbCustomer;integrated security=true");
        private void btnListele_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * from TblCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblCity (CityName,CityCountry)values(@cityName,@cityCountry)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@cityName", txtSehirAdi.Text);
            sqlCommand.Parameters.AddWithValue("@cityCountry", txtUlke.Text);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Şehir başarılı bir şekilde eklendi.");
            btnListele_Click(sender, e);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM TblCity WHERE CıtyID=@sehirID",sqlConnection);
            sqlCommand.Parameters.AddWithValue("@sehirID",txtSehirID.Text);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Şehir başarılı bir şekilde silindi.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnListele_Click(sender, e);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE TblCity SET CityName=@cityName, CityCountry=@cityCountry WHERE CıtyID=@cityID", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@cityName", txtSehirAdi.Text);
            sqlCommand.Parameters.AddWithValue("@cityCountry", txtUlke.Text);
            sqlCommand.Parameters.AddWithValue("@cityID", txtSehirID.Text);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Şehir başarılı bir şekilde güncelledi.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnListele_Click(sender, e);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TblCity WHERE CityName=@cityName",sqlConnection);
            sqlCommand.Parameters.AddWithValue("@cityName", txtSehirAdi.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlCommand.ExecuteNonQuery() ;
            sqlConnection.Close();
        }

        private void FrmCity_Load(object sender, EventArgs e)
        {

        }
    }
}
