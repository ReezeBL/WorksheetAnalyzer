using System.ComponentModel;

namespace Matreshka.Core
{
    public enum EyeColor
    {
        [Description("Голубые")]
        Blue,
        [Description("Зеленые")]
        Green,
        [Description("Карие")]
        Brown,
        [Description("Серые")]
        Grey,
        [Description("Черные")]
        Black,
        [Description("Другие;Не важно")]
        Other
    }
}