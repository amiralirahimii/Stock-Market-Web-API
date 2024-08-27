using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock;

public class UpdateStockDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Symbol must be at least 3 characters long")]
    [MaxLength(10, ErrorMessage = "Symbol must be at most 10 characters long")]
    public string Symbol { get; set; } = String.Empty;
    [Required]
    [MinLength(3, ErrorMessage = "Company-name must be at least 3 characters long")]
    [MaxLength(10, ErrorMessage = "Company-name must be at most 10 characters long")]
    public string CompanyName { get; set; } = String.Empty;
    [Required]
    [Range(1, 10000, ErrorMessage = "Purchase must be between 1 and 10000")]
    public decimal Purchase { get; set; }
    [Required]
    [Range(0.001, 100, ErrorMessage = "Last-div must be between 0.001 and 100")]
    public decimal LastDiv { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "Industry must be at least 3 characters long")]
    [MaxLength(10, ErrorMessage = "Industry must be at most 10 characters long")]
    public string Industry { get; set; } = String.Empty;
    [Required]
    [Range(1, 1000000000, ErrorMessage = "Market-cap must be between 1 and 1000000000")]
    public long MarketCap { get; set; }
}