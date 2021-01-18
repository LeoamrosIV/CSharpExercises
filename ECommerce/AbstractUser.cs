using System;


namespace ECommerce
{
    abstract class AbstractUser : ILoggable, IQueryable, ICRUDable
    {
        // Fields
        protected int _id;
        protected string _firstName;
        protected string _lastName;
        protected string _email;
        protected string _password;

        // Properties
        public int Id { get => _id; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }

        // ID generator
        protected static int _idGen = 1;
        protected static int GenerateId()
        {
            return _idGen++;
        }

        public AbstractUser(){}
        public AbstractUser(string firstName, string lastName, string email, string password)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
            this._password = password;
            this._id = GenerateId();
        }

        public bool Login(string email, string password)
        {
            if (this._email == email && this._password == password)
            {
                Console.WriteLine($"\nHi {this._firstName}!");
                return true;
            }
            Console.WriteLine("\nWrong username or password");
            return false;
        }

        public void Logout()
        {
            Console.WriteLine("\nLogged out");
        }

        public void SearchInFile(string path, string searchTerm)
        {
            //...
        }

        public void WriteToFile(string path)
        {
            //...
        }

        public abstract string ToInlineString();

        public void Create()
        {
            //...
        }

        public void Retrieve()
        {
            //...
        }

        public void Update()
        {
            //...
        }

        public void Delete()
        {
            //...
        }
    }
}