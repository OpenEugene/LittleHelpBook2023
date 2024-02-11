using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using M = OE.Module.LHB.Shared.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace OE.Module.LHB.Repository {
    public partial class LHBRepository
    {

        public IEnumerable<M.Attribute> GetAttributes() {
            var list = from a in _db.Attribute.AsNoTracking()
                       select a;
            return list;
        }

    }
}