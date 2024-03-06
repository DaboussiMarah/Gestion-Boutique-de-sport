using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BoutiqueApp.Models;
using Xamarin.Forms;

namespace BoutiqueApp.ViewModels
{
    public class ProduitUtilisateurViewModel : BaseProductViewModel
    {
        private ObservableCollection<Produit> _produits;
        private ObservableCollection<Commande> _shoppingCart;

        public ObservableCollection<Produit> Produits
        {
            get { return _produits; }
            set { SetProperty(ref _produits, value); }
        }

        public ObservableCollection<Commande> ShoppingCart
        {
            get { return _shoppingCart; }
            set { SetProperty(ref _shoppingCart, value); }
        }

        public decimal TotalPrice => ShoppingCart.Sum(item => item.CPrix);

        public Command<Produit> AddToCartCommand { get; }

        public ProduitUtilisateurViewModel()
        {
            Produits = new ObservableCollection<Produit>();
            ShoppingCart = new ObservableCollection<Commande>();

            LoadProducts();

            AddToCartCommand = new Command<Produit>(AddToCart);
        }

        async void LoadProducts()
        {
            IsBusy = true;

            try
            {
                Produits.Clear();
                var prodList = await App.ProductService.GetProductsAsync();
                foreach (var prod in prodList)
                {
                    Produits.Add(prod);
                }
            }
            catch (Exception)
            {
                // Gérez les erreurs, par exemple, log ou affichage d'un message d'erreur
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void AddToCart(Produit product)
        {
            ShoppingCart.Add(new Commande { CProduitId = product.ProduitId, CProduitNom = product.ProduitNom, CPrix = product.Prix });
        }

        public void OnAppearing()
        {
            IsBusy = true;
            // Ajoutez ici le code supplémentaire que vous souhaitez exécuter lors de l'affichage de la page.
        }
    }
}
