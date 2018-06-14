namespace TreasureGenRv4.Objects
{
    internal class PotionData
    {
        public string LesserMinor { get; set; }
        public string GreaterMinor { get; set; }
        public string LesserMedium { get; set; }
        public string GreaterMedium { get; set; }
        public string LesserMajor { get; set; }
        public string GreaterMajor { get; set; }
        public string CasterLevel { get; set; }
        public string SpellLevel { get; set; }
        public Rarity Rarity { get; set; }
        public SpellList Spells { get; set; }
    }
}