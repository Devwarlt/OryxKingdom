#region

using System;
using System.Collections.Generic;
using db.data;

#endregion

namespace wServer.realm.entities.player
{
    public class Prices
    {
        public List<int> SellSlots = new List<int>();
        public Dictionary<short, int> prices = new Dictionary<short, int>();
        public int Itemprice = -1;
        public short item = -1;
        public string ItemName = "";
        public List<TierList> PricesList = new List<TierList>();
        public Prices()
        {
            //Note: These are SELL prices, not BUY prices.

            AddPrice(1, "Ravenheart Sword", "Studded Leather Armor", "Mithril Armor", "Fire Dagger", "Golden Bow", "Robe of the Illusionist", "Staff of Horror");
            AddPrice(2, "Dragonsoul Sword", "Drake Hide Armor", "Dragonscale Armor", "Ragetalon Dagger", "Verdant Bow", "Robe of the Master", "Staff of Necrotic Arcana");
            AddPrice(3, "Archon Sword", "Golden Shield", "Roc Leather Armor", "Desolation Armor", "Emeraldshard Dagger", "Bow of Fey Magic", "Scorching Blast Spell", "Tome of Renewing", "Seal of the Divine", "Cloak of the Red Agent", "Robe of the Shadow Magus", "Magesteel Quiver", "Steel Helm", "Staff of Diabolic Secrets", "Felwasp Toxin", "Essence Tap Skull", "Demonhunter Trap", "Timelock Orb", "Prism of Figments", "Cloudflash Scepter");
            AddPrice(4, "Hippogriff Hide Armor", "Vengeance Armor");
            AddPrice(5, "Skysplitter Sword", "Mithril Shield", "Griffon Hide Armor", "Abyssal Armor", "Agateclaw Dagger", "Bow of Innocent Blood", "Destruction Sphere Spell", "Tome of Divine Favor", "Seal of the Holy Warrior", "Cloak of Endless Twilight", "Robe of the Moon Wizard", "Golden Quiver", "Golden Helm", "Staff of Astral Knowledge", "Nightwing Venom", "Lifedrinker Skull", "Dragonstalker Trap", "Banishment Orb", "Prism of Phantoms", "Scepter of Skybolts");
            AddPrice(10, "Sword of Acclaim", "Poison Fang Dagger", "Fire Water", "Cream Spirit", "Chardonnay", "Melon Liqueur", "Cabernet", "Vintage Port", "Sauvignon Blanc", "Muscat", "Rice Wine", "Shiraz", "Snake Oil", "Healing Ichor", "Tincture of Dexterity", "Tincture of Life", "Tincture of Mana", "Tincture of Defense", "Snake Eye Ring", "Spider's Eye Ring", "Ring of Greater Attack", "Ring of Greater Defense", "Ring of Greater Speed", "Ring of Greater Vitality", "Ring of Greater Wisdom", "Ring of Greater Dexterity", "Ring of Greater Health", "Ring of Greater Magic", "Robe of the Elder Warlock");
            AddPrice(15, "Wand of Evocation");
            AddPrice(20, "Wand of Retribution", "Potion of Speed", "Potion of Dexterity", "Greater Health Potion", "Greater Magic Potion", "Ring of Superior Attack", "Ring of Superior Defense", "Ring of Superior Speed", "Ring of Superior Vitality", "Ring of Superior Wisdom", "Ring of Superior Dexterity", "Ring of Superior Health", "Ring of Superior Magic", "Pirate Rum", "Magic Mushroom");
            AddPrice(25, "Snake Skin Shield", "Snake Skin Armor", "Purple Drake Egg", "Blue Drake Egg", "Orange Drake Egg", "Green Drake Egg", "Yellow Drake Egg");
            AddPrice(30, "Hydra Skin Armor", "Acropolis Armor", "Dagger of Foul Malevolence", "Bow of Covert Havens", "Potion of Attack", "Potion of Wisdom", "Effusion of Dexterity", "Effusion of Life", "Effusion of Mana", "Effusion of Defense", "Magic Nova Spell", "Tome of Holy Guidance", "Seal of the Blessed Champion", "Cloak of Ghostly Concealment", "Robe of the Grand Sorcerer", "Quiver of Elvish Mastery", "Helm of the Great General", "Staff of the Cosmic Whole", "Baneserpent Poison", "Bloodsucker Skull", "Giantcatcher Trap", "Planefetter Orb", "Prism of Apparitions", "Scepter of Storms", "Coral Juice", "Pollen Powder");
            AddPrice(35, "Potion of Vitality");
            AddPrice(40, "Sword of Splendor", "Wyrmhide Armor", "Dominion Armor", "Dagger of Sinister Deeds", "Bow of Mystical Energy", "Potion of Defense", "Robe of the Star Mother", "Staff of the Vital Unity");
            AddPrice(50, "Sword of Majesty", "Colossus Shield", "Leviathan Armor", "Annihilation Armor", "Dagger of Dire Hatred", "Bow of Deep Enchantment", "Ring of Paramount Attack", "Ring of Paramount Defense", "Ring of Paramount Speed", "Ring of Paramount Vitality", "Ring of Paramount Wisdom", "Ring of Paramount Dexterity", "Ring of Paramount Health", "Ring of Paramount Magic", "Elemental Detonation Spell", "Robe of the Ancient Intellect", "Staff of the Fundamental Core", "White Drake Egg", "Robe of the Tlatoani", "Cracked Crystal Skull", "Crystal Bone Ring");
            AddPrice(65, "Potion of Life", "Potion of Mana");
            AddPrice(75, "Staff of the Crystal Serpent");
            AddPrice(100, "Ring of Exalted Attack", "Ring of Exalted Defense", "Ring of Exalted Speed", "Ring of Exalted Vitality", "Ring of Exalted Wisdom", "Ring of Exalted Dexterity", "Ring of Exalted Health", "Ring of Exalted Magic", "Coral Ring");
            AddPrice(200, "Staff of Extreme Prejudice");
            AddPrice(300, "Coral Silk Armor", "Coral Venom Trap", "Bone Dagger", "Spectral Cloth Armor");
            AddPrice(400, "Skull of Endless Torment", "Captain's Ring", "Ghostly Prism");
            AddPrice(500, "Crystal Wand", "Wand of the Bulwark", "Ring of the Sphinx", "Ring of the Nile", "Ring of the Pyramid", "Seal of Blasphemous Prayer", "Thousand Shot", "St. Abraham's Wand", "Chasuble of Holy Light", "Ring of Divine Faith", "Experimental Ring");
            AddPrice(600, "Crystal Sword", "Demon Blade", "Ancient Stone Sword", "Chicken Leg of Doom", "Anatis Staff", "Robe of the Mad Scientist", "Conducting Wand");
            AddPrice(650, "Cloak of the Planewalker");
            AddPrice(700, "Penetrating Blast Spell", "Tome of Purification", "Spirit Dagger", "Scepter of Fulmination");
            AddPrice(900, "Dirk of Cronus", "Doom Bow", "Coral Bow", "Minor Health Potion", "Minor Magic Potion", "America Ring");
            AddPrice(1000, "Quiver of Thunder", "Helm of the Juggernaut", "Orb of Conflict", "Tome of Holy Protection");
            AddPrice(1200, "Shield of Ogmur", "Prism of Dancing Swords");
            AddPrice(1500, "Ammy");
            AddPrice(5000, "Transformation Potion", "Platinum Sword");
            AddPrice(10000, "Bronze Medal", "Sword of Dark Enchantment");
            AddPrice(20000, "Silver Medal");
            AddPrice(30000, "Gold Medal");
            AddPrice(99999, "Sword of OUTDATED MERCY");
        }
        public bool HasPrices(Player p)
        {
            var ret = false;
            var removeSlots = new List<int>();
            foreach (var i in SellSlots)
                if (p.Inventory[i] != null && prices.ContainsKey(p.Inventory[i].ObjectType))
                    ret = true;
                else
                    removeSlots.Add(i);
            foreach (var i in removeSlots)
                SellSlots.Remove(i);
            return ret;
        }

