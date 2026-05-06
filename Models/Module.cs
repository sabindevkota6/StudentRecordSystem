namespace StudentRecordSystem.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }

        // Foreign Key
        public int CourseId { get; set; }

        // Navigation properties
        public Course Course { get; set; } = null!;
        public ICollection<ModuleInstructor> ModuleInstructors { get; set; } = new List<ModuleInstructor>();
    }
}