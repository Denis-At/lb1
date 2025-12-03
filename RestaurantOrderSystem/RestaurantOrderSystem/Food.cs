using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem
{
    public class Food : MenuItem
    {
        public string Category { get; }

        public Food(int id, string name, decimal price, string category)
            : base(id, name, price)
        {
            Category = category;
        }
        public override string ToShortString()
        {
            return $"{Id}. {Name} ({Category}) - {Price} грн";
        }
    }
}
