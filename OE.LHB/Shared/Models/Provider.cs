using Microsoft.Extensions.Localization;
using Oqtane.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json;

namespace OE.LHB.Models
{
    [Table("Provider")]
    public class Provider : IAuditable, IStringLocalizer<Provider>
    {
        public LocalizedString this[string name]
        {
            get
            {
                // deserialize L10n string to JSON object
                try
                {
                    var l10nObject = JsonSerializer.Deserialize<Dictionary<string, StringDictionary>>(L10n);

                    // retrieve the current culture
                    var currentCulture = CultureInfo.CurrentUICulture;

                    // get the culture-specific string for a given name parameter
                    if (l10nObject != null && l10nObject.ContainsKey(name))
                    {
                        return new LocalizedString(name, l10nObject[name][currentCulture.Name]);
                    }
                }
                catch { }

                // key not found, return the default in the Name or Description property depending on the parameter passed
                return name switch
                {
                    nameof(Name) => new LocalizedString(name, Name),
                    nameof(Description) => new LocalizedString(name, Description),
                    _ => new LocalizedString(name,string.Empty)
                }; ;
            }
        }

        public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string L10n { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }
    }
}
