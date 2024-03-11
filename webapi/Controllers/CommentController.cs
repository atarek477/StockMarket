using Microsoft.AspNetCore.Mvc;
using webapi.interfaces;
using webapi.mapper;

namespace webapi.Controllers
{


    [ApiController]
    [Route("api/commend")]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
           _commentRepository = commentRepository;  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(comments);

        }






    }
}
