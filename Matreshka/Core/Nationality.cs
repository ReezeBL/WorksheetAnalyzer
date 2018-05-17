using System.ComponentModel;

namespace Matreshka.Core
{
    public enum Nationality
    {
        [Description("Славянин")]
        Slav,
        [Description("Армянин")]
        Aremnian,
        [Description("Грузин")]
        Grousian,
        [Description("Беларус")]
        Belarus,
        [Description("Украинец")]
        Ukranian
    }
}