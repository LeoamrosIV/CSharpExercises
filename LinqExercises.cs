using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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

        /* public static void FirstColumnQuery(string source, char separator)
        // Esempio scritto da Marco
        {
            IEnumerable<string> firstColumnQuery=
                from element in source.Split(separator)
                let trimmed = element.Trim()
                let splitted = trimmed.Split(",")[0]
                where splitted.Contains("Monte Falterona")
                select splitted;
            
            foreach (var peaks in firstColumnQuery)
            {
                Console.WriteLine(peaks);
            }
        } */
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
    class Person
    {
        // Fields
        protected string _firstName;
        protected string _lastName;
        protected int _age;
        protected bool _isAlive = true;

        // Properties
        public string Age
        {
            get => _age.ToString();
            set
            {
                try
                {
                    var parsedAge = Int32.Parse(value);
                    this._age = parsedAge;
                }
                catch (FormatException error)
                {
                    string logLine = $"{DateTime.Now} - {error.Message}\n{error.StackTrace}\n";
                    File.AppendAllText("./error_log.txt", logLine);
                    Console.WriteLine($"Format error: please insert a valid integer for the age\nError details: {error.Message}");
                }
            }
        }

        public Person(string firstName, string lastName, string age)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this.Age = age;
        }
        public void Save(string path)
        // Appends person's data to the selected path
        {
            string stringifiedPerson = $"{this._firstName}; {this._lastName}; {this._age}\n";
            File.AppendAllText(path, stringifiedPerson);
        }
        public void Breath()
        {
            if (this._isAlive)
            {
                Console.WriteLine("I am breathing. Yay!");
            }
            else
            {
                Console.WriteLine("Nothing is happening");
            }
        }
        public void Die()
        {
            this._isAlive = false;
            Console.WriteLine($"{this._firstName} is dead");
        }
        public void Fly()
        {
            Console.WriteLine($"My name is {this._firstName} {this._lastName} and I'm flying");
        }
    }

    /*class Brother : Person
    {

        public Brother(string firstName, string lastName, int age) : base(firstName, lastName, age)
        { // base si riferisce al costruttore della super-classe 
            this._firstName = firstName;
            this._lastName = lastName;
            this._age = age;
        }
    }*/
}