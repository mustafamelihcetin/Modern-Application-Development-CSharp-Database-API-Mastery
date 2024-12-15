using Project12_JwtToken.JWT;
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

namespace Project12_JwtToken
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Server=DPCM; initial catalog=Db12Project20; integrated security=true");
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TokenGenerator tokenGenerator = new TokenGenerator();
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From TblUser Where Username=@userName and Password=@password", connection);
            command.Parameters.AddWithValue("@userName", txtUsername.Text);
            command.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string token = tokenGenerator.GenerateJwtToken2(txtUsername.Text);
                //MessageBox.Show(token);
                FrmEmployee employee = new FrmEmployee();
                employee.tokenGet = token;
                employee.Show();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
            connection.Close();
        }
    }
}
