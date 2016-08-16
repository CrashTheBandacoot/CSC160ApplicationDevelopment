using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    public static class ExtentionMethods
    {
        public static void Print(this List<Student> list)
        {
            foreach(var s in list)
            {
                Console.WriteLine(s.ToString());
            }
        }
        public static string ListConcat(this List<int> list)
        {
            string nums = "";
            for (int i = 0; i < list.Count; ++i)
            {
                nums = nums + " " + list.ElementAt(i);
            }
            return nums;
        }
    }
}