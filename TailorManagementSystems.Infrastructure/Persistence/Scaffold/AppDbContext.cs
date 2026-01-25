using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeetask> Employeetasks { get; set; }

    public virtual DbSet<Employeetype> Employeetypes { get; set; }

    public virtual DbSet<ItemManagement> ItemManagements { get; set; }

    public virtual DbSet<Itememployeefee> Itememployeefees { get; set; }

    public virtual DbSet<Itemsize> Itemsizes { get; set; }

    public virtual DbSet<Itemsizecustomer> Itemsizecustomers { get; set; }

    public virtual DbSet<Mappingrole> Mappingroles { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Paymenttype> Paymenttypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Statustransaction> Statustransactions { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transactionitem> Transactionitems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("agency");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnType("int(11)");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.EmployeeTypeId, "EmployeeTypeId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmployeeTypeId).HasColumnType("int(11)");
            entity.Property(e => e.Gender).HasColumnType("enum('Pria','Wanita')");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");

            entity.HasOne(d => d.EmployeeType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("employee_ibfk_1");
        });

        modelBuilder.Entity<Employeetask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employeetask");

            entity.HasIndex(e => e.EmployeeId, "EmployeeId");

            entity.HasIndex(e => e.ItemEmployeeFeeId, "ItemEmployeeFeeId");

            entity.HasIndex(e => e.TransactionItemId, "TransactionItemId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.EmployeeId).HasColumnType("int(11)");
            entity.Property(e => e.IsDone).HasDefaultValueSql("'0'");
            entity.Property(e => e.ItemEmployeeFeeId).HasColumnType("int(11)");
            entity.Property(e => e.Note).HasColumnType("text");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
            entity.Property(e => e.TransactionItemId).HasColumnType("int(11)");

            entity.HasOne(d => d.Employee).WithMany(p => p.Employeetasks)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("employeetask_ibfk_2");

            entity.HasOne(d => d.ItemEmployeeFee).WithMany(p => p.Employeetasks)
                .HasForeignKey(d => d.ItemEmployeeFeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("employeetask_ibfk_3");

            entity.HasOne(d => d.TransactionItem).WithMany(p => p.Employeetasks)
                .HasForeignKey(d => d.TransactionItemId)
                .HasConstraintName("employeetask_ibfk_1");
        });

        modelBuilder.Entity<Employeetype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employeetype");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<ItemManagement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("item");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CustomerPrice).HasPrecision(10, 2);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Itememployeefee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("itememployeefee");

            entity.HasIndex(e => e.EmployeeTypeId, "EmployeeTypeId");

            entity.HasIndex(e => e.ItemId, "ItemId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.EmployeeTypeId).HasColumnType("int(11)");
            entity.Property(e => e.Fee).HasPrecision(10, 2);
            entity.Property(e => e.ItemId).HasColumnType("int(11)");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");

            entity.HasOne(d => d.EmployeeType).WithMany(p => p.Itememployeefees)
                .HasForeignKey(d => d.EmployeeTypeId)
                .HasConstraintName("itememployeefee_ibfk_2");

            entity.HasOne(d => d.Item).WithMany(p => p.Itememployeefees)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("itememployeefee_ibfk_1");
        });

        modelBuilder.Entity<Itemsize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("itemsize");

            entity.HasIndex(e => e.ItemId, "ItemId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ItemId).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");

            entity.HasOne(d => d.Item).WithMany(p => p.Itemsizes)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("itemsize_ibfk_1");
        });

        modelBuilder.Entity<Itemsizecustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("itemsizecustomer");

            entity.HasIndex(e => e.ItemSizeId, "ItemSizeId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ItemSizeId).HasColumnType("int(11)");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
            entity.Property(e => e.Value).HasMaxLength(100);

            entity.HasOne(d => d.ItemSize).WithMany(p => p.Itemsizecustomers)
                .HasForeignKey(d => d.ItemSizeId)
                .HasConstraintName("itemsizecustomer_ibfk_1");
        });

        modelBuilder.Entity<Mappingrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mappingrole");

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.RoleId).HasColumnType("int(11)");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.Role).WithMany(p => p.Mappingroles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("mappingrole_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Mappingroles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("mappingrole_ibfk_2");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menus");

            entity.HasIndex(e => e.OrderPosition, "idx_order_position");

            entity.HasIndex(e => e.ParentId, "idx_parent_id");

            entity.HasIndex(e => e.Slug, "slug").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnName("created_at");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("'1'")
                .HasColumnName("RowStatus");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.OrderPosition)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("order_position");
            entity.Property(e => e.ParentId)
                .HasColumnType("int(11)")
                .HasColumnName("parent_id");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("menus_ibfk_1");
        });

        modelBuilder.Entity<Paymenttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paymenttype");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Statustransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statustransaction");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("transaction");

            entity.HasIndex(e => e.AgencyId, "AgencyId");

            entity.HasIndex(e => e.CreatedBy, "CreatedBy");

            entity.HasIndex(e => e.CustomerId, "CustomerId");

            entity.HasIndex(e => e.PaymentTypeId, "PaymentTypeId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AgencyId).HasColumnType("int(11)");
            entity.Property(e => e.Amount)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.BalanceDue)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.CompletionDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasColumnType("int(11)");
            entity.Property(e => e.CustomerId).HasColumnType("int(11)");
            entity.Property(e => e.Note).HasColumnType("text");
            entity.Property(e => e.PaidAmount)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.PaymentTypeId).HasColumnType("int(11)");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Agency).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("transaction_ibfk_2");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("transaction_ibfk_4");

            entity.HasOne(d => d.Customer).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("transaction_ibfk_1");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("transaction_ibfk_3");
        });

        modelBuilder.Entity<Transactionitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("transactionitem");

            entity.HasIndex(e => e.ItemId, "ItemId");

            entity.HasIndex(e => e.ItemSizeCustomerId, "ItemSizeCustomerId");

            entity.HasIndex(e => e.StatusTransactionId, "StatusTransactionId");

            entity.HasIndex(e => e.TransactionId, "TransactionId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CustomerPrice).HasPrecision(10, 2);
            entity.Property(e => e.ItemId).HasColumnType("int(11)");
            entity.Property(e => e.ItemSizeCustomerId).HasColumnType("int(11)");
            entity.Property(e => e.Note).HasColumnType("text");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
            entity.Property(e => e.StatusTransactionId).HasColumnType("int(11)");
            entity.Property(e => e.TransactionId).HasColumnType("int(11)");

            entity.HasOne(d => d.Item).WithMany(p => p.Transactionitems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("transactionitem_ibfk_2");

            entity.HasOne(d => d.ItemSizeCustomer).WithMany(p => p.Transactionitems)
                .HasForeignKey(d => d.ItemSizeCustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("transactionitem_ibfk_3");

            entity.HasOne(d => d.StatusTransaction).WithMany(p => p.Transactionitems)
                .HasForeignKey(d => d.StatusTransactionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("transactionitem_ibfk_4");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Transactionitems)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("transactionitem_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female','Other')");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
