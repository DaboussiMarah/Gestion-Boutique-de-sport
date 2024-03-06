using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BoutiqueApp.Models;
using BoutiqueApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace BoutiqueApp.ViewModels
{
    public class CategorieAdminViewModel: BaseCategorieViewModel
    {

        public Command LoadCategorieCommand { get; }
        public ObservableCollection<Categorie> categorie { get; }


        public Command AddCategorieCommand { get; }
        public Command CategorieTappedEdit { get; }
        public Command CategorieTappedDelete { get; }


        public Command ClearCategorieCommand { get; }





        public CategorieAdminViewModel(INavigation _navigation)
        {
            LoadCategorieCommand = new Command(async () => await ExecuteLoadProductCommand());
            categorie = new ObservableCollection<Categorie>();
            AddCategorieCommand = new Command(onAddCategorie);
            CategorieTappedEdit = new Command<Categorie>(onEditCategorie);
            CategorieTappedDelete = new Command<Categorie>(onDeleteCategorie);
            ClearCategorieCommand = new Command(ClearCategorie);
            Navigation = _navigation;


        }

        async Task ExecuteLoadProductCommand()
        {
            IsBusy = true;

            try
            {

                categorie.Clear();
                var catList = await App.CategorieService.GetCategoriesAsync();
                foreach (var prod in catList)
                {
                    categorie.Add(prod);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }






        }

        private async void onAddCategorie(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AjouterCategorieAdmin));
        }



        private async void onEditCategorie(Categorie cat)
        {
            await Navigation.PushAsync(new AjouterCategorieAdmin(cat));
        }



        private async void onDeleteCategorie(Categorie cat)
        {
            if (cat == null)
            {
                return;
            }

            await App.CategorieService.DeleteCategorieAsync(cat.CategorieId);
            await ExecuteLoadProductCommand();
        }


        private async void ClearCategorie()
        {
            categorie.Clear();
        }

        public void OnAppearing()
        {
            IsBusy = true;

        }
    }
}
