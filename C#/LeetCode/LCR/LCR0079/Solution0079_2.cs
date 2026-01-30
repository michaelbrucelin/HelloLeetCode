using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0079
{
    public class Solution0079_2 : Interface0079
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = [];
            dfs([], 0);

            return result;

            void dfs(List<int> list, int idx)
            {
                if (idx == nums.Length) { result.Add(list); return; }
                dfs(list, idx + 1);
                dfs([.. list, nums[idx]], idx + 1);
            }
        }
    }
}
