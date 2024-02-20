using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oqtane.Models;

namespace OE.Module.LHB.Shared.Models;

[Table("ProviderAttribute")]
public partial class ProviderAttribute : ModelBase
{
    [Key]
    public int ProviderAttributeId { get; set; }

    public int ProviderId { get; set; }

    public int AttributeId { get; set; }


}