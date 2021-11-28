using CoffeeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDbContent content)
        {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Coffee.Any())
            {
                content.AddRange(
                    new Coffee
                    {
                        name = "Мексика Иксуатлан",
                        shortDesc = "Яркий кофе со вкусом черники, малины, красного вермута и шоколада",
                        persentArabica = "100%",
                        img = "/img/FilterCoffee.png",
                        price = 690,
                        grade = "87.00",
                        Category = Categories["Фильтр-кофе"]
                    },
                    new Coffee
                    {
                        name = "Бэрри",
                        shortDesc = "Вкус с нотами ореховой пасты, темных ягод и печенья. Низкая кислотность и высокая сладость",
                        persentArabica = "100%",
                        img = "/img/MilkCoffee.png",
                        price = 370,
                        grade = "none",
                        Category = Categories["Эспрессо"]
                    },
                    new Coffee
                    {
                        name = "Бариста",
                        shortDesc = "Яркий вкус с нотами молочного шоколада и цветочного меда с цитрусовой кислотностью",
                        persentArabica = "100%",
                        img = "/img/EspressoCoffee.png",
                        price = 390,
                        grade = "none",
                        Category = Categories["Фильтр-кофе"]
                    },
                    new Coffee
                    {
                        name = "Бэрри",
                        shortDesc = "10 дрип-пакетов Бэрри для заваривания в чашке",
                        persentArabica = "100%",
                        img = "/img/DripCoffee.png",
                        price = 400,
                        grade = "none",
                        Category = Categories["Дрип-пакеты"]
                    },
                     new Coffee
                     {
                         name = "Бурунди Гатукуза",
                         shortDesc = "Очень приятная и сбалансированная фруктовая кислотность, яркие цветочные билеты с сочными тропическими фруктами",
                         persentArabica = "100%",
                         img = "/img/sibaristica.jpg",
                         price = 944,
                         grade = "none",
                         Category = Categories["Эспрессо"]
                     },
                      new Coffee
                      {
                          name = "Бэрри",
                          shortDesc = "Он считается одним из лучших сортов кофе на земле. Из этого легендарного кофе можно попробовать многовековые традиции.",
                          persentArabica = "100%",
                          img = "/img/ethiopia.jpg",
                          price = 1700,
                          grade = "87.00",
                          Category = Categories["Фильтр-кофе"]
                      }
                 );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{ categoryName = "Фильтр-кофе"},
                        new Category{ categoryName = "Эспрессо"},
                        new Category{ categoryName = "Фильтр-кофе"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }

                return category;
            }
        }
    }
}
