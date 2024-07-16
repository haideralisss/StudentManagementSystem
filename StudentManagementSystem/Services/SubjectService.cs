using StudentManagementSystem.Data;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class SubjectService : ISubject
    {
        public bool AddNewSubject(Subject subject)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    context.Subjects.Add(subject);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Subject> GetAllSubjects()
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    return context.Subjects.ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteSubject(string subjectCode)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var subject = context.Subjects.SingleOrDefault(s => s.SubjectCode == subjectCode);
                    Console.WriteLine(subject.SubjectName);
                    if (subject != null)
                    {
                        context.Subjects.Remove(subject);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
