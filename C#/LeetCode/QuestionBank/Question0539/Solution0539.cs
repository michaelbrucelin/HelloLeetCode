using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0539
{
    public class Solution0539 : Interface0539
    {
        /// <summary>
        /// 映射 + 排序
        /// 将时间映射为数字后再排序
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int FindMinDifference(IList<string> timePoints)
        {
            if (timePoints.Count > 1440) return 0;

            int cnt = timePoints.Count;
            int[] times = new int[cnt];
            for (int i = 0; i < cnt; i++) times[i] = int.Parse(timePoints[i][0..2]) * 60 + int.Parse(timePoints[i][3..5]);
            Array.Sort(times);

            int result = times[0] + 1440 - times[^1];
            for (int i = 1; i < cnt; i++)
            {
                result = Math.Min(result, times[i] - times[i - 1]);
                if (result == 0) return 0;
            }

            return result;
        }
    }
}
