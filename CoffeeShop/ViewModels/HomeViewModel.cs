using CoffeeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Coffee> FavCoffee { get; set; }
    }
}
