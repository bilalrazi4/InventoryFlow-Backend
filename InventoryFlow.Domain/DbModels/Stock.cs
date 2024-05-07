using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class Stock
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int VendorId { get; set; }

    public int CategoryId { get; set; }

    public string? Batch { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Rate { get; set; }

    public DateTime? ManufacturingDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool InStock { get; set; }
}
