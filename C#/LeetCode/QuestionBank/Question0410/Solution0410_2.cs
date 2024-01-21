using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0410
{
    public class Solution0410_2 : Interface0410
    {
        /// <summary>
        /// 逻辑与Solution0140完全一样，只是将dfs部分改成了返回值版
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
            return dfs(sums, len, 0, k, memory);
        }

        private int dfs(int[] sums, int len, int id, int k, Dictionary<(int, int), int> memory)
        {
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

            return memory[(id, k)];
        }
    }
}
