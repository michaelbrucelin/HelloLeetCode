using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0565
{
    public class Solution0565 : Interface0565
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ArrayNesting(int[] nums)
        {
            if (nums.Length == 1) return 1;

            int result = 0, len = nums.Length;
            bool[] mask = new bool[len];
            for (int i = 0, p, cnt; i < len; i++) if (!mask[i])
                {
                    p = i; cnt = 1; mask[p] = true;
                    while (!mask[p = nums[p]]) { cnt++; mask[p] = true; }
                    result = Math.Max(result, cnt);
                }

            return result;
        }
    }
}
