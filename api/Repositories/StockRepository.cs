using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class StockRepository(ApplicationDbContext dbContext) : IStockRepository
{
    public async Task<List<Stock>> GetAllAsync(StockQueryObject stockQueryObject)
    {
        var stocks =
            dbContext.Stocks
                .Include(stock => stock.Comments)
                .AsQueryable();
        if (!string.IsNullOrWhiteSpace(stockQueryObject.Symbol))
        {
            stocks = stocks.Where(stock => stock.Symbol.Contains(stockQueryObject.Symbol));
        }

        if (!string.IsNullOrWhiteSpace(stockQueryObject.CompanyName))
        {
            stocks = stocks.Where(stock => stock.CompanyName.Contains(stockQueryObject.CompanyName));
        }
        if(stockQueryObject.PurchaseUpperBound != null)
        {
            stocks = stocks.Where(stock => stock.Purchase <= stockQueryObject.PurchaseUpperBound);
        }
        if(stockQueryObject.PurchaseLowerBound != null)
        {
            stocks = stocks.Where(stock => stock.Purchase >= stockQueryObject.PurchaseLowerBound);
        }
        if (!string.IsNullOrWhiteSpace(stockQueryObject.SortBy))
        {
            if(String.Equals(stockQueryObject.SortBy, "symbol", StringComparison.OrdinalIgnoreCase))
            {
                stocks = stockQueryObject.IsSortAscending ? stocks.OrderBy(stock => stock.Symbol) : stocks.OrderByDescending(stock => stock.Symbol);
            }
            if(String.Equals(stockQueryObject.SortBy, "companyName", StringComparison.OrdinalIgnoreCase))
            {
                stocks = stockQueryObject.IsSortAscending ? stocks.OrderBy(stock => stock.CompanyName) : stocks.OrderByDescending(stock => stock.CompanyName);
            }
            if(String.Equals(stockQueryObject.SortBy, "purchase", StringComparison.OrdinalIgnoreCase))
            {
                stocks = stockQueryObject.IsSortAscending ? stocks.OrderBy(stock => stock.Purchase) : stocks.OrderByDescending(stock => stock.Purchase);
            }
            if(String.Equals(stockQueryObject.SortBy, "lastDiv", StringComparison.OrdinalIgnoreCase))
            {
                stocks = stockQueryObject.IsSortAscending ? stocks.OrderBy(stock => stock.LastDiv) : stocks.OrderByDescending(stock => stock.LastDiv);
            }
            if(String.Equals(stockQueryObject.SortBy, "industry", StringComparison.OrdinalIgnoreCase))
            {
                stocks = stockQueryObject.IsSortAscending ? stocks.OrderBy(stock => stock.Industry) : stocks.OrderByDescending(stock => stock.Industry);
            }
            if(String.Equals(stockQueryObject.SortBy, "marketCap", StringComparison.OrdinalIgnoreCase))
            {
                stocks = stockQueryObject.IsSortAscending ? stocks.OrderBy(stock => stock.MarketCap) : stocks.OrderByDescending(stock => stock.MarketCap);
            }
        }
        var skipAmount = stockQueryObject.PageSize * (stockQueryObject.PageNumber - 1);
        return await stocks
            .Skip(skipAmount)
            .Take(stockQueryObject.PageSize)
            .ToListAsync();
}

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await dbContext.Stocks
            .Include(stock => stock.Comments)
            .FirstOrDefaultAsync(stock => stock.Id == id);
    }

    public async Task<Stock?> CreateAsync(Stock stockModel)
    {
        await dbContext.AddAsync(stockModel);
        await dbContext.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> UpdateAsync(int id, Stock newStockModel)
    {
        var stockModel = await dbContext.Stocks.FindAsync(id);
        if (stockModel == null)
        {
            return null;
        }
        stockModel.Symbol = newStockModel.Symbol;
        stockModel.CompanyName = newStockModel.CompanyName;
        stockModel.Purchase = newStockModel.Purchase;
        stockModel.LastDiv = newStockModel.LastDiv;
        stockModel.Industry = newStockModel.Industry;
        stockModel.MarketCap = newStockModel.MarketCap;
        await dbContext.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await dbContext.Stocks.FindAsync(id);
        if (stockModel == null)
        {
            return null;
        }
        dbContext.Stocks.Remove(stockModel);
        await dbContext.SaveChangesAsync();
        return stockModel;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await dbContext.Stocks.AnyAsync(stock => stock.Id == id);
    }
}