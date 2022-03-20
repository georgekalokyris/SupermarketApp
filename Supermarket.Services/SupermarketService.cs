using Supermarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Data;
using System.ServiceModel;

namespace Supermarket.Services
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
        public class SupermarketService : ISupermarketService, IDisposable
        {
        readonly SupermarketDbContext dbContext = new SupermarketDbContext();
       
        public List<Customer> GetCustomers()
        {
            return dbContext.Customers.ToList();
        }

        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SubmitOrder(Order order)
        {
            dbContext.Orders.Add(order);
            order.OrderItems.ForEach(x => dbContext.OrderItems.Add(x));
            dbContext.SaveChanges();
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
