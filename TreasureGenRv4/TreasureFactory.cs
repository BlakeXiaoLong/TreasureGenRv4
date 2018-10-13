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
    internal enum RarityTypeEnum
    {
        Masterwork,
        LesserMinor,
        GreaterMinor,
        LesserMedium,
        GreaterMedium,
        LesserMajor,
        GreaterMajor
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

    internal interface ITreasureBuilder
    {
        Treasure GetResult();
    }
    internal class CoinBuilder : ITreasureBuilder
    {
        private readonly int _x, _y, _m;
        private readonly ValueTypeEnum _valueType;

        public CoinBuilder(int x, int y, ValueTypeEnum valueType) : this(x, y, 1, valueType) { }
        public CoinBuilder(int x, int y, int m, ValueTypeEnum valueType)
        {
            _x = x;
            _y = y;
            _m = m;
            _valueType = valueType;
        }

        public Treasure GetResult()
        {
            return new Treasure
            {
                Name = "Sack of Coins",
                TreasureType = TreasureTypeEnum.Coin,
                TreasureValue = $"{Helpers.Roll(_x, _y, _m)} {Enum.GetName(typeof(ValueTypeEnum),_valueType)}",
            };
        }
    }
    internal class GemBuilder : ITreasureBuilder
    {
        private readonly int _grade;

        public GemBuilder(int grade)
        {
            _grade = grade;
        }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class ArtBuilder : ITreasureBuilder
    {
        private readonly int _grade;

        public ArtBuilder(int grade)
        {
            _grade = grade;
        }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class ScrollBuilder : ITreasureBuilder
    {
        public RarityTypeEnum RarityType { get; set; }
        private readonly DataSet _data = TreasureData.Instance.ScrollData;

        public Treasure GetResult()
        {
            DataRow levelRow = Helpers.GetRow(_data, "ScrollLevel", Enum.GetName(typeof(RarityTypeEnum), RarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), scrollLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string scrollType = Helpers.GetRow(_data, "ScrollType", "d%").Field<string>("type");
            DataRow spellRow = Helpers.GetRow(_data, scrollLevel + scrollType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Scroll,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    internal class PotionBuilder : ITreasureBuilder
    {
        public RarityTypeEnum RarityType { get; set; }
        private readonly DataSet _data = TreasureData.Instance.PotionData;

        public Treasure GetResult()
        {
            DataRow levelRow = Helpers.GetRow(_data, "PotionLevel", Enum.GetName(typeof(RarityTypeEnum), RarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), potionLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string potionType = Helpers.GetRow(_data, "PotionType", "d%").Field<string>("type");
            DataRow spellRow = Helpers.GetRow(_data, potionLevel + potionType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Potion,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    internal class WandBuilder : ITreasureBuilder
    {
        private RarityTypeEnum RarityType { get; set; }
        private readonly DataSet _data = TreasureData.Instance.WandData;

        public Treasure GetResult()
        {
            DataRow levelRow = Helpers.GetRow(_data, "WandLevel", Enum.GetName(typeof(RarityTypeEnum), RarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), wandLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string wandType = Helpers.GetRow(_data, "WandType", "d%").Field<string>("type");
            DataRow spellRow = Helpers.GetRow(_data, wandLevel + wandType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Potion,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    internal class WeaponEnchantmentBuilder : ITreasureBuilder
    {
        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class UniqueWeaponBuilder : ITreasureBuilder
    {
        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class WeaponBuilder : ITreasureBuilder
    {
        WeaponTypeEnum _weaponType;
        RarityTypeEnum _rarityType;

        public WeaponBuilder(WeaponTypeEnum weaponType, RarityTypeEnum rarityType)
        {
            _weaponType = weaponType;
            _rarityType = rarityType;
        }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class ArmorEnchantmentBuilder : ITreasureBuilder
    {
        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class UniqueArmorBuilder : ITreasureBuilder
    {
        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class ArmorBuilder : ITreasureBuilder
    {
        ArmorTypeEnum _armorType;
        RarityTypeEnum _rarityType;

        public ArmorBuilder(ArmorTypeEnum armorType, RarityTypeEnum rarityType)
        {
            _armorType = armorType;
            _rarityType = rarityType;
        }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class RingBuilder : ITreasureBuilder
    {
        RarityTypeEnum _rarityType;

        public RingBuilder(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class WondrousBuilder : ITreasureBuilder
    {
        RarityTypeEnum _rarityType;

        public WondrousBuilder(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
    internal class RodBuilder : ITreasureBuilder
    {
        RarityTypeEnum _rarityType;

        public RodBuilder(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure GetResult()
        {
            throw new NotImplementedException();
        }
    }
}