using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi.extension;
using webapi.interfaces;
using webapi.model;

namespace webapi.Controllers
{



    [ApiController]
    [Route("api/portfolio")]
    public class PortfolioController :ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;


        public PortfolioController(UserManager<AppUser> userManager,
     IStockRepository stockRepo, IPortfolioRepository portfolioRepo
    )
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _portfolioRepo = portfolioRepo;
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepo.GetAysncBySymbol(symbol);
             if (stock == null) { BadRequest("stock not found"); }

            var portfolioVal = await _portfolioRepo.GetUserPortfolio(appUser);
            if (portfolioVal.Any(s=>s.Symbol.ToLower()==symbol.ToLower())){ 
                BadRequest("stock is the same");
            }
            var portfolioModel = new Portfolio
            {
                stockId = stock.Id,
                appuserId = appUser.Id
            };

            await _portfolioRepo.CreateAsync(portfolioModel);

            if (portfolioModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            else
            {
                return Created();
            }

        }


        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            var filter = userPortfolio.Where(x => x.Symbol.ToLower() == symbol.ToLower());
            if (filter.Count() == 1)
            {
                await _portfolioRepo.DeletePortfolio(appUser, symbol);

            }
            else { return BadRequest("stock doesnt exit with user"); }

            return Ok();
        }


        }
}
