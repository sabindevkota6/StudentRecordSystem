namespace StudentRecordSystem.Models
{
    public class ModuleInstructor
    {
        // Composite Primary Key (configured in DbContext)
        public int ModuleId { get; set; }
        public int InstructorId { get; set; }

        // Navigation properties
        public Module Module { get; set; } = null!;
        public Instructor Instructor { get; set; } = null!;
    }
}