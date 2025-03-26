using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2829
{
    public class Solution2829 : Interface2829
    {
        /// <summary>
        /// 贪心
        /// 每个 x+y=k 的数对取小的即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumSum(int n, int k)
        {
            int result = 0, k2 = k >> 1;
            if (n <= k2)
            {
                for (int i = 1; i <= n; i++) result += i;
            }
            else
            {
                for (int i = 1; i <= k2; i++) result += i;
                for (int i = 0; i < n - k2; i++) result += k + i;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同MinimumSum()，将其中的for循环改为数学公式
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumSum2(int n, int k)
        {
            int result, k2 = k >> 1;
            if (n <= k2)
            {
                result = n * (n + 1) >> 1;
            }
            else
            {
                result = (k2 * (k2 + 1) + (k + k + n - k2 - 1) * (n - k2)) >> 1;
            }

            return result;
        }
    }
}
