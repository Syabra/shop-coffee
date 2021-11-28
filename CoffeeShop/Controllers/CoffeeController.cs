using CoffeeShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class CoffeeController : Controller
    {
        private readonly IAllCoffee _allCoffee;
        private readonly ICoffeeCategory _allCategories;

        public CoffeeController(IAllCoffee iAllCoffee, ICoffeeCategory iCoffeeCategory)
        {
            _allCoffee = iAllCoffee;
            _allCategories = iCoffeeCategory;
        }
        
        public ViewResult List()
        {
            var coffee = _allCoffee;
            return View(coffee);
        }
    }
}
 