using System;

namespace ECommerce
{
    class Admin : AbstractUser
    {
        public Admin(string firstName, string lastName, string email, string password) : base(firstName, lastName, email, password) {}

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

        public override string ToInlineString()
        {
            return $"{this._id}; {this._firstName}; {this._lastName}";
        }
    }
}