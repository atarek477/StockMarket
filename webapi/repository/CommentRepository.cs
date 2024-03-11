using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using webapi.api;
using webapi.data;
using webapi.dto;
using webapi.interfaces;
using webapi.mapper;

namespace webapi.repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CommentRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;

        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _dbContext.comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _dbContext.comments.FindAsync(id);
            if (comment == null) { return null; }
            _dbContext.comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()

        {
            return await _dbContext.comments.ToListAsync();
        }

        public async Task<Comment?> GetAsyncById(int id)
        {
            var comment= await _dbContext.comments.FindAsync(id);
            if(comment == null) { return null; }
            return comment;
        }

        public async Task<Comment?> UpdateAsync(int id, CommentRequestDto commentRequest)
        {
            var comment = await _dbContext.comments.FindAsync(id);
            if (comment == null) { return null; }
            comment.Title = commentRequest.Title;
            comment.Content = commentRequest.Content;
            await _dbContext.SaveChangesAsync();
            return comment;

        }
    }
}
