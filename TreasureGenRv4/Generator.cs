using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TreasureGenRv4.Objects;
namespace TreasureGenRv4
{
    public class Generator
    {
        public enum BudgetTypeEnum
        {
            None,
            Incidental,
            Normal,
            Double,
            Triple,
            Npc
        }
        public enum ProgressionEnum
        {
            Slow,
            Medium,
            Fast
        }

        private readonly Random _random = new Random();
        private List<PotionData> _potions;

        public void Populate()
        {
            using (var r = new StreamReader("Data/Potion.json"))
            {
                string json = r.ReadToEnd();
                _potions = JsonConvert.DeserializeObject<List<PotionData>>(json);
            }
        }

        private int Roll(string roll)
        {
            int x = 1, m = 1;
            if (roll.Contains('d'))
            {
                string[] split = roll.Split('d');
                x = int.Parse(split[0]);
                roll = split[1];
            }

            if (roll.Contains('x'))
            {
                string[] split = roll.Split('x');
                m = int.Parse(split[1]);
                roll = split[0];
            }
            int y = int.Parse(roll);
            return Roll(x, y, m);
        }
        private int Roll(int x = 1, int y = 100, int m = 1)
        {
            int result = 0;
            for (int i = 0; i < x; i++) result += _random.Next(1, y + 1);
            return result * m;
        }
        private bool InRange(int num, string range)
        {
            string[] r = range.Split('–');
            if (r.Length != 2 || !int.TryParse(r[0], out int start) || !int.TryParse(r[1], out int end)) return false;
            return num >= start && num <= end;
        }
    }
}