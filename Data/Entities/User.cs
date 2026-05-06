using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentRecordSystem.Data.Entities
{
    public class User : IdentityUser
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required, StringLength(50)]
        public string LastName { get; set; } = null!;
        
    }
}
