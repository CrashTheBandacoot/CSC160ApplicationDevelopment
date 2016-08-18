using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    class Program
    {
        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
        };
        static void Main(string[] args)
        {
            //Q01
            students.Print();
            Console.WriteLine("----------");
            //Q02
            var lastNameG = students.Where(s=> (s.Last.Equals("Garcia")));
            foreach(var s in lastNameG)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("----------");
            //Q03
            var firstNameH = 
                from s in students
                where s.First.StartsWith("H")
                select s;
            firstNameH.ToList().Print();
            Console.WriteLine("----------");
            //Q04
            var firstNameAlphebetically = students.OrderBy(s=>(s.First)).ToList();
            firstNameAlphebetically.Print();
            Console.WriteLine("----------");
            //Q06
            var firstOrDefault = students.FirstOrDefault();
            Console.WriteLine(firstOrDefault);
            Console.WriteLine("----------");
            //Q08 Not printed
            var groupedByFirstNameLetter = 
                from student in students
                group student by student.First[0];
            //Q10
            foreach (var studentGroup in groupedByFirstNameLetter)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}",
                              student.Last, student.First);
                }
            }
            Console.WriteLine("----------");
            //Q12
            foreach (var s in students)
            {
                Console.WriteLine(s.Scores.AverageStudentScores());
            }
            Console.WriteLine("----------");

            //Q13

        }
    }
}