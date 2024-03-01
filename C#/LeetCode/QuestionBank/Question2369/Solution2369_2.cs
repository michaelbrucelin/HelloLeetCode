using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2369
{
    public class Solution2369_2 : Interface2369
    {
        /// <summary>
        /// DFS
        /// 逻辑同Solution2369，添加了记忆化搜索来优化速度
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ValidPartition(int[] nums)
        {
            Dictionary<int, bool> memory = new Dictionary<int, bool>();
            memory[nums.Length] = true;
            memory[nums.Length - 1] = false;  // 题目限定nums.Length >= 2

            return ValidPartition(nums, 0, memory);
        }

        private bool ValidPartition(int[] nums, int start, Dictionary<int, bool> memory)
        {
            if (memory.ContainsKey(start)) return memory[start]; memory.Add(start, false);

            int len = nums.Length;
            // if (len - start == 0) return true; else if (len - start == 1) return false;  // 初始化在memory中
            if (nums[start] == nums[start + 1])
            {
                if (ValidPartition(nums, start + 2, memory))
                {
                    memory[start] = true;
                }
                else if (start + 2 < len && nums[start] == nums[start + 2])
                {
                    if (ValidPartition(nums, start + 3, memory)) memory[start] = true;
                }
            }
            else if (start + 2 < len && nums[start] + 1 == nums[start + 1] && nums[start] + 2 == nums[start + 2])
            {
                if (ValidPartition(nums, start + 3, memory)) memory[start] = true;
            }

            return memory[start];
        }
    }
}
