using Project9_MongoDbOrder.Entities;
using Project9_MongoDbOrder.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project9_MongoDbOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OrderOperation orderOperation = new OrderOperation();
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                City = txtCity.Text,
                CustomerName = txtCustomerName.Text,
                District = txtDistrict.Text,
                TotalPrice = decimal.Parse(txtTotalPrice.Text)
            };

            orderOperation.AddOrder(order);
            MessageBox.Show("Ekleme işlemi yapıldı.");
        }
        private void btnList_Click(object sender, EventArgs e)
        {

        }

        
    }
}
