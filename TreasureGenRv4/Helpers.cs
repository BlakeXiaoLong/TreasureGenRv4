using System;
using System.Data;
using System.Linq;

namespace TreasureGenRv4
{
   public static class Helpers
    {
        internal static int Roll(int x, int y, int m = 1)
        {
            if (y == 1) return x;
            if (x < 1 || m == 0) return 0;

            int ret = 0;
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < x; i++) ret += random.Next(1, y + 1);
            return ret;
        }
        internal static bool InRange(string range, int value)
        {
            try
            {
                string[] values = range.Split('-');
                if (values.Length == 1 && values[0] == "-") return false;
                else if (values.Length == 1)
                    return int.TryParse(values[0], out var x) && x == value;
                else if (values.Length == 2)
                    return int.TryParse(values[0], out var x) && x <= value
                        && int.TryParse(values[1], out var y) && y >= value;
            }
            catch { }
            return false;
        }
        internal static DataRow GetRow(this DataSet ds, string tableName, string colName)
        {
            int roll = Roll(1, 100);
            return ds.Tables[tableName].AsEnumerable().FirstOrDefault(x => InRange(x.Field<string>(colName), roll)) ?? GetRow(ds, tableName, colName);

        }
    }
}
