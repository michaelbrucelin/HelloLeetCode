using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2221
{
    public class Solution2221_2 : Interface2221
    {
        /// <summary>
        /// 数学
        /// 逻辑同Solution2221_err，采用更靠谱的方式计算组合数
        /// 
        /// 逻辑没问题，竟然TLE，输入的数据是1000个0
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangularSum(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int result = 0, n = nums.Length - 1, m = (nums.Length - 2) >> 1;
            for (int i = 0; i <= m; i++) result = (result + (nums[i] + nums[n - i]) * Combination(n, i)) % 10;
            if ((n & 1) == 0) result = (result + nums[n >> 1] * Combination(n, (n >> 1))) % 10;

            return result;

            int Combination(int n, int k)
            {
                if (k == 0) return 1;
                if (k == 1) return n % 10;

                BigInteger result = 1;
                for (int i = n - k + 1; i <= n; i++) result *= i;
                for (int i = k; i > 1; i--) result /= i;
                return (int)(result % 10);
            }
        }
    }
}
