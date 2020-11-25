using System;
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

            Customer.PrintSomething();


            /* Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.WriteLine("Enter your name:");
            string tuoNome = Console.ReadLine();
            Console.WriteLine($"Il tuo nome è {tuoNome.ToUpper()}!"); */
        }
    }
}
