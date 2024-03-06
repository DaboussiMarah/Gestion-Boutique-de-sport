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
    public partial class AuthentificationPage : ContentPage
    {
        public AuthentificationPage()
        {
            InitializeComponent();
        }






        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // TODO: Implémentez votre logique d'authentification ici
            if (IsUserAuthenticated(username, password))
            {
                // L'utilisateur est authentifié, vous pouvez naviguer vers la section admin
                Shell.Current.Navigation.PushAsync(new AdminPage());
            }
            else
            {
                DisplayAlert("Erreur", "Nom d'utilisateur ou mot de passe incorrect", "OK");
            }
        }




        private bool IsUserAuthenticated(string username, string password)
        {
            // Vérification statique pour l'authentification
            return username == "admin" && password == "admin123";
        }

    }



}
