using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        public string? TeacherName { get; set; }
        [Required]
        public string? TeacherEnrolledId { get; set; }
        public string? TeacherEmail { get; set; }
        public string? TeacherAddress { get; set; }
        public long TeacherSalary { get; set; }
        public ICollection<StudentTeacher>? StudentTeachers { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
    }
}
