using System.ComponentModel.DataAnnotations;
using System.IO;

namespace webapi.dto
{
    public class CommentRequestDto
    {
        [Required]
        [MinLength(5,ErrorMessage = "content length at least 5 char")]
        [MaxLength(280, ErrorMessage = "content length at most 280 char")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "title length at least 5 char")]
        [MaxLength(280, ErrorMessage = "title length at most 280 char")]
        public string Title { get; set; } = string.Empty;
        
        

    }
}
