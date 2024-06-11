using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3040
{
    public class Solution3040 : Interface3040
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxOperations(int[] nums)
        {
            if (nums.Length == 2) return 1;

            int result = 0, len = nums.Length;
            Dictionary<(int left, int right), int> memory = new Dictionary<(int left, int right), int>();
            HashSet<int> targets = new HashSet<int>() { nums[0] + nums[1], nums[len - 1] + nums[len - 2], nums[0] + nums[len - 1] };
            foreach (int target in targets)
            {
                memory.Clear();
                result = Math.Max(result, dfs(nums, 0, len - 1, target, memory));
            }

            return result;
        }

        private int dfs(int[] nums, int left, int right, in int target, Dictionary<(int left, int right), int> memory)
        {
            if (left >= right) return 0;
            if (memory.ContainsKey((left, right))) return memory[(left, right)];

            memory.Add((left, right), 0);
            if (left + 1 == right)
            {
                if (nums[left] + nums[right] == target) memory[(left, right)]++;
            }
            else
            {
                if (nums[left] + nums[left + 1] == target) memory[(left, right)] = Math.Max(memory[(left, right)], dfs(nums, left + 2, right, target, memory) + 1);
                if (nums[right] + nums[right - 1] == target) memory[(left, right)] = Math.Max(memory[(left, right)], dfs(nums, left, right - 2, target, memory) + 1);
                if (nums[left] + nums[right] == target) memory[(left, right)] = Math.Max(memory[(left, right)], dfs(nums, left + 1, right - 1, target, memory) + 1);
            }

            return memory[(left, right)];
        }
    }
}
