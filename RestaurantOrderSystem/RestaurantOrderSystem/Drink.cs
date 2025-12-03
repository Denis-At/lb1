using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem
{
    public class Drink : MenuItem
    {
        public int Volume { get; }
        public bool IsAlcoholic { get; }

        public Drink(int id, string name, decimal price, int volume, bool isAlcoholic)
            : base(id, name, price)
        {
            Volume = volume;
            IsAlcoholic = isAlcoholic;
        }

        public override string ToShortString()
        {
            return $"{Id}. {Name} ({Volume} мл) - {Price} грн";
        }
    }
}
