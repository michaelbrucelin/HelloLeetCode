using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0539
{
    public class Solution0539_2 : Interface0539
    {
        /// <summary>
        /// 映射 + 排序
        /// 逻辑同Solution0539，将排序改为计数排序
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int FindMinDifference(IList<string> timePoints)
        {
            if (timePoints.Count > 1440) return 0;

            int cnt = timePoints.Count;
            int[] times = new int[1440];
            for (int i = 0; i < cnt; i++) times[int.Parse(timePoints[i][0..2]) * 60 + int.Parse(timePoints[i][3..5])]++;

            int min = 0; while (times[min] == 0) min++; if (times[min] > 1) return 0;
            int max = 1439; while (times[max] == 0) max--; if (times[max] > 1) return 0;
            int result = min + 1440 - max;
            for (int curr = min + 1, last = min; curr <= max; curr++)
            {
                if (times[curr] == 0) continue;
                if (times[curr] > 1) return 0;
                result = Math.Min(result, curr - last);
                last = curr;
            }

            return result;
        }
    }
}
