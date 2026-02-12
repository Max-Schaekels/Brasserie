using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brasserie.Utilities.EntriesValidation
{
    public class ValidUtils
    {

        public static bool CheckIfPositiveNumber(int value)
        {
            return value >= 0;
        }

        public static bool CheckIfPositiveNumber(double value)
        {
            return value >= 0;
        }

        public static bool CheckEntryName(string name)
        {
            //name = "P- Henri";
            //si le nom débute ou termine par un espace ou un tiret
            if (name.StartsWith(" ") || name.StartsWith("-") || name.EndsWith(" ") || name.EndsWith("-"))
            {//MessageBox.Show($"La saisie {name} ne peut commencer ou se terminer par un espace ou un tiret", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //si le nom contient au moins un double espace.
            if (name.Contains(" ") || name.Contains("--"))
            {
                //MessageBox.Show($"La saisie {name} comporte au moins un double espace ou tiret non autorisé", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            //test s'il y a présence de caractère spéciaux (en dehors de l'alphabet) ou accentués sans tenir compte d'un espace ou un tiret (derrière le Z: Z -)
            if (!Regex.IsMatch(name, @"^[a-zA-Z -]*$"))
            {
                //MessageBox.Show($"La saisie {name} ne peut comporter de caractères spéciaux ou accentués", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            string[] nameParts = name.Split('-', ' ');
            foreach (string s in nameParts)
            {
                //test si la première lettre est une majuscule et les suivantes de a à z en minuscule et sans accent
                if (!Regex.IsMatch(s, @"^[A-Z][a-z]*$"))
                {
                    //MessageBox.Show($"La saisie {name} ne correpond pas aux critères. La première lettre de chaque élément qui compose la saisie doit être une majuscule et les suivantes des minuscules.", $"Erreur de saisie {name}", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            //tous les tests concluants, saisie valide.
            return true;
        }

        public static bool CheckEntryDescription(string description, int lenght)
        {

            if (description.Length < lenght)
            {

                return false;
            }

            return true;
        }

        public static bool CheckEntryPictureName(string value)
        {
            if (!Regex.IsMatch(value, @"^[a-zA-Z0-9_-]+\.(jpg|png)$"))
            {
                return false;
            }

            return true;
        }

        public static bool CheckFileFormat(string fileName, string[] AuthorizedFormats)
        {
            foreach (string format in AuthorizedFormats)
            {
                if (fileName.EndsWith(format))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckSeatNumber(int seatNumber)
        {
            if (seatNumber >= 2)
            {
                return true;
            }
            return false;
        }

        public static bool IsInRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }
        /// <summary>
        /// Check if value is in range defined by a low limit included
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static bool IsInRange(int value, int min)
        {
            return value >= min;
        }
    }
}
