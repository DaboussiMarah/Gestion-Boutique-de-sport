
using BoutiqueApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueApp.Services
{
    interface ICategorieRepository
    {
        Task<bool> AddCategorieAsync(Categorie categorie);

        Task<bool> UpdateCategorieAsync(Categorie categorie);


        Task<bool> DeleteCategorieAsync(int id);

        Task<Categorie> GetCategorieAsync(int id);

        Task<IEnumerable<Categorie>> GetCategoriesAsync();

    }
}
