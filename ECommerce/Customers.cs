using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ECommerce
{
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

        public void List()
        {
            Console.WriteLine("Customers list:");
            foreach (Customer customer in this._customersList)
            {
                Console.WriteLine($"Id: {customer.Id}, First name: {customer.FirstName}, Last name: {customer.LastName}, Age: {customer.Age}, e-mail: {customer.Email}");
            }
            Console.WriteLine("");
        }
        public void Add(Customer customer)
        {
            this._customersList.Add(customer);
        }
        public void Add(Customer[] customers)
        {
            foreach (Customer customer in customers)
            {
                this._customersList.Add(customer);
            }
        }
        public void Remove(Customer customer)
        {
            this._customersList.Remove(customer);
        }
    }
}