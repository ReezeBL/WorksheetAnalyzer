using System.ComponentModel;

namespace Matreshka.Core
{
    public enum HairColor
    {
        [Description("Русые")]
        Grey,
        [Description("Блонд")]
        Blond,
        [Description("Черные")]
        Black,
        [Description("Рыжие")]
        Red,
        [Description("Другие;Не важно")]
        Other
    }
}