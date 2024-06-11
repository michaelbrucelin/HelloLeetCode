using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3040
{
    public class Solution3040_2 : Interface3040
    {
        /// <summary>
        /// 逻辑同Solution3040，只是将记忆化搜索使用的字典改为了二维数组，试一下
        /// 直接看代码，Solution3040与官解中的代码只有记忆化字典与二维数组的区别，但是时间复杂度相差很大，这里试一下
        /// 
        /// 果然，只是将字典改为了二维数组，时间复杂度得到了大幅提升（1546ms --> 236ms）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxOperations(int[] nums)
        {
            if (nums.Length == 2) return 1;

            int result = 0, len = nums.Length;
            int[,] memory = new int[len, len];
            HashSet<int> targets = new HashSet<int>() { nums[0] + nums[1], nums[len - 1] + nums[len - 2], nums[0] + nums[len - 1] };
            foreach (int target in targets)
            {
                for (int i = 0; i < len; i++) for (int j = 0; j < len; j++) memory[i, j] = -1;
                result = Math.Max(result, dfs(nums, 0, len - 1, target, memory));
            }

            return result;
        }

        private int dfs(int[] nums, int left, int right, in int target, int[,] memory)
        {
            if (left >= right) { memory[left, right] = 0; return 0; }
            if (memory[left, right] >= 0) return memory[left, right];

            memory[left, right] = 0;
            if (left + 1 == right)
            {
                if (nums[left] + nums[right] == target) memory[left, right] = 1;
            }
            else
            {
                if (nums[left] + nums[left + 1] == target) memory[left, right] = Math.Max(memory[left, right], dfs(nums, left + 2, right, target, memory) + 1);
                if (nums[right] + nums[right - 1] == target) memory[left, right] = Math.Max(memory[left, right], dfs(nums, left, right - 2, target, memory) + 1);
                if (nums[left] + nums[right] == target) memory[left, right] = Math.Max(memory[left, right], dfs(nums, left + 1, right - 1, target, memory) + 1);
            }

            return memory[left, right];
        }
    }
}
