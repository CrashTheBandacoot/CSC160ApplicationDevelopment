using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkSyntax
{
    class Person
    {
        //people have name and age

        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Age: { Age }, Name: { Name }";
        }
    }
}
