using webapi.api;

namespace webapi.model
{
    public class Portfolio
    {

        public string appuserId { get; set; }
        public int stockId { get; set; }

        public Stock stock { get; set; }
        public AppUser appUser { get; set; }


    }
}
