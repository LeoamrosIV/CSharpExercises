using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercises
{
    class FilteringUtils
    {
        public static IEnumerable<string> SearchString(List<string> list, string searchTerm)
        {
            IEnumerable<string> query =
                from i in list
                where i == searchTerm
                select i;
            
            return query;
        }

        public static void ListString(IEnumerable<string> list)
        {
            foreach (string i in list)
            {
                Console.WriteLine(i);
            };
        }

        public static List<string> SeparateStrings(string myString, char divisor)
        {
            List<string> resultList = new List<string>();
            foreach (string i in myString.Split(divisor))
            {
                resultList.Add(i.Trim());
            }

            return resultList;
        }
        public static string FirstColumn(string myString, char divisor)
        {
            return FilteringUtils.SeparateStrings(myString, divisor)[0];
        }
    }

    class Mountain
    {
        private string _name;
        private int _height;
        private string _location;
        public string Name { get => _name; set => _name = value; }
        public int Height { get => _height; set => _height = value; }
        public string Location { get => _location; set => _location = value; }

        public Mountain(string myMountain)
        {
            List<string> mountainParameters = FilteringUtils.SeparateStrings(myMountain, ',');
            this._name = mountainParameters[0];
            this._height = Convert.ToInt32(mountainParameters[1]);
            this._location = mountainParameters[2];
        }
    }

    class Mountains
    {
        private List<Mountain> _mountainsList;
        public List<Mountain> MountainsList
        { 
            get => _mountainsList; 
        }

        public Mountains()
        {
            this._mountainsList = new List<Mountain>();
        }

        public void List()
        {
            Console.WriteLine("Mountains list:");
            foreach (Mountain mountain in this._mountainsList)
            {
                Console.WriteLine($"Name: {mountain.Name}, Height: {mountain.Height}, Location: {mountain.Location}");
            }
        }

        public void ListNames()
        {
            Console.WriteLine("Mountains' names:");
            foreach (Mountain mountain in this._mountainsList)
            {
                Console.WriteLine(mountain.Name);
            }
        }
        public void Add(Mountain mountain)
        {
            this._mountainsList.Add(mountain);
        }
        public void AddFromString(string mountains)
        {
            List<string> mountainsList = FilteringUtils.SeparateStrings(mountains, ';');
            foreach (string mountain in mountainsList)
            {
                this._mountainsList.Add(new Mountain(mountain));
            }
        }
        public void Removemountain(Mountain mountain)
        {
            this._mountainsList.Remove(mountain);
        }
    }
}