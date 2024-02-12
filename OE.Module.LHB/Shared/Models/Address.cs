using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oqtane.Models;

namespace OE.Module.LHB.Shared.Models;

[Table("Address")]
public partial class Address : ModelBase
{
    [Key]
    public int AddressId { get; set; }

    public int ProviderId { get; set; }

    [StringLength(120)]
    public string Address1 { get; set; }

    [StringLength(120)]
    public string Address2 { get; set; }

    [StringLength(120)]
    public string Address3 { get; set; }

    [StringLength(100)]
    public string City { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string State { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string PostalCode { get; set; }

    public bool HasWheelchairAccess { get; set; }

    public bool HasLanguageSupport { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string Geocoding { get; set; }

    public float? Longitude { get; set; }

    public float? Latitude { get; set; }

    [Required]
    public bool IsActive { get; set; }

   

}