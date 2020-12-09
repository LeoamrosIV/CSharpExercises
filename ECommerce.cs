using System;
using System.Collections.Generic;

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
        public Customer(string firstName, string lastName, string email)
        {
            // Called on instantiation
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
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

        public void ListCustomers()
        {
            Console.WriteLine("Customers list:");
            foreach (Customer customer in this._customersList)
            {
                Console.WriteLine($"Id: {customer.Id}, First name: {customer.FirstName}, Last name: {customer.LastName}, e-mail: {customer.Email}");
            }
        }
        public void AddCustomer(Customer customer)
        {
            this._customersList.Add(customer);
        }
        public void RemoveCustomer(Customer customer)
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
        private int _stock;
        private int _ageRestriction;
        private int _taxes;

        // Properties
        public int Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
        public double Price { get => _price; set => _price = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public int AgeRestriction { get => _ageRestriction; }
        
        // ID generator
        private static int _idGen = 1;
        static int generateId()
        {
            return _idGen++;
        }

        public Article(string description, double price, int ageRestriction)
        {
            this._description = description;
            this._price = price;
            this._ageRestriction = ageRestriction;
            this._id = generateId();
        }

        public void Create()
        {
            Console.WriteLine("Create new article");
        }
        public void List() 
        {
            Console.WriteLine("List all articles");
        }
        public void Retrieve()
        {
            Console.WriteLine($"Id: {this.Id}, description: {this.Description}, price: {this.Price}");
        }
        public void Update()
        {
            Console.WriteLine("Update your article.");
        }
        public void Destroy(int id)
        {
            Console.WriteLine($"You just destroyed item #{id}");
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
        public void ListArticles()
        {
            Console.WriteLine("Articles list:");
            foreach (Article article in this._articlesList)
            {
                Console.WriteLine($"Id: {article.Id}, description: {article.Description}, price: {article.Price}, Age Restriction: {article.AgeRestriction}");
            }
        }
        public void AddArticle(Article article)
        {
            this._articlesList.Add(article);
        }
        public void RemoveArticle(Article article)
        {
            this._articlesList.Remove(article);
        }
        /* public static Article Search()
        {
            //
        } */
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
        private int _articleId;
        private int _userId;
        private int _articleAmount;

        public int Id { get => _id; }
        public int ArticleId { get => _articleId; }
        public int UserId { get => _userId; }
        public int ArticleAmount { get => _articleAmount; }
        
        public Cart(int userId, int articleId, int articleAmount)
        {
            this._userId = userId;
            this._articleId = articleId;
            this._articleAmount = articleAmount;
        }
        public void CheckOut()
        {
            Console.WriteLine("Product(s) purchased.");
        }
        /* public void Add(Article article, int amount)
        {
            //
        } */
        public void Delete()
        {
            Console.WriteLine("You just deleted your cart");
        }
        public void List()
        {
            Console.WriteLine("Show items in your cart");
        }
    }
}