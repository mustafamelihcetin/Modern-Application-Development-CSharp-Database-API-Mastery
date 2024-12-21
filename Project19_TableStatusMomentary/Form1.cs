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

namespace Project19_TableStatusMomentary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Db19Project20Entities context = new Db19Project20Entities();
        private void Form1_Load(object sender, EventArgs e)
        {
            var values = context.TblTables.ToList();

            int buttonWidth = 150;
            int buttonHeight = 75;
            int padding = 10;
            int xOffSet = 10;
            int yOffSet = 10;

            for (int i = 0; i < values.Count; i++)
            {
                var item = values[i];
                Button button = new Button();
                button.Text = item.TableNumber.ToString();
                button.Size = new Size(buttonWidth, buttonHeight);
                button.Location = new Point(xOffSet + (i % 4) * (buttonWidth + padding), yOffSet + (i / 4) * (buttonHeight + padding));

                button.BackColor = bool.Parse(item.Status.ToString()) ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                this.Controls.Add(button);
            }




        }
    }
}
