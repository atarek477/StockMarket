using System.ComponentModel.DataAnnotations;

namespace webapi.dto
{
    public class RegisterDto
    {
        [Required]
        public string? username { get; set; }

        [Required]
        [EmailAddress]
        public string? email {  get; set; } 

        [Required]
        public string? password { get; set; }



    }
}
