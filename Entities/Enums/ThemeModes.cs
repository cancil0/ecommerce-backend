using System.ComponentModel;

namespace Entities.Enums
{
    public enum ThemeModes
    {
        [Description("DarkMode"), Value("D")]
        DarkMode,

        [Description("LightMode"), Value("L")]
        LightMode,

        [Description("SystemMode"), Value("S")]
        SystemMode
    }
}
