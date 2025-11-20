using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3745
{
    public class Solution3745 : Interface3745
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximizeExpressionOfThree(int[] nums)
        {
            Array.Sort(nums);
            return nums[^1] + nums[^2] - nums[0];
        }

        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximizeExpressionOfThree2(int[] nums)
        {
            int[] dist = new int[201];
            foreach (int num in nums) dist[num + 100]++;

            int result = 0, ptr = 200;
            while (true) if (dist[ptr] > 0) { result += ptr - 100; dist[ptr]--; break; } else { ptr--; }
            while (true) if (dist[ptr] > 0) { result += ptr - 100; dist[ptr]--; break; } else { ptr--; }
            ptr = 0;
            while (true) if (dist[ptr] > 0) { result -= ptr - 100; break; } else { ptr++; }

            return result;
        }
    }
}
