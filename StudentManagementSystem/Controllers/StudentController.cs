using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using System.Diagnostics;

namespace StudentManagementSystem.Controllers
{
    public class StudentController
    {
        StudentService _studentService;
        Student student;

        public StudentController() 
        {
            _studentService = new StudentService();
            student = new Student();
        }

        public void addNewStudent()
        {
            Console.Clear();
            Console.Write("Please enter the student data:\n" +
                "Student Name: ");
            student.StudentName = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Student Enrolment: ");
            student.StudentEnrollment = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Student Email: ");
            student.StudentEmail = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Student Address: ");
            student.StudentAdress = Console.ReadLine() ?? throw new ArgumentException();

            if(_studentService.AddStudent(student))
            {
                Console.WriteLine("Student data added Successfully!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.WriteLine("Error while entering the student data");
                Thread.Sleep(1600);
            }
        }

        public void getAllStudents()
        {
            Console.Clear();
            Console.Write("Fetching data! Please wait....");
            List<dynamic> students = _studentService.GetStudents();
            Console.Clear();
            if(student != null)
            {
                foreach (var student in students)
                {
                    Console.WriteLine("***************** Student data *****************\n");
                    Console.Write($"Student Name: {student.StudentName}\n" +
                        $"Student Enrolment: {student.StudentEnrollment}\n" +
                        $"Student Email: {student.StudentEmail}\n" +
                        $"Student Address: {student.StudentAdress}\n");
                    Console.WriteLine();

                    if(student.SubjectName != null)
                    {
                        Console.WriteLine("\n--------------- Subjects enrolled --------------\n");
                        Console.WriteLine($"Subject Name: {student.SubjectName}\n" +
                            $"Subject Code: {student.SubjectCode}");
                    }
                    if(student.StudentGrade != null)
                    {
                        Console.WriteLine($"Subject Grade: {student.StudentGrade}\n");
                    }
                }
                Console.WriteLine("************************************************\n");
                Console.WriteLine("Press any key to go back!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No data found!");
                Thread.Sleep(2000);
            }
        }

        public void getStudentByEnrolment()
        {
            Console.Clear();

            Console.Write("Please enter the student enrolment: ");
            string? enrolment = Console.ReadLine();
            Console.Clear();
            Console.Write("Fetching data! Please wait....");
            dynamic student = _studentService.GetStudentByEnrolment(enrolment ?? throw new ArgumentException());
            Console.Clear();

            if(student != null)
            {
                Console.WriteLine("***************** Student data *****************\n");
                Console.Write($"Student Name: {student.StudentName}\n" +
                    $"Student Enrolment: {student.StudentEnrollment}\n" +
                    $"Student Email: {student.StudentEmail}\n" +
                    $"Student Address: {student.StudentAdress}");
                Console.WriteLine();

                if (student.SubjectName != null)
                {
                    Console.WriteLine("\n--------------- Subjects enrolled --------------\n");
                    Console.WriteLine($"Subject Name: {student.SubjectName}\n" +
                        $"Subject Code: {student.SubjectCode}");
                }
                if (student.StudentGrade != null)
                {
                    Console.WriteLine($"Subject Grade: {student.StudentGrade}\n");
                }
                Console.WriteLine("************************************************\n");
                Console.WriteLine("Press any key to go back!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No data found!");
                Thread.Sleep(2000);
            }
        }

        public void updateStudent()
        {
            Console.Clear();
            Console.Write("Please enter the student enrolment: ");
            string? enrolment = Console.ReadLine();

            Console.Clear();
            Console.Write("Please enter the student data:\n\n" +
                "Student Name: ");
            student.StudentName = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Student Enrolment: ");
            student.StudentEnrollment = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Student Email: ");
            student.StudentEmail = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Student Address: ");
            student.StudentAdress = Console.ReadLine() ?? throw new ArgumentException();

            Console.Clear();
            Console.Write("Updating data! Please wait....");

            if (_studentService.UpdateStudent(enrolment ?? throw new ArgumentException(), student))
            {
                Console.Clear();
                Console.WriteLine("Successfully updated the student data!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error while updating the student data!");
                Thread.Sleep(1600);
            }
        }

        public void deleteStudent()
        {
            Console.Clear();
            Console.Write("Please enter the student enrolment: ");
            string? enrolment = Console.ReadLine();

            Console.Clear();
            Console.Write("Deleting data! Please wait....");

            if (_studentService.DeleteStudent(enrolment ?? throw new ArgumentException()))
            {
                Console.Clear();
                Console.WriteLine("Successfully deleted the student data!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot delete the student data or student not found!");
                Thread.Sleep(1600);
            }
        }

        public void registerNewCourse()
        {
            Console.Clear();
            Console.Write("Please enter the student enrolment: \n" +
                "Student Enrolment: ");
            string enrolment = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("\nPlease enter the subject code: \n" +
                "Subject Code: ");
            string subjectCode = Console.ReadLine() ?? throw new ArgumentException();

            Console.Clear();
            Console.Write("Registering new course! Please wait....");

            if (_studentService.RegisterCourse(enrolment, subjectCode))
            {
                Console.Clear();
                Console.WriteLine("Successfully registered a new course!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot register the course or student not found!");
                Thread.Sleep(1600);
            }
        }

        public void enterGrade()
        {
            Console.Clear();
            Console.Write("Please enter the student enrolment: ");
            string enrolment = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Please enter the subject code: ");
            string subjectCode = Console.ReadLine() ?? throw new ArgumentException();

            Console.Clear();
            Console.Write("Entering grade! Please wait....");

            if (_studentService.EnterGrade(enrolment, subjectCode, "D+"))
            {
                Console.Clear();
                Console.WriteLine("Successfully entered a grade!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot enter a grade or student not found!");
                Thread.Sleep(1600);
            }
        }
    }
}
