using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enums
{
    public enum BloodGroupEnum
    {
        [Description("Tanımsız")]
        Undefined = 0,
        [Description("A")]
        A = 1,
        [Description("B")]
        B = 2,
        [Description("AB")]
        AB = 3,
        [Description("0")]
        O= 4,

    }
}
