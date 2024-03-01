using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2369
{
    public class Solution2369_2_2 : Interface2369
    {
        /// <summary>
        /// DFS
        /// 逻辑同Solution2369_2，只是将递归1:1翻译为显示的栈迭代，写着玩的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ValidPartition(int[] nums)
        {
            Dictionary<int, bool> memory = new Dictionary<int, bool>();
            memory[nums.Length] = true;
            memory[nums.Length - 1] = false;  // 题目限定nums.Length >= 2

            Stack<int> stack = new Stack<int>();
            stack.Push(0); int start, len = nums.Length;
            while (stack.Count > 0)
            {
                start = stack.Pop();
                if (memory.ContainsKey(start)) continue;

                // if (len - start == 0) memory[start] = true; else if (len - start == 1) memory[start] = false;  // 初始化在memory中
                bool flag = false;
                if (!memory.ContainsKey(start + 2))
                {
                    stack.Push(start); stack.Push(start + 2);
                    flag = true;
                }
                if (start + 2 < len && !memory.ContainsKey(start + 3))
                {
                    if (!flag) stack.Push(start); stack.Push(start + 3);
                    flag = true;
                }
                if (flag) continue;

                memory.Add(start, false);
                if (nums[start] == nums[start + 1])
                {
                    if (memory[start + 2])
                    {
                        memory[start] = true;
                    }
                    else if (start + 2 < len && nums[start] == nums[start + 2])
                    {
                        if (memory[start + 3]) memory[start] = true;
                    }
                }
                else if (start + 2 < len && nums[start] + 1 == nums[start + 1] && nums[start] + 2 == nums[start + 2])
                {
                    if (memory[start + 3]) memory[start] = true;
                }
            }

            return memory[0];
        }
    }
}
