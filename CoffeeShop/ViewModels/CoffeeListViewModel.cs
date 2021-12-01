﻿using CoffeeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.ViewModels
{
    public class CoffeeListViewModel
    {
        public IEnumerable<Coffee> AllCoffee { get; set; }
        public string currCategory { get; set; }
    }
}
