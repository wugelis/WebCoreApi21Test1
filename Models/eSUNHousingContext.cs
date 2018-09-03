using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebCoreApi21Test1.Models
{
    public partial class eSUNHousingContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetail { get; set; }
        public virtual DbSet<HousingLoansData> HousingLoansData { get; set; }
        public virtual DbSet<QuestionnaireData> QuestionnaireData { get; set; }

        public eSUNHousingContext(DbContextOptions<eSUNHousingContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=(local)\MSSQLSERVER2016;Database=eSUNHousing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplyDate)
                    .HasColumnName("applyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.HasIndex(e => e.UserId)
                    .HasName("IXFK_CustomerDetail_Account");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Aid)
                    .HasColumnName("aid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChtName)
                    .HasColumnName("chtName")
                    .HasMaxLength(50);

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyNum).HasColumnName("familyNum");

                entity.Property(e => e.LocationNow)
                    .HasColumnName("locationNow")
                    .HasMaxLength(50);

                entity.Property(e => e.Marry).HasColumnName("marry");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomerDetail)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerDetail_Account");
            });

            modelBuilder.Entity<HousingLoansData>(entity =>
            {
                entity.HasKey(e => new { e.LoansId, e.CustomerId });

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IXFK_HousingLoansData_CustomerDetail");

                entity.Property(e => e.LoansId).HasColumnName("loansId");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.LoansAmount).HasColumnName("loansAmount");

                entity.Property(e => e.LoansHousingLocation)
                    .HasColumnName("loansHousingLocation")
                    .HasMaxLength(50);

                entity.Property(e => e.LoansPeriodStart)
                    .HasColumnName("loansPeriodStart")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoansPeriosEnd)
                    .HasColumnName("loansPeriosEnd")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoansUse)
                    .HasColumnName("loansUse")
                    .HasMaxLength(50);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.HousingLoansData)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HousingLoansData_CustomerDetail");
            });

            modelBuilder.Entity<QuestionnaireData>(entity =>
            {
                entity.HasKey(e => e.Aid);

                entity.Property(e => e.Aid)
                    .HasColumnName("aid")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ChtName)
                    .HasColumnName("chtName")
                    .HasMaxLength(10);

                entity.Property(e => e.EstimateAmount).HasColumnName("estimateAmount");

                entity.Property(e => e.HousingAddress)
                    .HasColumnName("housingAddress")
                    .HasMaxLength(200);

                entity.Property(e => e.HousingType).HasColumnName("housingType");

                entity.Property(e => e.IsHavePark).HasColumnName("isHavePark");

                entity.Property(e => e.LoansType)
                    .HasColumnName("loansType")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
