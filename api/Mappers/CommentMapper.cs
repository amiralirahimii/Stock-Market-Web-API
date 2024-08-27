using api.Dtos.Comment;
using api.Models;

namespace api.Mappers;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreateOn = commentModel.CreateOn,
            StockId = commentModel.StockId
        };
    }

    public static Comment ToComment(this CreateCommentDto createCommentDto)
    {
        return new Comment
        {
            Title = createCommentDto.Title,
            Content = createCommentDto.Content
        };
    }
    
    public static Comment ToComment(this UpdateCommentDto updateCommentDto)
    {
        return new Comment
        {
            Title = updateCommentDto.Title,
            Content = updateCommentDto.Content
        };
    }
}