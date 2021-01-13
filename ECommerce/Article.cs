using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ECommerce
{
    class Article
    {
        // private int Id; // Field
        // private int Id { get; set; }; // Proprietà
        
        // Attributes
        private int _id;
        private string _description;
        private double _price;
        private string _size;
        private int _stock;
        private int _ageRestriction;
        private int _taxes;

        // Properties
        public int Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
        public double Price { get => _price; set => _price = value; }
        public string Size { get => _size; set => _size = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public int AgeRestriction { get => _ageRestriction; }
        
        // ID generator
        private static int _idGen = 1;
        static int generateId()
        {
            return _idGen++;
        }

        public Article(string description, double price, int ageRestriction, string size)
        {
            this._description = description;
            this._price = price;
            this._ageRestriction = ageRestriction;
            this._size = size;
            this._id = generateId();
        }

        public void Create()
        {
            Console.WriteLine("Create new article");
        }
        public void Retrieve()
        {
            Console.WriteLine($"Id: {this.Id}, description: {this.Description}, price: {this.Price}, size: {this.Size}, age restriction: {this.AgeRestriction}");
        }
        public void Update()
        {
            Console.WriteLine("Update your article.");
        }
        public void Destroy(int id)
        {
            Console.WriteLine($"You just destroyed item #{id}");
        }
        public string ToInlineString()
        {
            return $"{this._id}; {this._description}; {this._size}; {this._price}; {this._taxes}; {this._stock}; {this._ageRestriction}";
        }
        public static void SearchInFile(string path, string searchTerm)
        {
            string[] lines = File.ReadAllLines(path);
            var query = 
                from line in lines
                let row = line.Split(';')
                let descriptionColumn = row[1].Trim()
                where descriptionColumn.Contains(searchTerm)
                select line;
            
            Console.WriteLine($"\nArticles found in {path}:");
            foreach (var line in query)
            {
                Console.WriteLine(line);
            }
            // seleziona line dove descriptionColumn == searchTerm
        }
    }
}