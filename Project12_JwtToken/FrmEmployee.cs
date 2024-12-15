using Project12_JwtToken.JWT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project12_JwtToken
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }
        public string tokenGet;
        SqlConnection connection = new SqlConnection("Server=DPCM; initial catalog=Db12Project20; integrated security=true");
        private void FrmEmployer_Load(object sender, EventArgs e)
        {
            TokenValidator validator = new TokenValidator();
            richTextBox1.Text = tokenGet;
            var principal = validator.ValidateJwtToken(tokenGet);
            if (principal != null)
            {
                string username = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
                MessageBox.Show("Hoş geldiniz, " + username);

                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * From TblEmployee", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
            else
            {
                MessageBox.Show("Geçersiz token!");
            }
        }
    }
}
