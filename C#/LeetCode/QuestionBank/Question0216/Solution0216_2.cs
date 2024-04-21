using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0216
{
    public class Solution0216_2 : Interface0216
    {
        /// <summary>
        /// DFS
        /// 每一项，都只有选与不选两种可能。
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            int min = (k * (k + 1)) >> 1, max = (k * (19 - k)) >> 1;
            if (n < min || n > max) return new List<IList<int>>();
            if (n == min) return new List<IList<int>>() { Enumerable.Range(1, k).ToList() };
            if (n == max) return new List<IList<int>>() { Enumerable.Range(8 - k, k).ToList() };

            List<IList<int>> result = new List<IList<int>>();
            dfs(1, k, n, 0, new List<int>(), result);

            return result;
        }

        private void dfs(int curr, int k, int n, int sum, List<int> list, List<IList<int>> result)
        {
            // 不选择curr
            if (curr < 9) dfs(curr + 1, k, n, sum, list, result);

            // 选择curr
            int _sum = sum + curr;
            if (_sum > n) return;
            List<int> _list = new List<int>(list) { curr };
            if (_sum == n)
            {
                if (k == 1) result.Add(_list);
            }
            else
            {
                if (curr < 9 && k > 0) dfs(curr + 1, k - 1, n, _sum, _list, result);
            }
        }
    }
}
