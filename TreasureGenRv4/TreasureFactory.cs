using System;
using System.Data;
using TreasureGenRv4.Data;

namespace TreasureGenRv4
{
    internal enum ArmorTypeEnum
    {
        LightArmor,
        MediumArmor,
        HeavyArmor,
        AnyArmor,
        LightShield,
        HeavyShield,
        AnyShield
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
    internal enum WeaponTypeEnum
    {

    }

    internal interface ITreasureFactory
    {
        Treasure CreateNew();
    }
    internal class CoinFactory : ITreasureFactory
    {
        private readonly int _x, _y, _m;
        private readonly ValueTypeEnum _valueType;

        public CoinFactory(int x, int y, ValueTypeEnum valueType) : this(x, y, 1, valueType) { }
        public CoinFactory(int x, int y, int m, ValueTypeEnum valueType)
        {
            _x = x;
            _y = y;
            _m = m;
            _valueType = valueType;
        }

        public Treasure CreateNew()
        {
            return new Treasure
            {
                Name = "Sack of Coins",
                TreasureType = TreasureTypeEnum.Coin,
                TreasureValue = $"{Helpers.Roll(_x, _y, _m)} {Enum.GetName(typeof(ValueTypeEnum),_valueType)}",
            };
        }
    }
    internal class GemFactory : ITreasureFactory
    {
        private readonly int _grade;

        public GemFactory(int grade)
        {
            _grade = grade;
        }

        public Treasure CreateNew()
        {
            throw new System.NotImplementedException();
        }
    }
    internal class ArtFactory : ITreasureFactory
    {
        private readonly int _grade;

        public ArtFactory(int grade)
        {
            _grade = grade;
        }

        public Treasure CreateNew()
        {
            throw new System.NotImplementedException();
        }
    }
    internal class ScrollFactory : ITreasureFactory
    {
        private readonly RarityTypeEnum _rarityType;

        public ScrollFactory(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure CreateNew()
        {
            DataSet data = TreasureData.Instance.ScrollData;

            DataRow levelRow = Helpers.GetRow(data, "ScrollLevel", Enum.GetName(typeof(RarityTypeEnum), _rarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), scrollLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string scrollType = Helpers.GetRow(data, "ScrollType", "d%").Field<string>("type");
            DataRow spellRow = Helpers.GetRow(data, scrollLevel + scrollType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Scroll,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    internal class PotionFactory : ITreasureFactory
    {
        private readonly RarityTypeEnum _rarityType;

        public PotionFactory(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure CreateNew()
        {
            DataSet data = TreasureData.Instance.PotionData;

            DataRow levelRow = Helpers.GetRow(data, "PotionLevel", Enum.GetName(typeof(RarityTypeEnum), _rarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), potionLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string potionType = Helpers.GetRow(data, "PotionType", "d%").Field<string>("type");
            DataRow spellRow = Helpers.GetRow(data, potionLevel + potionType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Potion,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    internal class WandFactory : ITreasureFactory
    {
        readonly RarityTypeEnum _rarityType;

        public WandFactory(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure CreateNew()
        {
            DataSet data = TreasureData.Instance.WandData;

            DataRow levelRow = Helpers.GetRow(data, "WandLevel", Enum.GetName(typeof(RarityTypeEnum), _rarityType));
            int casterLevel = Convert.ToInt32(levelRow["CasterLevel"]), wandLevel = Convert.ToInt32(levelRow["SpellLevel"]);
            string wandType = Helpers.GetRow(data, "WandType", "d%").Field<string>("type");
            DataRow spellRow = Helpers.GetRow(data, wandLevel + wandType, "d%");

            return new CastableTreasure
            {
                Name = spellRow.Field<string>("spell"),
                TreasureType = TreasureTypeEnum.Potion,
                TreasureValue = spellRow.Field<string>("price"),
                CasterLevel = casterLevel
            };
        }
    }
    internal class WeaponFactory : ITreasureFactory
    {
        WeaponTypeEnum _weaponType;
        RarityTypeEnum _rarityType;

        public WeaponFactory(WeaponTypeEnum weaponType, RarityTypeEnum rarityType)
        {
            _weaponType = weaponType;
            _rarityType = rarityType;
        }

        public Treasure CreateNew()
        {
            throw new System.NotImplementedException();
        }
    }
    internal class ArmorFactory : ITreasureFactory
    {
        ArmorTypeEnum _armorType;
        RarityTypeEnum _rarityType;

        public ArmorFactory(ArmorTypeEnum armorType, RarityTypeEnum rarityType)
        {
            _armorType = armorType;
            _rarityType = rarityType;
        }

        public Treasure CreateNew()
        {
            throw new System.NotImplementedException();
        }
    }
    internal class RingFactory : ITreasureFactory
    {
        RarityTypeEnum _rarityType;

        public RingFactory(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure CreateNew()
        {
            throw new System.NotImplementedException();
        }
    }
    internal class WondrousFactory : ITreasureFactory
    {
        RarityTypeEnum _rarityType;

        public WondrousFactory(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure CreateNew()
        {
            throw new System.NotImplementedException();
        }
    }
    internal class RodFactory : ITreasureFactory
    {
        RarityTypeEnum _rarityType;

        public RodFactory(RarityTypeEnum rarityType)
        {
            _rarityType = rarityType;
        }

        public Treasure CreateNew()
        {
            throw new System.NotImplementedException();
        }
    }
}