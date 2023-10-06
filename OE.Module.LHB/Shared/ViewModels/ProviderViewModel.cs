using System.Collections.Generic;
using OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Shared.ViewModels {
    public class ProviderViewModel : Provider {
        public List<Address> Addresses = new List<Address>();
        public List<PhoneNumber> PhoneNumbers = new List<PhoneNumber>();
        public List<ProviderAttribute> ProviderAttributes = new List<ProviderAttribute>();


    }
}

