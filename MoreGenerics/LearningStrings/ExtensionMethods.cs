using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreGenerics
{
    public static class ExtensionMethods
    {
        public static void Print(this string me)
        {
            Console.WriteLine(me);
        }
    }
}
