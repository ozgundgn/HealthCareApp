using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enums
{
    public enum CivilStatusEnum
    {
        [Description("Tanımsız")]
        Undefined = 0,
        [Description("Evli")]
        Married = 1,
        [Description("Bekar")]
        Single = 2
    }
}
