﻿using System.Collections.Generic;
using Microsoft.Identity.Client;
using OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Shared.ViewModels {
    public class ProviderViewModel : Provider {
        public List<Address> Addresses { get;set; } = new();
        public List<PhoneNumber> PhoneNumbers { get;set; }=  new();
        public List<ProviderAttributeViewModel> ProviderAttributes { get; set; } = new();
        public ProviderViewModel() { }
        public ProviderViewModel(Provider provider) { 
            ProviderId = provider.ProviderId;
            Name = provider.Name;
            Description = provider.Description;
            WebAddress = provider.WebAddress;
            EmailAddress = provider.EmailAddress;
            HoursOfOperation = provider.HoursOfOperation;
            IsActive = provider.IsActive;
            CreatedBy = provider.CreatedBy;
            CreatedOn = provider.CreatedOn;
            ModifiedBy = provider.ModifiedBy;
            ModifiedOn = provider.ModifiedOn;
        }

    }
}

