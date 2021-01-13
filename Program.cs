using System;
using ECommerce;
using System.Collections.Generic;
using LinqExercises;
using System.Linq;
using System.IO;
using UsersList;
using MeterExercise;

namespace CSharpExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractUserTest();
            //MeterConvertExercise();
            //UsersExercise();
            //SearchExample();
            //AggregateExercise();
            //ReadAndWriteFileExercise();
            //PersonFromConsoleExercise(args);
        }

        static void AbstractUserTest()
        {
            Customer giovanni = new Customer("Giovanni", "Bianchi", "gb2021@mail.com", "00000", 21);
            giovanni.Login("gb2021@mail.com", "00000");
        }

        static void MeterConvertExercise()
        {
            EuSpeedometer myEuSpeedometer = new EuSpeedometer();
            UsaSpeedometer myUsaSpeedometer = new UsaSpeedometer();

            myEuSpeedometer.Speed(1000, 3600);
            myUsaSpeedometer.Speed(5280, 3600);

            myEuSpeedometer.ConvertSpeed(1);
            myUsaSpeedometer.ConvertSpeed(1);

            myUsaSpeedometer.GetMilesPerYear(50);
        }

        static void UsersExercise()
        {
            User marco = new User("Marco", 33);
            User francesco = new User("Francesco", 15);
            User giovanni = new User("Giovanni", 69);
            User paola = new User("Paola", 21);
            User marcella = new User("Marcella", 29);

            ListOfUsers myUsers = new ListOfUsers();
            myUsers.Add(new User[] {marco, francesco, giovanni, paola, marcella});
            myUsers.List();

            var myQuery = myUsers.Search("c");

            ListOfUsers.WriteSearchResultInFile("./UsersList.txt", myQuery);
        }

        static void SearchExample()
        {
            // Declare customers and articles lists
            Customers customersList = new Customers();
            Articles articlesList = new Articles();

            // Customers
            Customer marco = new Customer("Marco", "Camici", "marco.camici@hotmail.it", "12345", 33);
            Customer francesco = new Customer("Francesco", "Bacci", "madcatxxx@gmail.com", "12345", 34);

            // Articles
            Article hat = new Article("Hat", 15.99, 0, "L");
            Article redHat = new Article("Red Hat", 16.75, 0, "XL");
            Article redScarf = new Article("Red Scarf", 11.49, 0, "M");
            Article pinkGloves = new Article("Pink Gloves", 17.85, 0, "S");
            Article redSockets = new Article("Red Sockets", 4.59, 0, "M");
            Article whiteScarf = new Article("White Scarf", 18.60, 0, "L");

            // Add customers and articles to respective lists
            customersList.Add(new Customer[2] {marco, francesco});
            articlesList.Add(new Article[6] {hat, redHat, redScarf, pinkGloves, redSockets, whiteScarf});

            // Show lists
            customersList.List();
            articlesList.List();

            // Search for an article containing "Red" keyword
            var searched = articlesList.Search("Red"); // BONUS, add size
            
            // Creates a cart and adds some items
            Cart marcoCart = new Cart(marco);
            marcoCart.Add(searched, 4);
            marcoCart.Add(new Article[] {pinkGloves, hat}, new int[] {2, 3});

            // Prints cart list and total price
            marcoCart.List();
            marcoCart.Total();

            // Writes articlesList on a file
            articlesList.WriteFile("./articles-exercise.txt");

            // Search an article in a file
            Article.SearchInFile("articles-exercise.txt", "Red");

            // Writes articles in cart on a file
            marcoCart.WriteFile("./cart-exercise.txt");

            // Calculates total price from a file
            Cart.TotalFromFile("cart-exercise.txt");
        }

        static void AggregateExercise()
        {
            TestingClassArticle test1 = new TestingClassArticle(4.35, "T-shirt");
            TestingClassArticle test2 = new TestingClassArticle(58.39, "Jeans");

            List<TestingClassArticle> prices = new List<TestingClassArticle> {test1, test2};

            TestingClassArticle test3 = new TestingClassArticle(7.79, "Hat");
            prices.Add(test3);

            Console.WriteLine(prices[2].Description);

            double total = prices.Aggregate(0.0, ((acc, val) => (acc + val.Price)));
            Console.WriteLine(total);
        
        }

        class TestingClassArticle
        {
            public double Price { get; } = 14.50;
            public string Description { get; } = "Description";
            public TestingClassArticle(){}
            public TestingClassArticle(double price, string description)
            {
                this.Price = price;
                this.Description = description;
            }
        }

        static void ReadAndWriteFileExercise()
        {
            string[] lines = File.ReadAllLines("./order-details.csv");
            var query =
                from line in lines
                let row = line.Split(',')
                let fourthColumn = row[3].Trim()
                select Int32.Parse(fourthColumn);
                // select (int)fourthColumn // non funziona con tringhe, ma solo con altri tipi di numeri

            int max = query.Max();
            Console.WriteLine(query.Sum());
            Console.WriteLine(max);

            File.WriteAllText("./max.txt", max.ToString());
        }

        static void PersonFromConsoleExercise(string[] args)
        // dotnet run firstName lastName age
        {
            if (args.Length == 3)
            {
                Person consolePerson = new Person(args[0], args[1], args[2]);
                if (consolePerson.Age != "0") 
                {
                    consolePerson.Save("./people-test.csv");
                }
            }
        }
    }
}
