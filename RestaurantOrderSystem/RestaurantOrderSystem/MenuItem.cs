using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem
{
    public abstract class MenuItem: IPriceable
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        protected MenuItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public virtual string ToShortString()
        {
            return $"{Id}. {Name} - {Price} грн";
        }
    }
}
