using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureGenRv4
{
    public static class Generator
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
        internal static KeyValuePair<int, List<ITreasureFactory>>[][] TreasureValues = new KeyValuePair<int, List<ITreasureFactory>>[][]
        {
            //new[]{1,5,10,25,50,100,200,500,1000,5000,10000,50000},
            //new[]{10,15,25,50,50,75,100,100,150,200,250,500,500,750,1000,1000,2500,5000,5000,10000,20000,50000},
            //new[]{50,100,100,150,200,250,500,500,750,1000,1000,1500,2000,2500,5000,5000,7500,10000,1000,15000,20000,50000},
            //new[]{50,50,100,150,200,250,300,400,500,500,750,1000,1000,1500,1500,2000,2000,3000,4000,5000,7500,7500,10000,10000,15000,15000,20000,20000,25000,30000,50000},
            //new[]{200,300,350,1000,1500,2500,3000,3000,4000,5500,6000,7500,8000,9000,10000,13000,13000,15000,20000,25000,30000,30000,35000,35000,40000,50000,75000,100000},
            //new[]{50,250,350,400,500,750,1000,1500,2000,3000,4000,5000,6000,7500,10000,10000,12500,15000,20000,25000,30000,40000,50000,60000,75000,100000},
            //new[]{50,75,100,150,200,250,500,750,1000,1500,2000,2500,3000,4000,5000,6000,7500,10000,12500,15000,2000,25000,30000,40000,50000,60000,75000,100000},
            //new[]{500,1000,2500,5000,7500,10000,15000,20000,25000,30000,40000,50000,75000,100000},
            //new[]{5000,10000,15000,20000,25000,30000,40000,50000,60000,75000,100000,125000,150000,200000,300000}
        };

        public static int GetOverallCr(IEnumerable<int> crValues)
        {

        }
        public static int GetBudget(int overallCr, ProgressionTypeEnum progressionType, MultiplierTypeEnum multiplierType)
        {
            int maxLevel = progressionType == ProgressionTypeEnum.NPC ? 21 : 20;
            overallCr = overallCr > maxLevel ? maxLevel : overallCr;
            return EncounterValues[(int)progressionType][overallCr] * (int)multiplierType;
        }
        public static List<Treasure> Run(int budget, TreasureTypeEnum treasureType)
        {
            List<ITreasureFactory> factoryList = new List<ITreasureFactory>();
            KeyValuePair<int, List<ITreasureFactory>>[] values = TreasureValues[(int)treasureType];
            for (int i = values.Length - 1; i >= 0; i--)
            {
                List<List<ITreasureFactory>> factories = values.Where(x => x.Key == values[i].Key).Select(x => x.Value).ToList();
                while (budget > values[i].Key)
                {
                    factoryList.AddRange(factories[Roll(1, factories.Count) - 1]);
                    budget -= values[i].Key;
                }
            }
            return factoryList.Select(x => x.CreateNew()).ToList();
        }

        internal static int Roll(int x, int y, int m = 1)
        {
            if (y == 1) return x;
            if (x < 1 || m == 0) return 0;

            int ret = 0;
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < x; i++) ret += random.Next(1, y + 1);
            return ret;
        }
    }
}