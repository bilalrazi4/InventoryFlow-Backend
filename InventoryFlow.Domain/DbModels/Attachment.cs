using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class Attachment
{
    public int Id { get; set; }

    public byte[] ChequeImage { get; set; } = null!;

    public string? ChequeDetail { get; set; }

    public int RequestId { get; set; }
}
