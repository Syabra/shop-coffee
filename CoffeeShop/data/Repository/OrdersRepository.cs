using CoffeeShop.Data.Interfaces;
using CoffeeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDbContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetails()
                {
                    id = el.id,
                    CoffeeId = el.coffee.id,
                    orderID = order.id,
                    price = el.coffee.price,
                };
                appDBContent.OrderDetails.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
