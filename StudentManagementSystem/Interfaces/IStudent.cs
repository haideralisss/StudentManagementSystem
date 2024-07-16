using StudentManagementSystem.Models;

namespace StudentManagementSystem.Interfaces
{
    public interface IStudent
    {
        bool AddStudent(Student student);
        List<dynamic> GetStudents();
        dynamic GetStudentByEnrolment(string enrolment);
        bool UpdateStudent(string enrolment, Student student);
        bool DeleteStudent(string enrolment);
        bool RegisterCourse(string enrolment, string subjectCode);
        bool EnterGrade(string enrolment, string subjectCode, string grade);
    }
}
