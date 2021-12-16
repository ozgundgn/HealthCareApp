using System.ComponentModel;

namespace Models.Enums
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
