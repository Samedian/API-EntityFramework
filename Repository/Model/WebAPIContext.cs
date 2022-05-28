using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Model
{
    public partial class WebAPIContext : DbContext
    {
        public WebAPIContext()
        {
        }

        public WebAPIContext(DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreateAccount> CreateAccounts { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Withdraw> Withdraws { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WebAPI;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreateAccount>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__CreateAc__BE2ACD6ECA4A4E93");

                entity.ToTable("CreateAccount");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DailyTransactionLimit).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.HasKey(e => new { e.CustomerName, e.Pannumber })
                    .HasName("PK__Customer__3A6FC3F0F1D3331A");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pannumber).HasColumnName("PANNumber");
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Deposit");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__Deposit__Account__30F848ED");
            });

            modelBuilder.Entity<Withdraw>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Withdraw");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__Withdraw__Accoun__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
