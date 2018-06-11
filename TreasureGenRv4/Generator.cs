using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using static TreasureGenRv4.CoinTypeEnum;
using static TreasureGenRv4.ItemPowerEnum;
using static TreasureGenRv4.MagicTypeEnum;
using static TreasureGenRv4.ArmorTypeEnum;
using static TreasureGenRv4.WeaponTypeEnum;

namespace TreasureGenRv4
{
    public class Generator
    {
        public enum BudgetTypeEnum
        {
            None,
            Incidental,
            Normal,
            Double,
            Triple,
            NPC
        }
        public enum ProgressionEnum
        {
            Slow,
            Medium,
            Fast
        }

        private readonly Random _random = new Random();

        private Dictionary<decimal, int> _crValue;
        private Dictionary<decimal, int[]> _valuePerEncounter; // overall CR, [slow, medium, fast]
        private Dictionary<decimal, int> _npcValue; // basic level, value

        private List<Tuple<char, int, GeneratorSet>> _treasureTable; // type, value, generation set

        private List<Tuple<Range[], int, int>> _potionSpellLevel; // [LMi, GMi, LMe, GMe, LMa, GMa], CL, SL
        private List<Tuple<Range, bool>> _potionType; // d%, common?
        private List<Tuple<Range, Potion>> _potions; // d%, potion

        private List<Tuple<Range[], int, int>> _scrollSpellLevel; // [LMi, GMi, LMe, GMe, LMa, GMa], CL, SL
        private List<Tuple<Range, bool>> _scrollType; // d%, common?
        private List<Tuple<Range, Scroll>> _scrolls; // d%, scroll

        private List<Tuple<Range[], int, int>> _wandSpellLevel; // [LMi, GMi, LMe, GMe, LMa, GMa], CL, SL
        private List<Tuple<Range, bool>> _wandType; // d%, common?
        private List<Tuple<Range, Wand>> _wands; // d%, wand

        private List<Tuple<Range, Gem>> _gems; // d%, gem
        private List<Tuple<Range, Art>> _art; // d%, art

        private List<Tuple<Range, Type>> _wondrousType; // d%, type
        private List<Tuple<Range, Type, Wondrous>> _wondrous; // d%, type, wondrous

        private List<Tuple<Range, Armor>> _armor; // d%, armor
        private List<Tuple<Range, Weapon>> _weapons; // d%, weapon
        private List<Tuple<Range, Ring>> _rings; // d%, ring

        private List<Tuple<Range, ItemPowerEnum, List<int>>> _enchantmentModifier; // d%, itemPower, modifiers (- is a straight modifier, 0 is specific, + is enchantment)
        private List<Tuple<Range, Enchantment>> _enchantments;
        private List<Tuple<Range, Armor>> _specificArmor;
        private List<Tuple<Range, Weapon>> _specificWeapon;

        public Tuple<decimal,int> GetCr(List<KeyValuePair<decimal, int>> crList, BudgetTypeEnum multiplier, ProgressionEnum progression)
        {
            int xp = 0;
            foreach (KeyValuePair<decimal, int> cr in crList) xp += _crValue[cr.Key] * cr.Value;
            decimal overallCr = _crValue.OrderByDescending(x => x.Key).FirstOrDefault(x => x.Value < xp).Key;

            var value = multiplier == BudgetTypeEnum.NPC ? _npcValue[overallCr] : _valuePerEncounter[overallCr][(int) progression];
            switch (multiplier)
            {
                case BudgetTypeEnum.None:
                    value *= 0;
                    break;
                case BudgetTypeEnum.Incidental:
                    value = (int) (value * 0.5);
                    break;
                case BudgetTypeEnum.Double:
                    value *= 2;
                    break;
                case BudgetTypeEnum.Triple:
                    value *= 3;
                    break;
            }

            return new Tuple<decimal, int>(overallCr, value);
        }
        public List<Item> Generate(char type, int gpValue)
        {
            List<Item> list = new List<Item>();
            GeneratorSet set = _treasureTable.OrderByDescending(x => x.Item2).FirstOrDefault(x => x.Item1 == type && x.Item2 > gpValue)?.Item3;
            if (set == null) return list;

            foreach (CoinGenerator g in set.CoinGenerators) list.Add(GenerateCoin(g.X, g.Y, g.CoinType, g.Multiplier));
            foreach (GemGenerator g in set.GemGenerators) list.Add(GenerateGem(g.Grade));
            foreach (ArtGenerator g in set.ArtGenerators) list.Add(GenerateArt(g.Grade));
            foreach (ScrollGenerator g in set.ScrollGenerators) list.Add(GenerateScroll(g.ItemPower, g.MagicType));
            foreach (PotionGenerator g in set.PotionGenerators) list.Add(GeneratePotion(g.ItemPower, g.MagicType));
            foreach (WandGenerator g in set.WandGenerators) list.Add(GenerateWand(g.ItemPower, g.MagicType));
            foreach (ArmorGenerator g in set.ArmorGenerators) list.Add(GenerateArmor(g.ItemPower, g.masterwork, g.ArmorType));
            foreach (WeaponGenerator g in set.WeaponGenerators) list.Add(GenerateWeapon(g.ItemPower, g.masterwork, g.WeaponType));
            foreach (WondrousGenerator g in set.WondrousGenerators) list.Add(GenerateWondrous(g.ItemPower));
            foreach (RingGenerator g in set.RingGenerators) list.Add(GenerateRing(g.ItemPower));

            return list;
        }

