using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oqtane.Models;
using M=OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Shared.ViewModels;

public partial class ProviderAttributeViewModel : M.ProviderAttribute
{
   public M.Attribute Attribute { get; set; }
}