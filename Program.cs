using System;

namespace CSharpExercises
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your name:");
            string tuoNome = Console.ReadLine();
            Console.WriteLine($"Il tuo nome è {tuoNome.ToUpper()}!");
        }
    }
}
