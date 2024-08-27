using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync(StockQueryObject stockQueryObject);
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, Stock stockModel);
    Task<Stock?> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}