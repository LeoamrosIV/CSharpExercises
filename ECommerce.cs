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
            Console.WriteLine("You are logged in ..");
        }
        public void Purchase()
        {
            Console.WriteLine("Purchase");
        }
        public void MyOrders()
        {
            Console.WriteLine("Orders");
        }
        public void WishList()
        {
            Console.WriteLine("Wishlist");
        }
        public void Cart()
        {
            Console.WriteLine("Cart");
        }
        public void Signin()
        {
            Console.WriteLine("Signin");
        }
    }
}