using System;

namespace ECommerce
{
    class Customer : AbstractUser
    {
        // Fields or Attributes
        // Più privati possibili

        // Properties
        // getter - setter

        // private string _X
        // _X -> Underscore convenzione che indica attributo privato


        // Attributes
        /* protected int _id;
        protected string _firstName;
        protected string _lastName; */
        protected string _adress;
        protected int _postalCode;
        /* protected string _email;
        protected string _password; */
        protected int _age;

        // Properties
        /* public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; } */
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
        /* protected static int _idGen = 1;
        protected static int GenerateId()
        {
            return _idGen++;
        } */

        // Constructors
        public Customer() {}
        public Customer(string firstName, string lastName, string email, string password, int age)
        {
            // Called on instantiation
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
            this._password = password;
            this._age = age;
            this._id = GenerateId();
        }

        // Methods
        // visibilità - valore di ritorno - NomeMetodo()
        public override void Login(string email, string password)
        {
            if (email == this._email & password == this._password)
            {
                Console.WriteLine($"Hi {this._firstName} {this._lastName}, you are logged in.");
            }
            else
            {
                Console.WriteLine("Wrong username or password");
            }
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
}