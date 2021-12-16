using System.ComponentModel;

namespace Models.Enums
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
