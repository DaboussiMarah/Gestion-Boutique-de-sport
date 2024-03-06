using BoutiqueApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueApp.Services
{
    public class CategorieService : ICategorieRepository


    {


        public SQLiteAsyncConnection _database;

        public CategorieService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Categorie>().Wait();

        }






        public async Task<bool> AddCategorieAsync(Categorie categorie)
        {
            if (categorie.CategorieId > 0)
            {
                await _database.UpdateAsync(categorie);
            }
            else
            {
                await _database.InsertAsync(categorie);

            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCategorieAsync(int id)
        {
            await _database.DeleteAsync<Categorie>(id);
            return await Task.FromResult(true);
        }

        public async Task<Categorie> GetCategorieAsync(int id)
        {
            return await _database.Table<Categorie>().Where(p => p.CategorieId == id).FirstOrDefaultAsync();

        }

        public  async  Task<IEnumerable<Categorie>> GetCategoriesAsync()
        {
            return await Task.FromResult(await _database.Table<Categorie>().ToListAsync());

        }

        public Task<bool> UpdateCategorieAsync(Categorie categorie)
        {
            throw new NotImplementedException();
        }
    }
}
