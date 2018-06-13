using Newtonsoft.Json;

namespace TreasureGenRv4.Data
{
    internal static class PotionTables
    {
        private const string PotionJson = @"
        [
            {
		        ""Lesser Minor"": ""01–40"",
		        ""Greater Minor"": ""01–10"",
		        ""Lesser Medium"": ""—"",
		        ""Greater Medium"": ""—"",
		        ""Lesser Major"": ""—"",
		        ""Greater Major"": ""—"",
		        ""Caster Level"": ""1"",
		        ""Spell Level"": ""0"",
		        ""Rarity"": {
			        ""Common"": ""01-100"",
			        ""Uncommon"": ""101-101""
		        },
		        ""Spells"": {
			        ""Common"": [{
					        ""d%"": ""01–14"",
					        ""Common Potion or Oil"": ""Arcane mark"",
					        ""Price"": ""25 gp""
				        },
				        {
					        ""d%"": ""15–28"",
					        ""Common Potion or Oil"": ""Guidance"",
					        ""Price"": ""25 gp""
				        },
				        {
					        ""d%"": ""29–44"",
					        ""Common Potion or Oil"": ""Light"",
					        ""Price"": ""25 gp""
				        },
				        {
					        ""d%"": ""45–58"",
					        ""Common Potion or Oil"": ""Purify food and drink"",
					        ""Price"": ""25 gp""
				        },
				        {
					        ""d%"": ""59–72"",
					        ""Common Potion or Oil"": ""Resistance"",
					        ""Price"": ""25 gp""
				        },
				        {
					        ""d%"": ""73–86"",
					        ""Common Potion or Oil"": ""Stabilize"",
					        ""Price"": ""25 gp""
				        },
				        {
					        ""d%"": ""87–100"",
					        ""Common Potion or Oil"": ""Virtue"",
					        ""Price"": ""25 gp""
				        }
			        ],
			        ""Uncommon"": []
		        }
	        },
	        {
		        ""Lesser Minor"": ""41–100"",
		        ""Greater Minor"": ""11–60"",
		        ""Lesser Medium"": ""01–25"",
		        ""Greater Medium"": ""01–10"",
		        ""Lesser Major"": ""—"",
		        ""Greater Major"": ""—"",
		        ""Caster Level"": ""1"",
		        ""Spell Level"": ""1"",
		        ""Rarity"": {
			        ""Common"": ""01-75"",
			        ""Uncommon"": ""76-100""
		        },
		        ""Spells"": {
			        ""Common"": [{
					        ""d%"": ""01–04"",
					        ""Common Potion or Oil"": ""Bless weapon"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""05–14"",
					        ""Common Potion or Oil"": ""Cure light wounds"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""15–19"",
					        ""Common Potion or Oil"": ""Endure elements"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""20–27"",
					        ""Common Potion or Oil"": ""Enlarge person"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""28–33"",
					        ""Common Potion or Oil"": ""Jump"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""34–41"",
					        ""Common Potion or Oil"": ""Mage armor"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""42–47"",
					        ""Common Potion or Oil"": ""Magic fang"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""48–55"",
					        ""Common Potion or Oil"": ""Magic weapon"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""56–60"",
					        ""Common Potion or Oil"": ""Pass without trace"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""61–64"",
					        ""Common Potion or Oil"": ""Protection from chaos"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""65–68"",
					        ""Common Potion or Oil"": ""Protection from evil"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""69–72"",
					        ""Common Potion or Oil"": ""Protection from good"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""73–76"",
					        ""Common Potion or Oil"": ""Protection from law"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""77–81"",
					        ""Common Potion or Oil"": ""Reduce person"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""82–87"",
					        ""Common Potion or Oil"": ""Remove fear"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""88–92"",
					        ""Common Potion or Oil"": ""Sanctuary"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""93–100"",
					        ""Common Potion or Oil"": ""Shield of faith"",
					        ""Price"": ""50 gp""
				        }
			        ],
			        ""Uncommon"": [{
					        ""d%"": ""01–04"",
					        ""Common Potion or Oil"": ""Animate rope"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""05–11"",
					        ""Common Potion or Oil"": ""Ant haul"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""12–16"",
					        ""Common Potion or Oil"": ""Cloak of the shade"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""17–20"",
					        ""Common Potion or Oil"": ""Erase"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""21–26"",
					        ""Common Potion or Oil"": ""Feather step"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""27–30"",
					        ""Common Potion or Oil"": ""Goodberry"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""31–34"",
					        ""Common Potion or Oil"": ""Grease"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""35–41"",
					        ""Common Potion or Oil"": ""Hide from animals"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""42–49"",
					        ""Common Potion or Oil"": ""Hide from undead"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""50–53"",
					        ""Common Potion or Oil"": ""Hold portal"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""54–58"",
					        ""Common Potion or Oil"": ""Invigorate"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""59–64"",
					        ""Common Potion or Oil"": ""Keen senses"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""65–68"",
					        ""Common Potion or Oil"": ""Magic stone"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""69–75"",
					        ""Common Potion or Oil"": ""Remove sickness"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""76–80"",
					        ""Common Potion or Oil"": ""Sanctify corpse"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""81–84"",
					        ""Common Potion or Oil"": ""Shillelagh"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""85–92"",
					        ""Common Potion or Oil"": ""Touch of the sea"",
					        ""Price"": ""50 gp""
				        },
				        {
					        ""d%"": ""93–100"",
					        ""Common Potion or Oil"": ""Vanish"",
					        ""Price"": ""50 gp""
				        }
			        ]
		        }
	        },
	        {
		        ""Lesser Minor"": ""—"",
		        ""Greater Minor"": ""61–100"",
		        ""Lesser Medium"": ""26–85"",
		        ""Greater Medium"": ""11–50"",
		        ""Lesser Major"": ""01–35"",
		        ""Greater Major"": ""01–10"",
		        ""Caster Level"": ""3"",
		        ""Spell Level"": ""2"",
		        ""Rarity"": {
			        ""Common"": ""01-75"",
			        ""Uncommon"": ""76-100""
		        },
		        ""Spells"": {
			        ""Common"": [{
					        ""d%"": ""01–04"",
					        ""Common Potion or Oil"": ""Aid"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""05–07"",
					        ""Common Potion or Oil"": ""Align weapon"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""08–11"",
					        ""Common Potion or Oil"": ""Barkskin"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""12–16"",
					        ""Common Potion or Oil"": ""Bear's endurance "",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""17–20"",
					        ""Common Potion or Oil"": ""Blur"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""21–25"",
					        ""Common Potion or Oil"": ""Bull's strength "",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""26–30"",
					        ""Common Potion or Oil"": ""Cat's grace "",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""31–37"",
					        ""Common Potion or Oil"": ""Cure moderate wounds"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""38–41"",
					        ""Common Potion or Oil"": ""Darkvision"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""42–44"",
					        ""Common Potion or Oil"": ""Delay poison"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""45–49"",
					        ""Common Potion or Oil"": ""Eagle's splendor "",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""50–54"",
					        ""Common Potion or Oil"": ""Fox's cunning "",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""55–61"",
					        ""Common Potion or Oil"": ""Invisibility"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""62–66"",
					        ""Common Potion or Oil"": ""Levitate"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""67–71"",
					        ""Common Potion or Oil"": ""Owl's wisdom "",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""72–73"",
					        ""Common Potion or Oil"": ""Protection from arrows"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""74–76"",
					        ""Common Potion or Oil"": ""Remove paralysis"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""77–80"",
					        ""Common Potion or Oil"": ""Resist energy, acid"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""81–84"",
					        ""Common Potion or Oil"": ""Resist energy, cold"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""85–88"",
					        ""Common Potion or Oil"": ""Resist energy, electricity"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""89–92"",
					        ""Common Potion or Oil"": ""Resist energy, fire"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""93–94"",
					        ""Common Potion or Oil"": ""Resist energy, sonic"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""95–98"",
					        ""Common Potion or Oil"": ""Spider climb"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""99–100"",
					        ""Common Potion or Oil"": ""Undetectable alignment"",
					        ""Price"": ""300 gp""
				        }
			        ],
			        ""Uncommon"": [{
					        ""d%"": ""01–06"",
					        ""Common Potion or Oil"": ""Ablative barrier"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""07–14"",
					        ""Common Potion or Oil"": ""Acute senses"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""15–19"",
					        ""Common Potion or Oil"": ""Arcane lock"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""20–24"",
					        ""Common Potion or Oil"": ""Bullet shield"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""25–30"",
					        ""Common Potion or Oil"": ""Certain grip"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""31–35"",
					        ""Common Potion or Oil"": ""Continual flame"",
					        ""Price"": ""350 gp""
				        },
				        {
					        ""d%"": ""36–40"",
					        ""Common Potion or Oil"": ""Corruption resistance"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""41–48"",
					        ""Common Potion or Oil"": ""Disguise other"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""49–56"",
					        ""Common Potion or Oil"": ""Gentle repose"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""57–61"",
					        ""Common Potion or Oil"": ""Make whole"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""62–67"",
					        ""Common Potion or Oil"": ""Obscure object"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""68–72"",
					        ""Common Potion or Oil"": ""Reduce animal"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""73–76"",
					        ""Common Potion or Oil"": ""Rope trick"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""77–82"",
					        ""Common Potion or Oil"": ""Slipstream"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""83–90"",
					        ""Common Potion or Oil"": ""Status"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""91–95"",
					        ""Common Potion or Oil"": ""Warp wood"",
					        ""Price"": ""300 gp""
				        },
				        {
					        ""d%"": ""96–100"",
					        ""Common Potion or Oil"": ""Wood shape"",
					        ""Price"": ""300 gp""
				        }
			        ]
		        }
	        },
	        {
		        ""Lesser Minor"": ""—"",
		        ""Greater Minor"": ""—"",
		        ""Lesser Medium"": ""86–100"",
		        ""Greater Medium"": ""51–100"",
		        ""Lesser Major"": ""36–100"",
		        ""Greater Major"": ""11–100"",
		        ""Caster Level"": ""5"",
		        ""Spell Level"": ""3"",
		        ""Rarity"": {
			        ""Common"": ""01-75"",
			        ""Uncommon"": ""76-100""
		        },
		        ""Spells"": {
			        ""Common"": [{
					        ""d%"": ""01–06"",
					        ""Common Potion or Oil"": ""Cure serious wounds"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""07–10"",
					        ""Common Potion or Oil"": ""Dispel magic"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""11–14"",
					        ""Common Potion or Oil"": ""Displacement"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""15–20"",
					        ""Common Potion or Oil"": ""Fly"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""21–25"",
					        ""Common Potion or Oil"": ""Gaseous form"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""26–29"",
					        ""Common Potion or Oil"": ""Good hope"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""30–35"",
					        ""Common Potion or Oil"": ""Haste"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""36–40"",
					        ""Common Potion or Oil"": ""Heroism"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""41–44"",
					        ""Common Potion or Oil"": ""Keen edge"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""45–48"",
					        ""Common Potion or Oil"": ""Magic fang, greater"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""49–52"",
					        ""Common Potion or Oil"": ""Magic vestment"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""53–57"",
					        ""Common Potion or Oil"": ""Neutralize poison"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""58–60"",
					        ""Common Potion or Oil"": ""Protection from energy, acid"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""61–63"",
					        ""Common Potion or Oil"": ""Protection from energy, cold"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""64–66"",
					        ""Common Potion or Oil"": ""Protection from energy, electricity"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""67–69"",
					        ""Common Potion or Oil"": ""Protection from energy, fire"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""70–71"",
					        ""Common Potion or Oil"": ""Protection from energy, sonic"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""72–74"",
					        ""Common Potion or Oil"": ""Rage"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""75–77"",
					        ""Common Potion or Oil"": ""Remove blindness/deafness"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""78–81"",
					        ""Common Potion or Oil"": ""Remove curse"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""82–86"",
					        ""Common Potion or Oil"": ""Remove disease"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""87–91"",
					        ""Common Potion or Oil"": ""Tongues"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""92–96"",
					        ""Common Potion or Oil"": ""Water breathing"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""97–100"",
					        ""Common Potion or Oil"": ""Water walk"",
					        ""Price"": ""750 gp""
				        }
			        ],
			        ""Uncommon"": [{
					        ""d%"": ""01–12"",
					        ""Common Potion or Oil"": ""Burrow"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""11–22"",
					        ""Common Potion or Oil"": ""Countless eyes"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""23–34"",
					        ""Common Potion or Oil"": ""Daylight"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""35–49"",
					        ""Common Potion or Oil"": ""Draconic reservoir"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""50–58"",
					        ""Common Potion or Oil"": ""Flame arrow"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""59–67"",
					        ""Common Potion or Oil"": ""Shrink item"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""68–77"",
					        ""Common Potion or Oil"": ""Stone shape"",
					        ""Price"": ""750 gp""
				        },
				        {
					        ""d%"": ""78–87"",
					        ""Common Potion or Oil"": ""Fire trap"",
					        ""Price"": ""775 gp""
				        },
				        {
					        ""d%"": ""88–100"",
					        ""Common Potion or Oil"": ""Nondetection"",
					        ""Price"": ""800 gp""
				        }
			        ]
		        }
	        }
        ]";
    }
}