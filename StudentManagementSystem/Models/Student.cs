using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string? StudentName { get; set; }
        [Required]
        public string? StudentEnrollment { get; set; }
        public string? StudentEmail { get; set; }
        public string? StudentAdress { get; set; }
        public ICollection<StudentTeacher>? StudentTeachers { get; set; }
        public ICollection<StudentSubject>? StudentSubjects { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
