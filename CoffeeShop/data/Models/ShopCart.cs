using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContent appDBContent;

        public ShopCart(AppDbContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopId { get; set; }

        public List<ShopItems> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CoffeeId") ?? Guid.NewGuid().ToString();

            session.SetString("CoffeeId", shopCartId);

            return new ShopCart(context) { ShopId = shopCartId };

        }

        public void AddToCart(Coffee coffee)
        {
            appDBContent.ShopItems.Add(new ShopItems
            {
                ShopId = ShopId,
                coffee = coffee,
                price = coffee.price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopItems> getShopItems()
        {
            return appDBContent.ShopItems.Where(c => c.ShopId == ShopId).Include(s => s.coffee).ToList();
        }
    }
}
