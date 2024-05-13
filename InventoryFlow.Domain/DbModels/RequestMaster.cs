using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class RequestMaster
{
    public int Id { get; set; }

    public string? AdminId { get; set; }

    public string? RequestStatus { get; set; }

    public int? UserHfId { get; set; }

    public string? Remarks { get; set; }

    public bool? ChequeStatus { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }
}
