using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0055
{
    public class Solution0055_2 : Interface0055
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 1) return true;

            int len = nums.Length;
            bool[] visited = new bool[len];
            visited[0] = true;
            return dfs(0);

            bool dfs(int start)
            {
                if (start + nums[start] >= len - 1) return true;
                for (int id = start + 1; id < len && id <= start + nums[start]; id++) if (!visited[id])
                    {
                        if (dfs(id)) return true;
                        visited[id] = true;
                    }

                return false;
            }
        }
    }
}
