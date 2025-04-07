using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0416
{
    public class Solution0416_2 : Interface0416
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 排列组合
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            int len = nums.Length, sum = 0;
            for (int i = 0; i < len; i++) sum += nums[i];
            if ((sum & 1) != 0) return false;

            sum >>= 1;
            Dictionary<(int, int), bool> memory = new Dictionary<(int, int), bool>();
            return dfs(0, sum);

            bool dfs(int id, int target)
            {
                if (id >= len) return false;
                if (nums[id] == target) return true;

                if (!memory.ContainsKey((id, target)))
                {
                    if (nums[id] < target)
                    {
                        memory.Add((id, target), dfs(id + 1, target - nums[id]) || dfs(id + 1, target));
                    }
                    else
                    {
                        memory.Add((id, target), dfs(id + 1, target));
                    }
                }

                return memory[(id, target)];
            }
        }
    }
}
