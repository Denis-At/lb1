using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem
{
    public class Restaurant
    {
        public string Name { get; }
        public Menu Menu { get; }
        private List<Order> orders = new List<Order>();
        private int nextOrderId = 1;
        public Restaurant(string name)
        {
            Name = name;
            Menu = new Menu();
        }
        public Order CreateOrder(int tableNumber)
        {
            var order = new Order(nextOrderId++, tableNumber);
            orders.Add(order);
            return order;
        }
        public Order? GetOrder(int orderId)
        {
            return orders.FirstOrDefault(o => o.Id == orderId);
        }
        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }
}
