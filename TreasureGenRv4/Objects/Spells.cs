using System.Collections.Generic;

namespace TreasureGenRv4.Objects
{
    internal class Rarity
    {
        public string Common { get; set; }
        public string Uncommon { get; set; }
    }

    internal class SpellList
    {
        public List<Spell> Common { get; set; }
        public List<Spell> Uncommon { get; set; }
    }

    internal class Spell
    {
        public string D { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}