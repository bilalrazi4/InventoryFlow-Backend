﻿using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class Request
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? AdminId { get; set; }

    public int StockId { get; set; }

    public int ProductId { get; set; }

    public int? HfId { get; set; }

    public int RequestedQuantity { get; set; }

    public int PricePerUnit { get; set; }

    public int TotalPrice { get; set; }

    public string? Status { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }
}