using Brasserie.Utilities.EntriesValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public abstract class Item : INotifyPropertyChanged
    {
        private const int MINIMUM_DESCRIPTION_LENGTH = 10;
        private const int MINIMUM_NAME_LENGTH = 3;
        public static readonly string[] ALLOWED_PICTURE_FILE_FORMATS = { "jpg", "png" } ;

        private string _name;
        private string _description;
        private int _id;
        private double _unitPrice;
        private double _vatRate;
        private string _pictureName;

        public event PropertyChangedEventHandler? PropertyChanged;

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
                if (ValidUtils.CheckEntryDescription(value, MINIMUM_NAME_LENGTH))
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
                OnPropertyChanged(nameof(UnitPrice));
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

        /// <summary>
        /// generate auto description of this item
        /// </summary>
        /// <returns>auto description</returns> 
        public abstract string AutoDescription();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
