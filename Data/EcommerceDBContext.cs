using Ecommerce_App.Auth.Models;
using Ecommerce_App.Auth.Models.DTO;
using Ecommerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Data
{
    public class EcommerceDBContext : IdentityDbContext<AuthUser>
    {

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<CategoryProduct> categoryProducts { get; set; }

        public EcommerceDBContext(DbContextOptions options) : base(options) {}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, and Identity needs it
            base.OnModelCreating(modelBuilder);
            SeedRole(modelBuilder, "Admin", "read", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "read", "create", "update");
            SeedRole(modelBuilder, "Guest", "read");

            //TODO: figure out why this isn't seeding :(

            //modelBuilder.Entity<AuthUser>().HasData(
            //new AuthUser { UserName = "Kjell0", Email = "no@thankyou.com", PasswordHash = "Test!23", PhoneNumber = "1561456161", Roles = { "Admin" } },
            //new RegisterUser { Username = "AGValdes", Email = "yes@please.com", Password = "Test!45", PhoneNumber = "1561615156126", Roles = { "Admin" } }
            //);

            //modelBuilder.Entity<IdentityUserRole>().HasData(
                //new IdentityRole { Id = "6d89ac3a-07ca-4d3b-b102-d6ac0481d7b4", Name = "Admin", NormalizedName = "ADMIN" }
            //);

            modelBuilder.Entity<CategoryProduct>().HasKey(
                categoryProduct => new { categoryProduct.CategoryId, categoryProduct.ProductId }
            );
        }
        private int nextId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
            var roleClaims = permissions.Select(permission =>
              new IdentityRoleClaim<string>
              {
                  Id = nextId++,
                  RoleId = role.Id,
                  ClaimType = "permissions",
            ClaimValue = permission
              }).ToArray();
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
    }
}
