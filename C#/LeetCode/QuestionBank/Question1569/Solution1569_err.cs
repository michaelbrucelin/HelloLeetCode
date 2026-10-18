using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1569
{
    public class Solution1569_err : Interface1569
    {
        /// <summary>
        /// 数学
        /// 数组的第一个元素一定是根
        /// 数组其余元素比根小的是左子树，假定有m个，x1, x2, ... xm
        ///             比根大的是右子树，假定有n个，y1, y2, ... yn
        /// 则将这m+n个元素合并成一个排列，并且保证两个排列各自的相对顺序不变即可
        /// 所以总结果为 (m+n)!/m!/n! 个
        /// 
        /// 思路是错的，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumOfWays(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int m = 0, n = 0, len = nums.Length;
            for (int i = 1; i < len; i++) if (nums[i] < nums[0]) m++; else n++;
            if (m < n) (m, n) = (n, m);  // 保证 m >= n，小驱动大
            if (n == 0) return 0;

            int[] args = new int[n];
            args[0] = m + n;
            for (int i = 1; i < n; i++) args[i] = args[i - 1] - 1;
            for (int i = 2; i <= n; i++) for (int j = 0; j < n; j++) if (args[j] % i == 0) { args[j] /= i; break; }

            long result = args[0];
            for (int i = 1; i < n; i++) result = result * args[i] % MOD;
            return result != 0 ? (int)result - 1 : MOD - 1;
        }
    }
}
