using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project1_AdoNetCustomer
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=DPCM;initial catalog=DbCustomer;integrated security=true");
        private void listItems()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT CustomerID,CustomerName,CustomerSurname,CustomerBalance,CustomerStatus, CityName  FROM TblCustomer\r\nINNER JOIN TblCity ON TblCity.CıtyID=TblCustomer.CustomerCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM TblCity",sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbCity.ValueMember = "CityID";
            cmbCity.DisplayMember = "CityName";
            cmbCity.DataSource = dataTable;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listItems();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {            
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Execute CustomerListWithCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblCustomer (CustomerName,CustomerSurname,CustomerCity,CustomerBalance,CustomerStatus) values(@customerName,@customerSurname,@customerCity,@customerBalance,@customerStatus)", sqlConnection);

            
            sqlCommand.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            sqlCommand.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);

            // Şehir ID'sini doğru şekilde alıyoruz
            if (cmbCity.SelectedValue is DataRowView rowView)
            {
                sqlCommand.Parameters.AddWithValue("@customerCity", Convert.ToInt32(rowView["CıtyID"]));  // "CityID" tabloya göre değişebilir
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@customerCity", Convert.ToInt32(cmbCity.SelectedValue));  // Değer int ise direkt ekleriz
            }

            // Balance'ı sayısal bir tipe çeviriyoruz
            sqlCommand.Parameters.AddWithValue("@customerBalance", decimal.Parse(txtCustomerBalance.Text));

            // Müşteri durumu (aktif/pasif)
            if (rdbActive.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", true);
            }
            else if (rdbPassive.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", false);
            }

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri başarılı bir şekilde eklendi.");
            btnListele_Click(sender, e); // Listeyi güncelle
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM TblCustomer WHERE CustomerID=@customerID", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@customerID",txtCustomerId.Text);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Müşteri başarılı bir şekilde silindi.");
            btnListele_Click(sender, e); // Listeyi güncelle
        }
    }
}

