
using BoutiqueApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BoutiqueApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AjouterProduitAdmin), typeof(AjouterProduitAdmin));
            Routing.RegisterRoute(nameof(AjouterCategorieAdmin), typeof(AjouterCategorieAdmin));


        }


    }
}
