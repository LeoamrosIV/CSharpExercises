﻿using System;
using ECommerce;

namespace CSharpExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
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
            secondCustomer.AddToCart(article);

            /* Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.WriteLine("Enter your name:");
            string tuoNome = Console.ReadLine();
            Console.WriteLine($"Il tuo nome è {tuoNome.ToUpper()}!"); */
        }
    }
}
