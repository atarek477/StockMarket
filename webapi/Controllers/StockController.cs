using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.data;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public StockController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _dbContext.stocks.ToList();
            return Ok(stocks);

        }
        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _dbContext.stocks.Find(id);

            if (stock == null) { return NotFound(); }

            return Ok(stock);
                
        }
    }
}
