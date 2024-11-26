using Microsoft.EntityFrameworkCore;
using WebApp.Models.Services;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private string DbPath { get; set; }


    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(c => c.OrganizationId);


        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Name = "WSEI",
                    NIP = "32354624",
                    REGON = "23234523442",
                },
                new OrganizationEntity()
            {
                Id = 102,
                Name = "PKP",
                NIP = "32354624",
                REGON = "23234523442",
            }
            );
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new { City="Krkaow", Street="sw. Filipa", OrganizationEntityId = 101 },
                new { City="Warszawa", Street="Dworcowa 8", OrganizationEntityId = 102 }
            );
        
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Kowalski",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "adad@gmail.com",
                    PhoneNumber = "123456234",
                    Created = DateTime.Now,
                    OrganizationId = 101,
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Adam",
                    LastName = "owak",
                    BirthDate = new DateOnly(2003, 11, 12),
                    Email = "adam@gmail.com",
                    PhoneNumber = "123742684",
                    Created = DateTime.Now,
                    OrganizationId = 102,
                },
                new ContactEntity()
                {
                    Id = 3,
                    FirstName = "Ktos",
                    LastName = "Pupu",
                    BirthDate = new DateOnly(1995, 03, 05),
                    Email = "ktos@gmail.com",
                    PhoneNumber = "124963748",
                    Created = DateTime.Now,
                    OrganizationId = 101,
                }
            );
    }
}