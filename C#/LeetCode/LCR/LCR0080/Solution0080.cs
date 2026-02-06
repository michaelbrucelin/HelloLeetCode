using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0080
{
    public class Solution0080 : Interface0080
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = [];
            dfs([], 1);

            return result;

            void dfs(List<int> list, int _n)
            {
                if (list.Count == k) { result.Add(list); return; }
                if (n - _n + 1 < k - list.Count) return;
                dfs([.. list, _n], _n + 1);
                dfs(list, _n + 1);
            }
        }

        /// <summary>
        /// 逻辑同Combine()，改为回溯
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine2(int n, int k)
        {
            IList<IList<int>> result = [];
            int[] buffer = new int[k];
            backtrack(1, 0);

            return result;

            void backtrack(int _n, int idx)
            {
                if (idx == k) { result.Add([.. buffer]); return; }
                if (n - _n + 1 < k - idx) return;
                buffer[idx] = _n;
                backtrack(_n + 1, idx + 1);
                backtrack(_n + 1, idx);
            }
        }
    }
}
