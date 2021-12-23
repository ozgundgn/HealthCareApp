using Entity.Models;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository
{
    public partial class HealtyCareContext : DbContext
    {
        public HealtyCareContext()
        {
        }

        public HealtyCareContext(DbContextOptions<HealtyCareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionResult> QuestionResults { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<SickApplicationDetails> SickApplicationDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserApplicationMatch> UserApplicationMatches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=OZGUN;Database=HealtyCare;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressDesc)
                    .HasColumnName("addressdesc")
                    .HasMaxLength(150);

                entity.Property(e => e.CityId).HasColumnName("cityid");

                entity.Property(e => e.DistrictId).HasColumnName("districtid");

                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_address_district");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_address_user");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("application");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CancellationReason)
                    .HasColumnName("cancellationreason")
                    .HasMaxLength(250);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.RelativesName)
                    .HasColumnName("relativesname")
                    .HasMaxLength(50);

                entity.Property(e => e.RelativesPhone)
                    .HasColumnName("relativesphone")
                    .HasMaxLength(15);

                entity.Property(e => e.RelativeSurname)
                    .HasColumnName("relativesurname")
                    .HasMaxLength(50);

                entity.Property(e => e.Statu).HasColumnName("statu");

                entity.Property(e => e.TransferType).HasColumnName("transfertype");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_application_user1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityName)
                    .HasColumnName("cityname")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("cityid");

                entity.Property(e => e.DistrictName)
                    .HasColumnName("districtname")
                    .HasMaxLength(60);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_district_city");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.QuestionDesc)
                    .HasColumnName("questiondesc")
                    .HasMaxLength(150);

                entity.Property(e => e.UserType).HasColumnName("usertype");
            });

            modelBuilder.Entity<QuestionResult>(entity =>
            {
                entity.ToTable("questionresult");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationId).HasColumnName("applicationid");

                entity.Property(e => e.QuestionId).HasColumnName("questionid");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.QuestionResult)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_questionresult_application");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionResult)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_questionresult_question");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationId).HasColumnName("applicationid");

                entity.Property(e => e.ReportName)
                    .HasColumnName("reportname")
                    .HasMaxLength(60);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_report_application");
            });

            modelBuilder.Entity<SickApplicationDetails>(entity =>
            {
                entity.ToTable("sickapplicationdetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationId).HasColumnName("applicationid");

                entity.Property(e => e.SicknessDate)
                    .HasColumnName("sicknessdate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SicknessDetail)
                    .HasColumnName("sicknessdetail")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.SickApplicationDetails)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_sickapplicationdetails_application");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.BloodGroup).HasColumnName("bloodgroup");

                entity.Property(e => e.CivilStatus).HasColumnName("civilstatus");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EducationStatus).HasColumnName("educationstatus");

                entity.Property(e => e.FatherName)
                    .HasColumnName("fathername")
                    .HasMaxLength(40);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstname")
                    .HasMaxLength(40);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdentityNumber)
                    .HasColumnName("identitynumber")
                    .HasMaxLength(11);

                entity.Property(e => e.LastLoginDate)
                    .HasColumnName("lastlogindate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastname")
                    .HasMaxLength(40);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50);

                entity.Property(e => e.MotherName)
                    .HasColumnName("mothername")
                    .HasMaxLength(40);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(25);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15);

                entity.Property(e => e.Rh).HasColumnName("rh");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserType).HasColumnName("usertype");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<UserApplicationMatch>(entity =>
            {
                entity.ToTable("userapplicationmatch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationDonorId).HasColumnName("applicationdonorid");

                entity.Property(e => e.ApplicationSickId).HasColumnName("applicationsickid");

                entity.Property(e => e.DonorUserId).HasColumnName("donoruserid");

                entity.Property(e => e.MatchDate)
                    .HasColumnName("matchdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SickUserId).HasColumnName("sickuserid");

                entity.HasOne(d => d.ApplicationDonor)
                    .WithMany(p => p.UserApplicationMatchApplicationDonor)
                    .HasForeignKey(d => d.ApplicationDonorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userapplicationmatch_application1");

                entity.HasOne(d => d.ApplicationSick)
                    .WithMany(p => p.UserApplicationMatchApplicationSick)
                    .HasForeignKey(d => d.ApplicationSickId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userapplicationmatch_application");

                entity.HasOne(d => d.DonorUser)
                    .WithMany(p => p.UserApplicationMatchDonorUser)
                    .HasForeignKey(d => d.DonorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userapplicationmatch_user1");

                entity.HasOne(d => d.SickUser)
                    .WithMany(p => p.UserApplicationMatchSickUser)
                    .HasForeignKey(d => d.SickUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userapplicationmatch_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
