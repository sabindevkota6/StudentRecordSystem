namespace StudentRecordSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }

        // Navigation property
        public ICollection<ModuleInstructor> ModuleInstructors { get; set; } = new List<ModuleInstructor>();
    }
}