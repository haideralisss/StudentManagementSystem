using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class TeacherController
    {
        Teacher teacher;
        TeacherService _teacherService;

        public TeacherController() 
        {
            teacher = new Teacher();
            _teacherService = new TeacherService();
        }

        public void addNewTeacher()
        {
            Console.Clear();
            Console.Write("Please enter the teacher data:\n" +
                "Teacher Name: ");
            teacher.TeacherName = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Teacher Enrolled Id: ");
            teacher.TeacherEnrolledId = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Teacher Salary: ");
            teacher.TeacherSalary = (long)Convert.ToDecimal(Console.ReadLine());
            Console.Write("Teacher Email: ");
            teacher.TeacherEmail = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Teacher Address: ");
            teacher.TeacherAddress = Console.ReadLine() ?? throw new ArgumentException();

            if (_teacherService.AddTeacher(teacher))
            {
                Console.WriteLine("Student data added Successfully!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.WriteLine("Error while entering the teacher data");
                Thread.Sleep(1600);
            }
        }

        public void getAllTeachers()
        {
            Console.Clear();
            Console.Write("Fetching data! Please wait....");
            List<Teacher> teachers = _teacherService.GetAllTeachers();
            Console.Clear();
            if (teachers != null)
            {
                foreach (var teacher in teachers)
                {
                    Console.WriteLine("***************** Teacher data *****************\n");
                    Console.Write($"Teacher Name: {teacher.TeacherName}\n" +
                        $"Teacher Enrolled Id: {teacher.TeacherEnrolledId}\n" +
                        $"Teacher Salary: {teacher.TeacherSalary}\n" +
                        $"Teacher Email: {teacher.TeacherEmail}\n" +
                        $"Teacher Address: {teacher.TeacherAddress}\n\n");

                    if (teacher.StudentTeachers != null)
                    {
                        foreach (var student in teacher.StudentTeachers)
                        {
                            Console.WriteLine("\n--------------- Teaching Students --------------\n");
                            Console.WriteLine($"Student Name: {student.Student.StudentName}\n" +
                                $"Student Enrolment: {student.Student.StudentEnrollment}");
                        }
                    }
                    if(teacher.Subjects != null)
                    {
                        foreach (var subject in teacher.Subjects)
                        {
                            Console.WriteLine("\n--------------- Teaching Subjects --------------\n");
                            Console.WriteLine($"Subject Name: {subject.SubjectName}\n" +
                                $"Subject Code: {subject.SubjectCode}\n");
                        }
                    }
                }
                Console.WriteLine("\n************************************************\n");
                Console.WriteLine("Press any key to go back!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No data found!");
                Thread.Sleep(2000);
            }
        }

        public void updateTeacher()
        {
            Console.Clear();
            Console.Write("Please enter the teacher enrolled id: ");
            string? teacherEnrolledId = Console.ReadLine();

            Console.Clear();
            Console.Write("Please enter the teacher data:\n" +
                "Teacher Name: ");
            teacher.TeacherName = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Teacher Enrolled Id: ");
            teacher.TeacherEnrolledId = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Teacher Salary: ");
            teacher.TeacherSalary = (long)Convert.ToDecimal(Console.ReadLine());
            Console.Write("Teacher Email: ");
            teacher.TeacherEmail = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Teacher Address: ");
            teacher.TeacherAddress = Console.ReadLine() ?? throw new ArgumentException();

            Console.Clear();
            Console.Write("Updating data! Please wait....");

            if (_teacherService.UpdateTeacher(teacherEnrolledId ?? throw new ArgumentException(), teacher))
            {
                Console.Clear();
                Console.WriteLine("Successfully updated the teacher data!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error while updating the teacher data!");
                Thread.Sleep(1600);
            }
        }

        public void deleteTeacher()
        {
            Console.Clear();
            Console.Write("Please enter the teacher enrolled id: ");
            string? teacherEnrolledId = Console.ReadLine();

            Console.Clear();
            Console.Write("Deleting data! Please wait....");

            if (_teacherService.DeleteTeacher(teacherEnrolledId ?? throw new ArgumentException()))
            {
                Console.Clear();
                Console.WriteLine("Successfully deleted the teacher data!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot delete the teacher data or teacher not found!");
                Thread.Sleep(1600);
            }
        }

        public void registerStudentForATeacher()
        {
            Console.Clear();
            Console.Write("Please enter the student enrolment: ");
            string enrolment = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Please enter the teacher enrolled id: ");
            string teacherEnrolledId = Console.ReadLine() ?? throw new ArgumentException();

            Console.Clear();
            Console.WriteLine("Registering student for teacher! Please wait....");

            if(_teacherService.AddStudentForTeacher(enrolment, teacherEnrolledId))
            {
                Console.Clear();
                Console.WriteLine("Successfully added a student to the teacher data!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot add student! Or either student or teacher cannot found!");
                Thread.Sleep(1600);
            }
        }

        public void registerSubjectForATeacher()
        {
            Console.Clear();
            Console.Write("Please enter the teacher enrolled id: ");
            string teacherEnrolledId = Console.ReadLine() ?? throw new ArgumentException();
            Console.Write("Please enter the subject code: ");
            string subjectCode = Console.ReadLine() ?? throw new ArgumentException();

            Console.Clear();
            Console.WriteLine("Adding course to teacher! Please wait....");

            if (_teacherService.AddSubjectForTeacher(teacherEnrolledId, subjectCode))
            {
                Console.Clear();
                Console.WriteLine("Successfully added a course to the teacher data!");
                Thread.Sleep(1600);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot add course! Or either course or teacher cannot found!");
                Thread.Sleep(1600);
            }
        }
    }
}
