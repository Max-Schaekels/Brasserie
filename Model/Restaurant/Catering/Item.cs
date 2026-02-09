using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Item
    {
        private string _name;
        private string _description;
        private int _id;
        private double _unitPrice;
        private double _vatRate;
        private string _pictureName;

        public Item(int id, string name, string description, double unitPrice, double vatRate, string pictureName)
        {
            Id = id;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            VatRate = vatRate;
            PictureName = pictureName;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (Utilities.EntriesValidation.ValidUtils.CheckEntryName(value))
                {
                    _name = value;
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (Utilities.EntriesValidation.ValidUtils.CheckEntryDescription(value, 10))
                {
                    _description = value;
                }
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                if (Utilities.EntriesValidation.ValidUtils.CheckIfPositiveNumber(value))
                {
                    _id = value;
                }
            }
        }

        public double UnitPrice
        {
            get => _unitPrice;
            set
            {
                if (Utilities.EntriesValidation.ValidUtils.CheckIfPositiveNumber(value))
                {
                    _unitPrice = value;
                }
            }
        }

        public double VatRate
        {
            get => _vatRate;
            set
            {
                if (Utilities.EntriesValidation.ValidUtils.CheckIfPositiveNumber(value))
                {
                    _vatRate = value;
                }
            }
        }

        public string PictureName
        {
            get => _pictureName;
            set
            {
                if (Utilities.EntriesValidation.ValidUtils.CheckEntryPictureName(value))
                {
                    _pictureName = value;
                }
            }
        }


    }
}
