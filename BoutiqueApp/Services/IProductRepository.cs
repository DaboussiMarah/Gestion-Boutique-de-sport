using BoutiqueApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueApp.Services
{
    interface IProductRepository
    {
        Task<bool> AddProductAsync(Produit produit);
         
        Task<bool> UpdateProductAsync(Produit produit);


        Task<bool> DeleteProductAsync(int id);

        Task<Produit> GetProductAsync(int id);

        Task<IEnumerable<Produit>> GetProductsAsync();

    }
}
