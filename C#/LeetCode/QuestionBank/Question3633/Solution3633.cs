using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3633
{
    public class Solution3633 : Interface3633
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="landStartTime"></param>
        /// <param name="landDuration"></param>
        /// <param name="waterStartTime"></param>
        /// <param name="waterDuration"></param>
        /// <returns></returns>
        public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
        {
            int result = int.MaxValue, len1 = landStartTime.Length, len2 = waterStartTime.Length;
            for (int i = 0, d1, e1, d2, e2; i < len1; i++)
            {
                d1 = landDuration[i]; e1 = landStartTime[i] + landDuration[i];
                for (int j = 0; j < len2; j++)
                {
                    d2 = waterDuration[j]; e2 = waterStartTime[j] + waterDuration[j];
                    result = Math.Min(result, Math.Max(e2, e1 + d2));
                    result = Math.Min(result, Math.Max(e1, e2 + d1));
                }
            }

            return result;
        }
    }
}
