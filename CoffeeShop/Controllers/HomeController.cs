using CoffeeShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.ViewModels;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        
        private IAllCoffee _coffeeRep;

        public HomeController(IAllCoffee coffeeRep)
        {
            _coffeeRep = coffeeRep;
        }

        public ViewResult Index()
        {
            var homeCoffee = new HomeViewModel
            {
                FavCoffee = _coffeeRep.getCoffee
            };

            return View(homeCoffee);
        }
        
    }
}
