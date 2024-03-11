using webapi.api;
using webapi.dto;

namespace webapi.interfaces
{
    public interface ICommentRepository
    {

        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetAsyncById(int id);

        Task<Comment> CreateAsync(Comment comment);
        Task<Comment?> UpdateAsync(int id, CommentRequestDto commentRequest);
        Task<Comment?> DeleteAsync(int id);

    }
}
