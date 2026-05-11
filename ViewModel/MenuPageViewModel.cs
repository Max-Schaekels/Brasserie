using Brasserie.Model.Restaurant.Catering;
using Brasserie.Utilities.Interfaces;
using Brasserie.View;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.ViewModel
{
    public partial class MenuPageViewModel : BaseViewModel
    {
        public MenuPageViewModel(IAlertService alertService, IDataAccess dataAccessService) : base(alertService)
        {
            dataAccess = dataAccessService;
            MenuItems = dataAccess.GetAllItems(); //get user's collection datas from chosen DataAccessSource (excel, csv, json...).
        }

        private IDataAccess dataAccess;

        public ItemsCollection MenuItems { get; set; }

        public List<Dish> Dishes
        {
            get
            {
                return MenuItems.OfType<Dish>().ToList();
            }
        }

        public List<Soft> Softs
        {
            get
            {
                return MenuItems.OfType<Soft>().ToList();
            }
        }

        public List<Beer> Beers
        {
            get
            {
                return MenuItems.OfType<Beer>().ToList();
            }
        }

        public List<Aperitif> Aperitifs
        {
            get
            {
                return MenuItems.OfType<Aperitif>().ToList();
            }
        }

        [ObservableProperty]
        private Item itemPopupDisplayed;

        [ObservableProperty]
        private Dish dishPopupDisplayed;

        [ObservableProperty]
        private Drink drinkPopupDisplayed;

        [ObservableProperty]
        private Alcohol alcoholPopupDisplayed;

        [ObservableProperty]
        private Beer beerPopupDisplayed;

        [ObservableProperty]
        private bool isDrinkSelected;

        [ObservableProperty]
        private bool isAlcoholSelected;

        [ObservableProperty]
        private bool isBeerSelected;

        [RelayCommand()]
        private void SelectItem(Item item)
        {
            if (item == null)
            {
                return;
            }

            ItemPopupDisplayed = item;

            DishPopupDisplayed = null;
            DrinkPopupDisplayed = null;
            AlcoholPopupDisplayed = null;
            BeerPopupDisplayed = null;

            IsDrinkSelected = false;
            IsAlcoholSelected = false;
            IsBeerSelected = false;

            if (item is Beer beer)
            {
                BeerPopupDisplayed = beer;
                AlcoholPopupDisplayed = beer;
                DrinkPopupDisplayed = beer;

                IsDrinkSelected = true;
                IsAlcoholSelected = true;
                IsBeerSelected = true;
            }
            else if (item is Alcohol alcohol)
            {
                AlcoholPopupDisplayed = alcohol;
                DrinkPopupDisplayed = alcohol;

                IsDrinkSelected = true;
                IsAlcoholSelected = true;
                IsBeerSelected = false;
            }
            else if (item is Drink drink)
            {
                DrinkPopupDisplayed = drink;

                IsDrinkSelected = true;
                IsAlcoholSelected = false;
                IsBeerSelected = false;
            }
            else if (item is Dish dish)
            {
                DishPopupDisplayed = dish;

                IsDrinkSelected = false;
                IsAlcoholSelected = false;
                IsBeerSelected = false;
            }

            ItemPopup popup = new ItemPopup(this);

            Shell.Current.CurrentPage.ShowPopup(popup);
        }

        [RelayCommand()]
        private async Task SaveItem()
        {
            if (dataAccess.UpdateAllItems(MenuItems))
            {
                await alertService.ShowAlert("Modification", "L'item a bien été modifié.");
            }
            else
            {
                await alertService.ShowAlert("Erreur", "Une erreur est survenue lors de l'enregistrement.");
            }
        }
    }
}
