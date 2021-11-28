using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{
    public class OrderDetails
    {
        public int id { get; set; }

        public int orderID { get; set; }

        public int CoffeeId { get; set; }

        public string adress { get; set; }

        public int price { get; set; }

        public virtual Coffee coffee { get; set; }

        public virtual Order order { get; set; }
    }
}
