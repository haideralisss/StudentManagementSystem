using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        [Required]
        public string? SubjectName { get; set; }
        [Required]
        public string? SubjectCode { get; set; }
        public ICollection<StudentSubject>? StudentSubjects { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
