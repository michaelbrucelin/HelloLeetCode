using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3599
{
    public class Solution3599_err : Interface3599
    {
        /// <summary>
        /// 前缀和 + dfs + 记忆化搜索
        /// x ^ x = 0，因此可以使用前缀和的思想来预处理子数组的异或值
        /// 
        /// 读错题了，题目要求的是所有子数组最大异或值的最小值，而这里写的是所有子数组异或值和的最大值... ...
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinXor(int[] nums, int k)
        {
            int len = nums.Length;
            int[] sums = new int[len + 1], xors = new int[len + 1];
            for (int i = 0; i < len; i++) { sums[i + 1] = sums[i] + nums[i]; xors[i + 1] = xors[i] ^ nums[i]; }
            int[,] memory = new int[len, k + 1];
            for (int i = 0; i < len; i++) for (int j = 0; j <= k; j++) memory[i, j] = -1;

            return dfs(0, k);

            int dfs(int idx, int k)
            {
                if (k == 1) return xors[len] ^ xors[idx];
                if (len - idx == k) return sums[len] - sums[idx];
                if (memory[idx, k] != -1) return memory[idx, k];

                int result = 0;
                for (int i = idx; i <= len - k + 1; i++) result = Math.Max(result, (xors[i + 1] ^ xors[idx]) + dfs(i + 1, k - 1));

                memory[idx, k] = result;
                return result;
            }
        }
    }
}
