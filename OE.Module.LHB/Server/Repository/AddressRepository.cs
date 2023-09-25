using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

using M = OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Repository
{
    public class AddressRepository :  ITransientService
    {
        private readonly LHBContext _db;

        public AddressRepository(LHBContext context)
        {
            _db = context;
        }

        public M.Address GetAddressByProviderId(int providerId) {
            var providerAddress = _db.ProviderAddress.FirstOrDefault(pa => pa.ProviderId == providerId);
            return providerAddress != null ? _db.Address.FirstOrDefault(a => a.AddressId == providerAddress.AddressId) : null;
        }

        public M.Address GetAddressByAddressId(int addressId)
        {
            return GetAddress(addressId, true);
        }

        public M.Address GetAddress(int addressId, bool tracking) {
            return tracking ? _db.Address.Find(addressId) : _db.Address.AsNoTracking().FirstOrDefault(item => item.AddressId == addressId);
        }

        public M.Address AddAddress(M.Address item)
        {
            _db.Address.Add(item);
            _db.SaveChanges();
            return item;
        }

        public M.Address UpdateAddress(M.Address addressId)
        {
            _db.Entry(addressId).State = EntityState.Modified;
            _db.SaveChanges();
            return addressId;
        }

        public void DeleteAddress(int addressId)
        {
            var item = _db.Address.Find(addressId);

            if (item == null) return;
            _db.Address.Remove(item);
            _db.SaveChanges();

        }
    }
}
