using System;
using ECommerce;
using System.Collections.Generic;
using LinqExercises;

namespace CSharpExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Customers customersList = new Customers();
            Articles articlesList = new Articles();

            // ADMIN
            Customer marco = new Customer("Marco", "Camici", "marco.camici@hotmail.it", 33);
            Customer francesco = new Customer("Francesco", "Bacci", "madcatxxx@gmail.com", 34);

            // ADMIN
            Article hat = new Article("Hat", 15.99, 0, "L");
            Article redHat = new Article("Red Hat", 16.75, 0, "XL");
            Article redScarf = new Article("Red Scarf", 11.49, 0, "M");



            customersList.Add(new Customer[2] {marco, francesco});
            articlesList.Add(new Article[3] {hat, redHat, redScarf});

            customersList.List();
            articlesList.List();

            // USER UI
            var searched = articlesList.Search("Red"); // BONUS, add size
            
            Cart marcoCart = new Cart(marco);

            marcoCart.Add(searched, 4);
            marcoCart.Add(new Article[] {redScarf, hat}, new int[] {2, 3});

            marcoCart.List();

            // marcoCart.Add([hat, redHat]);

            marcoCart.Total();
        }
    }
}
