using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoutiqueApp.Models
{
   public  class Categorie
    {
        [PrimaryKey, AutoIncrement]
        public int CategorieId { get; set; }
        public string CategorieNom { get; set; }

       public String CategorieImageUrl { get; set; }
    }
}
