using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BoutiqueApp.ViewModels;

namespace BoutiqueApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        private ProduitUtilisateurViewModel _viewModel;

        public CategoriesPage()
        {
            InitializeComponent();

            // Initialiser le ViewModel
            BindingContext = _viewModel = new ProduitUtilisateurViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Appeler la méthode OnAppearing du ViewModel
            _viewModel.OnAppearing();
        }
    }
}