        private int Roll(string roll)
        {
            int x = 1, m = 1;
            if (roll.Contains('d'))
            {
                string[] split = roll.Split('d');
                x = int.Parse(split[0]);
                roll = split[1];
            }

            if (roll.Contains('x'))
            {
                string[] split = roll.Split('x');
                m = int.Parse(split[1]);
                roll = split[0];
            }
            int y = int.Parse(roll);
            return Roll(x, y, m);
        }
        private int Roll(int x = 1, int y = 100, int m = 1)
        {
            int result = 0;
            for (int i = 0; i < x; i++) result += _random.Next(1, y + 1);
            return result * m;
        }

        private Coin GenerateCoin(int x, int y, CoinTypeEnum coinType, int multiplier)
        {
            return new Coin
            {
                Name = "Coins",
                Value = Roll(x, y, multiplier),
                CoinType = coinType
            };
        }
        private Gem GenerateGem(int grade)
        {
            Gem gem = _gems.First(x => x.Item1.InRange(Roll()) && x.Item2.Grade == grade).Item2;
            return new Gem
            {
                Name = gem.Name,
                Value = gem.BaseVal + Roll(gem.AddedVal),
                BaseVal = gem.BaseVal,
                AddedVal = gem.AddedVal,
                Grade = gem.Grade,
                CoinType = GP
            };
        }
        private Art GenerateArt(int grade)
        {
            Art art = _art.First(x => x.Item1.InRange(Roll()) && x.Item2.Grade == grade).Item2;
            return new Art
            {
                Name = art.Name,
                Value = art.Value,
                Grade = art.Grade,
                CoinType = GP
            };
        }
        private Scroll GenerateScroll(ItemPowerEnum itemPower, MagicTypeEnum magicType)
        {
            int level = _scrollSpellLevel.First(x => x.Item1[(int) itemPower].InRange(Roll())).Item3; // roll for spell level
            bool common = _scrollType.First(x => x.Item1.InRange(Roll())).Item2; // common or uncommon
            Scroll scroll = _scrolls.First(x =>
                x.Item1.InRange(Roll()) && // roll for item
                x.Item2.MagicType == magicType && // arcane or divine
                x.Item2.SpellLevel == level &&
                x.Item2.IsCommon == common).Item2;

            return new Scroll
            {
                Name = scroll.Name,
                Value = scroll.Value,
                ItemPower = scroll.ItemPower,
                MagicType = scroll.MagicType,
                CasterLevel = scroll.CasterLevel,
                SpellLevel = scroll.SpellLevel,
                IsCommon = scroll.IsCommon
            };
        }
        private Potion GeneratePotion(ItemPowerEnum itemPower, MagicTypeEnum magicType)
        {
            int level = _potionSpellLevel.First(x => x.Item1[(int)itemPower].InRange(Roll())).Item3; // roll for spell level
            bool common = _potionType.First(x => x.Item1.InRange(Roll())).Item2; // common or uncommon
            Potion potion = _potions.First(x =>
                x.Item1.InRange(Roll()) && // roll for item
                x.Item2.MagicType == magicType && // arcane or divine
                x.Item2.SpellLevel == level &&
                x.Item2.IsCommon == common).Item2;

            return new Potion
            {
                Name = potion.Name,
                Value = potion.Value,
                ItemPower = potion.ItemPower,
                MagicType = potion.MagicType,
                CasterLevel = potion.CasterLevel,
                SpellLevel = potion.SpellLevel,
                IsCommon = potion.IsCommon
            };
        }
        private Wand GenerateWand(ItemPowerEnum itemPower, MagicTypeEnum magicType)
        {
            int level = _wandSpellLevel.First(x => x.Item1[(int)itemPower].InRange(Roll())).Item3; // roll for spell level
            bool common = _wandType.First(x => x.Item1.InRange(Roll())).Item2; // common or uncommon
            Wand wand = _wands.First(x =>
                x.Item1.InRange(Roll()) && // roll for item
                x.Item2.MagicType == magicType && // arcane or divine
                x.Item2.SpellLevel == level &&
                x.Item2.IsCommon == common).Item2;

            return new Wand
            {
                Name = wand.Name,
                Value = wand.Value,
                ItemPower = wand.ItemPower,
                MagicType = wand.MagicType,
                CasterLevel = wand.CasterLevel,
                SpellLevel = wand.SpellLevel,
                IsCommon = wand.IsCommon
            };
        }
        private Armor GenerateArmor(ItemPowerEnum itemPower, bool masterwork, ArmorTypeEnum armorType)
        {
            Armor armor;
            do armor = _armor.FirstOrDefault(x =>
                x.Item1.InRange(Roll()) &&
                armorType == AnyArmor ||
                x.Item2.ArmorType == armorType)?.Item2;
            while (armor == null);

            List<Enchantment> enchantments = GenerateEnchantment(itemPower, armor.ArmorType);
            if (!enchantments.Any()) return _specificArmor.First(x => x.Item1.InRange(Roll())).Item2;

            return new Armor
            {
                Name = armor.Name,
                Value = armor.Value + (masterwork ? 150 : 0),
                IsMasterwork = masterwork,
                Enchantments = enchantments,
                ArmorType = armor.ArmorType
            };
        }
        private Weapon GenerateWeapon(ItemPowerEnum itemPower, bool masterwork, WeaponTypeEnum weaponType)
        {
            Weapon weapon;
            do weapon = _weapons.FirstOrDefault(x =>
                x.Item1.InRange(Roll()) &&
                weaponType == AnyWeapon ||
                x.Item2.WeaponType == weaponType)?.Item2;
            while (weapon == null);

            List<Enchantment> enchantments = GenerateEnchantment(itemPower, weapon.WeaponType);
            if (!enchantments.Any()) return _specificWeapon.First(x => x.Item1.InRange(Roll())).Item2;

            return new Weapon
            {
                Name = weapon.Name,
                Value = weapon.Value + (masterwork ? 150 : 0),
                IsMasterwork = masterwork,
                Enchantments = enchantments,
                WeaponType = weapon.WeaponType
            };
        }
        private List<Enchantment> GenerateEnchantment(ItemPowerEnum itemPower, ArmorTypeEnum armorType)
        {
            var enhancements = _enchantmentModifier.Where(x => x.Item1.InRange(Roll()) && x.Item2 == itemPower).ToList();
            List<int> enhancement = enhancements[Roll(1, enhancements.Count) - 1].Item3;
            List<Enchantment> enchantments = new List<Enchantment>();

            // generate modifier
            int modifier = enhancement.SingleOrDefault(x => x < 0);
            if (modifier < 0) enchantments.Add(new Enchantment { Modifier = modifier });

            // generate special abilities
            foreach (var ability in enhancement)
            {
                Enchantment enchantment;
                do enchantment = _enchantments.FirstOrDefault(x =>
                    x.Item1.InRange(Roll()) &&
                    x.Item2.Modifier == ability &&
                    x.Item2.ArmorType == armorType || x.Item2.ArmorType == AnyArmor)?.Item2;
                while(enchantment == null);
                enchantments.Add(enchantment);
            }

            return enchantments;
        }
        private List<Enchantment> GenerateEnchantment(ItemPowerEnum itemPower, WeaponTypeEnum weaponType)
        {
            var enhancements = _enchantmentModifier.Where(x => x.Item1.InRange(Roll()) && x.Item2 == itemPower).ToList();
            List<int> enhancement = enhancements[Roll(1, enhancements.Count) - 1].Item3;
            List<Enchantment> enchantments = new List<Enchantment>();

            // generate modifier
            int modifier = enhancement.SingleOrDefault(x => x < 0);
            if (modifier < 0) enchantments.Add(new Enchantment { Modifier = modifier });

            // generate special abilities
            foreach (var ability in enhancement)
            {
                Enchantment enchantment;
                do enchantment = _enchantments.FirstOrDefault(x =>
                    x.Item1.InRange(Roll()) &&
                    x.Item2.Modifier == ability &&
                    x.Item2.WeaponType == weaponType || x.Item2.WeaponType == AnyWeapon)?.Item2;
                while (enchantment == null);
                enchantments.Add(enchantment);
            }

            return enchantments;
        }
        private Wondrous GenerateWondrous(ItemPowerEnum itemPower)
        {
            Type wondrousType = _wondrousType.First(x => x.Item1.InRange(Roll())).Item2;
            Wondrous wondrous = _wondrous.First(x =>
                x.Item1.InRange(Roll()) &&
                x.Item2 == wondrousType).Item3;

            return new Wondrous
            {
                Name = wondrous.Name,
                Value = wondrous.Value,
                CoinType = wondrous.CoinType,
                ItemPower = wondrous.ItemPower
            };
        }
        private Ring GenerateRing(ItemPowerEnum itemPower)
        {
            Ring ring = _rings.First(x => x.Item1.InRange(Roll())).Item2;
            return new Ring
            {
                Name = ring.Name,
                Value = ring.Value,
                CoinType = ring.CoinType,
                ItemPower = ring.ItemPower
            };
        }
    }

