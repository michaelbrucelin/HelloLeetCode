using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3633
{
    public class Solution3633_2 : Interface3633
    {
        /// <summary>
        /// 分类讨论 + 贪心
        /// 1. 先陆再水
        ///     选出结束时间最早的陆地游戏，然后再选水中游戏
        /// 2. 先水再陆
        ///     逻辑对称
        /// </summary>
        /// <param name="landStartTime"></param>
        /// <param name="landDuration"></param>
        /// <param name="waterStartTime"></param>
        /// <param name="waterDuration"></param>
        /// <returns></returns>
        public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
        {
            int result = int.MaxValue, len1 = landStartTime.Length, len2 = waterStartTime.Length;
            // 先陆再水
            int start = landStartTime[0] + landDuration[0];
            for (int i = 1; i < len1; i++) start = Math.Min(start, landStartTime[i] + landDuration[i]);
            for (int i = 0; i < len2; i++) result = Math.Min(result, Math.Max(start, waterStartTime[i]) + waterDuration[i]);
            // 先水再陆
            start = waterStartTime[0] + waterDuration[0];
            for (int i = 1; i < len2; i++) start = Math.Min(start, waterStartTime[i] + waterDuration[i]);
            for (int i = 0; i < len1; i++) result = Math.Min(result, Math.Max(start, landStartTime[i]) + landDuration[i]);

            return result;
        }
    }
}
