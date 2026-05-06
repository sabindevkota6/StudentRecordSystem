using System.Reflection;

namespace StudentRecordSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DurationYears { get; set; }

        // Navigation properties
        public ICollection<Module> Modules { get; set; } = new List<Module>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}