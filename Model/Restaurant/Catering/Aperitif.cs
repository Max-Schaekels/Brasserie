using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Aperitif : Alcohol
    {
        public Aperitif(int id, string name, string description, double unitPrice, double vatRate, string pictureName, double volume, double percentage) : base(id, name, description, unitPrice, vatRate, pictureName, volume, percentage)
        {
        }
    }
}
