using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Dish : Item
    {
        public Dish() : base()
        {
        }

        public Dish(int id, string name, string description, double unitPrice, double vatRate, string pictureName) : base(id, name, description, unitPrice, vatRate, pictureName)
        {
        }
    }
}
