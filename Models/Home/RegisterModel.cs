using System;
using System.Collections.Generic;
using Entity.Models;
using Models.Enums;

namespace Models.Home
{
    public class RegisterModel
    {
        public List<City> CityList { get; set; }
        public List<District> DistrictList { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string RPassword { get; set; }
        public short? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int? BloodGroup { get; set; }
        public int Rh { get; set; }
        public int? CivilStatus { get; set; }
        public int? EducationStatus { get; set; }
        public IEnumerable<EducationStatusEnum> EducationStatusList { get; set; }
        public IEnumerable<CivilStatusEnum> CivilStatusList { get; set; }
        public IEnumerable<RhEnum> RhList { get; set; }
        public IEnumerable<BloodGroupEnum> BloodGroupList { get; set; }
        public short? UserType { get; set; }
        public string AddressDesc { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string TitleHead { get; set; }   
        public string TitleButton { get; set; }   
	}
}
