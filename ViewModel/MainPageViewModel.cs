using Brasserie.Model.Restaurant.Catering;
using Brasserie.Utilities.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(IDataAccess dataAccessService, IAlertService alertService, string restaurantName = "My Restaurant") : base(alertService, restaurantName)
        {
            dataAccess = dataAccessService;
            Items = dataAccess.GetAllItems(); //get user's collection datas from chosen DataAccessSource (excel, csv, json...).
            //Tables = DataAccess.GetTables(); //get table's collection datas from chosen DataAccessSource (excel, csv, json...).
        }

        /// <summary> /// Manager to the data access (Csv, Json, XAML, SQL...) /// </summary> 
        private IDataAccess dataAccess;
        /// <summary> /// Collection of all users in the databse (source file) /// </summary> 
        public ItemsCollection Items { get; set; }
        //public Item ItemUserSelection { get; set; }

        [ObservableProperty]
        private Item itemUserSelection;

        [RelayCommand()]
        private async void ShowItemDetails()
        {
            if (ItemUserSelection != null)
            {
                await alertService.ShowAlert("Selection", $"Voitre choix :\n{ItemUserSelection.Name}\n " + $"{ItemUserSelection.Description}\n{ItemUserSelection.PictureName}\n{ItemUserSelection.UnitPrice}€");
            }
            else
            {
                await alertService.ShowAlert("Error", "No item selection");
            }
        }
        [RelayCommand()]
        private async void Indexer()
        {           
            if(await alertService.ShowConfirmation("Indexer", "Confirmer l'indexation de tous les prix de 5% ?"))
            {
                Items.IndexPrices(5.0);
            }
        }
        [RelayCommand()]
        private async void SaveChanges()
        {
            bool confirm = await alertService.ShowConfirmation("Save Changes", "Confirmer l'enregistrement des modifications ?");
            if (confirm)
            {
                dataAccess.UpdateAllItems(Items);
                await alertService.ShowAlert("Save Changes", "Modifications enregistrées avec succès !");
            }

        }
    }
}
