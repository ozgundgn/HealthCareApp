using System;
using System.Collections.Generic;
using Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entity.Models
{
    public partial class User : IEntity
    {
        public User()
        {
            Address = new HashSet<Address>();
            Application = new HashSet<Application>();
            UserApplicationMatchDonorUser = new HashSet<UserApplicationMatch>();
            UserApplicationMatchSickUser = new HashSet<UserApplicationMatch>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public short? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int? BloodGroup { get; set; }
        public int? Rh { get; set; }
        public int? CivilStatus { get; set; }
        public int? EducationStatus { get; set; }
        public short? UserType { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<UserApplicationMatch> UserApplicationMatchDonorUser { get; set; }
        public virtual ICollection<UserApplicationMatch> UserApplicationMatchSickUser { get; set; }
    }
}
