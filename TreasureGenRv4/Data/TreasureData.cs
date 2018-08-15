using Newtonsoft.Json;
using System;
using System.Data;

namespace TreasureGenRv4.Data
{
    public sealed class TreasureData
    {
        public DataSet WandData { get; private set; }
        public DataSet PotionData { get; private set; }
        public DataSet ScrollData { get; private set; }
        public DataSet ArmamentData { get; private set; }

        private static readonly Lazy<TreasureData> lazy = new Lazy<TreasureData>(() => new TreasureData());
        public static TreasureData Instance { get { return lazy.Value; } }
        private TreasureData()
        {
            WandData = JsonConvert.DeserializeObject<DataSet>("WandData.json");
            PotionData = JsonConvert.DeserializeObject<DataSet>("PotionData.json");
            ScrollData = JsonConvert.DeserializeObject<DataSet>("ScrollData.json");
            ArmamentData = JsonConvert.DeserializeObject<DataSet>("ArmamentData.json");
        }
    }
}
