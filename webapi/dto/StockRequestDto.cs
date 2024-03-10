namespace webapi.dto
{
    public class StockRequestDto
    {

       
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
      
        public decimal Purshase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;


        public long MarketCap { get; set; }
    }
}
