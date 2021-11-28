using CoffeeShop.Data.Models;
using CoffeeShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Repository
{
    public class CategoryRepository : ICoffeeCategory
    {
        private readonly AppDbContent appDBContent;

        public CategoryRepository(AppDbContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;

    }
}
