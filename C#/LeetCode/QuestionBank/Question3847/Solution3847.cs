using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3847
{
    public class Solution3847 : Interface3847
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ScoreDifference(int[] nums)
        {
            int[] scores = new int[2];
            int idx = 0, len = nums.Length;
            for (int i = 0, j = 5, num; i < len; i++)
            {
                num = nums[i];
                if ((num & 1) == 1) idx ^= num & 1;     // idx = 1 - idx;
                if (i == j) { idx = 1 - idx; j += 6; }
                scores[idx] += num;
            }

            return scores[0] - scores[1];
        }
    }
}
