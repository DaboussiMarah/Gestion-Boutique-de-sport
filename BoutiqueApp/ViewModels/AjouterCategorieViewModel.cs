using BoutiqueApp.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoutiqueApp.ViewModels
{
     public class AjouterCategorieViewModel: BaseCategorieViewModel
    {


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public AjouterCategorieViewModel()
        {
            SaveCommand = new Command(Onsave);
            CancelCommand = new Command(OnCancel);
            Categorie = new Categorie();
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();


        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void Onsave()
        {
            var categorie = Categorie;
            await App.CategorieService.AddCategorieAsync(categorie);
            await Shell.Current.GoToAsync("..");


        }
    }
}
