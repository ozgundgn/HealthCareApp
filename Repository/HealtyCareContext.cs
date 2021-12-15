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

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Questionresult> Questionresult { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Sickapplicationdetails> Sickapplicationdetails { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Userapplicationmatch> Userapplicationmatch { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=OZGUN;Database=HealtyCare;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addressdesc)
                    .HasColumnName("addressdesc")
                    .HasMaxLength(150);

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Districtid).HasColumnName("districtid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.Districtid)
                    .HasConstraintName("FK_address_district");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_address_user");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("application");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cancellationreason)
                    .HasColumnName("cancellationreason")
                    .HasMaxLength(250);

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Relativesname)
                    .HasColumnName("relativesname")
                    .HasMaxLength(50);

                entity.Property(e => e.Relativesphone)
                    .HasColumnName("relativesphone")
                    .HasMaxLength(15);

                entity.Property(e => e.Relativesurname)
                    .HasColumnName("relativesurname")
                    .HasMaxLength(50);

                entity.Property(e => e.Statu).HasColumnName("statu");

                entity.Property(e => e.Transfertype).HasColumnName("transfertype");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_application_user1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cityname)
                    .HasColumnName("cityname")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Districtname)
                    .HasColumnName("districtname")
                    .HasMaxLength(60);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK_district_city");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Questiondesc)
                    .HasColumnName("questiondesc")
                    .HasMaxLength(150);

                entity.Property(e => e.Usertype).HasColumnName("usertype");
            });

            modelBuilder.Entity<Questionresult>(entity =>
            {
                entity.ToTable("questionresult");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Applicationid).HasColumnName("applicationid");

                entity.Property(e => e.Questionid).HasColumnName("questionid");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Questionresult)
                    .HasForeignKey(d => d.Applicationid)
                    .HasConstraintName("FK_questionresult_application");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Questionresult)
                    .HasForeignKey(d => d.Questionid)
                    .HasConstraintName("FK_questionresult_question");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Applicationid).HasColumnName("applicationid");

                entity.Property(e => e.Reportname)
                    .HasColumnName("reportname")
                    .HasMaxLength(60);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.Applicationid)
                    .HasConstraintName("FK_report_application");
            });

            modelBuilder.Entity<Sickapplicationdetails>(entity =>
            {
                entity.ToTable("sickapplicationdetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Applicationid).HasColumnName("applicationid");

                entity.Property(e => e.Sicknessdate)
                    .HasColumnName("sicknessdate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Sicknessdetail)
                    .HasColumnName("sicknessdetail")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Sickapplicationdetails)
                    .HasForeignKey(d => d.Applicationid)
                    .HasConstraintName("FK_sickapplicationdetails_application");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Bloodgroup).HasColumnName("bloodgroup");

                entity.Property(e => e.Civilstatus).HasColumnName("civilstatus");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Educationstatus).HasColumnName("educationstatus");

                entity.Property(e => e.Fathername)
                    .HasColumnName("fathername")
                    .HasMaxLength(40);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(40);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Identitynumber)
                    .HasColumnName("identitynumber")
                    .HasMaxLength(11);

                entity.Property(e => e.Lastlogindate)
                    .HasColumnName("lastlogindate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(40);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50);

                entity.Property(e => e.Mothername)
                    .HasColumnName("mothername")
                    .HasMaxLength(40);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(25);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15);

                entity.Property(e => e.Rh).HasColumnName("rh");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Usertype).HasColumnName("usertype");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Userapplicationmatch>(entity =>
            {
                entity.ToTable("userapplicationmatch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Applicationdonorid).HasColumnName("applicationdonorid");

                entity.Property(e => e.Applicationsickid).HasColumnName("applicationsickid");

                entity.Property(e => e.Donoruserid).HasColumnName("donoruserid");

                entity.Property(e => e.Matchdate)
                    .HasColumnName("matchdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sickuserid).HasColumnName("sickuserid");

                entity.HasOne(d => d.Applicationdonor)
                    .WithMany(p => p.UserapplicationmatchApplicationdonor)
                    .HasForeignKey(d => d.Applicationdonorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userapplicationmatch_application1");

                entity.HasOne(d => d.Applicationsick)
                    .WithMany(p => p.UserapplicationmatchApplicationsick)
                    .HasForeignKey(d => d.Applicationsickid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userapplicationmatch_application");

                entity.HasOne(d => d.Donoruser)
                    .WithMany(p => p.UserapplicationmatchDonoruser)
                    .HasForeignKey(d => d.Donoruserid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userapplicationmatch_user1");

                entity.HasOne(d => d.Sickuser)
                    .WithMany(p => p.UserapplicationmatchSickuser)
                    .HasForeignKey(d => d.Sickuserid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userapplicationmatch_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
