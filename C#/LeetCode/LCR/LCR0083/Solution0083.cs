using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0083
{
    public class Solution0083 : Interface0083
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = [];
            dfs([], [.. nums]);

            return result;

            void dfs(List<int> list, HashSet<int> set)
            {
                if (set.Count == 0) { result.Add(list); return; }
                foreach (int x in set)
                {
                    HashSet<int> _set = [.. set];
                    _set.Remove(x);
                    dfs([.. list, x], _set);
                }
            }
        }

        /// <summary>
        /// 逻辑完全同Permute()，改为回溯
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<IList<int>> Permute2(int[] nums)
        {
            throw new NotImplementedException();
        }
    }
}
