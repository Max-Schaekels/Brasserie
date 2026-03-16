using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Soft : Drink
    {
        public Soft() : base()
        {
        }
        public Soft(int id, string name, string description, double unitPrice, double vatRate, string pictureName, double volume) : base(id, name, description, unitPrice, vatRate, pictureName, volume)
        {
        }
    }
}
