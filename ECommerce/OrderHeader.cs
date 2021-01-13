using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ECommerce
{
    class OrderHeader 
    {
        private int _id;
        private string _orderNumber;
        private DateTime _date;
        private int _userId;
        public int Id { get => _id; }
        public string OrderNumber { get => _orderNumber; }
        public DateTime Date { get => _date; }
        public int UserId { get => _userId; }

        public OrderHeader(int userId, DateTime date)
        {
            // È possibile anche scrivere "UserId = userId;" senza il this
            this._userId = userId;
            this._date = date;
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