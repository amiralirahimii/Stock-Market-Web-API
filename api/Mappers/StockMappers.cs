using api.Dtos.Stock;
using api.Models;

namespace api.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap,
            Comments = stockModel.Comments.Select(comment => comment.ToCommentDto()).ToList()
        };
    }

    public static Stock ToStock(this CreateStockDto createStockDto)
    {
        return new Stock
        {
            Symbol = createStockDto.Symbol,
            CompanyName = createStockDto.CompanyName,
            Purchase = createStockDto.Purchase,
            LastDiv = createStockDto.LastDiv,
            Industry = createStockDto.Industry,
            MarketCap = createStockDto.MarketCap
        };
    }

    public static Stock ToStock(this UpdateStockDto updateStockDto)
    {
        return new Stock
        {
            Symbol = updateStockDto.Symbol,
            CompanyName = updateStockDto.CompanyName,
            Purchase = updateStockDto.Purchase,
            LastDiv = updateStockDto.LastDiv,
            Industry = updateStockDto.Industry,
            MarketCap = updateStockDto.MarketCap
        };
    }
}