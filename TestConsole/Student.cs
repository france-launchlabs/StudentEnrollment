using System;
namespace TestConsole
{
    public class Student
    {
        public string StudentId
        {
            get;
            set;
        }
        public string FirstName{
            get;set;
        }
        public string LastName
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }

        public void PrintInfo(){
            Console.WriteLine("### STUDENT INFO ###");
            Console.WriteLine("Id: {0} - {1} - {2} - {3}", StudentId, FirstName, LastName, Age);
        }
    }
}
