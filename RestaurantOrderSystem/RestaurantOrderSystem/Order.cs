using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem
{
    public class Order
    {
        public int Id { get; }
        public int TableNumber { get; }
        public OrderStatus Status { get; set; }
        private List<MenuItem> items = new List<MenuItem>();
        public Order(int id, int tableNumber)
        {
            Id = id;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
        }
        public void AddItem(MenuItem item)
        {
            items.Add(item);
        }
        public bool RemoveItem(int index)
        {
            if (index < 0 || index >= items.Count)
                return false;

            items.RemoveAt(index);
            return true;
        }
        public decimal TotalPrice => items.Sum(i => i.Price);
        public void PrintItems()
        {
            Console.WriteLine("--- Позиції замовлення ---");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].ToShortString()}");
            }
        }
    }
}
