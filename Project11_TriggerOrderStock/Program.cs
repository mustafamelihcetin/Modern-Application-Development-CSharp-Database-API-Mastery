using Project11_TriggerOrderStock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project11_TriggerOrderStock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Db11Project20Entities context = new Db11Project20Entities();
            string number;
            Console.WriteLine("##### Sipariş Stok Sistemi #####");
            Console.WriteLine();
            Console.WriteLine("1- Ürün Listesi");
            Console.WriteLine("2- Sipariş Listesi");
            Console.WriteLine("3- Kasa Durumu");
            Console.WriteLine("4- Yeni Ürün Satışı");
            Console.WriteLine("5- Ürün Stok Güncelleme");
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            Console.Write("Lütfen yapmak istediğiniz işlemi seçin: ");
            number = Console.ReadLine();
            Console.WriteLine();

            if(number =="1")
            {
                Console.WriteLine("### Ürün Listesi ###");
                var values = context.TblProducts.ToList();
                foreach(var product in values)
                {
                    Console.WriteLine(product.ProductID + "- " + product.ProductName + " Stok Sayısı: " + product.ProductStock + " Fiyatı: " + product.ProductPrice + " TL");
                }
            }
            Console.Read();
        }
    }
}
