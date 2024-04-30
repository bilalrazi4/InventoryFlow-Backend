using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class Vendor
{
    public int Id { get; set; }

    public string Vendor1 { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }
}