    public class Range
    {
        private int First { get; }
        private int Last { get; }
        public Range(int both) : this(both, both) { }
        public Range(int first, int last)
        {
            First = first;
            Last = last;
        }
        public bool InRange(int value) => value >= First && value <= Last;
    }

    public class GeneratorSet
    {
        public List<CoinGenerator> CoinGenerators { get; }
        public List<GemGenerator> GemGenerators { get; }
        public List<ArtGenerator> ArtGenerators { get; }
        public List<ScrollGenerator> ScrollGenerators { get; }
        public List<PotionGenerator> PotionGenerators { get; }
        public List<WandGenerator> WandGenerators { get; }
        public List<ArmorGenerator> ArmorGenerators { get; }
        public List<WeaponGenerator> WeaponGenerators { get; }
        public List<WondrousGenerator> WondrousGenerators { get; }
        public List<RingGenerator> RingGenerators { get; }

        public GeneratorSet()
        {
            CoinGenerators = new List<CoinGenerator>();
            GemGenerators = new List<GemGenerator>();
            ArtGenerators = new List<ArtGenerator>();
            ScrollGenerators = new List<ScrollGenerator>();
            PotionGenerators = new List<PotionGenerator>();
            WandGenerators = new List<WandGenerator>();
            ArmorGenerators = new List<ArmorGenerator>();
            WeaponGenerators = new List<WeaponGenerator>();
            WondrousGenerators = new List<WondrousGenerator>();
            RingGenerators = new List<RingGenerator>();
        }
    }
    public class CoinGenerator
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CoinTypeEnum CoinType { get; set; }
        public int Multiplier { get; set; }
    }
    public class GemGenerator
    {
        public int Grade { get; set; }
    }
    public class ArtGenerator
    {
        public int Grade { get; set; }
    }
    public class ScrollGenerator
    {
        public ItemPowerEnum ItemPower { get; set; }
        public MagicTypeEnum MagicType { get; set; }
    }
    public class PotionGenerator
    {
        public ItemPowerEnum ItemPower { get; set; }
        public MagicTypeEnum MagicType { get; set; }
    }
    public class WandGenerator
    {
        public ItemPowerEnum ItemPower { get; set; }
        public MagicTypeEnum MagicType { get; set; }
    }
    public class ArmorGenerator
    {
        public ItemPowerEnum ItemPower { get; set; }
        public bool masterwork { get; set; }
        public ArmorTypeEnum ArmorType { get; set; }
    }
    public class WeaponGenerator
    {
        public ItemPowerEnum ItemPower { get; set; }
        public bool masterwork { get; set; }
        public WeaponTypeEnum WeaponType { get; set; }
    }
    public class WondrousGenerator
    {
        public ItemPowerEnum ItemPower { get; set; }
    }
    public class RingGenerator
    {
        public ItemPowerEnum ItemPower { get; set; }
    }
}