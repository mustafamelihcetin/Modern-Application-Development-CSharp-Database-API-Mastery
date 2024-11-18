using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project9_MongoDbOrder.Entities
{
    public class Order
    {
        public string OrderID { get; set; }
        public string CustomerName { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string TotalPrice { get; set; }
    }
}
