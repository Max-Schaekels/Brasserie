using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brasserie.Utilities.EntriesValidation;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Alcohol : Drink
    {
        private const double MINIMUM_PERCENTAGE = 0.0;
        private const double MAXIMUM_PERCENTAGE = 100.0;

        private double _percentage;
        private bool _isNA;

        public double Percentage
        {
            get => _percentage;
            set
            {
                if (ValidUtils.IsInRange(value, MINIMUM_PERCENTAGE, MAXIMUM_PERCENTAGE))
                {
                    _percentage = value;
                    EvalNA();
                }
            }
        }

        public bool IsNA
        {
            get => _isNA;
            set => _isNA = value;
        }

        public void EvalNA()
        {
            IsNA = Percentage == 0.0;
        }

        public Alcohol(int id, string name, string description, double unitPrice, double vatRate, string pictureName, double volume, double percentage) : base(id, name, description, unitPrice, vatRate, pictureName, volume)
        {
            Percentage = percentage;
            
        }
    }
}
