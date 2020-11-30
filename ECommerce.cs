using System;

namespace ECommerce
{
    class Customer
    {
        // Fields or Attributes
        // Più privati possibili

        // private string _X
        // _X -> Underscore convenzione che indica attributo privato

        protected int Id;
        protected string FirstName;
        protected string LastName;
        protected string Adress;
        protected int PostalCode;
        protected string Email;
        protected string Password;
        
        // Properties
        // getter - setter

        // Constructor
        public Customer(string firstName, string lastName, string email)
        {
            // Called on instantiation
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        // Methods
        // visibilità - valore di ritorno - NomeMetodo()
        public void Login()
        {
            Console.WriteLine($"Hi {this.FirstName} {this.LastName}, you are logged in.");
        }
        public void CheckOut()
        {
            Console.WriteLine("Product(s) purchased.");
        }
        public void MyOrders()
        {
            Console.WriteLine("These are your orders.");
        }
        public void WishList()
        {
            Console.WriteLine("This is your wishlist.");
        }
        public void AddToCart()
        {
            Console.WriteLine("Product added to cart!");
        }
        public void Signin()
        {
            Console.WriteLine("You are now signed in.");
        }
        public static void PrintSomething()
        {
            Console.WriteLine("Something");
        }
    }

    class Article
    {
        private int Id;
        private string Description;
        private double Price;
        private int Stock;
        private int Taxes;
        
        public Article(string description, double price)
        {
            this.Description = description;
            this.Price = price;
        }

        public void Create()
        {
            Console.WriteLine("Create new article");
        }
        public void List() 
        {
            Console.WriteLine("List all articles");
        }
        public void Retrieve(int id)
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

    class OrderHeader {
        private int Id;
        private int OrderNumber;
        private DateTime Date;
        private int UserId;

        public OrderHeader(int userId, DateTime date)
        {
            // È possibile anche scrivere "UserId = userId;" senza il this
            this.UserId = userId;
            this.Date = date;
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
            Console.WriteLine("Update your order.");
        }
        public void Destroy(int id)
        {
            Console.WriteLine($"You just destroyed order #{id}");
        }
    }
}