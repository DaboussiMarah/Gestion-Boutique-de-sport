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
    public class ProduitAdminViewModel : BaseProductViewModel
    {

        public Command LoadProductCommand { get; }
        public ObservableCollection<Produit> produit { get; }


        public Command AddProductCommand { get; }
        public Command ProductTappedEdit { get; }
        public Command ProductTappedDelete { get; }


        public Command ClearProductCommand { get; }





        public ProduitAdminViewModel(INavigation _navigation)
        {
            LoadProductCommand = new Command(async () => await ExecuteLoadProductCommand());
            produit = new ObservableCollection<Produit>();
            AddProductCommand = new Command(onAddProduct);
            ProductTappedEdit = new Command<Produit>(onEditProduct);
            ProductTappedDelete = new Command<Produit>(onDeleteProduct);
            ClearProductCommand = new Command(ClearProduct);
            Navigation = _navigation;


        }

        async Task ExecuteLoadProductCommand()
        {
            IsBusy = true;

            try
            {

                produit.Clear();
                var prodList = await App.ProductService.GetProductsAsync();
                foreach (var prod in prodList)
                {
                    produit.Add(prod);
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

        private async void onAddProduct(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AjouterProduitAdmin));
        }



        private async void onEditProduct(Produit prod)
        {
            await Navigation.PushAsync(new AjouterProduitAdmin(prod));
        }



        private async void onDeleteProduct(Produit prod)
        {
            if (prod == null)
            {
                return;
            }

            await App.ProductService.DeleteProductAsync(prod.ProduitId);
            await ExecuteLoadProductCommand();
        }


        private async void ClearProduct()
        {
            produit.Clear();
        }

        public void OnAppearing()
        {
            IsBusy = true;
            
        }
    }
}