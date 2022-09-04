using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class RandomProductGenerator
    {
        const string allNames = "cake, birthday cake, wedding cake, Christmas cake, fruitcake, shortcake, strawberry shortcake,chocolate cake, chocolate chip cake, chocolate layer cake, chocolate frosting cake, honey cake,pound cake, almond cake, napoleon, sponge cake, cheesecake, lemon cake, torte, gingerbread,coffee cake, raisin cupcake, fudge brownie, oatmeal cookie, chocolate cookie, pie, apple pie, blueberry pie, cherry pie, homemade pie, tart, apple tart,mince pie, mincemeat pie, pumpkin pie, rhubarb pie, meat pie, knish, pizza, muffin, blueberry muffin, raisin muffin, biscuit, sour cream biscuit, pancake, griddle cake, English muffin, doughnut, fritter, waffle, meat, beef, pork, veal, lamb, mutton, beefsteak, roast beef, ground beef, hamburger, spare rib, pork chop, lamb chop, veal cutlet, ham, bacon, pastrami, corned beef, sausage, salami, smoked sausage, Bologna, hot dogs, link sausages, frankfurters, wieners, poultry, chicken, turkey, goose, duck, fowl, eggs, whole chicken, chicken quarters, chicken leg, drumstick, chicken wing, chicken breast, turkey breast";
        string[] ProductNames;
        Random random = new Random();

        public RandomProductGenerator()
        {
            ProductNames = allNames.Split(",");
        }
        public Product[] GetRandomProducts(int count)
        {
            Product[] products = new Product[count];
            for (int i = 0; i < count; i++)
            {
                products[i] = new Product();
                products[i].Name = ProductNames[random.Next(0, ProductNames.Length)].Trim();
                products[i].Price = random.Next(1000);
            }
            return products;
        }
    }
}
