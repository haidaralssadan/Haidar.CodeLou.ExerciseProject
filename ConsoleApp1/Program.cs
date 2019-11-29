//using System.Windows.forms;
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
        var ans = "y";
        var studentList= new List<Student>()   ;
        Console.WriteLine("Welcome to the Student List program\n\nWould you like to initialize the list with saved values?  Y\\N");
        ans=Console.ReadLine();
        if (ans=="y" || ans=="Y") 
        {
            initList(studentList);
            Console.WriteLine();
            printList(studentList);
        }
            
        while (true) {
            var myChoice = " ";
            Console.WriteLine("\nWhat would you like to do?\n\n-1 Add New Student\n-2 List All Students\n-3 Search Students\n-4 Quit");
            myChoice = Console.ReadLine();
            switch (myChoice)
            {
                case "1":
                    addStudent(studentList);
                    break;
                case "2":  
                    if (studentList.Count() == 0)
                        {
                            Console.WriteLine("\nThe student list is empty, no students to show!");
                        }
                    else
                        {
                            printList(studentList);
                        }
                    break;
                case "3":
                    if (studentList.Count()==0)
                        {
                            Console.WriteLine("\nThe student list is empty, no students to search!");
                        }
                    else
                        {
                            serachList(studentList);   
                        }
                    break;
                    case "4":
                    Console.WriteLine("\nThank you for using my program\nGood bye");
                    //pause
                    break;        
            }
        }
        //Console.WriteLine($"{studentRecord.StudentId} | {studentRecord.FirstName} {studentRecord.LastName} | {studentRecord.ClassName} ");
        //Console.ReadKey();
    }

    static void initList (List<Student> studArg)
    {
        //Console.WriteLine("Initialization");
        Student NewStudent1 = new Student();
        NewStudent1.StudentId =1;
        NewStudent1.FirstName="Ali";
        NewStudent1.LastName="Alssadan";
        NewStudent1.ClassName="C#";
        NewStudent1.LastClassCompleted="WFE";
        NewStudent1.LastClassCompletedOn=DateTime.Now.Date;
        NewStudent1.StartDate=DateTime.Now.Date;
        studArg.Add(NewStudent1);
        //Console.WriteLine($"Student Name {studArg[0].FirstName}");

        Student NewStudent2 = new Student();
        NewStudent2.StudentId =2;
        NewStudent2.FirstName="Haidar";
        NewStudent2.LastName="Alssadan";
        NewStudent2.ClassName="CSS";
        NewStudent2.LastClassCompleted="WFE";
        NewStudent2.LastClassCompletedOn=DateTime.Now.Date;
        NewStudent2.StartDate=DateTime.Now.Date;
        studArg.Add(NewStudent2);
        //Console.WriteLine($"Student Name {studArg[1].FirstName}");

        Student NewStudent3 = new Student();
        NewStudent3.StudentId =3;
        NewStudent3.FirstName="Jon";
        NewStudent3.LastName="Smith";
        NewStudent3.ClassName="Java";
        NewStudent3.LastClassCompleted="Python";
        NewStudent3.LastClassCompletedOn=DateTime.Now.Date;
        NewStudent3.StartDate=DateTime.Now.Date;
        studArg.Add(NewStudent3);
        //Console.WriteLine($"Student Name {studArg[2].FirstName}");

        Console.WriteLine();
        Console.WriteLine($"{studArg.Count()} Students were added to the list.");  

        //Console.WriteLine($"Student Name {studArg[0].FirstName}");
        //Console.WriteLine($"Student Name {studArg[1].FirstName}");
        Console.WriteLine("");
    }

    static void addStudent(List<Student> studArg){
        string keepAdding = "y";
        var count = 0;
        while (true)
        {
            Console.WriteLine($"Student list has {studArg.Count} students\n");
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
                studArg.Add(studentRecord);
            }
            count++;
            Console.WriteLine("Add More Students?  Y/N");
            keepAdding = Console.ReadLine();
            Console.Clear();
            if (keepAdding != "y") { break; }
        }
        Console.WriteLine($"You added {count} new students.\n\nTotal Students are {studArg.Count}");
        Console.WriteLine("");
    }

    static void printList (List<Student> studArg)
    {
        var nameStr= " ";
        var fName= " ";
        var lName = " " ;
        Console.WriteLine("");
        Console.WriteLine($"SId\t| Name\t\t\t| Class ");
        foreach (Student stud in studArg)
        {
            fName = stud.FirstName;
            lName = stud.LastName;
            nameStr= fName + " " + lName;
            if (nameStr.Length<8)
            {
                nameStr=nameStr+"\t\t\t";
            }
            else if (nameStr.Length<14)
            {
                nameStr=nameStr+"\t\t";
            }
            else if (nameStr.Length<22)
            {
                nameStr= nameStr+"\t";
            }

            Console.WriteLine($"{stud.StudentId}\t| {nameStr}| {stud.ClassName}");
        }
        clScreen();
    }

    static void serachList (List<Student> studArg)
    {
        var studToSearch = " ";
        var fName= " ";
        var lName = " " ;
        int serCount = 0;
        var searchRes = new List<Student> ();

        Console.WriteLine("Enter Student name to search");
        //studToSearch = Convert.ToInt32(Console.ReadLine());
        studToSearch = (Console.ReadLine());
            
        for (int i = 0; i < studArg.Count; i++)
        {
            fName = studArg[i].FirstName;
            lName = studArg[i].LastName;
            if (fName == studToSearch || lName == studToSearch) 
            {
                searchRes.Add(studArg[i]);
                serCount =+1;
            }
        }
        if (serCount == 0) 
        {
            Console.WriteLine("No match found");
            clScreen();
        }
        else 
        {
            printList(searchRes);
        }
    }

    static void clScreen()
        {
            Console.WriteLine("");
            Console.WriteLine("Press ENTER key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
}
}

        /*
        static void printList (List<Student> studArg)
    {
        var count = 0;
        Console.WriteLine($"Student Id | Name |  Class ");
        Console.WriteLine(studArg[0].FirstName);
        foreach (Student stud in studArg) 
        {
            count=+1;
            Console.WriteLine($"{stud.StudentId} | {stud.FirstName} {stud.LastName} | {stud.ClassName}"); 
        }
    } */




    

