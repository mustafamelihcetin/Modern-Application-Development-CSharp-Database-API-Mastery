using System;
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
            SqlCommand command = new SqlCommand("Select * from TblCustomer", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            listItems();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listItems();
        }
    }
}
