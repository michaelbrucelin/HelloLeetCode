using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0416
{
    public class Solution0416 : Interface0416
    {
        /// <summary>
        /// DFS
        /// 排列组合
        /// 
        /// TLE，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            int len = nums.Length, sum = 0;
            for (int i = 0; i < len; i++) sum += nums[i];
            if ((sum & 1) != 0) return false;

            sum >>= 1;
            return dfs(0, sum);

            bool dfs(int id, int target)
            {
                if (id >= len) return false;
                if (nums[id] == target) return true;
                if (nums[id] < target)
                {
                    return dfs(id + 1, target - nums[id]) || dfs(id + 1, target);
                }
                else
                {
                    return dfs(id + 1, target);
                }
            }
        }
    }
}
