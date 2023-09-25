﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OE.Module.LHB.Shared.Models;

[Table("ProviderAddress")]
public partial class ProviderAddress
{
    [Key]
    public int ProviderAddressId { get; set; }

    public int ProviderId { get; set; }

    public int AddressId { get; set; }

    [Required]
    public bool? IsActive { get; set; }

    [Required]
    [StringLength(256)]
    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    [Required]
    [StringLength(256)]
    public string ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("ProviderAddresses")]
    public virtual Address Address { get; set; }

    [ForeignKey("ProviderId")]
    [InverseProperty("ProviderAddresses")]
    public virtual Provider Provider { get; set; }
}