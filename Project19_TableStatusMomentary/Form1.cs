using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            int buttonWidth = 150;
            int buttonHeight = 75;
            int padding = 10;
            int xOffSet = 10;
            int yOffSet = 10;

            for (int i = 0; i < 12; i++)
            {
                Button button = new Button();
                button.Text = $"Buton{i}";
                button.Size = new Size(buttonWidth, buttonHeight);
                button.Location = new Point(xOffSet + (i % 4) * (buttonWidth + padding), yOffSet + (i / 4) * (buttonHeight + padding));
                this.Controls.Add(button);
            }
        }
    }
}
