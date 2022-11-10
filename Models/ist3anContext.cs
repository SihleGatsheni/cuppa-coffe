using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class ist3anContext : DbContext
    {

        public ist3anContext(DbContextOptions<ist3anContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Phonebook> Phonebook { get; set; }
        public virtual DbSet<Prod> Prod { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleItem> SaleItem { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.EmpAddress)
                    .IsRequired()
                    .HasColumnName("Emp_Address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmail)
                    .IsRequired()
                    .HasColumnName("Emp_Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFirstName)
                    .IsRequired()
                    .HasColumnName("Emp_FirstName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpIsManager).HasColumnName("Emp_IsManager");

                entity.Property(e => e.EmpLastname)
                    .IsRequired()
                    .HasColumnName("Emp_Lastname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPassword)
                    .IsRequired()
                    .HasColumnName("Emp_Password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPhone)
                    .IsRequired()
                    .HasColumnName("Emp_Phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpTypeId)
                    .IsRequired()
                    .HasColumnName("Emp_Type_ID")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProdCategory).HasColumnName("Prod_Category");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasColumnName("Prod_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdPrice)
                    .HasColumnName("Prod_Price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProdQuantity).HasColumnName("Prod_Quantity");

                entity.Property(e => e.ProdReOrderLevel).HasColumnName("Prod_ReOrder_Level");
            });

            modelBuilder.Entity<Phonebook>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Prod>(entity =>
            {
                entity.HasKey(e => e.ProductNumber);

                entity.ToTable("PROD");

                entity.Property(e => e.ProductNumber)
                    .HasColumnName("Product_Number")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.Property(e => e.ProdId)
                    .HasColumnName("ProdID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProdDate).HasColumnType("date");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProdType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SaleId);
                entity.Property(e => e.CustId).HasColumnName("CustId");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmpId).HasColumnName("EmpId");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(e => e.SaleItemId);
                
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProdId).HasColumnName("ProdId");
                entity.Property(e => e.Quantity).HasColumnName("Quantity");

                entity.Property(e => e.SaleId).HasColumnName("SaleId");
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.HasKey(e => e.StaffId);

                entity.Property(e => e.StaffId)
                    .HasColumnName("StaffID")
                    .ValueGeneratedNever();

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StaffDate).HasColumnType("date");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.Property(e => e.FirstName)
                    .ValueGeneratedNever();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.AspUserId)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
