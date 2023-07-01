using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;
using static MudBlazor.CategoryTypes;

namespace OE.Theme.LHB
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "LHB Theme",
            Version = "1.0.0",
            PackageName = "OE.Theme.LHB",
            Resources = new List<Resource>()
            {		        
                
                // boostrap for the side menu conflicts with mudblazor a tad.  need to resolve.
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/css/bootstrap.min.css", Integrity = "sha512-t4GWSVZO1eC8BM339Xd7Uphw5s17a86tIZIj8qRxhnKub6WoyhnrxeCIMeAqBPgdZGlCcG2PrZjMc+Wr78+5Xg==", CrossOrigin = "anonymous" },
                new Resource { ResourceType = ResourceType.Script, Url = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/js/bootstrap.bundle.min.js", Integrity = "sha512-VK2zcvntEufaimc+efOYi622VN5ZacdnufnmX7zIhCPmjhKnOi9ZDMtg1/ug5l183f19gG1/cBstPO4D8N/Img==", CrossOrigin = "anonymous" },

                // bulk of the app style is Mudblazor.
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "_content/MudBlazor_oqtane/MudBlazor.min.css"},
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"},
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Theme.css" },

                
                // loading the Mud script last seems to help
                new Resource { ResourceType = ResourceType.Script, Url = "_content/MudBlazor_oqtane/MudBlazor.min.js"},

            }
        };

    }
}
