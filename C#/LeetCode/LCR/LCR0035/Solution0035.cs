using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0035
{
    public class Solution0035 : Interface0035
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int FindMinDifference(IList<string> timePoints)
        {
            if (timePoints.Count > 1440) return 0;

            int cnt = timePoints.Count;
            int[] times = new int[cnt];
            for (int i = 0; i < cnt; i++) times[i] = int.Parse(timePoints[i].AsSpan(0, 2)) * 60 + int.Parse(timePoints[i].AsSpan(3, 2));
            Array.Sort(times);

            int result = times[0] + 1440 - times[cnt - 1];
            for (int i = 1; i < cnt; i++) result = Math.Min(result, times[i] - times[i - 1]);
            return result;
        }

        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int FindMinDifference2(IList<string> timePoints)
        {
            if (timePoints.Count > 1440) return 0;

            int[] times = new int[1440];
            int idx;
            foreach (string str in timePoints)
            {
                times[idx = int.Parse(str.AsSpan(0, 2)) * 60 + int.Parse(str.AsSpan(3, 2))]++;
                if (times[idx] > 1) return 0;
            }

            int min = 0000; while (times[min] == 0) min++;
            int max = 1439; while (times[max] == 0) max--;
            int result = min + 1440 - max, pl = min, pr;
            while (pl < max)
            {
                pr = pl + 1; while (times[pr] == 0) pr++;
                result = Math.Min(result, pr - pl);
                pl = pr;
            }
            return result;
        }
    }
}
