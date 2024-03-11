using webapi.api;
using webapi.dto;

namespace webapi.interfaces
{
    public interface IStockRepository
    {

        Task<List<Stock>> GetAllAysnc();
        Task<Stock?> GetAysncById(int id);

        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id,StockRequestDto stockRequest );
        Task<Stock?> DeleteAsync(int id);

    }
}
