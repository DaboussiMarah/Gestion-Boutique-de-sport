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
    public partial class AdminPage   : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }



        private  void LogoutButton_Clicked(object sender, EventArgs e)
        {
           
            Shell.Current.Navigation.PushAsync(new AuthentificationPage());
        }



        private void CategorieButton_Clicked(object sender, EventArgs e)
        {

            Shell.Current.Navigation.PushAsync(new CategorieAdmin());
        }


        private void ProduitButton_Clicked(object sender, EventArgs e)
        {

            Shell.Current.Navigation.PushAsync(new ProduitAdmin());
        }


    }
}