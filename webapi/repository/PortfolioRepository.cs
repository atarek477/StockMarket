using Microsoft.EntityFrameworkCore;
using webapi.api;
using webapi.data;
using webapi.interfaces;
using webapi.model;

namespace webapi.repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context) { 
        
        _context = context; 
        }
        public Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.portfolios.Where(x=>x.appuserId==user.Id)
           .Select(Stock => new Stock
           {
               Id=Stock.stockId,
               Symbol=Stock.stock.Symbol,
               CompanyName= Stock.stock.CompanyName,    
               Purshase=Stock.stock.Purshase,   
               LastDiv=Stock.stock.LastDiv,
               Industry=Stock.stock.Industry,   
               MarketCap=Stock.stock.MarketCap
           }).ToListAsync();
        }
    }
}
