using System.ComponentModel;

namespace Models.Enums
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
