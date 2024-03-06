using BoutiqueApp.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoutiqueApp.ViewModels
{
    public class AjouterProduitViewModel:BaseProductViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public AjouterProduitViewModel()
        {
            SaveCommand = new Command(Onsave);
            CancelCommand = new Command(OnCancel);
            Produit = new Produit();
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();


        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void Onsave()
        {
            var produit = Produit;
            await App.ProductService.AddProductAsync(produit);
            await Shell.Current.GoToAsync("..");


        }
    }
}