        public int ItemPrice(string name)
        {
            int price = 0;
            short itemid = XmlDatas.IdToType[name];
            foreach (KeyValuePair<short, int> i in prices)
            {
                if (i.Key == itemid)
                {
                    ItemName = name;
                    price = i.Value;
                    item = itemid;
                    Itemprice = price;
                    break;
                }
            }
            return price;
        }

        public int GetPrices(Player p)
        {
            var price = 0;
            foreach (var i in SellSlots)
                if (p.Inventory[i] != null && prices.ContainsKey(p.Inventory[i].ObjectType))
                    price += prices[p.Inventory[i].ObjectType];
            return price;
        }

        public void AddPrice(int price, params string[] items)
        {

            /*
       TierList List = new TierList();
       List.Price = price;
   //    foreach (var i in items)
   //      List.itemnames.Add(i);
       switch(price)
       {  
         case 1:
           List.Description = "T8 Weapons"; break;
         case 2:
           List.Description = ""; break;
       }
              */

            foreach (var i in items)
                try
                {
                    prices.Add(XmlDatas.IdToType[i], price);
                }
                catch
                {
                    Console.Out.WriteLine("Can't find item: " + i);
                }
        }
    }
    public class TierList
    {
        public List<string> itemnames;
        public int Price;
        public string Description = "";
        /*  public void TierList()
          {
          }
   
           */
    }
}