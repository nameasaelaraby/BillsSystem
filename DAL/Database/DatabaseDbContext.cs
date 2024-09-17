using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using DAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
namespace DAL.database
{
    public class DatabaseDbContext : IdentityDbContext
    {
        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Unit> Units { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<SelesReport> SelesReports { get; set; }




        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<AppUser>().ToTable("Users", "Sur");
        //    builder.Entity<IdentityRole>().ToTable("Roles", "Sur");
        //    builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Sur");
        //    builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Sur");
        //    builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Sur");
        //    builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Sur");
        //    builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Sur");


        //}

    }

}
