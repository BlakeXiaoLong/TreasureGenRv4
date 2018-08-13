using System.Linq;
using System.Collections.Generic;

namespace TreasureGenRv4
{
    public enum ValueTypeEnum
    {
        CP,
        SP,
        GP,
        PP
    }
    public enum TreasureTypeEnum
    {
        Coin,
        Gem,
        Art,
        Scroll,
        Potion,
        Wand,
        Weapon,
        Armor,
        Ring,
        Wondrous,
        Rod
    }
    public enum QualityTypeEnum
    {
        Intelligent,
        Charged,
        Descriptive,
        None
    }
    public enum SlotTypeEnum
    {
        Belt,
        Body,
        Chest,
        Eyes,
        Feet,
        Hands,
        Head,
        Headband,
        Neck,
        Shoulders,
        Wrists,
        Slotless
    }

    public class Treasure
    {
        public int TreasureValue { get; internal set; }
        public ValueTypeEnum ValueType { get; internal set; }
        public TreasureTypeEnum TreasureType { get; internal set; }
        public string Name { get; internal set; }
    }
    public class CastableTreasure : Treasure
    {
        public int CasterLevel { get; internal set; }
    }
    public class CharacterizedTreasure : Treasure
    {
        public QualityTypeEnum QualityType { get; internal set; }
        public int Charges { get; internal set; }
    }
    public class SlottedTreasure : CharacterizedTreasure
    {
        public SlotTypeEnum SlotType { get; internal set; }
    }
    public class EnchantableTreasure : CharacterizedTreasure
    {
        private List<string> _enchantments;

        public int Enhancement { get; internal set; }
        public IEnumerable<string> Enchantments
        {
            get => _enchantments.AsReadOnly();
            internal set => _enchantments = value.ToList();
        }
    }
}