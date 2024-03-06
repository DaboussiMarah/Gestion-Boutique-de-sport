// ProduitAdmin.xaml.cs
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BoutiqueApp.ViewModels;
using System;

namespace BoutiqueApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProduitAdmin : ContentPage
    {
        private ProduitAdminViewModel _viewModel;

        public ProduitAdmin()
        {
            InitializeComponent();
             
            BindingContext = _viewModel = new ProduitAdminViewModel(Navigation);
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing(); 
        }
    }
}