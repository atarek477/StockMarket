using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using webapi.api;
using webapi.data;
using webapi.interfaces;

namespace webapi.repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CommentRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;

        }

        public async Task<List<Comment>> GetAllAsync()

        {
            return await _dbContext.comments.ToListAsync();
        }
    }
}
