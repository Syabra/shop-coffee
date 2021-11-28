using CoffeeShop.Data.Interfaces;
using CoffeeShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Repository
{
    public class CoffeeRepository : IAllCoffee
    {
        private readonly AppDbContent appDBContent;

        public CoffeeRepository(AppDbContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }


        public IEnumerable<Coffee> Coffee => appDBContent.Coffee.Include(c => c.Category);

        public IEnumerable<Coffee> getCoffee => appDBContent.Coffee.Include(c => c.Category);

        public Coffee getObjectCar(int coffeeId) => appDBContent.Coffee.FirstOrDefault(p => p.id == coffeeId);

    }
}
