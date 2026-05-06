using System.ComponentModel.DataAnnotations;

namespace StudentRecordSystem.Dtos.Request
{
    public class RegisterUserDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required, StringLength(30)]
        public string LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required, Phone]
        public string PhoneNumber { get; set; } = null!;        
    }
}
