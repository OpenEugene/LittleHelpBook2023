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
            Version = "1.0.2",
            PackageName = "OE.Theme.LHB",
            Resources = new List<Resource>()
            {
                new Resource { ResourceType = ResourceType.Script, Url = "_content/MudBlazor_oqtane/MudBlazor.min.js",Level=ResourceLevel.Site },
                //new Resource { ResourceType = ResourceType.Stylesheet, Url = "_content/MudBlazor_oqtane/MudBlazor.min.css",Level=ResourceLevel.Site },
                //new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap",Level=ResourceLevel.Site },
                //new Resource { ResourceType = ResourceType.Stylesheet, Url = "Themes/OE.Theme.LHB/Theme.css",Level=ResourceLevel.Site },
                // the above doens't work, so we'll just add the css to the ThemeLJB.razor file
            }
        };

    }
}
