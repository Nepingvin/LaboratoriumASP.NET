using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext: DbContext
{
    private string DbPath { get; set; }
   public DbSet<ContactEntity> Contacts{ get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source ={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = new DateOnly(2000, 10,10),
                    Email = "john.doe@gmail.com",
                    PhoneNumber = "088888888",
                    Created = DateTime.Now
                },
        new ContactEntity()
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateOnly(2000, 10,10),
                Email = "john@gmail.com",
                PhoneNumber = "088888889",
                Created = DateTime.Now
            }
            );
    }
}