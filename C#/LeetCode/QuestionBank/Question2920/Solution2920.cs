using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2920
{
    public class Solution2920 : Interface2920
    {
        /// <summary>
        /// DFS
        /// 暴力DFS，大概率会TLE，先写出来在靠开展通过记忆化搜索或者DP来优化
        /// 
        /// 逻辑没问题，意料之中的TLE，但是没想到坚持到了倒数第2个测试用例，参考测试用例03
        /// 测试用例03直接递归栈溢出了。。。
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="coins"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumPoints(int[][] edges, int[] coins, int k)
        {
            if (k == 0) return coins.Sum();

            // 创建有向树
            int n = coins.Length;
            HashSet<int>[] tree = new HashSet<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new HashSet<int>();
            foreach (int[] edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }
            for (int i = 0; i < n; i++) foreach (int j in tree[i]) tree[j].Remove(i);

            return dfs(0, 0);

            int dfs(int node, int lazy)  // lazy: 折半次数
            {
                int r1, r2, coin = lazy < 32 ? (coins[node] >> lazy) : 0;
                // for (int i = 0; i < lazy && coin > 0; i++) coin >>= 1;  // 脑残写法

                // 方法1
                r1 = coin - k;
                foreach (int _node in tree[node]) r1 += dfs(_node, lazy);
                // 方法2
                r2 = coin >> 1;
                lazy++;
                foreach (int _node in tree[node]) r2 += dfs(_node, lazy);

                return Math.Max(r1, r2);
            }
        }
    }
}
