using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3333
{
    public class Solution3333 : Interface3333
    {
        /// <summary>
        /// 枚举 + DFS + 记忆化搜索
        /// 1. 列出可以删除的可能
        ///     例如 aaabbbbcdd  ->  2 3 1，即可以删除2个a，3个b，1个d
        /// 2. 枚举可删除的数量[0 .. length-k]，每一种可能使用DFS计算可能数
        /// 
        /// 逻辑没问题，TLE，参考测试用例04
        /// </summary>
        /// <param name="word"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int PossibleStringCount(string word, int k)
        {
            if (k >= word.Length) return 1;

            List<int> cnts = new List<int>();
            int len = word.Length, pl = 0, pr;
            while (pl < len)
            {
                pr = pl;
                while (pr + 1 < len && word[pr + 1] == word[pr]) pr++;
                if (pr > pl) cnts.Add(pr - pl);
                pl = pr + 1;
            }
            List<int> sums = cnts.ToList();  // cuts的后缀和，稍后剪枝时会用
            for (int i = sums.Count - 2; i >= 0; i--) sums[i] += sums[i + 1];

            int result = 0, limit = len - k;
            const int MOD = (int)1e9 + 7;
            Dictionary<(int cnt, int id), int> memory = new Dictionary<(int cnt, int id), int>();
            for (int i = 0; i <= limit; i++) result = (result + dfs(i, 0)) % MOD;

            return result;

            int dfs(int cnt, int id)
            {
                if (cnt == 0) return 1;
                if (id >= cnts.Count || cnt > sums[id]) return 0;
                if (memory.ContainsKey((cnt, id))) return memory[(cnt, id)];

                if (cnt == sums[id])
                {
                    memory.Add((cnt, id), 1);
                }
                else
                {
                    int count = 0, max_get = Math.Min(cnts[id], cnt);
                    for (int i = 0; i <= max_get; i++) count = (count + dfs(cnt - i, id + 1)) % MOD;
                    memory.Add((cnt, id), count);
                }

                return memory[(cnt, id)];
            }
        }
    }
}
