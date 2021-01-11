using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace UsersList
{
    class User
    {
        // Fields
        private int _id;
        private string _name;
        private int _age;
        
        // Properties
        public int Id { get => _id; }
        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }

        // Constructor
        public User(string name, int age)
        {
            this._name = name;
            if (age >= 18)
            {
                this._age = age;
            }
        }
    }

    class ListOfUsers
    {
        // Fields
        private List<User> _myList;

        // Properties
        public List<User> MyList { get => _myList; }

        // Constructor
        public ListOfUsers()
        {
            this._myList = new List<User>();
        }

        public void Add(User user)
        {
            _myList.Add(user);
        }
        public void Add(User[] users)
        {
            foreach (var user in users)
            {
                _myList.Add(user);
            }
        }

        public void List()
        {
            Console.WriteLine("\nList of users:");
                foreach (var user in _myList)
                {
                    Console.WriteLine($"User name: {user.Name}, user age: {user.Age}");
                }
        }

        public IEnumerable<string> Search(string searchTerm)
        {
            IEnumerable<string> query =
                from user in _myList
                where user.Name.ToLower().Contains(searchTerm.ToLower())
                select user.Name;
            
            Console.WriteLine($"\nSearch results for \"{searchTerm}\":");
            foreach (var user in query)
            {
                Console.WriteLine($"User name: {user}");
            }

            return query;
        }

        public static void WriteSearchResultInFile(string path, IEnumerable<string> searchResult)
        {
            File.WriteAllLines(path, searchResult);
            Console.WriteLine($"Your search result has been written in {path}");
        }
    }
}