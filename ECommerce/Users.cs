using System;
using System.Collections.Generic;
using System.IO;

namespace ECommerce
{
    static class Users
    // TODO: _list deve caricare la lista da _path, crea metodi per convertire da stringa ad AbstractUser
    {
        private static List<AbstractUser> _list = new List<AbstractUser>();
        private static string _path = "./ECommerce-users.csv";

        public static List<AbstractUser> List { get => _list; }
        public static string Path { get => _path; set => _path = value; }


        public static void ShowList()
        {
            Console.WriteLine("Users list:");
            foreach (AbstractUser user in _list)
            {
                Console.WriteLine($"Id: {user.Id}, First name: {user.FirstName}, Last name: {user.LastName}, e-mail: {user.Email}");
            }
            Console.WriteLine("");
        }

        public static void Add(AbstractUser user)
        {
            _list.Add(user);
            WriteToFile();
        }

        public static void Add(AbstractUser[] users)
        {
            foreach (AbstractUser user in users)
            {
                _list.Add(user);
            }
            WriteToFile();
        }

        public static void Remove(AbstractUser user)
        {
            _list.Remove(user);
            WriteToFile();
        }

        private static void WriteToFile()
        {
            File.WriteAllLines(_path, ToStringList());
        }

        private static List<string> ToStringList()
        {
            List<string> userStrings = new List<string>();

            foreach (var user in _list)
            {
                userStrings.Add(user.ToInlineString());
            }

            return userStrings;
        }

        private static List<AbstractUser> RetrieveFromFile()
        // TODO: add users from _path to usersList 
        {
            List<AbstractUser> usersList = new List<AbstractUser>();
            
            return usersList;
        }
    }
}