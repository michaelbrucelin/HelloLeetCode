using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2221
{
    public class Solution2221_3 : Interface2221
    {
        /// <summary>
        /// 数学
        /// 逻辑同Solution2221_2，优化计算组合数的环节
        /// 
        /// 速度还没Solution2221原地模拟快呢...
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangularSum(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int result = 0, n = nums.Length - 1, len = nums.Length;
            BigInteger[] coms = new BigInteger[len];
            Combination();
            for (int i = 0; i < len; i++) result += (int)(coms[i] * nums[i] % 10);

            return result % 10;

            void Combination()
            {
                int m = (nums.Length - 2) >> 1;
                coms[0] = coms[n] = 1;
                for (int i = 1; i <= m; i++) coms[i] = coms[n - i] = coms[i - 1] * (n - i + 1) / i;
                if ((n & 1) == 0) coms[n >> 1] = coms[m] * (n - m) / (m + 1);
            }
        }
    }
}
