using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    public class TeacherService : ITeacher
    {
        public bool AddTeacher(Teacher teacher)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    context.Teachers.Add(teacher);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return false;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    return context.Teachers.
                        Include(t => t.StudentTeachers).
                        ThenInclude(t => t.Student).
                        Include(t => t.Subjects).
                        ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateTeacher(string teacherEnrolledId, Teacher teacher)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var teacherToUpdate = context.Teachers.SingleOrDefault(t => t.TeacherEnrolledId == teacherEnrolledId);
                    if(teacherToUpdate != null)
                    {
                        teacherToUpdate.TeacherName = teacher.TeacherName;
                        teacherToUpdate.TeacherSalary = teacher.TeacherSalary;
                        teacherToUpdate.TeacherEmail = teacher.TeacherEmail;
                        teacherToUpdate.TeacherAddress = teacher.TeacherAddress;
                        teacherToUpdate.TeacherEnrolledId = teacher.TeacherEnrolledId;
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

        public bool DeleteTeacher(string teacherEnrolledId)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var teacherToDelete = context.Teachers.SingleOrDefault(t => t.TeacherEnrolledId == teacherEnrolledId);
                    if(teacherToDelete != null)
                    {
                        context.Teachers.Remove(teacherToDelete);
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

        public bool AddStudentForTeacher(string studentEnrolment, string teacherEnrolledId)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var student = context.Students.SingleOrDefault(s => s.StudentEnrollment == studentEnrolment);
                    if(student != null)
                    {
                        var teacher = context.Teachers.SingleOrDefault(t => t.TeacherEnrolledId == teacherEnrolledId);
                        if(teacher != null)
                        {
                            StudentTeacher studentTeacher = new StudentTeacher();
                            studentTeacher.StudentId = student.StudentId;
                            studentTeacher.TeacherId = teacher.TeacherId;
                            context.StudentTeachers.Add(studentTeacher);
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

        public bool AddSubjectForTeacher(string teacherEnrolledId, string subjectCode)
        {
            try
            {
                using(var context = new AppDbContext())
                {
                    var teacher = context.Teachers.SingleOrDefault(t => t.TeacherEnrolledId == teacherEnrolledId);
                    if(teacher != null)
                    {
                        var subject = context.Subjects.SingleOrDefault(s =>  s.SubjectCode == subjectCode);
                        if(subject != null)
                        {
                            subject.TeacherId = teacher.TeacherId;
                            context.SaveChanges();
                            return true;
                        }
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
