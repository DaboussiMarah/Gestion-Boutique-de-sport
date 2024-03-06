using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoutiqueApp.Models;
using BoutiqueApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoutiqueApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjouterCategorieAdmin : ContentPage
    {

        public Categorie categorie { get; set; }
        public AjouterCategorieAdmin()
        {
            InitializeComponent();
            BindingContext = new AjouterCategorieViewModel();
        }




        public AjouterCategorieAdmin(Categorie categorie)
        {
            InitializeComponent();
            BindingContext = new AjouterCategorieViewModel();

            if (categorie != null)
            {
                ((AjouterCategorieViewModel)BindingContext).Categorie = categorie;
            }
        }
    }
}