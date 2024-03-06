using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoutiqueApp.Models
{
    public class Produit
    {
        
         [PrimaryKey,AutoIncrement]
        public int ProduitId { get; set; }
        public string ProduitNom { get; set; }
        public string Description { get; set; }
        [NotNull]
        public Decimal Prix { get; set; }
        public String ImageUrl { get; set; }

        
    }
}
