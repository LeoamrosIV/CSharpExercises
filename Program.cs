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
            /* for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i].ToUpper());
            }

            // var firstCustomer = new Customer();
            Customer firstCustomer = new Customer("Francesco", "Bacci", "madcatxxx@gmail.com");
            firstCustomer.Login();

            Customer secondCustomer = new Customer("Mario", "Rossi", "m.rossi99@hotmail.com");
            secondCustomer.Login();

            Customer.SaySomething();


            Article article = new Article("Face mask", 12.44, true);

            article.List();
            article.Retrieve(0);
            article.Destroy(0);

            Console.WriteLine(article.Description); // GET
            article.Description = "Red scarf"; // SET

            Console.WriteLine($"{article.Description} price: {article.Price}");

            OrderHeader orderHeader = new OrderHeader(101, DateTime.Now);

            orderHeader.List();
            orderHeader.Retrieve(0);
            orderHeader.Destroy(0);
            
            Console.WriteLine($"Date: {orderHeader.Date}, UserID: {orderHeader.UserId}");


            firstCustomer.Age = 11;
            firstCustomer.GetAge();
            firstCustomer.AddToCart(article);

            secondCustomer.Age = 45;
            secondCustomer.GetAge();
            secondCustomer.AddToCart(article); */

            Customers customersList = new Customers();
            Articles articlesList = new Articles();

            Customer luigi = new Customer("Luigi", "Mario", "luigi.mario@nintendo.com");
            customersList.AddCustomer(luigi);
            
            Customer sonic = new Customer("Sonic", "Hedgehog", "sonic.hedgehog@sega.com");
            customersList.AddCustomer(sonic);

            Customer alex = new Customer("Alex", "Kidd", "alex.kidd@miracleworld.net");
            customersList.AddCustomer(alex);
            
            Article gloves = new Article("White gloves", 13.49, 0);
            articlesList.AddArticle(gloves);

            Article fedora = new Article("Black fedora", 16.99, 18);
            articlesList.AddArticle(fedora);

            luigi.Age = 16;
            luigi.GetAge();

            luigi.AddToCart(fedora);

            Console.WriteLine("");

            sonic.Age = 21;
            sonic.GetAge();

            alex.Age = 19;
            
            sonic.AddToCart(gloves);

            customersList.ListCustomers();
            /* Customers list:
            Id: 1, First name: Luigi, Last name: Mario, e-mail: luigi.mario@nintendo.com
            Id: 2, First name: Sonic, Last name: Hedgehog, e-mail: sonic.hedgehog@sega.com
            Id: 3, First name: Alex, Last name: Kidd, e-mail: alex.kidd@miracleworld.net */

            /* customersList.RemoveCustomer(luigi);
            customersList.ListCustomers();

            customersList.AddCustomer(luigi);
            customersList.ListCustomers(); */

            articlesList.ListArticles();
            /* Articles list:
            Id: 1, description: White gloves, price: 13,49, Age Restriction: 0
            Id: 2, description: Black fedora, price: 16,99, Age Restriction: 18 */

            Admin mario = new Admin("Mario", "Mario", "mario.mario@nintendo.com");
            customersList.AddCustomer(mario);

            mario.ManageArticles();

            customersList.ListCustomers();

            Cart myCart = new Cart(1, 2, 4);
            myCart.List();
            myCart.CheckOut();

            OrderDetail orderDetail = new OrderDetail(1, 2, 3);
            Console.WriteLine($"Order ID #{orderDetail.OrderId}: Article number #{orderDetail.ArticleId} x {orderDetail.ArticleAmount} pieces");

            // Classes: Customer, Admin, Customers, OrderHeader, OrderDetail, Article, Articles, Cart
            /* class Article // tabella articles
            {
                private int Id; // colonna id - primary key
            } */
            // class Admin : Customer {} // Ereditarietà
            // ASP.NET Core - Object relational mapper - ORM
            // Linq
            // Entity framework

            // Customer luca = new Customer();
            // Article searchedArticle = Articles.Search("Cappello rosso");
            // new OrderHeader(luca.id); Create; Delete; List;
            // new Articles(); // NO
            // Articles.Add(); // SI PUO` FARE CON METODO STATICO?
            // Cart.Add(searchedArticle); 
            // BONUS: SCRIVERE SU FILE

            Cities cities = new Cities(new List<string> {"Arezzo", "Arezzo", "Siena", "Firenze", "Lucca"});

            //cities.ListCities();

            IEnumerable<string> myQuery = cities.SelectCity("Arezzo");

            foreach (string city in myQuery)
            {
                Console.WriteLine(city);
            };

            /* Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.WriteLine("Enter your name:");
            string tuoNome = Console.ReadLine();
            Console.WriteLine($"Il tuo nome è {tuoNome.ToUpper()}!"); */
        }
    }
}
