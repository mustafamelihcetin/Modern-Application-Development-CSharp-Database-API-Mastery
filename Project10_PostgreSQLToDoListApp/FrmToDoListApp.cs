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
    public partial class FrmToDoListApp : Form
    {
        public FrmToDoListApp()
        {
            InitializeComponent();
        }

        private void FrmToDoListApp_Load(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection("Server=localHost;port=5432;Database=Db10Project20;user ID=postgres;Password=1234;");

            string query = "Select * From \"ToDoLists\"";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource=dataSet.Tables[0];
        }
    }
}
