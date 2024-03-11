using Microsoft.AspNetCore.Mvc;
using webapi.api;
using webapi.dto;
using webapi.interfaces;
using webapi.mapper;

namespace webapi.Controllers
{


    [ApiController]
    [Route("api/commend")]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetAsyncById(id);

            if (comment == null) { return NotFound(); }

            return Ok(comment.ToCommentDto());

        }


        [HttpPost("{id}")]

        public async Task<IActionResult> Create([FromRoute] int id, CommentRequestDto commentRequestDto)
        {
            if (!await _stockRepository.StockExist(id))
            {
                return BadRequest("there no stock");
            }
            var comment = commentRequestDto.ToComment(id);
            await _commentRepository.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { Id = comment.Id }, comment.ToCommentDto());

        }



        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CommentRequestDto commmentRequest)
        {
            var comment = await _commentRepository.UpdateAsync(id, commmentRequest);

            if (comment == null) { return NotFound(); }

            return Ok(comment);


        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var comment = await _commentRepository.DeleteAsync(id);

            if (comment == null) { return NotFound(); }

            return NoContent();


        }




    }
}
    
