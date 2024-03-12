using System.ComponentModel.DataAnnotations;

namespace webapi.dto
{
    public class StockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "max symbol is 10 char")]
        public string Symbol { get; set; } = string.Empty;

        
        
        [Required]
        [MaxLength(10, ErrorMessage = "max company name is 10 char")]
        public string CompanyName { get; set; } = string.Empty;


        [Required]
        [Range(1,1000000)]
        public decimal Purshase { get; set; }
        
        
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "max company name is 10 char")]
        public string Industry { get; set; } = string.Empty;


        [Required]
        [Range(1, 1000000)]
        public long MarketCap { get; set; }
    }
}
