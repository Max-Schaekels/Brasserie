using Brasserie.Utilities.EntriesValidation;
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
        private const int MINIMUM_DESCRIPTION_LENGTH = 10;
        public static readonly string[] ALLOWED_PICTURE_FILE_FORMATS = { "jpg", "png" } ;

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

        public Item()
        {
        }

        public string Name
        {
            get => _name;
            set
            {
                if (ValidUtils.CheckEntryName(value))
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
                if (ValidUtils.CheckEntryDescription(value, MINIMUM_DESCRIPTION_LENGTH))
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
                if (ValidUtils.CheckIfPositiveNumber(value))
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
                if (ValidUtils.CheckIfPositiveNumber(value))
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
                if (ValidUtils.CheckIfPositiveNumber(value))
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
                if (ValidUtils.CheckFileFormat(value, ALLOWED_PICTURE_FILE_FORMATS))
                {
                    _pictureName = value;
                }
            }
        }


    }
}
