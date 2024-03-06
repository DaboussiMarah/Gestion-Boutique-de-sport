using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoutiqueApp.Models;
using BoutiqueApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoutiqueApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjouterProduitAdmin : ContentPage
    { 
        public Produit produit { get; set;   }
        public AjouterProduitAdmin()
        {
            InitializeComponent();
            BindingContext = new AjouterProduitViewModel();
        }




        public AjouterProduitAdmin(Produit produit)
        {
            InitializeComponent();
            BindingContext = new AjouterProduitViewModel();

            if(produit !=null)
            {
                ((AjouterProduitViewModel)BindingContext).Produit = produit;
            }
        }

    }
    }









