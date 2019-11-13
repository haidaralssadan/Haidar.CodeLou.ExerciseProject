using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Flag = true;
            var count = 1;
            string keepGoing = "y";
            var studList= new List<Student>();
            
            while (true)
            {
                Console.WriteLine("Enter Student Id");
                var studentId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter First Name");
                var studentFirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                var studentLastName = Console.ReadLine();
                Console.WriteLine("Enter Class Name");
                var className = Console.ReadLine();
                Console.WriteLine("Enter Last Class Completed");
                var lastClass = Console.ReadLine();
                Console.WriteLine("Enter Last Class Completed Date in format MM/dd/YYYY");
                var lastCompletedOn = DateTimeOffset.Parse(Console.ReadLine());
                Console.WriteLine("Enter Start Date in format MM/dd/YYYY");
                var startDate = DateTimeOffset.Parse(Console.ReadLine());
                {
                    var studentRecord = new Student();
                    studentRecord.StudentId = studentId;
                    studentRecord.FirstName = studentFirstName;
                    studentRecord.LastName = studentLastName;
                    studentRecord.ClassName = className;
                    studentRecord.StartDate = startDate;
                    studentRecord.LastClassCompleted = lastClass;
                    studentRecord.LastClassCompletedOn = lastCompletedOn;

                    studList.Add(studentRecord);
                }
                Console.WriteLine("Keep going? Type Y to continou, N to quit");
                keepGoing = Console.ReadLine();
                if (keepGoing == "n")
                { break; }
                
                
                count++;
            }

            Console.WriteLine($"Student Id | Name |  Class ");

            foreach (Student stud in studList)
            { Console.WriteLine($"{stud.StudentId} | {stud.FirstName} {stud.LastName} | {stud.ClassName}"); }
            //Console.WriteLine($"{studentRecord.StudentId} | {studentRecord.FirstName} {studentRecord.LastName} | {studentRecord.ClassName} ");

            Console.ReadKey();




        }
    }
}



    

