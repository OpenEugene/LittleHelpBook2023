using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

using M = OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Repository
{
    public partial class LHBRepository :  ITransientService
    {
        private readonly LHBContext _db;

        public LHBRepository(LHBContext context)
        {
            _db = context;
        }

    }
}
