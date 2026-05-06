namespace StudentRecordSystem.Models
{
    public class Enrollment
    {
        // Composite Primary Key (configured in DbContext)
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledDate { get; set; }

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}