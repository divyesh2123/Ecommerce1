using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Database
{
    public class EcommerceDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
        ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {


        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();


            });

            builder.Entity<Product>(product =>
            {
                product.HasOne(ur => ur.Unit)
                    .WithMany(r => r.Products)
                    .HasForeignKey(ur => ur.UnitId)
                    .IsRequired();

                product.HasOne(ur => ur.Category)
                    .WithMany(r => r.Products)
                    .HasForeignKey(ur => ur.CategoryId)
                    .IsRequired();

                product.HasOne(ur => ur.ApplicationUser)
                    .WithMany(r => r.Products)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

            });

            builder.Entity<ApplicationRole>().HasData(new ApplicationRole[] {
                new ApplicationRole{Id= "CUS",Name="Customer",NormalizedName = "CUSTOMER"},
                new ApplicationRole{Id="RET",Name="Retailer",NormalizedName="RETAILER"},
                new ApplicationRole{Id="ADN",Name="Admin",NormalizedName="ADMIN"},
            });


        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<ApplicationRole> ApplicationRole { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<Unit> Unit { get; set; }

        public  DbSet<Category> Categoy { get; set; }

        public  DbSet<Product> Product { get; set; }

      
    }
}
