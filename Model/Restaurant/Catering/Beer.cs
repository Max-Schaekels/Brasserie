using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Beer : Alcohol
    {
        private bool _isAbbeyBeer;
        private bool _isTrappistBeer;

        public bool IsAbbeyBeer
        {
            get => _isAbbeyBeer;
            set => _isAbbeyBeer = value;
        }

        public bool IsTrappistBeer
        {
            get => _isTrappistBeer;
            set => _isTrappistBeer = value;
        }

        public Beer() : base()
        {
        }
        public Beer(int id, string name, string description, double unitPrice, double vatRate, string pictureName, double volume, double percentage, bool isAbbeyBeer, bool isTrappistBeer) : base(id, name, description, unitPrice, vatRate, pictureName, volume, percentage)
        {
            IsAbbeyBeer = isAbbeyBeer;
            IsTrappistBeer = isTrappistBeer;
        }

        /// <summary>
        /// Auto Description for this Beer
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} {Volume}cl, {Description} avec un taux d'alcool de {Percentage}%, bière d'abbaye : {IsAbbeyBeer} Trappiste : {IsTrappistBeer} et au prix de {UnitPrice}";
        }
    }
}
