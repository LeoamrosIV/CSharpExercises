using System;

namespace ECommerce
{
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
}