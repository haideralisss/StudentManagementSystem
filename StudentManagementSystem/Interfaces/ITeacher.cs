using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces
{
    public interface ITeacher
    {
        bool AddTeacher(Teacher teacher);
        List<Teacher> GetAllTeachers();
        bool UpdateTeacher(string teacherEnrolledId, Teacher teacher);
        bool DeleteTeacher(string teacherEnrolledId);
        bool AddStudentForTeacher(string studentEnrolment, string teacherEnrolledId);
        bool AddSubjectForTeacher(string teacherEnrolledId, string subjectCode);
    }
}
