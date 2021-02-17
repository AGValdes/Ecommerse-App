using Ecommerce_App.Auth.Models;
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
        public EcommerceDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, and Identity needs it
            base.OnModelCreating(modelBuilder);
            // Seed a few roles using Identity
            SeedRole(modelBuilder, "Administrator", "read", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "read", "create", "update");
            SeedRole(modelBuilder, "Guest", "read");
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
            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
              new IdentityRoleClaim<string>
              {
                  Id = nextId++,
                  RoleId = role.Id,
                  ClaimType = "permissions", // This matches what we did in Startup.cs
            ClaimValue = permission
              }).ToArray();
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
    }
}
