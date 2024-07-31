using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0045
{
    public class Solution0045_2 : Interface0045
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int len = nums.Length;
            int[] steps = new int[len];
            Array.Fill(steps, -1); steps[^1] = 0;
            dfs(0);

            return steps[0];

            void dfs(int start)
            {
                if (steps[start] != -1) return;

                int _step = len + 1;
                for (int id = start + 1; id < len && id <= start + nums[start]; id++)
                {
                    if (steps[id] == -1) dfs(id);
                    _step = Math.Min(_step, steps[id]);
                }
                steps[start] = _step + 1;
            }
        }
    }
}
