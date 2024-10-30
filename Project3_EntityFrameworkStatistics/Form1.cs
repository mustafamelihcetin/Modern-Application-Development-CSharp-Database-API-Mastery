using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3_EntityFrameworkStatistics
{
    public partial class Form1 : Form
    {
        private readonly Db3Project20Entities _db;

        public Form1()
        {
            InitializeComponent();
            _db = new Db3Project20Entities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Center all labels in the corresponding panels
            CenterLabelsInPanels();

            // Display statistics
            DisplayStatistics();
        }

        /// <summary>
        /// Centers all relevant labels in their corresponding panels.
        /// </summary>
        private void CenterLabelsInPanels()
        {
            // Single Responsibility: This method centers all the labels inside their respective panels.
            CenterHeadLabelInPanel(label1, panel1);
            CenterHeadLabelInPanel(label2, panel2);
            CenterHeadLabelInPanel(label6, panel3);
            CenterHeadLabelInPanel(label8, panel4);
            CenterHeadLabelInPanel(label10, panel5);
            CenterHeadLabelInPanel(label20, panel10);
            CenterHeadLabelInPanel(label18, panel9);
            CenterHeadLabelInPanel(label16, panel8);
            CenterHeadLabelInPanel(label14, panel7);
            CenterHeadLabelInPanel(label12, panel6);
            CenterHeadLabelInPanel(label30, panel15);
            CenterHeadLabelInPanel(label28, panel14);
            CenterHeadLabelInPanel(label26, panel8);
            CenterHeadLabelInPanel(label24, panel8);
            CenterHeadLabelInPanel(label22, panel8);
            CenterHeadLabelInPanel(label40, panel8);
            CenterHeadLabelInPanel(label38, panel8);
            CenterHeadLabelInPanel(label36, panel8);
            CenterHeadLabelInPanel(label34, panel8);
            CenterHeadLabelInPanel(label32, panel8);
        }

        /// <summary>
        /// Displays the statistics for categories, products, customers, and orders.
        /// </summary>
        private void DisplayStatistics()
        {
            // Single Responsibility: This method handles only the display of statistics.
            SetLabelTextAndCenter(LblCategoryCount, panel1, _db.TblCategory.Count().ToString());
            SetLabelTextAndCenter(LblProductCount, panel2, _db.TblProduct.Count().ToString());
            SetLabelTextAndCenter(LblCustomerCount, panel3, _db.TblCustomer.Count().ToString());
            SetLabelTextAndCenter(LblOrderCount, panel4, _db.TblOrder.Count().ToString());

            var totalProductStock = _db.TblProduct.Sum(a => a.ProductStock);
            SetLabelTextAndCenter(LblProductTotalStock, panel5, totalProductStock.ToString());

            var averageProductPrice = (decimal)(_db.TblProduct.Sum(a => a.ProductPrice) / totalProductStock);
            SetLabelTextAndCenter(LblAverageProductPrice, panel10, averageProductPrice.ToString("N2") + "₺");

            var totalProductCountByCategoryIsFruit = _db.TblProduct.Where(a => a.CategoryID==1).Sum(y => y.ProductStock);
            SetLabelTextAndCenter(LblTotalFruit, panel9, totalProductCountByCategoryIsFruit.ToString());

            var totalTransactionVolumeAyranGetStock = _db.TblProduct.Where(a=> a.ProductID == 5).Select(y=> y.ProductStock).FirstOrDefault();
            var totalTransactionVolumeAyranGetPrice = _db.TblProduct.Where(a=> a.ProductID == 5).Select(y=> y.ProductPrice).FirstOrDefault();
            var totalTransactionVolumeAyran = totalTransactionVolumeAyranGetStock * totalTransactionVolumeAyranGetPrice; 
            SetLabelTextAndCenter(LblTotalTransactionVolumeAyran, panel8, (totalTransactionVolumeAyran + "₺").ToString());

            var ProductsWhereTotalStockIsUnder100 = _db.TblProduct.Where(a => a.ProductStock <= 100).Sum(y => y.ProductStock);
            SetLabelTextAndCenter(LblProductsWhereTotalStockIsUnder100, panel8, (ProductsWhereTotalStockIsUnder100.ToString()));
                        
            int id = _db.TblCategory.Where(a => a.CategoryName == "Sebze").Select(y => y.CategoryID).FirstOrDefault();
            var ActiveVegetableStock = _db.TblProduct.Where(a => a.CategoryID == id && a.ProductStatus==true).Sum(y => y.ProductStock);
            if (ActiveVegetableStock == null)
                ActiveVegetableStock = 0;
            SetLabelTextAndCenter(LblActiveVegetableStock, panel7, ActiveVegetableStock.ToString());

            var customerID = _db.TblCustomer.Where(a => a.CustomerCountry == "Türkiye").Select(y => y.CustomerID).FirstOrDefault();
            var x =_db.Database.SqlQuery<int>("SELECT COUNT(*) FROM TblOrder WHERE CustomerID IN (SELECT CustomerID FROM TblCustomer WHERE CustomerCountry='Türkiye')").FirstOrDefault();
            SetLabelTextAndCenter(LblOrdersFromTurkiyeSQL, panel15, x.ToString());


            var findCustomerID = _db.TblCustomer.Where(a => a.CustomerCountry == "Türkiye")
                                                .Select(y => y.CustomerID).ToList();
            var orderCountFromTurkiyeWithEF = _db.TblOrder.Count(c => findCustomerID.Contains(c.CustomerID.Value));
            SetLabelTextAndCenter(LblOrdersFromTurkiyeEF, panel15, orderCountFromTurkiyeWithEF.ToString());
            
            var orderTotalPriceByCategoryIsMeyve = _db.Database.SqlQuery<decimal>("SELECT SUM(o.TotalPrice) as ToplamSatisFiyati FROM TblOrder o JOIN TblProduct p ON o.ProductID = p.ProductID JOIN TblCategory c ON p.CategoryID = c.CategoryID WHERE c.CategoryName = 'Meyve'").FirstOrDefault();
            SetLabelTextAndCenter(LblFruitSalesIncome, panel13, orderTotalPriceByCategoryIsMeyve.ToString());

            var orderTotalPriceByCategoryIsMeyveEF = (from o in _db.TblOrder
                                                      join p in _db.TblProduct on o.ProductID equals p.ProductID
                                                      join c in _db.TblCategory on p.CategoryID equals c.CategoryID
                                                      where c.CategoryName=="Meyve"
                                                      select o.TotalPrice).Sum();
            SetLabelTextAndCenter(LblFruitSalesIncomeEF, panel12, orderTotalPriceByCategoryIsMeyveEF.ToString());

            var lastAddedProduct = _db.TblProduct.OrderByDescending(a => a.ProductID).Select(b => b.ProductName).FirstOrDefault();
            SetLabelTextAndCenter(LblLastAddedProduct, panel11, lastAddedProduct.ToString());

            var lastAddedCategory = _db.TblCategory.OrderByDescending(a => a.CategoryID).Select(b=> b.CategoryName).FirstOrDefault();
            SetLabelTextAndCenter(LblLastAddedCategory, panel20, lastAddedCategory.ToString());

            var totalActiveProduct = _db.TblProduct.Where(a => a.ProductStock>0).Count();
            SetLabelTextAndCenter(LblNumberOfActiveProduct,panel19, totalActiveProduct.ToString());

            var cokeStock = _db.TblProduct.Where(a => a.ProductName == "Kola").Select(b => b.ProductStock).FirstOrDefault();
            var cokePrice = _db.TblProduct.Where(a => a.ProductName == "Kola").Select(b => b.ProductPrice).FirstOrDefault();
            var totalIncomeFromCoke = cokeStock * cokePrice;
            SetLabelTextAndCenter(LblTotalIncomeOfCoke, panel18, totalIncomeFromCoke.ToString());

            var p1 = _db.TblOrder.OrderByDescending(a => a.OrderID).Select(b => b.CustomerID).FirstOrDefault();
            var lastOrderingCustomer = _db.TblCustomer.Where(a => a.CustomerID == p1).Select(b => b.CustomerName).FirstOrDefault();
            SetLabelTextAndCenter(LblLastOrderedCustomer, panel17, lastOrderingCustomer.ToString());

            var numberOfCountries = _db.Database.SqlQuery<int>("SELECT COUNT(DISTINCT (CustomerCountry)) FROM TblCustomer").FirstOrDefault();
            var numberOfCountriesEF = _db.TblCustomer.Select(a => a.CustomerCountry).Distinct().Count();
            SetLabelTextAndCenter(LblNumberOfCountryDiversity,panel16, numberOfCountriesEF.ToString());

        }

        /// <summary>
        /// Centers a label inside a panel.
        /// </summary>
        /// <param name="label">The label to be centered.</param>
        /// <param name="panel">The panel in which the label will be centered.</param>
        private void CenterLabelInPanel(Label label, Panel panel)
        {
            // Single Responsibility: This method only handles label centering logic.
            label.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label.Left = (panel.Width - label.Width) / 2;
            label.Top = (int)((panel.Height - label.Height) / 1.5);
        }
        /// <summary>
        /// Centers a head label inside a panel
        /// </summary>
        /// <param name="label">The head label to be centered</param>
        private void CenterHeadLabelInPanel(Label label, Panel panel)
        {
            label.Font = new Font("Segoe UI", 14);
            AdjustFontSizeToFit(label, panel);
            label.Left = (panel.Width - label.Width) / 2;
            label.Top = (panel.Height - label.Height) / 5;
        }

        /// <summary>
        /// Sets the text of the label to a count value and centers the label within the panel.
        /// </summary>
        /// <param name="label">The label to update.</param>
        /// <param name="panel">The panel in which the label resides.</param>
        /// <param name="count">The count to be displayed in the label.</param>
        private void SetLabelTextAndCenter(Label label, Panel panel, string count)
        {
            // Open/Closed: Allows extending the logic without modifying the method.
            label.Text = count.ToString();
            CenterLabelInPanel(label, panel);
        }
        /// <summary>
        /// Adjust the font size of the label to fit within the panel width
        /// </summary>
        /// <param name="label">The label whose font size needs adjustment.</param>
        /// <param name="panel">The panel within which the label needs to fit.</param>
        private void AdjustFontSizeToFit(Label label,Panel panel)
        {
            float fontSize = label.Font.Size;

            // Decrease font size until the label text fits within the panel width
            while (label.PreferredWidth > panel.Width && fontSize > 1)
            {
                fontSize -= 0.5f;
                label.Font = new Font(label.Font.FontFamily, fontSize, label.Font.Style);
            }
        }
    }
}