using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.dto;
using webapi.interfaces;
using webapi.mapper;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IStockRepository _stockRepo;

        public  StockController(ApplicationDBContext dBContext, IStockRepository stockRepo)
        {
            _dbContext = dBContext;
            _stockRepo = stockRepo;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }

            var stocks = await _stockRepo.GetAllAysnc();
            var stockDto= stocks.Select(s=>s.ToStockDTO());
            return Ok(stocks);

        }
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var stock = await _stockRepo.GetAysncById(id);

            if (stock == null) { return NotFound(); }

            return Ok(stock.ToStockDTO());
                
        }



        [HttpPost]

        public async Task<IActionResult> Create([FromBody] StockRequestDto stockRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var stock = stockRequest.ConvertToStock();
            await _stockRepo.CreateAsync(stock);                    
            return CreatedAtAction(nameof(GetById),new {Id= stock.Id},stock.ToStockDTO() );

        }



        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StockRequestDto stockRequest)
        {

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var stock = await _stockRepo.UpdateAsync(id,stockRequest);

            if (stock == null) { return NotFound(); }       

            return Ok(stock.ToStockDTO());

        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var stock = await _stockRepo.DeleteAsync(id);

            if (stock == null) { return NotFound(); }                   


            return NoContent();

        }


    }
}
