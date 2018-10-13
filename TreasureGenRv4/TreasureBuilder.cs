using System;
using System.Data;
using TreasureGenRv4.Data;

namespace TreasureGenRv4
{
    internal enum ArmorWeightEnum
    {
        Light,
        Medium,
        Heavy,
        Any
    }
    internal enum ArmorTypeEnum
    {
        Armor,
        Shield
    }
    internal enum WeaponWeightEnum
    {
        Unarmed,
        Light,
        OneHanded,
        TwoHanded,
        AnyMelee,
        Ranged
    }
    internal enum WeaponTypeEnum
    {
        Slashing,
        Piercing,
        Bludgeoning,

        BowNonComposite,
        BowComposite,
        Crossbow,
        Firearm,
        Thrown,

        AnyMelee,
        Bow,
        BowCrossbow,
        NotFirearm,
        AnyRanged
    }    

    internal class CoinBuilder
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int M { get; set; }
        public int ValueType { get; set; }

        private static readonly Lazy<CoinBuilder> lazy = new Lazy<CoinBuilder>(() => new CoinBuilder());
        public static CoinBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            return new Treasure
            {
                Name = "Sack of Coins",
                TreasureType = TreasureTypeEnum.Coin,
                TreasureValue = $"{Helpers.Roll(X, Y, M)} {Enum.GetName(typeof(ValueTypeEnum), ValueType)}",
            };
        }
    }
    internal class GemBuilder
    {
        public int Grade { get; set; }

        private static readonly Lazy<GemBuilder> lazy = new Lazy<GemBuilder>(() => new GemBuilder());
        public static GemBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class ArtBuilder
    {
        public int Grade { get; set; }

        private static readonly Lazy<ArtBuilder> lazy = new Lazy<ArtBuilder>(() => new ArtBuilder());
        public static ArtBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class ScrollBuilder
    {
        public RarityTypeEnum RarityType { get; set; }
        private readonly DataSet _data = TreasureData.Instance.ScrollData;

        private static readonly Lazy<ScrollBuilder> lazy = new Lazy<ScrollBuilder>(() => new ScrollBuilder());
        public static ScrollBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            DataRow levelRow = _data.GetRow("ScrollLevel", Enum.GetName(typeof(RarityTypeEnum), RarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), scrollLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string scrollType = _data.GetRow("ScrollType", "d%").Field<string>("type");
            DataRow spellRow = _data.GetRow(scrollLevel + scrollType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Scroll,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    internal class PotionBuilder
    {
        public RarityTypeEnum RarityType { get; set; }
        private readonly DataSet _data = TreasureData.Instance.PotionData;

        private static readonly Lazy<PotionBuilder> lazy = new Lazy<PotionBuilder>(() => new PotionBuilder());
        public static PotionBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            DataRow levelRow = _data.GetRow("PotionLevel", Enum.GetName(typeof(RarityTypeEnum), RarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), potionLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string potionType = _data.GetRow("PotionType", "d%").Field<string>("type");
            DataRow spellRow = _data.GetRow(potionLevel + potionType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Potion,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    internal class WandBuilder
    {
        private RarityTypeEnum RarityType { get; set; }
        private readonly DataSet _data = TreasureData.Instance.WandData;

        private static readonly Lazy<WandBuilder> lazy = new Lazy<WandBuilder>(() => new WandBuilder());
        public static WandBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            DataRow levelRow = _data.GetRow("WandLevel", Enum.GetName(typeof(RarityTypeEnum), RarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), wandLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string wandType = _data.GetRow("WandType", "d%").Field<string>("type");
            DataRow spellRow = _data.GetRow(wandLevel + wandType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Potion,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    public class WeaponBuilder
    {
        public RarityTypeEnum RarityType { get; set; }
        private readonly DataSet _data = TreasureData.Instance.WeaponData;

        private static readonly Lazy<WeaponBuilder> lazy = new Lazy<WeaponBuilder>(() => new WeaponBuilder());
        public static WeaponBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }

        private Enchantment GetEnchantment()
        {
            throw new NotImplementedException();
        }
        private EnchantableTreasure GetUnique()
        {
            DataRow row = _data.GetRow(Enum.GetName(typeof(RarityTypeEnum), RarityType) + "Specific", "d%");

            throw new NotImplementedException(); // need to add Enchantment(s) and Enhancement to Special Armor/Weapon Data
        }
    }
    internal class ArmorBuilder
    {
        public RarityTypeEnum RarityType { get; set; }
        private readonly DataSet _data = TreasureData.Instance.ArmorData;

        private static readonly Lazy<ArmorBuilder> lazy = new Lazy<ArmorBuilder>(() => new ArmorBuilder());
        public static ArmorBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }

        private Enchantment GetEnchantment()
        {
            throw new NotImplementedException();
        }
        private EnchantableTreasure GetUnique()
        {
            throw new NotImplementedException();
        }
    }
    internal class RingBuilder
    {
        public RarityTypeEnum RarityType { get; set; }

        private static readonly Lazy<RingBuilder> lazy = new Lazy<RingBuilder>(() => new RingBuilder());
        public static RingBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class WondrousBuilder
    {
        public RarityTypeEnum RarityType { get; set; }

        private static readonly Lazy<WondrousBuilder> lazy = new Lazy<WondrousBuilder>(() => new WondrousBuilder());
        public static WondrousBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class RodBuilder
    {
        public RarityTypeEnum RarityType { get; set; }

        private static readonly Lazy<RodBuilder> lazy = new Lazy<RodBuilder>(() => new RodBuilder());
        public static RodBuilder Instance() { return lazy.Value; }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
}