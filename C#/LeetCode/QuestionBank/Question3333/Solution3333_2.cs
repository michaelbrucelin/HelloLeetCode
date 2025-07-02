using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3333
{
    public class Solution3333_2 : Interface3333
    {
        /// <summary>
        /// 枚举 + DFS + 记忆化搜索
        /// 逻辑完全同Solution3333，只是将字典换成数组试一下
        /// 
        /// 只是将字典换成数据，快了不少，但是OLE了，参考测试用例05
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
            int[,] memory = new int[limit + 1, cnts.Count];
            for (int i = 0; i < limit + 1; i++) for (int j = 0; j < cnts.Count; j++) memory[i, j] = -1;
            for (int i = 0; i <= limit; i++) result = (result + dfs(i, 0)) % MOD;

            return result;

            int dfs(int cnt, int id)
            {
                if (cnt == 0) return 1;
                if (id >= cnts.Count || cnt > sums[id]) return 0;
                if (memory[cnt, id] != -1) return memory[cnt, id];

                if (cnt == sums[id])
                {
                    memory[cnt, id] = 1;
                }
                else
                {
                    int count = 0, max_get = Math.Min(cnts[id], cnt);
                    for (int i = 0; i <= max_get; i++) count = (count + dfs(cnt - i, id + 1)) % MOD;
                    memory[cnt, id] = count;
                }

                return memory[cnt, id];
            }
        }
    }
}
