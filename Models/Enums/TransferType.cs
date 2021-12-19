using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Models.Enums
{
    public enum TransferType
    {
        [Description("Tanımsız")]
        Undefined = 0,
        [Description("Kan Nakli")]
        BloodTransfer = 1,
        [Description("İlik Nakli")]
        MarrowTransfer =2,
        [Description("Böbrek Nakli")]
        KidneyTransfer = 3,
    }
}
