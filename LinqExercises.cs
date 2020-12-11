using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercises
{
    class Cities
    {
        private List<string> _citiesList;
        public List<string> CitiesList
        { 
            get => _citiesList; 
        }

        public Cities(List<string> cities)
        {
            this._citiesList = new List<string>(cities);
        }

        public void ListCities()
        {
            Console.WriteLine("Cities list:");
            foreach (string city in this._citiesList)
            {
                Console.WriteLine(city);
            }
        }
        public void AddCity(string city)
        {
            this._citiesList.Add(city); 
        }
        public void RemoveCity(string city)
        {
            this._citiesList.Remove(city);
        }
        public IEnumerable<string> SelectCity(string city)
        {
            IEnumerable<string> citiesQuery =
                from _city in this._citiesList
                where _city == city
                select _city;

            return citiesQuery;
        }
    }
}