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
    }
}