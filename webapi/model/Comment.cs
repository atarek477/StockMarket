using webapi.model;

namespace webapi.api
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }=string.Empty;
        public string Title { get; set; }= string.Empty;
        public DateTime CreateOn { get; set; }
        public int? stockId { get; set; }
        public Stock? stock { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
