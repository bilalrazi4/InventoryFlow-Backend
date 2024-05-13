using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class Invoice
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public bool InvoiceStatus { get; set; }

    public string Pdf { get; set; } = null!;
}
