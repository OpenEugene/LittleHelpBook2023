using Oqtane.Models;
using Oqtane.Services;
using System;

namespace OE.Module.LHB.Services
{
    internal static class ServiceExtensions
    {
        public static void EnsureIAuditable(this IAuditable item)
        {
            item.CreatedBy = "";
            item.CreatedOn = DateTime.UtcNow;
            item.ModifiedBy = "";
            item.ModifiedOn = DateTime.UtcNow;
        }
    }
}
