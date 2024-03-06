
using BoutiqueApp.Services;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoutiqueApp
{
    public partial class App : Application
    {
        static ProductService _productService;
        static CategorieService _categorieService;

        public static ProductService ProductService
        {
            get
            {
                if (_productService == null)
                {
                    _productService = new ProductService(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Product.db3"));
                }
                return _productService;
            }
        }

        public static CategorieService CategorieService
        {
            get
            {
                if (_categorieService == null)
                {
                    _categorieService = new CategorieService(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Product.db3"));
                }
                return _categorieService;
            }
        }





        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
