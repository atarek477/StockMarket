using Microsoft.EntityFrameworkCore;
using webapi.api;
using webapi.data;
using webapi.dto;
using webapi.helper;
using webapi.interfaces;
using webapi.mapper;

namespace webapi.repository
{
    public class StockRepository : IStockRepository
    { 
         private readonly ApplicationDBContext _dbContext;

    public StockRepository(ApplicationDBContext dBContext)
    {
        _dbContext = dBContext;

    }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _dbContext.AddAsync(stock);
            await _dbContext.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _dbContext.stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stock == null) { return null; }



            _dbContext.stocks.Remove(stock);
            await _dbContext.SaveChangesAsync();

            return stock;
        }

        public async Task<List<Stock>> GetAllAysnc(QueryObject query)
        {
           var stocks =_dbContext.stocks.Include(c=>c.Comments).ThenInclude(x=>x.AppUser).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Symbol)) 
            { stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol)); }
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            { stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName)); }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks= query.IsDesc?stocks.OrderByDescending(s=>s.Symbol):stocks.OrderBy(s=>s.Symbol);
                }
            
            }

            var SkipNumbr = (query.PageNumber - 1) * query.PageSize;

            return await stocks.Skip(SkipNumbr).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetAysncById(int id)
        {
            var stock = await _dbContext.stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);

            if (stock == null) { return null; }

            return stock;
        }

        public async Task<Stock?> GetAysncBySymbol(string symbol)
        {
            return await _dbContext.stocks.FirstOrDefaultAsync(s=>s.Symbol==symbol);
        }

        public async Task<bool> StockExist(int id)
        {
            return await _dbContext.stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, StockRequestDto stockRequest)
        {
            var stock = await _dbContext.stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stock == null) { return null; }


            stock.Symbol = stockRequest.Symbol;
            stock.CompanyName = stockRequest.CompanyName;
            stock.Purshase = stockRequest.Purshase;
            stock.Industry = stockRequest.Industry;
            stock.MarketCap = stockRequest.MarketCap;
            stock.LastDiv = stockRequest.LastDiv;

            await _dbContext.SaveChangesAsync();


            return stock;
        }
    }
}
