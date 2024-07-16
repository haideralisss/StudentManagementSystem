using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    public class SubjectController
    {
        SubjectService _subjectService;
        Subject subject;

        public SubjectController()
        {
            _subjectService = new SubjectService();
            subject = new Subject();
        }

        public void addNewSubject()
        {
            Console.Clear();
            Console.Write("Please enter the subject data: \n" +
                "Subject Name: ");
            subject.SubjectName = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Subject Code: ");
            subject.SubjectCode = Console.ReadLine() ?? throw new ArgumentException();

            if(_subjectService.AddNewSubject(subject))
            {
                Console.WriteLine("\nSuccessfully added new subject!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.WriteLine("\nError while adding new subject!");
                Thread.Sleep(1600);
            }
        }

        public void getAllSubjects()
        {
            Console.Clear();
            List<Subject> subjects = new List<Subject>();
            Console.Write("Fetching data! Please wait....");

            subjects = _subjectService.GetAllSubjects();
            Console.Clear();

            if(subjects != null)
            {
                foreach (Subject subject in subjects)
                {
                    Console.WriteLine("***************** Subject data *****************\n");
                    Console.WriteLine($"Subject Name: {subject.SubjectName}\n" +
                        $"Subject Code: {subject.SubjectCode}");
                }
                Console.WriteLine("\n************************************************\n");
                Console.WriteLine("Press any key to go back!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Cannot found data!");
                Thread.Sleep(1600);
            }
        }

        public void removeSubject() 
        { 
            Console.Clear();
            Console.Write("Please enter the subject code: ");
            string subjectCode = Console.ReadLine() ?? throw new ArgumentException();

            Console.Write("Deleting data! Please wait....");

            if (_subjectService.DeleteSubject(subjectCode))
            {
                Console.Clear();
                Console.WriteLine("Successfully deleted the subject!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error while deleting the subject!");
                Thread.Sleep(1600);
            }
        }
    }
}
