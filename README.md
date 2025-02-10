# SanderTenBrinke.EntityFrameworkCore.Extensions.SqlServer.DataMasking

Adds Dynamic Data Masking for SQL Server to EF Core.

This package is a fork from [EntityFrameworkCore.Extensions](https://github.com/nikitasavinov/EntityFrameworkCore.Extensions) as that package wasn't maintained anymore and didn't support the latest versions of EF Core. This package strips out all the other features and only focuses on the Dynamic Data Masking feature.

# Installation

To install the package:

```sh
dotnet add package SanderTenBrinke.EntityFrameworkCore.Extensions.SqlServer.DataMasking
```

# Examples

```csharp
public class SampleContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Use EntityFrameworkCoreExtensions (add DynamicDataMasking support)
        optionsBuilder.UseEntityFrameworkCoreExtensions();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add dynamic data masking (https://docs.microsoft.com/en-us/sql/relational-databases/security/dynamic-data-masking)
        modelBuilder.Entity<Customer>().Property(t => t.Surname).HasDataMask(MaskingFunctions.Default());
        modelBuilder.Entity<Customer>().Property(t => t.DiscountCardNumber).HasDataMask(MaskingFunctions.Random(10, 100));
        modelBuilder.Entity<Customer>().Property(t => t.Phone).HasDataMask(MaskingFunctions.Partial(2, "XX-XX", 1));
    }

    public DbSet<Customer> Customers { get; set; }
}
```
