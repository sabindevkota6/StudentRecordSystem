using System.ComponentModel.DataAnnotations;

namespace StudentRecordSystem.Dtos.Request
{
    public class ModuleCreateDto
    {
        [Required]
        public required string Title { get; set; }

        [Range(10, 30)]
        public int Credits { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
