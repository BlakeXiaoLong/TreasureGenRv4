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
                TreasureValue = Generator.Roll(_x, _y, _m),
                ValueType = _valueType
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

            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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