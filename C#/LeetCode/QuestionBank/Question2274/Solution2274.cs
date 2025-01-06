using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2274
{
    public class Solution2274 : Interface2274
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="special"></param>
        /// <returns></returns>
        public int MaxConsecutive(int bottom, int top, int[] special)
        {
            Array.Sort(special);
            int result = special[0] - bottom, len = special.Length;
            for (int i = 1; i < len; i++) result = Math.Max(result, special[i] - special[i - 1] - 1);
            result = Math.Max(result, top - special[^1]);

            return result;
        }
    }
}
