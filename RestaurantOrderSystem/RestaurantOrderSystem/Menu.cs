using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem
{
    public class Menu
    {
        private List<MenuItem> items = new List<MenuItem>();
        public void AddMenuItem(MenuItem item)
        {
            items.Add(item);
        }
        public MenuItem Find(int id)
        {
            foreach (var it in items)
            {
                if (it.Id == id)
                    return it;
            }
            return null;
        }
        public List<MenuItem> Search(string text)
        {
            text = text.ToLower();
            List<MenuItem> results = new List<MenuItem>();
            foreach (var it in items)
            {
                if (it.Name.ToLower().Contains(text))
                    results.Add(it);
                else if (it is Food foodItem && foodItem.Category.ToLower().Contains(text))
                    results.Add(it);
            }
            return results;
        }
        public void PrintMenu()
        {
            Console.WriteLine("--- Меню ресторану ---");
            foreach (var it in items)
            {
                Console.WriteLine(it.ToShortString());
            }
        }
    }
}
