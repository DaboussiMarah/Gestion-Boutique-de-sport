using BoutiqueApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoutiqueApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategorieAdmin : ContentPage
    {
        private CategorieAdminViewModel _viewModel;

        public CategorieAdmin()
        {
            InitializeComponent();

            BindingContext = _viewModel = new CategorieAdminViewModel(Navigation);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}