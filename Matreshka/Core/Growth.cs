using System;
using System.ComponentModel;

namespace Matreshka.Core
{
    public enum Growth
    {
        [Description("До 150")]
        Little = 1,
        [Description("От 151 до 170")]
        Small = 2,
        [Description("От 171 и выше")]
        High = 3,
        [Description("Не важно")]
        Other = 170,
    }
}