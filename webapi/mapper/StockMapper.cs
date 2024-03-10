using webapi.api;
using webapi.dto;
using webapi.NewFolder;
namespace webapi.mapper
{
    public static class StockMapper
    {

        public static StockDto ToStockDTO(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purshase = stock.Purshase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
        }



        public static Stock ConvertToStock(this StockRequestDto stockDTO)
        {
            return new Stock
            {
                Symbol = stockDTO.Symbol,
                CompanyName = stockDTO.CompanyName,
                Purshase = stockDTO.Purshase,
                LastDiv = stockDTO.LastDiv,
                Industry = stockDTO.Industry,
                MarketCap = stockDTO.MarketCap
            };
        }

    }
}
