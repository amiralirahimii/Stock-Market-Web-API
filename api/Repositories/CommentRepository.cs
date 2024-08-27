using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CommentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _dbContext.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _dbContext.Comments.FindAsync(id);
    }

    public async Task<Comment> Create(int stockId, Comment commentModel)
    {
        commentModel.StockId = stockId;
        await _dbContext.AddAsync(commentModel);
        await _dbContext.SaveChangesAsync();
        return commentModel;
    }

    public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
    {
        var comment = await _dbContext.Comments.FindAsync(id);
        if (comment == null)
        {
            return null;
        }
        comment.Title = commentModel.Title;
        comment.Content = commentModel.Content;
        await _dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var comment = await _dbContext.Comments.FindAsync(id);
        if (comment == null)
        {
            return null;
        }
        _dbContext.Remove(comment);
        await _dbContext.SaveChangesAsync();
        return comment;
    }
}