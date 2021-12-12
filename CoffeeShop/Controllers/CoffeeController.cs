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

        public CoffeeController(IAllCoffee iAllCars, ICoffeeCategory iCarsCat)
        {
            _allCoffee = iAllCars;
            _allCategories = iCarsCat;
        }

        //<summary>
        //Return view cars
        //</summary>
        [Route("Coffee/ListAllCoffee")]
        [Route("Coffee/ListAllCoffee/{category}")]
        public ViewResult AllCoffee(string category)
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
                if (string.Equals("Фильтр-кофе", category, StringComparison.OrdinalIgnoreCase))
                {
                    coffee = _allCoffee.Coffee.Where(i => i.Category.categoryName.Equals("Фильтр-кофе")).OrderBy(i => i.id);
                }
                else if (string.Equals("Эспрессо", category, StringComparison.OrdinalIgnoreCase))
                {
                    coffee = _allCoffee.Coffee.Where(i => i.Category.categoryName.Equals("Эспрессо")).OrderBy(i => i.id);
                }

                currCategory = _category;
            }

            var carObj = new CoffeeListViewModel
            {
                AllCoffee = coffee,
                currCategory = currCategory
            };

            return View(carObj);
        }

    }
}
 