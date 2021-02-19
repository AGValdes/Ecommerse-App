using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce_App.Migrations
{
    public partial class seedingcategoriesandproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Magical items used for combat", "Weapons" },
                    { 2, "Magical items used for armor", "Armor" },
                    { 3, "Magical concoctions", "Potions" },
                    { 4, "Magical Jewelry", "Rings" },
                    { 5, "Rods imbued with magical properties", "Rods" },
                    { 6, "Parchment scrolls with magical encryptions", "Scrolls" },
                    { 7, "Staves imbued with magical properties", "Staves" },
                    { 8, "Magical implements with pre-set spells", "Wands" },
                    { 9, "Miscellaneous Magical Item", "Wonderous Items" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "Description", "ImgUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 15, null, "This rod has a flanged head, and it functions as a magic mace that grants a +3 bonus to attack and damage rolls made with it. The rod has properties associated with six different buttons that are set in a row along the haft. ", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/388/315/315/636284765584014212.jpeg", "Rod of Lordly Might", 1000.00m },
                    { 16, null, "Each scroll of protection works against a specific type of creature. Using an action to read the scroll encloses you in a invisible barrier that extends from you to form a 5 - foot - radius, 10 - foot - high cylinder.For 5 minutes, this barrier prevents creatures of the specified type from entering or affecting anything within the cylinder.", "", "Scroll of Protection", 1000.00m },
                    { 17, null, "By using an action to read the scroll, you cause a comet to fall from the sky and crash to the ground at a point you can see up to 1 mile away from you. You must be outdoors when you use the scroll, or nothing happens and the scroll is wasted.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg", "Scroll of the Comet", 10000.00m },
                    { 18, null, "While holding this staff, you can use an action to expend 1 of its 10 charges to cast charm person, command, or comprehend languages from it using your spell save DC. The staff can also be used as a magic quarterstaff.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/408/315/315/636284768308428008.jpeg", "Staff of Charming", 900.00m },
                    { 19, null, "This staff has 10 charges. While holding it, you can use an action to expend 1 or more of its charges to cast one of the following spells from it, using your spell save DC and spellcasting ability modifier: cure wounds (1 charge per spell level, up to 4th), lesser restoration (2 charges), or mass cure wounds (5 charges).", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/414/315/315/636284768980904526.jpeg", "Staff of Healing", 1200.00m },
                    { 23, null, "The Wand of Smiles is a magic item that can target a humanoid and force them to smile for 1 minute. The Mighty Nein found the wand in the Manticore's lair.", "https://static.wikia.nocookie.net/criticalrole/images/d/de/Wand_of_Smiles_by_Anna_Molla.jpg/revision/latest?cb=20190304151635", "Wand of Smiles", 100.00m },
                    { 21, null, "This wand has 7 charges. While holding it, you can use an action and expend 1 charge to speak its command word. For the next minute, you know the direction of the nearest creature hostile to you within 60 feet, but not its distance from you. The wand can sense the presence of hostile creatures that are ethereal, invisible, disguised, or hidden, as well as those in plain sight. The effect ends if you stop holding the wand.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/466/315/315/636284781267634509.jpeg", "Wand of Enemy Detection", 800.00m },
                    { 22, null, "This wand has 7 charges. While holding it, you can use an action to expend 1 of its charges to cast the polymorph spell (save DC 15) from it.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/480/315/315/636284783799670435.jpeg", "Want of Polymorph", 600.00m },
                    { 14, null, "While holding this rod, you can use your reaction to absorb a spell that is targeting only you and not with an area of effect. The absorbed spell's effect is canceled, and the spell's energy -- not the spell itself -- is stored in the rod. ", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/386/315/315/636284765204637619.jpeg", "Rod of Absorption", 400.00m },
                    { 24, null, "This item first appears to be a Large sealed iron barrel weighing 500 pounds. The barrel has a hidden catch, which can be found with a successful DC 20 Intelligence (Investigation) check. Releasing the catch unlocks a hatch at one end of the barrel, allowing two Medium or smaller creatures to crawl inside. Ten levers are set in a row at the far end, each in a neutral position, able to move either up or down. When certain levers are used, the apparatus transforms to resemble a giant lobster. ", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/124/315/315/636284709585652016.jpeg", "Apparatus of the Crab", 60000.00m },
                    { 20, null, "This staff has 10 charges and regains 1d6 + 4 expended charges daily at dawn. If you expend the last charge, roll a d20. On a 1, a swarm of insects consumes and destroys the staff, then disperses.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/418/315/315/636284769826755468.jpeg", "Staff of Swarming Insects", 2000.00m },
                    { 13, null, "This flat iron rod has a button on one end. You can use an action to press the button, which causes the rod to become magically fixed in place. Until you or another creature uses an action to push the button again, the rod doesn't move, even if it is defying gravity. The rod can hold up to 8,000 pounds of weight. More weight causes the rod to deactivate and fall. A creature can use an action to make a DC 30 Strength check, moving the fixed rod up to 10 feet on a success.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/261/315/315/636284741670235041.jpeg", "Immovable Rod", 500.00m },
                    { 9, null, "You regain hit points when you drink this potion. The number of hit points depends on the potion’s rarity, as shown in the Potions of Healing table. Whatever its potency, the potion’s red liquid glimmers when agitated.", "https://media-waterdeep.cursecdn.com/attachments/2/667/potion.jpg", "Potion of Healing", 150.00m },
                    { 11, null, "This ring has 3 charges, and it regains 1d3 expended charges daily at dawn. While wearing the ring, you can use an action to expend 1 of its charges to cast one of the following spells: Animal friendship (save DC 13), Fear (save DC 13), targeting only beasts that have an https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/372/315/315/636284762810625788.jpeg of 3 or lower, Speak with animals", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/341/315/315/636284758989654087.jpeg", "Ring of Animal Influence", 1200.00m },
                    { 10, null, "While wearing this ring, you can stand on and move across any liquid surface as if it were solid ground.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/374/315/315/636284763046262817.jpeg", "Ring of Water Walking", 1000.00m },
                    { 25, null, "This bag has an interior space considerably larger than its outside dimensions, roughly 2 feet in diameter at the mouth and 4 feet deep. The bag can hold up to 500 pounds, not exceeding a volume of 64 cubic feet. The bag weighs 15 pounds, regardless of its contents. Retrieving an item from the bag requires an action.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/120/315/315/636284708068284913.jpeg", "Bag of Holding", 10000.00m },
                    { 8, null, "When you drink this potion, you gain the effect of the detect thoughts spell (save DC 13). The potion's dense, purple liquid has an ovoid cloud of pink floating in it.", "https://media-waterdeep.cursecdn.com/attachments/2/667/potion.jpg", "Potion of Mind Reading", 425.00m },
                    { 7, null, "Beads of this cloudy gray oil form on the outside of its container and quickly evaporate. The oil can cover a Medium or smaller creature, along with the equipment it's wearing and carrying (one additional vial is required for each size category above Medium). Applying the oil takes 10 minutes. The affected creature then gains the effect of the etherealness spell for 1 hour.", "https://media-waterdeep.cursecdn.com/attachments/2/667/potion.jpg", "Oil of Etherealness", 400.00m },
                    { 6, null, "While wearing these bracers, you have proficiency with the longbow and shortbow, and you gain a +2 bonus to damage rolls on ranged attacks made with such weapons.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/144/315/315/636284715992548759.jpeg", "Bracers of Archery", 100.00m },
                    { 5, null, "You gain a +1 bonus to AC while you wear this armor. You are considered proficient with this armor even if you lack proficiency with medium armor. Made of interlocking metal rings, a chain shirt is worn between layers of clothing or leather. This armor offers modest protection to the wearer's upper body and allows the sound of the rings rubbing against one another to be muffled by outer layers.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/208/315/315/636284731937952010.jpeg", "Elven Chain", 300.00m },
                    { 4, null, "Dragon scale mail is made of the scales of one kind of dragon. Sometimes dragons collect their cast-off scales and gift them to humanoids. Other times, hunters carefully skin and preserve the hide of a dead dragon. In either case, dragon scale mail is highly valued. While wearing this armor, you gain a + 1 bonus to AC, you have advantage on saving throws against the Frightful Presence and breath weapons of dragons, and you have resistance to one damage type that is determined by the kind of a dragon that provided the scales", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg", "Dragon Scale Mail", 2000.00m },
                    { 3, null, "When you attack a creature that has at least one head with this weapon and roll a 20 on the attack roll, you cut off one of the creature's heads.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/462/315/315/636284780691337497.jpeg", "Vorpal Sword", 2000.00m },
                    { 2, null, "When you hit a giant with it, the giant takes an extra 2d6 damage of the weapon's type and must succeed on a DC 15 Strength saving throw or fall prone.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg", "Giant Slayer", 500.00m },
                    { 1, null, "This appears to be a long sword hilt, but it emenates a radiant energy", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/436/1000/1000/636284772783859015.jpeg", "Sun Blade", 100.00m },
                    { 12, null, "While wearing this ring, you can use an action to expend 1 of its 3 charges to cast the wish spell from it. The ring becomes nonmagical when you use the last charge.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/231/315/315/636284736285144879.jpeg", "Ring of Three Wishes", 50000.00m },
                    { 26, null, "This robe is adorned with eyelike patterns. While you wear the robe, you gain the following benefits: The robe lets you see in all directions, and you have advantage on Wisdom (Perception) checks that rely on sight. You have darkvision out to a range of 120 feet. You can see invisible creatures and objects, as well as see into the Ethereal Plane, out to a range of 120 feet.", "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/378/315/315/636284763771366253.jpeg", "Rode of Eyes", 1000.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 26);
        }
    }
}
