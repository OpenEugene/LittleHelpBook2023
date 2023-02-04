using Oqtane.Models;
using Oqtane.Themes;

namespace OE.LHBTheme
{
    public class ThemeInfo : ITheme
    {
        public Theme Theme => new Theme
        {
            Name = "LHBTheme",
            Version = "1.0.0",
            PackageName = "OE.LHBTheme"
        };

    }
}
