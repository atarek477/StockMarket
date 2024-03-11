using System.ComponentModel.DataAnnotations.Schema;
using webapi.api;

namespace webapi.NewFolder
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;


        [Column(TypeName = "decimal(18,2)")]
        public decimal Purshase { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;


        public long MarketCap { get; set; }

        public List<Comment> comments { get; set; }


    }
}
