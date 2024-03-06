using BoutiqueApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueApp.Services
{
    public class ProductService : IProductRepository
    {

        public SQLiteAsyncConnection _database;

        public ProductService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Produit>().Wait();

        }


        public async Task<bool> AddProductAsync(Produit produit)
        {
            if (produit.ProduitId > 0)
            {
                await _database.UpdateAsync(produit);
            }
            else
            {
                await _database.InsertAsync(produit);

            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            await _database.DeleteAsync<Produit>(id);
            return await Task.FromResult(true);
        }

        public async Task<Produit> GetProductAsync(int id)
        {
            return await _database.Table<Produit>().Where(p => p.ProduitId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produit>> GetProductsAsync()
        {
            return await Task.FromResult(await _database.Table<Produit>().ToListAsync());

        }

        public Task<bool> UpdateProductAsync(Produit produit)
        {
            throw new NotImplementedException();
        }
    }
}
