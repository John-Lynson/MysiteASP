using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Core.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public User User { get; set; } // Relatie naar de gebruiker
        public List<ShoppingCartItem> Items { get; set; } // Lijst van items in de winkelwagen
    }
}
