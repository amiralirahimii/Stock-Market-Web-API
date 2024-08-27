using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment;

public class CreateCommentDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Title must be at most 50 characters long")]
    public string Title { get; set; } = String.Empty;
    [Required]
    [MinLength(3, ErrorMessage = "Content must be at least 3 characters long")]
    [MaxLength(500, ErrorMessage = "Content must be at most 500 characters long")]
    public string Content { get; set; } = String.Empty;
}