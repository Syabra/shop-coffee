using CoffeeShop.Data.Interfaces;
using CoffeeShop.Data.Models;
using CoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllCoffee _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCoffee carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Coffee.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Message_Item_Add()
        {
            ViewBag.Message = "Товар добавлен в корзину";
            return View();
        }
    }
}
