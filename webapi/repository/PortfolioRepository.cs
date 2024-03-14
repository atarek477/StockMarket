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
        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol)
        {
            var portfolioModel = await _context.portfolios
     .FirstOrDefaultAsync(x => x.appuserId == appUser.Id  && x.stock.Symbol == symbol);


            if (portfolioModel == null) { return null; }

              _context.Remove(portfolioModel);
               await _context.SaveChangesAsync();
                return portfolioModel;
        
        
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
