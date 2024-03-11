using webapi.api;
using webapi.dto;
using webapi.NewFolder;

namespace webapi.mapper
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                Title = comment.Title,
                CreateOn = comment.CreateOn,
                stockId= comment.stockId
            };
        }


    }
}
