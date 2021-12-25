using System.ComponentModel;

namespace Models.Enums
{
    public enum UserTypeEnum
    {
        [Description("Hasta")]
        Sick= 1,
        [Description("Donör")]
        Donor = 2
    }
}
