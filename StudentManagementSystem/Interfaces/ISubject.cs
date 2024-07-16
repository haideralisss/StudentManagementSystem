using StudentManagementSystem.Models;

namespace StudentManagementSystem.Interfaces
{
    public interface ISubject
    {
        bool AddNewSubject(Subject subject);
        List<Subject> GetAllSubjects();
        bool DeleteSubject(string subjectCode);
    }
}
