using webapi.api;
using webapi.dto;
using webapi.helper;

namespace webapi.interfaces
{
    public interface IStockRepository
    {

        Task<List<Stock>> GetAllAysnc(QueryObject query);
        Task<Stock?> GetAysncById(int id);
        Task<Stock?> GetAysncBySymbol(string symbol);


        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id,StockRequestDto stockRequest );
        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExist(int id);

    }
}
