using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0081
{
    public class Solution0081 : Interface0081
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            if (candidates.Length == 0) return [];

            int len = candidates.Length;
            IList<IList<int>> result = [];
            dfs(0, 0, []);

            return result;

            void dfs(int idx, int curr, List<int> buffer)
            {
                if (curr >= target)
                {
                    if (curr == target) result.Add(buffer);
                    return;
                }

                if (idx + 1 < len) dfs(idx + 1, curr, buffer);
                List<int> _buffer = [.. buffer, candidates[idx]];
                dfs(idx, curr + candidates[idx], _buffer);
            }
        }

        /// <summary>
        /// 逻辑同CombinationSum()，改为回溯
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            if (candidates.Length == 0) return [];

            int len = candidates.Length;
            IList<IList<int>> result = [];
            List<int> buffer = [];
            dfs(0, 0);

            return result;

            void dfs(int idx, int curr)
            {
                if (curr >= target)
                {
                    if (curr == target) result.Add([.. buffer]);
                    return;
                }

                if (idx + 1 < len) dfs(idx + 1, curr);
                buffer.Add(candidates[idx]);
                dfs(idx, curr + candidates[idx]);
                buffer.RemoveAt(buffer.Count - 1);
            }
        }
    }
}
