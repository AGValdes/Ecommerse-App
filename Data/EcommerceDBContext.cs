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

        public DbSet<CartProduct> cartProducts { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }
        public EcommerceDBContext(DbContextOptions options) : base(options) {}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*=========================================  Categories  =======================================*/

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Weapons", Description = "Magical items used for combat" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Armor", Description = "Magical items used for armor" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Potions", Description = "Magical concoctions" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Name = "Rings", Description = "Magical Jewelry" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 5, Name = "Rods", Description = "Rods imbued with magical properties" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 6, Name = "Scrolls", Description = "Parchment scrolls with magical encryptions" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 7, Name = "Staves", Description = "Staves imbued with magical properties" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 8, Name = "Wands", Description = "Magical implements with pre-set spells" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 9, Name = "Wonderous Items", Description = "Miscellaneous Magical Item" });

            ///*==========================================  Products  =========================================*/
            
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Sun Blade", Description = "This appears to be a long sword hilt, but it emenates a radiant energy", Price = 100.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Name = "Giant Slayer", Description = "When you hit a giant with it, the giant takes an extra 2d6 damage of the weapon's type and must succeed on a DC 15 Strength saving throw or fall prone.", Price = 500.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 3, Name = "Vorpal Sword", Description = "When you attack a creature that has at least one head with this weapon and roll a 20 on the attack roll, you cut off one of the creature's heads.", Price = 2000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/462/315/315/636284780691337497.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 4, Name = "Dragon Scale Mail", Description = "Dragon scale mail is made of the scales of one kind of dragon. Sometimes dragons collect their cast-off scales and gift them to humanoids. Other times, hunters carefully skin and preserve the hide of a dead dragon. In either case, dragon scale mail is highly valued. While wearing this armor, you gain a + 1 bonus to AC, you have advantage on saving throws against the Frightful Presence and breath weapons of dragons, and you have resistance to one damage type that is determined by the kind of a dragon that provided the scales", Price = 2000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 5, Name = "Elven Chain", Description = "You gain a +1 bonus to AC while you wear this armor. You are considered proficient with this armor even if you lack proficiency with medium armor. Made of interlocking metal rings, a chain shirt is worn between layers of clothing or leather. This armor offers modest protection to the wearer's upper body and allows the sound of the rings rubbing against one another to be muffled by outer layers.", Price = 300.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/208/315/315/636284731937952010.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 6, Name = "Bracers of Archery", Description = "While wearing these bracers, you have proficiency with the longbow and shortbow, and you gain a +2 bonus to damage rolls on ranged attacks made with such weapons.", Price = 100.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/144/315/315/636284715992548759.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 7, Name = "Oil of Etherealness", Description = "Beads of this cloudy gray oil form on the outside of its container and quickly evaporate. The oil can cover a Medium or smaller creature, along with the equipment it's wearing and carrying (one additional vial is required for each size category above Medium). Applying the oil takes 10 minutes. The affected creature then gains the effect of the etherealness spell for 1 hour.", Price = 400.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/attachments/2/667/potion.jpg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 8, Name = "Potion of Mind Reading", Description = "When you drink this potion, you gain the effect of the detect thoughts spell (save DC 13). The potion's dense, purple liquid has an ovoid cloud of pink floating in it.", Price = 425.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/attachments/2/667/potion.jpg" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 9, Name = "Potion of Healing", Description = "You regain hit points when you drink this potion. The number of hit points depends on the potion's rarity, as shown in the Potions of Healing table. Whatever its potency, the potion's red liquid glimmers when agitated.", Price = 150.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/attachments/2/667/potion.jpg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 10, Name = "Ring of Water Walking", Description = "While wearing this ring, you can stand on and move across any liquid surface as if it were solid ground.", Price = 1000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/374/315/315/636284763046262817.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 11, Name = "Ring of Animal Influence", Description = "This ring has 3 charges, and it regains 1d3 expended charges daily at dawn. While wearing the ring, you can use an action to expend 1 of its charges to cast one of the following spells: Animal friendship (save DC 13), Fear (save DC 13), targeting only beasts that have an https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/372/315/315/636284762810625788.jpeg of 3 or lower, Speak with animals", Price = 1200.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/341/315/315/636284758989654087.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 12, Name = "Ring of Three Wishes", Description = "While wearing this ring, you can use an action to expend 1 of its 3 charges to cast the wish spell from it. The ring becomes nonmagical when you use the last charge.", Price = 50000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 13, Name = "Immovable Rod", Description = "This flat iron rod has a button on one end. You can use an action to press the button, which causes the rod to become magically fixed in place. Until you or another creature uses an action to push the button again, the rod doesn't move, even if it is defying gravity. The rod can hold up to 8,000 pounds of weight. More weight causes the rod to deactivate and fall. A creature can use an action to make a DC 30 Strength check, moving the fixed rod up to 10 feet on a success.", Price = 500.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/261/315/315/636284741670235041.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 14, Name = "Rod of Absorption", Description = "While holding this rod, you can use your reaction to absorb a spell that is targeting only you and not with an area of effect. The absorbed spell's effect is canceled, and the spell's energy -- not the spell itself -- is stored in the rod. ", Price = 400.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/386/315/315/636284765204637619.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 15, Name = "Rod of Lordly Might", Description = "This rod has a flanged head, and it functions as a magic mace that grants a +3 bonus to attack and damage rolls made with it. The rod has properties associated with six different buttons that are set in a row along the haft. ", Price = 1000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/388/315/315/636284765584014212.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 16, Name = "Scroll of Protection", Description = "Each scroll of protection works against a specific type of creature. Using an action to read the scroll encloses you in a invisible barrier that extends from you to form a 5 - foot - radius, 10 - foot - high cylinder.For 5 minutes, this barrier prevents creatures of the specified type from entering or affecting anything within the cylinder.", Price = 1000.00m, ImgUrl = "", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 17, Name = "Scroll of the Comet", Description = "By using an action to read the scroll, you cause a comet to fall from the sky and crash to the ground at a point you can see up to 1 mile away from you. You must be outdoors when you use the scroll, or nothing happens and the scroll is wasted.", Price = 10000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 18, Name = "Staff of Charming", Description = "While holding this staff, you can use an action to expend 1 of its 10 charges to cast charm person, command, or comprehend languages from it using your spell save DC. The staff can also be used as a magic quarterstaff.", Price = 900.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/408/315/315/636284768308428008.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 19, Name = "Staff of Healing", Description = "This staff has 10 charges. While holding it, you can use an action to expend 1 or more of its charges to cast one of the following spells from it, using your spell save DC and spellcasting ability modifier: cure wounds (1 charge per spell level, up to 4th), lesser restoration (2 charges), or mass cure wounds (5 charges).", Price = 1200.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/414/315/315/636284768980904526.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 20, Name = "Staff of Swarming Insects", Description = "This staff has 10 charges and regains 1d6 + 4 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, a swarm of insects consumes and destroys the staff, then disperses.", Price = 2000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/418/315/315/636284769826755468.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 21, Name = "Wand of Enemy Detection", Description = "This wand has 7 charges. While holding it, you can use an action and expend 1 charge to speak its command word. For the next minute, you know the direction of the nearest creature hostile to you within 60 feet, but not its distance from you. The wand can sense the presence of hostile creatures that are ethereal, invisible, disguised, or hidden, as well as those in plain sight. The effect ends if you stop holding the wand.", Price = 800.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/466/315/315/636284781267634509.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 22, Name = "Want of Polymorph", Description = "This wand has 7 charges. While holding it, you can use an action to expend 1 of its charges to cast the polymorph spell (save DC 15) from it.", Price = 600.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/480/315/315/636284783799670435.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 23, Name = "Wand of Smiles", Description = "The Wand of Smiles is a magic item that can target a humanoid and force them to smile for 1 minute. The Mighty Nein found the wand in the Manticore's lair.", Price = 100.00m, ImgUrl = "https://static.wikia.nocookie.net/criticalrole/images/d/de/Wand_of_Smiles_by_Anna_Molla.jpg/revision/latest?cb=20190304151635", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 24, Name = "Apparatus of the Crab", Description = "This item first appears to be a Large sealed iron barrel weighing 500 pounds. The barrel has a hidden catch, which can be found with a successful DC 20 Intelligence (Investigation) check. Releasing the catch unlocks a hatch at one end of the barrel, allowing two Medium or smaller creatures to crawl inside. Ten levers are set in a row at the far end, each in a neutral position, able to move either up or down. When certain levers are used, the apparatus transforms to resemble a giant lobster. ", Price = 60000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/124/315/315/636284709585652016.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 25, Name = "Bag of Holding", Description = "This bag has an interior space considerably larger than its outside dimensions, roughly 2 feet in diameter at the mouth and 4 feet deep. The bag can hold up to 500 pounds, not exceeding a volume of 64 cubic feet. The bag weighs 15 pounds, regardless of its contents. Retrieving an item from the bag requires an action.", Price = 10000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/120/315/315/636284708068284913.jpeg", Quantity = 100 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 26, Name = "Rode of Eyes", Description = "This robe is adorned with eyelike patterns. While you wear the robe, you gain the following benefits: The robe lets you see in all directions, and you have advantage on Wisdom (Perception) checks that rely on sight. You have darkvision out to a range of 120 feet. You can see invisible creatures and objects, as well as see into the Ethereal Plane, out to a range of 120 feet.", Price = 1000.00m, ImgUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/378/315/315/636284763771366253.jpeg", Quantity = 100 });

            // This calls the base method, and Identity needs it
            base.OnModelCreating(modelBuilder);
            SeedRole(modelBuilder, "Admin", "read", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "read", "create", "update");
            SeedRole(modelBuilder, "Guest", "read");



            modelBuilder.Entity<CategoryProduct>().HasKey(
                categoryProduct => new { categoryProduct.CategoryId, categoryProduct.ProductId }
            );
             modelBuilder.Entity<CartProduct>().HasKey(
                cartProduct => new { cartProduct.ProductId, cartProduct.CartId }
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
