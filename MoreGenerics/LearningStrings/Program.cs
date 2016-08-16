using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
            Console.ReadLine();
            string hello = "Helloooooo";
            hello.Print();
        }

        private bool FilterPersonByAge(Person p)
        {
            return (p.Age > 50);
        }
        private void Start()
        {
            //a bunch of n people
            var people = new List<Person>();

            people.Add(new Person() { Age = 50, Name = "Billy" });
            people.Add(new Person() { Age = 20, Name = "Euphrades" });
            people.Add(new Person() { Age = -1, Name = "new born" });
            people.Add(new Person() { Age = 500, Name = "Oldie" });
            var filteredPeople = people.Where(p => p.Age > 30);
            Console.WriteLine(filteredPeople.ToList().Count());

            /*
             * I chose to make Person.Compare a static method because
             * the method isn't part of a single Person instance.  It 
             * compares two instances.  Making it an instance method
             * would have confused which person we should compare: this, arg1
             * or arg2.
             */
            people.Sort(Person.Compare);

            Console.WriteLine(people[0]);

            //create a method that returns the first person in the bunch
            //sorted by age, then name asc
        }
    }
}