using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3505
{
    public class Solution3505 : Interface3505
    {
        /// <summary>
        /// 中位数定理 + 预处理 + DFS + 记忆化搜索
        /// 由中位数定理可知子数组的目标值就是其中位数，进而可以预处理出以每个位置开头的长度为x的子数组的结果
        /// 然后就相当于“打家劫舍”取k个结果了，每两个结果间隔至少为x
        /// 
        /// 难点在于每个子数组（滑动窗口）的中位数怎样求，这里先暴力求取
        /// 逻辑没问题，TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="x"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MinOperations(int[] nums, int x, int k)
        {
            int len = nums.Length;
            long[] mins = new long[len - x + 1];
            for (int i = 0, j = x - 1; j < len; i++, j++) mins[i] = MinOperation(nums, i, x);
            Dictionary<(int, int), long> memory = new Dictionary<(int, int), long>();

            return dfs(mins, 0, k, x, memory);

            static long dfs(long[] mins, int start, int k, int x, Dictionary<(int, int), long> memory)
            {
                if (k == 0) return 0;
                if (start >= mins.Length) return -1;
                if (memory.ContainsKey((start, k))) return memory[(start, k)];

                long result;
                long r1 = dfs(mins, start + x, k - 1, x, memory);
                long r2 = dfs(mins, start + 1, k, x, memory);
                switch ((r1, r2))
                {
                    case (-1, -1): result = -1; break;
                    case (_, -1): result = mins[start] + r1; break;
                    case (-1, _): result = r2; break;
                    default: result = Math.Min(mins[start] + r1, r2); break;
                }

                memory.Add((start, k), result);
                return result;
            }

            static long MinOperation(int[] nums, int start, int x)
            {
                int[] arr = nums[start..(start + x)];
                Array.Sort(arr);

                long result = 0; int mid = (x - 1) >> 1;
                for (int i = 0; i < mid; i++) result += arr[mid] - arr[i];
                for (int i = mid + 1; i < x; i++) result += arr[i] - arr[mid];

                return result;
            }
        }
    }
}
