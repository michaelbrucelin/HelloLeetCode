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
            for (int i = 0; i < len; i += 2)
            {
            }

            return scores[0] - scores[1];
        }
    }
}
