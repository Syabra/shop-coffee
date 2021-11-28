using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{
    public class Coffee
    {
        public int id { get; set; }

        public string name { get; set; }

        public string persentArabica { get; set; }

        public string shortDesc { get; set; }

        public string img { get; set; }

        public string grade { get; set; }


        public int price { get; set; }

        public int categoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
