using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class HealthFacilitiesNew
{
    public int Id { get; set; }

    public string FacilityId { get; set; } = null!;

    public int DistrictId { get; set; }

    public int TehsilId { get; set; }

    public string FacilityCode { get; set; } = null!;

    public string FacilityName { get; set; } = null!;

    public string? FacilityType { get; set; }

    public string? AreaType { get; set; }

    public short? Services247 { get; set; }

    public string? Class { get; set; }

    public string? Phase { get; set; }

    public string? Otp { get; set; }

    public string? Sc { get; set; }

    public bool? Emr { get; set; }

    public bool? Dsr { get; set; }

    public bool? Psbi { get; set; }

    public string? TehsilCode { get; set; }

    public int? UcId { get; set; }

    public short? IrmnchFacility { get; set; }

    public short? FacilityStatus { get; set; }

    public int? MeaRegion { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public long? OldHfid { get; set; }

    public string? Dhisuid { get; set; }

    public long? HrmisId { get; set; }

    public string? HrmisCode { get; set; }

    public string? HrDivisionCode { get; set; }

    public string? HrDistrictCode { get; set; }

    public string? HrTehsilCode { get; set; }

    public string? HrHftype { get; set; }

    public bool? PmhiFacility { get; set; }

    public bool? PhcipFacility { get; set; }

    public string? HrmisHfTypeCode { get; set; }

    public string? HrmisHfTypeName { get; set; }

    public bool? PhfmcFacility { get; set; }

    public string? FunctionStatus { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public bool? IsDeviceCheck { get; set; }

    public string? HrDivisionName { get; set; }

    public string? HrDistrictName { get; set; }

    public string? HrTehsilName { get; set; }
}
