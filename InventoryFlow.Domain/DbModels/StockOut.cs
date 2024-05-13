using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class StockOut
{
    public int Id { get; set; }

    public int StockId { get; set; }

    public int CategoryId { get; set; }

    public int RequestId { get; set; }

    public string Batch { get; set; } = null!;

    public decimal RequestedQuantity { get; set; }

    public decimal LastAvailableQuantity { get; set; }

    public decimal ApprovedQuantity { get; set; }

    public decimal Rate { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }
}
