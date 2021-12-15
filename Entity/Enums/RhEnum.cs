using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enums
{
    public enum RhEnum
    {
        [Description("Tanımsız")]
        Undefined = 0,
        [Description("Pozitif +")]
        Positive = 1,
        [Description("Negatif -")]
        Negative = 2,
    }
}
