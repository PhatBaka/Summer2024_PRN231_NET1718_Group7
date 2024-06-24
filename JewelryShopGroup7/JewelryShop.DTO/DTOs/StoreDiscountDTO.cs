using System.ComponentModel.DataAnnotations;

namespace JewelryShop.DTO.DTOs;

public partial class StoreDiscountDTO
{
    [Key]
    public Guid? StoreDiscountId { get; set; }

    public string? DiscountCode { get; set; }

    public decimal? DiscountAmount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? RemainingUsage { get; set; }

    public List<OrderDiscountDTO> OrderDiscounts { get; } = new List<OrderDiscountDTO>();
}
