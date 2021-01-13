using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ECommerce
{
    class Articles
    {
        private List<Article> _articlesList;
        public List<Article> ArticlesList
        { 
            get => _articlesList; 
        }

        public Articles()
        {
            this._articlesList = new List<Article>();
        }
        public void Retrieve(int id)
        {
            Console.WriteLine($"Id: {id}, description: , price: ");
        }
        public void Retrieve(Article article)
        {
            Console.WriteLine($"Id: {article.Id}, description: {article.Description}, price: {article.Price}, size: {article.Size}, age restriction: {article.AgeRestriction}");
        }
        public void List()
        {
            Console.WriteLine("Articles list:");
            foreach (Article article in this._articlesList)
            {
                Console.WriteLine($"Id: {article.Id}, description: {article.Description}, price: {article.Price}, size: {article.Size}, age restriction: {article.AgeRestriction}");
            }
            Console.WriteLine("");
        }
        public void Add(Article article)
        {
            this._articlesList.Add(article);
        }
        public void Add(Article[] articles)
        {
            foreach (Article article in articles)
            {
                this._articlesList.Add(article);
            }
        }
        public void Remove(Article article)
        {
            this._articlesList.Remove(article);
        }
        public Article Search(string searchTerm)
        {
            // find the search term in articles description and size and returns the corresponding articles
            IEnumerable<Article> query =
                from article in this._articlesList
                where article.Description.ToLower().Contains(searchTerm.ToLower()) | article.Size.ToLower().Contains(searchTerm.ToLower())
                select article;

            // converts IEnumerable to List
            List<Article> queryList = query.ToList<Article>();

            // prints the search results
            Console.WriteLine("Search results:");
            foreach (Article article in queryList)
            {
                Console.WriteLine($"Item number #{queryList.IndexOf(article)} - Description: {article.Description}, size: {article.Size}, price: {article.Price}");
            }
            Console.WriteLine("");
            
            // if there is more than one result, it will ask to specify an item
            if (queryList.Count > 1) 
            {
                bool parseError;
                int articleIndex = -1;
                while (true)
                {
                    try
                    {
                        parseError = false;
                        Console.WriteLine("Enter the number for the item of your choice: ");
                        articleIndex = Int32.Parse(Console.ReadLine());
                    }
                    
                    // if the user enters an invalid character, it will ask again for input
                    catch (FormatException)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Insert a number from 0 to {queryList.Count - 1}, please");
                        parseError = true;
                    }

                    // if the user enters a number in range, it will return the selected article and print its specifications
                    if (!parseError && articleIndex < queryList.Count && articleIndex >= 0)
                    {
                        var myArticle = queryList[articleIndex];
                        Console.WriteLine($"Id: {myArticle.Id}, description: {myArticle.Description}, price: {myArticle.Price}, size: {myArticle.Size}, age restriction: {myArticle.AgeRestriction}");
                        return queryList[articleIndex];
                    }
                    
                    // if the user enters an out of range number, it will ask again for input
                    else if (!parseError)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Insert a number from 0 to {queryList.Count - 1}, please");
                    }
                }
            }
            
            // if there is exactly one element in the query, it will automatically return it and print its specifications
            else if (queryList.Count == 1)
            {
                var myArticle = queryList[0];
                Console.WriteLine($"Id: {myArticle.Id}, description: {myArticle.Description}, price: {myArticle.Price}, size: {myArticle.Size}, age restriction: {myArticle.AgeRestriction}");
                return myArticle;
            }

            // if there isn't any result, it will print "Nothing found" and return null
            else
            {
                Console.WriteLine("Nothing found");
                return null;
            }
        }

        public void WriteFile(string path)
        {
            File.WriteAllLines(path, this.ToStringList());
        }

        public List<string> ToStringList()
        {
            List<string> articlesStrings = new List<string>();

            foreach (var article in this._articlesList)
            {
                articlesStrings.Add(article.ToInlineString());
            }

            return articlesStrings;
        }
    }
}