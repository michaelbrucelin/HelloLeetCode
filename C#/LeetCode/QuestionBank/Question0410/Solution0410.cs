using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0410
{
    public class Solution0410 : Interface0410
    {
        /// <summary>
        /// DFS
        /// F(n, k)表示数组从索引为n的位置起，拆分为k个子数组，每个子数组和的最小值，则题目的解就是F(0, k)
        /// F(0, k) = Min(Min(Sum(nums[0..0]), F(1, k-1)),
        ///               Min(Sum(nums[0..1]), F(2, k-1)),
        ///               ... ...
        ///               Min(Sum(nums[0..(len-k)]), F(len-k+1, k-1))
        ///              )
        /// 逻辑没问题，本地执行不算慢，但是提交TLE（应该是所有测试用例总用时有限制），参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SplitArray(int[] nums, int k)
        {
            if (k == 1) return nums.Sum();
            if (k == nums.Length) return nums.Max();

            int len = nums.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + nums[i];

            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            dfs(sums, len, 0, k, memory);

            return memory[(0, k)];
        }

        private void dfs(int[] sums, int len, int id, int k, Dictionary<(int, int), int> memory)
        {
            // if (memory.ContainsKey((id, k))) return;
            if (k == 1)
            {
                memory.Add((id, k), sums[len] - sums[id]);
            }
            else
            {
                int min = sums[len];
                for (int i = id; i < len - k + 1; i++)
                {
                    if (!memory.ContainsKey((i + 1, k - 1))) dfs(sums, len, i + 1, k - 1, memory);
                    min = Math.Min(min, Math.Max(sums[i + 1] - sums[id], memory[(i + 1, k - 1)]));
                }
                memory.Add((id, k), min);
            }
        }
    }
}
