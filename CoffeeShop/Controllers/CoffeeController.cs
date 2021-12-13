using CoffeeShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Data.Models;
using CoffeeShop.ViewModels;

namespace CoffeeShop.Controllers
{
    public class CoffeeController : Controller
    {
        private readonly IAllCoffee _allCoffee;
        private readonly ICoffeeCategory _allCategories;

        public CoffeeController(IAllCoffee iAllCars, ICoffeeCategory iCoffeeCat)
        {
            _allCoffee = iAllCars;
            _allCategories = iCoffeeCat;
        }

        //<summary>
        //Return view cars
        //</summary>
        [Route("Coffee/List")]
        [Route("Coffee/List/{category}")]
        public ViewResult List(string category)
        {
            var _category = category;
            IEnumerable<Coffee> coffee = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                coffee = _allCoffee.Coffee.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Filtr-coffee", category, StringComparison.OrdinalIgnoreCase))
                {
                    coffee = _allCoffee.Coffee.Where(i => i.Category.categoryName.Equals("Фильтр-кофе")).OrderBy(i => i.id);
                    currCategory = "Фильтр-кофе";
                }
                else if (string.Equals("Espresso", category, StringComparison.OrdinalIgnoreCase))
                {
                    coffee = _allCoffee.Coffee.Where(i => i.Category.categoryName.Equals("Эспрессо")).OrderBy(i => i.id);
                    currCategory = "Эспрессо";
                }
                else if(string.Equals("Drip-package", category, StringComparison.OrdinalIgnoreCase))
                {
                    coffee = _allCoffee.Coffee.Where(i => i.Category.categoryName.Equals("Дрип-пакеты")).OrderBy(i => i.id);
                    currCategory = "Дрип-пакеты";
                }
            }

            var coffObj = new CoffeeListViewModel
            {
                AllCoffee = coffee,
                currCategory = currCategory
            };

            return View(coffObj);
        }

    }
}
 