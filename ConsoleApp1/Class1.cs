using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        public  int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string LastClassCompleted { get; set; }
        public DateTimeOffset LastClassCompletedOn { get; set; }
       
       
        //public int StudentId
        //{
        //    get => _StudentId;
        //    set
        //    {
        //        _StudentId = value;
        //    }
        //}

        //public string FirstName
        //{
        //    get => _FirstName;
        //    set
        //    {
        //        _FirstName = value;
        //    }
        //}
    }
}
