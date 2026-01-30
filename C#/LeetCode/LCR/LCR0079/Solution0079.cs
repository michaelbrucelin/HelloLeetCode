using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0079
{
    public class Solution0079 : Interface0079
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = [[]];
            int cnt;
            foreach (int num in nums)
            {
                cnt = result.Count;
                for (int i = 0; i < cnt; i++) result.Add([.. result[i], num]);
            }

            return result;
        }
    }
}
