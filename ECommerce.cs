using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ECommerce
{
    class Customer
    {
        // Fields or Attributes
        // Più privati possibili

        // Properties
        // getter - setter

        // private string _X
        // _X -> Underscore convenzione che indica attributo privato


        // Attributes
        protected int _id;
        protected string _firstName;
        protected string _lastName;
        protected string _adress;
        protected int _postalCode;
        protected string _email;
        protected string _password;
        protected int _age;

        // Properties
        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public int Age 
        { 
            get => _age;
            set 
            {
                _age = value;
                if (_age < 18) Console.WriteLine("You may not be able to buy certain articles");
            }
        }

        // ID generator
        protected static int _idGen = 1;
        protected static int GenerateId()
        {
            return _idGen++;
        }

        // Constructors
        public Customer() {}
        public Customer(string firstName, string lastName, string email, int age)
        {
            // Called on instantiation
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
            this._age = age;
            this._id = GenerateId();
        }

        // Methods
        // visibilità - valore di ritorno - NomeMetodo()
        public void Login()
        {
            Console.WriteLine($"Hi {this.FirstName} {this.LastName}, you are logged in.");
        }
        public void MyOrders()
        {
            Console.WriteLine("These are your orders.");
        }
        public void WishList()
        {
            Console.WriteLine("This is your wishlist.");
        }
        public void AddToCart(Article article)
        {
            if (this.Age >= article.AgeRestriction)
            {
                Console.WriteLine("You may not be able to purchase this item");
            }
            else
            {
                Console.WriteLine($"{article.Description} added to cart!");
            }
        }
        public void Signin()
        {
            Console.WriteLine("You are now signed in.");
        }
        public void GetAge()
        {
            Console.WriteLine($"{this.FirstName} {this.LastName} is {this.Age} years old");
            if (this.Age < 18) Console.WriteLine("This customer might not be able to buy certain articles");
        }

        public static void SaySomething()
        {
            Console.WriteLine("Something");
        }
    }

    class Admin : Customer
    {

        public Admin(string firstName, string lastName, string email)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
            this._id = GenerateId();
        }

        public void ManageOrders()
        {
            Console.WriteLine("Manage orders");
        }
        public void ManageArticles()
        {
            Console.WriteLine("Manage articles");
        }
        public void ManageCustomers()
        {
            Console.WriteLine("Manage customers");
        }
    }

    class Customers
    {
        private List<Customer> _customersList;
        public List<Customer> CustomersList
        { 
            get => _customersList; 
        }

        public Customers()
        {
            this._customersList = new List<Customer>();
        }

        public void List()
        {
            Console.WriteLine("Customers list:");
            foreach (Customer customer in this._customersList)
            {
                Console.WriteLine($"Id: {customer.Id}, First name: {customer.FirstName}, Last name: {customer.LastName}, Age: {customer.Age}, e-mail: {customer.Email}");
            }
            Console.WriteLine("");
        }
        public void Add(Customer customer)
        {
            this._customersList.Add(customer);
        }
        public void Add(Customer[] customers)
        {
            foreach (Customer customer in customers)
            {
                this._customersList.Add(customer);
            }
        }
        public void Remove(Customer customer)
        {
            this._customersList.Remove(customer);
        }
    }

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

    class OrderHeader 
    {
        private int _id;
        private string _orderNumber;
        private DateTime _date;
        private int _userId;
        public int Id { get => _id; }
        public string OrderNumber { get => _orderNumber; }
        public DateTime Date { get => _date; }
        public int UserId { get => _userId; }

        public OrderHeader(int userId, DateTime date)
        {
            // È possibile anche scrivere "UserId = userId;" senza il this
            this._userId = userId;
            this._date = date;
        }

        public void Create()
        {
            Console.WriteLine("Create new order");
        }
        public void List() 
        {
            Console.WriteLine("List all orders");
        }
        public void Retrieve(int id)
        {
            Console.WriteLine($"Id: {this.Id}, OrderNumber: {this.OrderNumber}, UserId: {this.UserId}, Date: {this.Date}");
        }
        public void Update()
        {
            Console.WriteLine("Update your order");
        }
        public void Destroy(int id)
        {
            Console.WriteLine($"You just destroyed order #{id}");
        }
    }

    class OrderDetail
    {
        private int _id;
        private int _orderId;
        private int _articleId;
        private double _price;
        private int _articleAmount;

        public int Id { get => _id; }
        public int OrderId { get => _orderId; }
        public int ArticleId { get => _articleId; }
        public double Price { get => _price; }
        public int ArticleAmount { get => _articleAmount; }

        public OrderDetail(int orderId, int articleId, int articleAmount)
        {
            this._orderId = orderId;
            this._articleId = articleId;
            this._articleAmount = articleAmount;
        }
    }
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