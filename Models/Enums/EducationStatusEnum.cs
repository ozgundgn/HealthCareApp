using System.ComponentModel;

namespace Models.Enums
{
    public enum EducationStatusEnum
    {
        [Description("Tanımsız")]
        Undefined = 0,
        [Description("İlk Okul")]
        PrimarySchool = 1,
        [Description("Orta Okul")]
        MiddleSchool = 2,
        [Description("Lise")]
        HighSchool = 3,
        [Description("Ön Lisans")]
        AssociateDegree = 4,
        [Description("Lisans")]
        University = 5,
        [Description("Yüksek Lisans")]
        HighUniversity = 6
    }
}
