using webapi.api;

namespace webapi.dto
{
    public class CommentDto
    {

        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
        public int? stockId { get; set; }
       

    }
}
