namespace ECommerce
{
    class Customer
    {
        protected int Id;
        protected string FirstName;
        protected string LastName;
        protected string Adress;
        protected int PostalCode;
        protected string Email;
        protected string Password;
        
        // visibilità - valore di ritorno - NomeMetodo()
        public void Login()
        {
            Console.WriteLine("You are logged in ...");
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
    }
}