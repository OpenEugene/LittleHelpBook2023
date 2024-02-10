using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace OE.Module.LHB.Shared.Models;

[Table("Attribute")]
public partial class Attribute : ModelBase
{
    [Key]
    public int AttributeId { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    public int? ParentAttributeId { get; set; }

    [Column("l10N")]
    [StringLength(4000)]
    public string L10N { get; set; }




}