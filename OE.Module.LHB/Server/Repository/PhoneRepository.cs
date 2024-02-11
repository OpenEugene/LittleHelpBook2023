using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using M = OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Repository {
    public partial class LHBRepository
    {

        public List<M.PhoneNumber> GetPhoneNumbersByProviderId(int providerId, bool tracking = false) {
            // get a list of Phones for a provider
            var nums = from p in _db.PhoneNumber
                        where p.ProviderId == providerId
                        select p;
            return nums.ToList();
        }

        public M.PhoneNumber GetPhoneNumberByPhoneNumberId(int phoneNumberId) {
            return GetPhoneNumber(phoneNumberId, true);
        }

        public M.PhoneNumber GetPhoneNumber(int phoneNumberId, bool tracking) {
            return tracking ? _db.PhoneNumber.Find(phoneNumberId) : _db.PhoneNumber.AsNoTracking().FirstOrDefault(item => item.PhoneNumberId == phoneNumberId);
        }

        public M.PhoneNumber AddPhoneNumber(M.PhoneNumber item) {
            _db.PhoneNumber.Add(item);
            _db.SaveChanges();
            return item;
        }

        public M.PhoneNumber UpdatePhoneNumber(M.PhoneNumber phoneNumberId) {
            _db.Entry(phoneNumberId).State = EntityState.Modified;
            _db.SaveChanges();
            return phoneNumberId;
        }

        public void DeletePhoneNumber(int phoneNumberId) {
            var item = _db.PhoneNumber.Find(phoneNumberId);

            if (item == null) return;
            _db.PhoneNumber.Remove(item);
            _db.SaveChanges();
        }
    }
}