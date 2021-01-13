using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ECommerce
{
    class Cart
    {
        private int _id;
        private List<Article> _articles;
        private List<int> _amount;
        private int _customerId;

        public int Id { get => _id; }
        public List<Article> Articles { get => _articles; }
        public int CustomerId { get => _customerId; }
        
        public Cart(Customer customer)
        {
            this._customerId = customer.Id;
            this._articles = new List<Article>();
            this._amount = new List<int>();
        }
        public void CheckOut()
        {
            Console.WriteLine("Product(s) purchased.");
        }
        public void Add(Article article, int amount = 1)
        {
            this._articles.Add(article);
            this._amount.Add(amount);
        }
        public void Add(Article[] articles, int[] amounts)
        {
            for (int i = 0; i < articles.Length; i++)
            {
                Add(articles[i], amounts[i]);
            }
        }
        public void Delete()
        {
            Console.WriteLine("You just deleted your cart");
        }
        public void List()
        {
            Console.WriteLine("\nArticles in cart:");
            for (int i = 0; i < this._articles.Count; i++)
            {
                Console.WriteLine($"Article: {_articles[i].Description}, amount: {_amount[i]}");
            }
        }
        public double Total()
        {
            double total = 0;
            for (int i = 0; i < this._articles.Count; i++)
            {
                total += (this._articles[i].Price * this._amount[i]);
            }

            Console.WriteLine($"\nTotal price: ${String.Format("{0:0.00}", total)}");
            return total;
        }
        public static double TotalFromFile(string path)
        {
            var query =
                from line in File.ReadAllLines(path)
                let row = line.Split(';')
                let price = double.Parse(row[3].Trim())
                let amount = int.Parse(row[7].Trim())
                let articleTotal = price*amount
                select articleTotal;
            
            double total = 0.0;
            foreach (double price in query)
            {
                total += price;
            }
            
            Console.WriteLine($"\nTotal price: ${String.Format("{0:0.00}", total)}");
            return total;
        }
        public void WriteFile(string path)
        {
            File.WriteAllLines(path, this.ToStringList());
        }

        public List<string> ToStringList()
        {
            List<string> articlesStrings = new List<string>();

            for (int i = 0; i < this._articles.Count; i++)
            {
                articlesStrings.Add($"{this._articles[i].ToInlineString()}; {this._amount[i]}");
            }

            return articlesStrings;
        }
    }
}