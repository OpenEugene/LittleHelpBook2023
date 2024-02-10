using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace OE.Module.LHB.Shared.Models;

[Table("Provider")]
public partial class Provider : ModelBase
{
    [Key]
    public int ProviderId { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [StringLength(2000)]
    public string Description { get; set; }

    [StringLength(500)]
    public string WebAddress { get; set; }

    [StringLength(100)]
    public string EmailAddress { get; set; }

    [StringLength(500)]
    public string HoursOfOperation { get; set; }

    [Required]
    public bool? IsActive { get; set; }

    [Column("l10N")]
    public string L10N { get; set; }


}