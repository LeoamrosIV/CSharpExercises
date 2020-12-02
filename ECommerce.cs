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
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _adress;
        private int _postalCode;
        private string _email;
        private string _password;
        private int _age;

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

        // Constructor
        public Customer(string firstName, string lastName, string email, Customers customers)
        {
            // Called on instantiation
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            customers.AddCustomer(this);
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
        public void AddToCart(Article article)
        {
            if (article.AdultsOnly && this.Age < 18)
            {
                Console.WriteLine("You may not be able to purchase this item");
            }
            else
            {
                Console.WriteLine($"{article.Description} added to cart!");
            }
        }
        public void ShowCart()
        {
            Console.WriteLine("Show items in your cart");
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

        public void ShowCustomers()
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
        public int Id { get; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        private int Taxes;
        public bool AdultsOnly { get; }
        
        public Article(string description, double price, bool adultsOnly)
        {
            this.Description = description;
            this.Price = price;
            this.AdultsOnly = adultsOnly;
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

    class OrderHeader 
    {
        public int Id { get; }
        public string OrderNumber { get; }
        public DateTime Date { get; }
        public int UserId { get; }

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
            Console.WriteLine("Update your order");
        }
        public void Destroy(int id)
        {
            Console.WriteLine($"You just destroyed order #{id}");
        }
    }
}