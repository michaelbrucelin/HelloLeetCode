using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3040
{
    public class Solution3040_3 : Interface3040
    {
        /// <summary>
        /// DP
        /// 本质上同Solution3040_2，Solution3040_2中的DFS是自顶向下，这里的DP是自底向上
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
                for (int i = 0; i < len; i++) for (int j = 0; j < len; j++) memory[i, j] = 0;
                for (int i = 0; i < len - 1; i++) if (nums[i] + nums[i + 1] == target) memory[i, i + 1] = 1;
                for (int span = 2; span < len; span++) for (int i = 0; i < len - span; i++)
                    {
                        if (nums[i] + nums[i + 1] == target) memory[i, i + span] = Math.Max(memory[i, i + span], memory[i + 2, i + span] + 1);
                        if (nums[i + span] + nums[i + span - 1] == target) memory[i, i + span] = Math.Max(memory[i, i + span], memory[i, i + span - 2] + 1);
                        if (nums[i] + nums[i + span] == target) memory[i, i + span] = Math.Max(memory[i, i + span], memory[i + 1, i + span - 1] + 1);
                    }
                result = Math.Max(result, memory[0, len - 1]);
            }

            return result;
        }
    }
}
