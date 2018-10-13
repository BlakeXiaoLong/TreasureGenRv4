using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;

namespace TreasureGenRv4.Data
{
    public sealed class TreasureData
    {
        public DataSet WandData { get; private set; }
        public DataSet PotionData { get; private set; }
        public DataSet ScrollData { get; private set; }
        public DataSet WeaponData { get; private set; }
        public DataSet ArmorData { get; private set; }

        private static readonly Lazy<TreasureData> lazy = new Lazy<TreasureData>(() => new TreasureData());
        public static TreasureData Instance { get { return lazy.Value; } }
        private TreasureData()
        {
            WandData = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("Data\\WandData.json"));
            PotionData = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("Data\\PotionData.json"));
            ScrollData = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("Data\\ScrollData.json"));
            WeaponData = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("Data\\WeaponData.json"));
            ArmorData = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("Data\\ArmorData.json"));
        }
    }
}
