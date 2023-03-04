using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0495
{
    public class Solution0495 : Interface0495
    {
        /// <summary>
        /// 分析
        /// timeSeries两个元素之间的间隔与duration，取其中较小的值
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            int result = duration;  // 最后一次攻击一定可以持续duration
            for (int i = 1; i < timeSeries.Length; i++)
                result += Math.Min(timeSeries[i] - timeSeries[i - 1], duration);

            return result;
        }

        /// <summary>
        /// API
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int FindPoisonedDuration2(int[] timeSeries, int duration)
        {
            return duration + Enumerable.Range(1, timeSeries.Length - 1)
                                        .Select(i => Math.Min(timeSeries[i] - timeSeries[i - 1], duration))
                                        .Sum();
        }

        /// <summary>
        /// API2
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int FindPoisonedDuration3(int[] timeSeries, int duration)
        {
            return duration + timeSeries.Skip(1)
                                        .Select((i, id) => Math.Min(i - timeSeries[id], duration))
                                        .Sum();
        }
    }
}
