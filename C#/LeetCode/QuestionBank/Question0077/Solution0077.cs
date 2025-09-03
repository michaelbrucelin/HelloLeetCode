using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0077
{
    public class Solution0077 : Interface0077
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();
            dfs(1, []);

            return result;

            void dfs(int start, List<int> list)                 // 从 [start,n] 中选 k-list.Count 个
            {
                if (list.Count == k) { result.Add(list); return; }
                if (k - list.Count > n - start + 1) return;
                dfs(start + 1, new List<int>(list) { start });  // 选择start
                dfs(start + 1, list);                           // 不选择start
            }
        }
    }
}
