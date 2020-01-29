//using System.Windows.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var ans = "y";
            var studentList = new List<Student>();

            while (true)
            {
                Console.WriteLine("Welcome to the Student List program.\n");
                var myChoice = 0;
                    Console.Write("-1 List All Current Students\n-2 Search Current Students\n-3 Load dumy test records\n" +
                    "-4 Add a New Student\n-5 Remove a student from list\n-6 Save Students to Default File\n" +
                    "-7 Load data from the default file\n-8 Load data from a custom file\n-9 Quit\n\nEnter your choice(1 to 9): ");
                //Console.WriteLine("\n");

                myChoice = Convert.ToInt32(Console.ReadLine());

                if (myChoice == 1)
                {
                    if (studentList.Count() == 0)
                    {
                        Console.WriteLine("\nThe student list is empty, no students to show!");
                        clScreen();
                    }
                    else
                    {
                        printList(studentList);
                    }
                }  // List students

                else if (myChoice == 2)
                {
                    if (studentList.Count() == 0)
                    {
                        Console.WriteLine("\nThe student list is empty, no students to search!");
                        clScreen();
                    }
                    else
                    {
                        serachList(studentList);
                    }
                }   // Search students

                else if (myChoice == 3)
                {
                    Console.Write("This will initialize the list with three test records?\nAre you sure?  Y\\N\n");
                    ans = Console.ReadLine();
                    if (ans.ToLower() == "y")
                    {
                        clScreen();
                        initList(studentList);
                        Console.WriteLine();
                        printList(studentList);
                    }
                    else
                    {
                        clScreen();
                    }
                }    //Load dumy data

                else if (myChoice == 4)
                {
                    Console.Clear();
                    addStudent(studentList);
                }    // add student Manually

                else if (myChoice == 5)
                {
                    Console.Write("This option is under development");
                    clScreen();
                }    // Delete a student

                else if (myChoice == 6)
                {
                    Console.WriteLine("You are about to save the student list to the default file Student.txt!\nProceed to save? Y\\N");
                    ans = Console.ReadLine();
                    if (ans.ToLower() == "y")
                    {
                        String fileName = "students.txt";
                        Console.WriteLine(WriteFile(fileName, ref studentList));
                    }
                }    // Save to the default file

                else if (myChoice == 7)
                {
                    Console.Write("Load the contents of the default file Students.txt to the list?  Y\\N: ");
                    ans = Console.ReadLine();
                    if (ans.ToLower() == "y")
                    {
                        var checkResult = ReadFile("students.txt", ref studentList);
                        if (checkResult == true)
                        {
                            Console.WriteLine($"File was loaded successfully?");
                            if (studentList.Count() == 0)
                            {
                                Console.WriteLine("\nThe student list is empty, no students to show!");
                            }
                            else
                            {
                                printList(studentList);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"File was NOT loaded successfully?");
                            clScreen();
                        }
                    }
                    //clScreen();
                }    //Load from default file

                else if (myChoice == 8)
                {
                    Console.Write("Enter file name to load contents from: ");
                    ans = Console.ReadLine();
                    if (string.IsNullOrEmpty(ans))
                    {
                        Console.WriteLine("No file name was entered, file name cannot be null or empty");
                    }
                    else
                    {
                        var checkResult = ReadFile(ans, ref studentList);
                        if (checkResult == true)
                        {
                            Console.WriteLine($"File {ans} was loaded successfully?");
                        }
                        else
                        {
                            Console.WriteLine($"File {ans} was NOT loaded successfully?");
                            clScreen();
                        }
                    }

                    if (studentList.Count() == 0)
                    {
                        Console.WriteLine("\nThe student list is empty, no students to show!");
                    }
                    else
                    {
                        printList(studentList);
                    }
                    clScreen();
                }    //Load from user defined file

                else if (myChoice == 9)
                {
                    Console.WriteLine("\nThank you for using my program\nGood bye");
                    Thread.Sleep(2000);
                    return;
                }    // Quit
            }
        }
        /*using (StreamWriter file = File.CreateText(@FilePath))
                               {
                                   JsonSerializer serializer = new JsonSerializer();
                                   //serialize object directly into file stream
                                   serializer.Serialize(file, _data);
                               }*/

        static void initList (List<Student> studArg)
        {
            //Console.WriteLine("Initialization");
            var lastListID = studArg.Count;
            Student NewStudent1 = new Student();
            NewStudent1.StudentId = lastListID + 1;
            NewStudent1.FirstName="Ali";
            NewStudent1.LastName="Alssadan";
            NewStudent1.ClassName="C#";
            NewStudent1.LastClassCompleted="WFE";
            NewStudent1.LastClassCompletedOn=DateTime.Now.Date;
            NewStudent1.StartDate=DateTime.Now.Date;
            studArg.Add(NewStudent1);
            //Console.WriteLine($"Student Name {studArg[0].FirstName}");

            Student NewStudent2 = new Student();
            NewStudent2.StudentId = lastListID + 2;
            NewStudent2.FirstName="Haidar";
            NewStudent2.LastName="Alssadan";
            NewStudent2.ClassName="CSS";
            NewStudent2.LastClassCompleted="WFE";
            NewStudent2.LastClassCompletedOn=DateTime.Now.Date;
            NewStudent2.StartDate=DateTime.Now.Date;
            studArg.Add(NewStudent2);
            //Console.WriteLine($"Student Name {studArg[1].FirstName}");

            Student NewStudent3 = new Student();
            NewStudent3.StudentId = lastListID + 3;
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
            //Console.WriteLine("");
        }

        static void addStudent(List<Student> studArg){
            string keepAdding = "y";
            var count = 0;
            while (true)
            {
                Console.WriteLine($"Student list has {studArg.Count} students\n");
                Console.WriteLine($"Adding a new student\n");
                Console.WriteLine($"Press Q at any time to return to main menue\n");

                Console.WriteLine("Enter Student Id");
                var strID = Console.ReadLine();
                //var studentId = Convert.ToInt32(Console.ReadLine());
                var studentId = 0;
                while (!int.TryParse(strID, out studentId))
                {
                    if (strID == "q") {
                        Console.WriteLine("you decided to return to main menue");
                        break; }
                    Console.WriteLine("Student ID must be a an integer, Enter an Integer number please!");
                    strID = Console.ReadLine();
                }
                if (strID == "q") { break; }

                var studentFirstName = " " ;
                validateString(ref studentFirstName, "First Name");

                var studentLastName = " ";
                validateString(ref studentLastName, "Last Name");

                var className = " ";
                validateString(ref className, "Class Name");

                var lastClass = " ";
                validateString(ref lastClass, "Last Class Completed");
              
                DateTimeOffset lastCompletedOn = DateTime.Today;
                validateDate(ref lastCompletedOn, "Last Class Completed Date");

                DateTimeOffset startDate = DateTime.MinValue;
                bool dateFlag = false;
                while (dateFlag == false) 
                {
                    validateDate(ref startDate, "Start Date");
                    dateFlag = DateTimeOffset.Compare(lastCompletedOn, startDate) > 0;
                    if (dateFlag == false)
                    {
                        Console.WriteLine("Start date cannot be greater than the Completed date.\nEnter a valid start date.");
                    }

                } 
                

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

        static void validateString(ref string strValue, string strName)
            {
                Console.WriteLine($"Enter {strName}");
                strValue= Console.ReadLine();
                while (string.IsNullOrEmpty(strValue))
                {
                    Console.WriteLine($"{strName} can't be empty! Input a valid name again");
                    strValue = Console.ReadLine();
                }
            }

        static void validateDate(ref DateTimeOffset dtValue, string strName)
        {
            /*Console.WriteLine($"Enter {strName} in format MM/dd/YYYY");
            DateTimeOffset temp ;
            string dtInput = Console.ReadLine();
            while (DateTimeOffset.TryParse(dtInput,out temp))
            {
                Console.WriteLine($"{strName} is not a date! Input a valid date again");
                dtInput = Console.ReadLine();
            }*/
            DateTimeOffset date = DateTimeOffset.MinValue;
            do
            {
                Console.WriteLine($"Enter {strName} in the format MM/dd/YYYY");
                string strDateString = Console.ReadLine();
                if (!DateTimeOffset.TryParse(strDateString, out date))
                {
                    Console.WriteLine("That is an invalid date format.  Please try again");
                }
            } while (date == DateTimeOffset.MinValue);
            dtValue = date;

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
                if (fName.ToLower() == studToSearch.ToLower() || lName.ToLower() == studToSearch.ToLower()) 
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

        static bool ReadFile (string fName, ref List<Student> tempStud)
        {
            String FilePath = Directory.GetCurrentDirectory();
            //Console.WriteLine($"\nCurrent Path is {FilePath}");
            string FileName = fName;
            //Console.WriteLine($"File name is {FileName}");
            String FullPath = $"{FilePath}\\{FileName}";
            //Console.WriteLine(FullPath);
            //Console.WriteLine("Press ENTER key to continue.");
            //Console.ReadLine();

            if (File.Exists(FullPath))
            {
                Console.WriteLine($"File was found.\n{FullPath}\nLoad its contents? Y\\N");
                var ans = "y";
                ans = Console.ReadLine();
                if (ans == "y" || ans == "Y")
                {           
                    string readResult = string.Empty;
                    string writeResult = string.Empty;
                    using (StreamReader r = new StreamReader(FullPath))

                        if (r.EndOfStream)
                        {
                           Console.WriteLine($"File is empty,no records were loaded\n");
                           return false;
                        }
                        else
                        {
                           var json = r.ReadToEnd();
                           tempStud = JsonConvert.DeserializeObject<List<Student>>(json);
                           return true;
                        }
                    
                    
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"{FullPath} was found NOT found");
                return false;
            }
            //Console.ReadLine();                     
        }

        static bool WriteFile(string fName, ref List<Student> tempStud)
        {
            String FilePath = Directory.GetCurrentDirectory();
            //Console.WriteLine($"\nCurrent Path is {FilePath}");
            string FileName = fName;
            //Console.WriteLine($"File name is {FileName}");

            String FullPath = $"{FilePath}\\{FileName}";
            //Console.WriteLine(FullPath);
            Console.WriteLine("Press ENTER key to continue.");
            Console.ReadLine();
            var ans = "y";

            if (File.Exists(FullPath))
            {
                Console.WriteLine($"{FullPath} is already exists, overwrite it? Y/N");
                ans = Console.ReadLine();
                if (ans.ToLower() == "y")
                {
                    string json = JsonConvert.SerializeObject(tempStud.ToArray());

                    //write string to file
                    System.IO.File.WriteAllText(FullPath, json);

                    //jsonString = JsonSerializer.Serialize(tempStud);
                    //File.WriteAllText(fileName, jsonString);
                      
                    return true;
                }
            
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"{FullPath} was found NOT found");
                return false;
            }
            //Console.ReadLine();
        }

        static void CheckFile2()
        {
            String FilePath = System.IO.Directory.GetCurrentDirectory() + "\\" + "io.json";

            StreamReader reader;
            string strJSONdata = "";
            try
            {
                if (File.Exists(FilePath))
                {
                    reader = new StreamReader(FilePath);
                    strJSONdata = reader.ReadToEnd();
                    reader.Dispose();
                }
            }
            catch (Exception ex) { }
        }

        static void programLoad ()
        {
            var fileName = "students.txt";
            var myPath = System.IO.Directory.GetCurrentDirectory() + "\\" + fileName;
                //string startupPath = Environment.CurrentDirectory;
                 //Console.WriteLine(startupPath);
               Console.WriteLine(myPath);

            if (File.Exists(myPath) == false)
            {
                Console.WriteLine("file does not exist");
               FileStream studentFile = File.Create(myPath) ;
               StreamReader sr = new StreamReader(myPath);
            }
            else
                {
                    StreamReader fh = new StreamReader(myPath);
                    string s;
                    while ((s = fh.ReadLine()) != null)
                        Console.WriteLine(s);
                    fh.Close();
                }
            //string curFile = @"c:\temp\test.txt";
            //Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
        }

        public static void RdWrJsonFile()
        {
            string filepath = "C:\\Users\\HD\\Desktop\\TreeHouse\\C#\\ConsoleApp1\\bin\\Debug\\IO.json";
            string readResult = string.Empty;
            string writeResult = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var students = JsonConvert.DeserializeObject<List<Student>>(json);

                //var jobj = JArray.Parse(json);
                //readResult = jobj.ToString();
                //foreach (var item in jobj)
                //{
                //    //item.Value = item.Value.ToString().Replace("v1", "v2");
                //}
                //writeResult = jobj.ToString();
                Console.WriteLine(writeResult);
            }
            Console.WriteLine(readResult);
            File.WriteAllText(filepath, writeResult);
        }

    }
}