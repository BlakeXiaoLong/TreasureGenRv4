using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureGenRv4
{
    public class Generator
    {
        public enum ProgressionTypeEnum { Slow = 0, Normal = 1, Fast = 2, NPC = 3 }
        public enum MultiplierTypeEnum { None, Incremental, Normal, Double, Triple }
        public enum TreasureTypeEnum { A = 0, B = 1, C = 2, D = 3, E = 4, F = 5, G = 6, H = 7, I = 8 }
        internal static int[][] EncounterValues = new int[][]
        {
            new[]{170,350,550,750,1000,1350,1750,2200,2850,3650,4650,6000,7750,10000,13000,16500,22000,28000,35000,44000 }, // slow progression
            new[]{260,550,800,1150,1550,2000,2600,3350,4250,5450,7000,9000,11600,15000,19500,25000,32000,41000,53000,67000 }, // normal progression
            new[]{400,800,1200,1700,2300,3000,3900,5000,6400,8200,10500,13500,17500,22000,29000,38000,48000,62000,79000,100000 }, // fast progression
            new[]{260,390,780,1650,2400,3450,4650,6000,7800,10050,12750,16350,21000,27000,34800,45000,58500,75000,96000,123000,159000 } // NPC Gear
        };

        public static int GetOverallCr(IEnumerable<int> crValues)
        {
            throw new NotImplementedException();
        }
        public static int GetBudget(int overallCr, ProgressionTypeEnum progressionType, MultiplierTypeEnum multiplierType)
        {
            int maxLevel = progressionType == ProgressionTypeEnum.NPC ? 21 : 20;
            overallCr = overallCr > maxLevel ? maxLevel : overallCr;
            return EncounterValues[(int)progressionType][overallCr] * (int)multiplierType;
        }
        public static List<Treasure> Run(int budget, TreasureTypeEnum treasureType)
        {
            List<ITreasureBuilder> factoryList = new List<ITreasureBuilder>();
            KeyValuePair<int, List<ITreasureBuilder>>[] values = TreasureValues[(int)treasureType];
            for (int i = values.Length - 1; i >= 0; i--)
            {
                List<List<ITreasureBuilder>> factories = values.Where(x => x.Key == values[i].Key).Select(x => x.Value).ToList();
                while (budget > values[i].Key)
                {
                    factoryList.AddRange(factories[Helpers.Roll(1, factories.Count) - 1]);
                    budget -= values[i].Key;
                }
            }
            return factoryList.Select(x => x.GetResult()).ToList();
        }        
    }
}
