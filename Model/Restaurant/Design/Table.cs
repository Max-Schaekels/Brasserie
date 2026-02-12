using Brasserie.Utilities.EntriesValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Design
{
    public class Table
    {
        public const int MINIMUM_SEATS_NUMBER = 2;
        private int _idNumber;
        private int _seatsNumber;
        private bool _isNowBusy;
        private static int _totalSeats;

        public int IdNumber
        {
            get => _idNumber;
            set
            {
                if (ValidUtils.CheckIfPositiveNumber(value))
                {
                    _idNumber = value;
                }
            }
        }

        public int SeatsNumber
        {
            get => _seatsNumber;
            set
            {
                if (ValidUtils.CheckSeatNumber(value))
                {
                    _seatsNumber = value;
                }
            }
        }

        public bool IsNowBusy { get => _isNowBusy; set => _isNowBusy = value; }

        public int TotalSeats { get => _totalSeats; set => _totalSeats = value; }

        public Table(int idNumber, int seatsNumber = MINIMUM_SEATS_NUMBER, bool isNowBusy = false )
        {
            IdNumber = idNumber;
            SeatsNumber = seatsNumber;
            IsNowBusy = isNowBusy;
            TotalSeats+= SeatsNumber;

        }

        public Table(int seatsNumber = MINIMUM_SEATS_NUMBER)
        {
            TotalSeats+= SeatsNumber;
        }
    }
}
