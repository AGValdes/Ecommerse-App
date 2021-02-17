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

                /*=========================================  Categories  =======================================*/

      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Weapons", Description = "Magical items used for combat" });
      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Armor", Description = "Magical items used for armor" });
      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Potions", Description = "Magical concoctions" });
      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Rings", Description = "Magical Jewelry" });
      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Rods", Description = "Rods imbued with magical properties" });
      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Scrolls", Description = "Parchment scrolls with magical encryptions" });
      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Staves", Description = "Staves imbued with magical properties" });
      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Wands", Description = "Magical implements with pre-set spells" });
      //modelBuilder.Entity<Category>().HasData(new Category() { Name = "Wonderous Items", Description = "Miscellaneous Magical Item" });

      ///*==========================================  Products  =========================================*/

      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Sun Blade", Description = "This appears to be a long sword hilt, but it emenates a radiant energy", Price = 100.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Giant Slayer", Description = "When you hit a giant with it, the giant takes an extra 2d6 damage of the weapon's type and must succeed on a DC 15 Strength saving throw or fall prone.", Price = 500.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Vorpal Sword", Description = "When you attack a creature that has at least one head with this weapon and roll a 20 on the attack roll, you cut off one of the creature's heads.", Price = 1000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/462/315/315/636284780691337497.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Dragon Scale Mail", Description = "Dragon scale mail is made of the scales of one kind of dragon. Sometimes dragons collect their cast-off scales and gift them to humanoids. Other times, hunters carefully skin and preserve the hide of a dead dragon. In either case, dragon scale mail is highly valued. While wearing this armor, you gain a + 1 bonus to AC, you have advantage on saving throws against the Frightful Presence and breath weapons of dragons, and you have resistance to one damage type that is determined by the kind of a dragon that provided the scales", Price = 2000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Giant Slayer", Description = "When you hit a giant with it, the giant takes an extra 2d6 damage of the weapon's type and must succeed on a DC 15 Strength saving throw or fall prone.", Price = 500.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Vorpal Sword", Description = "When you attack a creature that has at least one head with this weapon and roll a 20 on the attack roll, you cut off one of the creature's heads.", Price = 1000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/462/315/315/636284780691337497.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Sun Blade", Description = "This appears to be a long sword hilt, but it emenates a radiant energy", Price = 100.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Giant Slayer", Description = "When you hit a giant with it, the giant takes an extra 2d6 damage of the weapon's type and must succeed on a DC 15 Strength saving throw or fall prone.", Price = 500.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Vorpal Sword", Description = "When you attack a creature that has at least one head with this weapon and roll a 20 on the attack roll, you cut off one of the creature's heads.", Price = 1000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/462/315/315/636284780691337497.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Sun Blade", Description = "This appears to be a long sword hilt, but it emenates a radiant energy", Price = 100.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Giant Slayer", Description = "When you hit a giant with it, the giant takes an extra 2d6 damage of the weapon's type and must succeed on a DC 15 Strength saving throw or fall prone.", Price = 500.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Vorpal Sword", Description = "When you attack a creature that has at least one head with this weapon and roll a 20 on the attack roll, you cut off one of the creature's heads.", Price = 1000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/462/315/315/636284780691337497.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Sun Blade", Description = "This appears to be a long sword hilt, but it emenates a radiant energy", Price = 100.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Giant Slayer", Description = "When you hit a giant with it, the giant takes an extra 2d6 damage of the weapon's type and must succeed on a DC 15 Strength saving throw or fall prone.", Price = 500.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg" });
      //modelBuilder.Entity<Product>().HasData(new Product() { Name = "Vorpal Sword", Description = "When you attack a creature that has at least one head with this weapon and roll a 20 on the attack roll, you cut off one of the creature's heads.", Price = 1000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/462/315/315/636284780691337497.jpeg" });


    }
  }
}
