using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brasserie.Utilities.EntriesValidation;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Drink : Item
    {
        private const double MINIMUM_VOLUME = 1.0;
        private double _volume;

        public double Volume
        {
            get => _volume;
            set
            {
                if (ValidUtils.IsInRange(value, MINIMUM_VOLUME))
                {
                    _volume = value;
                }
            }
        }

        public Drink() : base()
        {
        }

        public Drink(int id, string name, string description, double unitPrice, double vatRate, string pictureName, double volume) : base(id, name, description, unitPrice, vatRate, pictureName)
        {
            Volume = volume;
        }

        /// <summary>
        /// Auto Description for this Drink
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} {Volume} cl, {Description} au prix de {UnitPrice}";
        }
    }
}
