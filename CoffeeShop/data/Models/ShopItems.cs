using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{ 
    public class ShopItems
    {
        public int id { get; set; }
        public Coffee coffee { get; set; }
        public int price { get; set; }

        public string ShopId { get; set; }
    }
}
