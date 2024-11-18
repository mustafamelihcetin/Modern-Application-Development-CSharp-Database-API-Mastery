using MongoDB.Bson;
using Project9_MongoDbOrder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project9_MongoDbOrder.Services
{
    public class OrderOperation
    {
        public void AddOrder(Order order)
        {
            var connection = new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollection();
            var document = new BsonDocument
            {
                {"CustomerName", order.CustomerName },
                {"District", order.District },
                {"City", order.City },
                {"TotalPrice", order.TotalPrice }
            };
            orderCollection.InsertOne(document);
        }
    }
}
