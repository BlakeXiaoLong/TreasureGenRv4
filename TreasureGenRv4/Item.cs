using System;
using System.Collections.Generic;

namespace TreasureGenRv4
{
    public enum CoinTypeEnum
    {
        CP,
        SP,
        GP,
        PP
    }
    public enum ItemPowerEnum
    {
        LesserMinor,
        GreaterMinor,
        LesserMedium,
        GreaterMedium,
        LesserMajor,
        GreaterMajor,
        Mundane
    }
    public enum MagicTypeEnum
    {
        Divine,
        Arcane
    }
    public enum ArmorTypeEnum
    {
        Light,
        Medium,
        Heavy,
        Shield,
        AnyArmor
    }
    public enum WeaponTypeEnum
    {
        AnyWeapon
    }

    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public CoinTypeEnum CoinType { get; set; }
    }
    public class Coin : Item { }

    public class Graded : Item
    {
        public int Grade { get; set; }
    }
    public class Gem : Graded
    {
        public int BaseVal { get; set; }
        public string AddedVal { get; set; }
    }
    public class Art : Graded { }

    public class Armament : Item
    {
        public bool IsMasterwork { get; set; }
        public List<Enchantment> Enchantments { get; set; }
    }
    public class Weapon : Armament
    {
        public WeaponTypeEnum WeaponType { get; set; }
    }
    public class Armor : Armament
    {
        public ArmorTypeEnum ArmorType { get; set; }
    }

    public class Magical : Item
    {
        public ItemPowerEnum ItemPower { get; set; }
    }
    public class Ring : Magical { }
    public class Enchantment : Item
    {
        public Type EnchantmentType { get; set; }
        public ArmorTypeEnum ArmorType { get; set; }
        public WeaponTypeEnum WeaponType { get; set; }
        public int Modifier { get; set; }
    }

    public class Castable : Magical
    {
        public MagicTypeEnum MagicType { get; set; }
        public int CasterLevel { get; set; }
        public int SpellLevel { get; set; }
        public bool IsCommon { get; set; }
    }
    public class Potion : Castable { }
    public class Scroll : Castable { }
    public class Wand : Castable { }

    public class Wondrous : Magical
    {
        //derivations... ?
    }
    public class Belt : Wondrous { }
    public class Body : Wondrous { }
    public class Chest : Wondrous { }
    public class Eyes : Wondrous { }
    public class Feet : Wondrous { }
    public class Hands : Wondrous { }
    public class Head : Wondrous { }
    public class Headband : Wondrous { }
    public class Neck : Wondrous { }
    public class Shoulders : Wondrous { }
    public class Wrists : Wondrous { }
    public class Slotless : Wondrous { }
}