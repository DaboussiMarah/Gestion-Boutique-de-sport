using System;
using System.Collections.ObjectModel;
using System.Linq;
using BoutiqueApp.Models;
using Xamarin.Forms;

namespace BoutiqueApp.ViewModels
{
    public class PanierViewModel : BaseViewModel
    {
        private ObservableCollection<Commande> _shoppingCart;

        public ObservableCollection<Commande> ShoppingCart
        {
            get { return _shoppingCart; }
            set
            {
                SetProperty(ref _shoppingCart, value);
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public decimal TotalPrice => ShoppingCart.Sum(item => item.CPrix);

        public PanierViewModel()
        {
            ShoppingCart = new ObservableCollection<Commande>();
        }
    }
}

