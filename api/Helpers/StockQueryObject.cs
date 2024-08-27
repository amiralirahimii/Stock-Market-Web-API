using System.ComponentModel.DataAnnotations;

namespace api.Helpers;

public class StockQueryObject
{
    public string? Symbol { get; set; } = String.Empty;
    public string? CompanyName { get; set; } = String.Empty;
    public decimal? PurchaseUpperBound { get; set; }
    public decimal? PurchaseLowerBound { get; set; }
    public string? SortBy { get; set; } = String.Empty;
    public bool IsSortAscending { get; set; } = true;
    [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than 0")]
    public int PageNumber { get; set; } = 1;
    [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than 0")]
    public int PageSize { get; set; } = 20;
}