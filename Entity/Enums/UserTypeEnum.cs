using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enums
{
    public enum UserTypeEnum
    {
        [Description("Tanımsız")]
        Undefined = 0,
        [Description("Hasta")]
        Sick= 1,
        [Description("Donör")]
        Donor = 2
    }
}
