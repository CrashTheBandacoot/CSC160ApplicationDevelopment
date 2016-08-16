using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreGenerics
{
    class Person
    {
        //people have name and age

        public int Age { get; set; }
        public string Name { get; set; }

        /*
         * I happened to put this method here, but because we’re 
         * using Sort that requires a delegate, I could have put 
         * this method in _any_ class... and the Person class doesn’t 
         * need to implement IComparable nor do we need a whole 
         * separate class that implements IComparer.
         *
         * Most importantly, note that Compare receives two _Person_ 
         * instances, not objects, like IComparer and IComparable 
         * both do.  Strongly typing this method, through Generics, 
         * allows this strong typing.
         *
         * Here is the Compare delegate definition:
         * public delegate int Comparison<in T>(
	     *    T x,
	     *    T y
         * )
         * Documented here https://msdn.microsoft.com/en-us/library/tfakywbh(v=vs.110).aspx
        */
        public static int Compare(Person x, Person y)
        {
            int output = x.Age.CompareTo(y.Age);
            if (output == 0)
            {
                output = x.Name.CompareTo(y.Name);
            }
            return output;
        }

        public override string ToString()
        {
            return $"Age: { Age }, Name: { Name }";
        }

    }
}