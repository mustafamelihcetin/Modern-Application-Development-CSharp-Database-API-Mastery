using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project10_PostgreSQLToDoListApp
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        void CategoryList()
        {
            NpgsqlConnection connection = new NpgsqlConnection("Server=localHost;port=5432;Database=Db10Project20;user ID=postgres;Password=1234;");
            string query = "Select * From \"categories\"";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection= new NpgsqlConnection("Server=localHost;port=5432;Database=Db10Project20;user ID=postgres;Password=1234;");            
            string query = "Insert Into categories (categoryname) values (@categoryName)";
            using(var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@categoryName", txtHeader.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Kategori Eklendi.");
                connection.Close();
                CategoryList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection("Server=localHost;port=5432;Database=Db10Project20;user ID=postgres;Password=1234;");
            string query = "Delete From categories Where categoryid = @categoryId";
            using(var command = new NpgsqlCommand(query,connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@categoryId",int.Parse(txtName.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Kategori Silindi.");
                connection.Close();
                CategoryList();
            }
        }
    }
}
