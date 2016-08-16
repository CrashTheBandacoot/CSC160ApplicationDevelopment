using LinkSyntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            //a bunch of n people
            var people = new List<Person>();

            people.Add(new Person() { Age = 50, Name = "Euphrades" });
            people.Add(new Person() { Age = 20, Name = "Billy" });
            people.Add(new Person() { Age = 2019, Name = "Gandalf" });
            people.Add(new Person() { Age = 0, Name = "new born" });
            people.Add(new Person() { Age = 500, Name = "Oldie" });

            var filteredPeople = people.Where(p => (p.Age > 100 && p.Name.StartsWith("G")));

            foreach (var p in filteredPeople)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
