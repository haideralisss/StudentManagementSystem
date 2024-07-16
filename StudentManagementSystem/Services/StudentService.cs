using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudent
    {
        public bool AddStudent(Student student)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }

        public List<dynamic> GetStudents()
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var query = from student in context.Students
                                join studentSubject in context.StudentSubjects on student.StudentId equals studentSubject.StundentId into studentSubjectsGroup
                                from studentSubject in studentSubjectsGroup.DefaultIfEmpty()
                                join subject in context.Subjects on studentSubject.SubjectId equals subject.SubjectId into subjectsGroup
                                from subject in subjectsGroup.DefaultIfEmpty()
                                join grade in context.Grades on new { student.StudentId, studentSubject.SubjectId } equals new { grade.StudentId, grade.SubjectId } into gradesGroup
                                from grade in gradesGroup.DefaultIfEmpty()
                                select new
                                {
                                    student.StudentName,
                                    student.StudentEnrollment,
                                    student.StudentEmail,
                                    student.StudentAdress,
                                    SubjectName = subject != null ? subject.SubjectName : null,
                                    SubjectCode = subject != null ? subject.SubjectCode : null,
                                    StudentGrade = grade != null ? grade.StudentGrade : null
                                };

                    return query.ToList<dynamic>();
                }
            }
            catch
            {
                return null;
            }
        }

        public dynamic GetStudentByEnrolment(string enrolment)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var query = from student in context.Students
                                where student.StudentEnrollment == enrolment
                                join studentSubject in context.StudentSubjects on student.StudentId equals studentSubject.StundentId into studentSubjectsGroup
                                from studentSubject in studentSubjectsGroup.DefaultIfEmpty()
                                join subject in context.Subjects on studentSubject.SubjectId equals subject.SubjectId into subjectsGroup
                                from subject in subjectsGroup.DefaultIfEmpty()
                                join grade in context.Grades on new { student.StudentId, studentSubject.SubjectId } equals new { grade.StudentId, grade.SubjectId } into gradesGroup
                                from grade in gradesGroup.DefaultIfEmpty()
                                select new
                                {
                                    student.StudentName,
                                    student.StudentEnrollment,
                                    student.StudentEmail,
                                    student.StudentAdress,
                                    SubjectName = subject != null ? subject.SubjectName : null,
                                    SubjectCode = subject != null ? subject.SubjectCode : null,
                                    StudentGrade = grade != null ? grade.StudentGrade : null
                                };
                    return query.FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateStudent(string enrolment, Student student)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var studentToUpdate = context.Students.SingleOrDefault(st => st.StudentEnrollment == enrolment);
                    if(studentToUpdate != null)
                    {
                        studentToUpdate.StudentName = student.StudentName;
                        studentToUpdate.StudentEnrollment = student.StudentEnrollment;
                        studentToUpdate.StudentEmail = student.StudentEmail;
                        studentToUpdate.StudentAdress = student.StudentEmail;
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

        public bool DeleteStudent(string enrolment)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var student = context.Students.SingleOrDefault(st => st.StudentEnrollment == enrolment);
                    if(student != null)
                    {
                        context.Students.Remove(student);
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

        public bool RegisterCourse(string enrolment, string subjectCode)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var studentToUpdate = context.Students.SingleOrDefault(s => s.StudentEnrollment == enrolment);
                    if(studentToUpdate != null)
                    {
                        var subject = context.Subjects.SingleOrDefault(sb => sb.SubjectCode == subjectCode);
                        if (subject != null)
                        {
                            StudentSubject subjectData = new StudentSubject();
                            subjectData.StundentId = studentToUpdate.StudentId;
                            subjectData.SubjectId = subject.SubjectId;
                            context.StudentSubjects.Add(subjectData);
                            context.SaveChanges();
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool EnterGrade(string enrolment, string subjectCode, string grade)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var studentSubject = context.StudentSubjects
                        .Include(s => s.Subject)
                        .SingleOrDefault(s => s.Student.StudentEnrollment == enrolment
                         && s.Subject.SubjectCode == subjectCode);
                    
                    if(studentSubject != null)
                    {
                        Grade studentGrade = new Grade();
                        studentGrade.StudentGrade = grade;
                        studentGrade.SubjectId = studentSubject.SubjectId;
                        studentGrade.StudentId = studentSubject.StundentId;
                        context.Grades.Add(studentGrade);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return false;
            }
        }
    }
}
