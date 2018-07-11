using System;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        
        static List<Student> studentsArr = new List<Student>();

        static void Main(string[] args)
        {
            var a = Console.ReadLine();
            Console.WriteLine(a);


            //Actor actor = new Actor();
            //actor.GetOccupation();

            bool shouldStopApp = false;

            while (!shouldStopApp)
            {

                Console.WriteLine("Menu: Enroll (1) Student Info(2) View All Students(3) Quit(4)");
                int choice = 0;
                bool isValidChoice = Int32.TryParse(Console.ReadLine(),out choice);

                if (isValidChoice)
                {
                    switch (choice)
                    {
                        case 1:
                            StartEnroll();
                            break;
                        case 2:
                            ViewStudentInfo();
                            break;
                        case 3:
                            ViewAllStudents();
                            break;
                        case 4:
                            shouldStopApp = true;
                            break;
                    }
                }
                else{
                    Console.WriteLine("Invalid Menu Choice. Please try again.");
                }
            }


        }
        static void StartEnroll()
        {
            Student student;
            bool shouldEnrollAgain = true;

            do
            {
                student = new Student();
                bool isExistingStudent = false;
                string searchId = "";
                do
                {
                    Console.WriteLine("Enter Student Id: ");
                    searchId = Console.ReadLine();


                    for (int index = 0; index < studentsArr.Count; index++)
                    {
                        Student studentIteration = studentsArr[index];
                        if (studentIteration.StudentId.Equals(searchId))
                        {
                            isExistingStudent = true;
                            break;
                        }
                    }
                } while (isExistingStudent);
                student.StudentId = searchId;

                Console.WriteLine("Enter First Name: ");
                student.FirstName = Console.ReadLine();

                Console.WriteLine("Enter Last Name: ");
                student.LastName = Console.ReadLine();


                bool isInt=false;
                do
                {
                    Console.WriteLine("Enter Age: ");
                    int v = 0;

                    isInt = Int32.TryParse(Console.ReadLine(), out v);
                    if (isInt)
                    {
                        student.Age = v;
                        isInt = true;
                    }else{
                        Console.WriteLine("Entered age is not a number, please try again. ");
                    }
                    
                } while (!isInt);

                studentsArr.Add(student);
                Console.WriteLine("Student has been added, do you want to enroll another student? y/n");

                bool shouldAskAgain = false;
                do
                {
                    string shouldAddResponse = Console.ReadLine();
                    if (shouldAddResponse.ToLower().Trim().Equals("n"))
                        shouldEnrollAgain = false;
                    else if (shouldAddResponse.ToLower().Trim().Equals("y"))
                        shouldEnrollAgain = true;
                    else{
                        Console.WriteLine("Sorry I did not understand your response, do you want to enroll another student? y/n");
                        shouldAskAgain = true;
                    }
                } while (shouldAskAgain);

            } while (shouldEnrollAgain);
        

        }

        static void ViewStudentInfo()
        {

            bool shouldViewAnotherStudent = false;
            do
            {
                Console.WriteLine("Enter Student Id:");

                string studentId = Console.ReadLine();
                Student student = null;

                for (int index = 0; index < studentsArr.Count; index++)
                {
                    Student studentIteration = studentsArr[index];
                    if (studentIteration.StudentId.Equals(studentId))
                    {
                        student = studentIteration;
                        break;
                    }
                }

                if (student != null)
                {
                    student.PrintInfo();
                }else{
                    Console.WriteLine("Student not found.");
                }

                Console.WriteLine("Do you want to view another student info? y/n");
                bool shouldTryAgain = false;

                do
                {
                    string shouldTryResponse = Console.ReadLine();
                    if (shouldTryResponse.ToLower().Trim().Equals("n"))
                        shouldViewAnotherStudent = false;
                    else if (shouldTryResponse.ToLower().Trim().Equals("y"))
                        shouldViewAnotherStudent = true;
                    else
                    {
                        Console.WriteLine("Sorry I did not understand your response, Do you want to view another student info? y/n");
                        shouldTryAgain = true;
                    }

                } while (shouldTryAgain);
            } while (shouldViewAnotherStudent);

        }
        static void ViewAllStudents(){

            if (studentsArr.Count == 0)
                Console.WriteLine("No Students Enrolled Yet.");
                
            foreach(Student student in studentsArr){
                student.PrintInfo();
                Console.WriteLine("##########");
            }
        }
        
    }
}
