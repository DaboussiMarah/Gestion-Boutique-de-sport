using System;
using System.Collections.Generic;
using System.Text;

namespace BoutiqueApp.Models
{
   public  class Commande
    {
        public int CProduitId { get; set; }
        public string CProduitNom { get; set; }
        public decimal CPrix { get; set; }
    }
}
