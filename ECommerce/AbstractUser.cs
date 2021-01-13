namespace ECommerce
{
    abstract class AbstractUser
    {
        // Fields
        protected int _id;
        protected string _firstName;
        protected string _lastName;
        protected string _email;
        protected string _password;

        //Properties
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

        public abstract void Login(string email, string password);
    }
}