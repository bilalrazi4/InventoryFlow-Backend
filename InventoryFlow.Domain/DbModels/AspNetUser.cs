﻿using System;
using System.Collections.Generic;

namespace InventoryFlow.Domain.DbModels;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? Hash { get; set; }

    public string? Cnic { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? ProfileImage { get; set; }

    public string? Gender { get; set; }

    public string? DivisionCode { get; set; }

    public string? DistrictCode { get; set; }

    public string? TownCode { get; set; }

    public string? InstituteId { get; set; }

    public string? Address { get; set; }

    public string? Designation { get; set; }

    public string? Department { get; set; }

    public bool? IsDisabled { get; set; }

    public DateTime? LastLoggedInDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
