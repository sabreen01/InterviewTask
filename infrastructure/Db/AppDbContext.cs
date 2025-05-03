using domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace infrastructure.Db
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "b2da474d-a3ed-4d9d-8721-90a17ef6a4d8",
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
                );

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "a94188ea-e7e6-4359-bebc-a489a675fba8",
                    UserName = "farah",
                    NormalizedUserName = "FARAH",
                    Email= "ad@hh.com",
                    NormalizedEmail= "AD@HH.COM",
                    PasswordHash= "AQAAAAIAAYagAAAAEFaxE07NGTqsxIggMwbEwq6c8d7xq0PECWWPgQgrIKXDWssvqxCSXrtBGCS/cQIIFQ==",
                    SecurityStamp= "F4Y2Z6X5W5AWDWZ3J7B62XSNOOWJCIUB",
                    ConcurrencyStamp= "5d0fc983-045b-4948-9c1c-e1ab4db1f9ca",

                }
                );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   UserId = "a94188ea-e7e6-4359-bebc-a489a675fba8",
                   RoleId = "b2da474d-a3ed-4d9d-8721-90a17ef6a4d8",
                   
               }
               );
           
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
    }
}
