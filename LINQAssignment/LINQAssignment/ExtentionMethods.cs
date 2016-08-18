using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    public static class ExtentionMethods
    {
        public static void Print<T>(this List<T> list)
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
        public static int AverageScores(this List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                sum += list.ElementAt(i);
            }
            return sum / list.Count;
        }
    }
}