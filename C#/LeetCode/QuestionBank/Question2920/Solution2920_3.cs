using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2920
{
    public class Solution2920_3 : Interface2920
    {
        /// <summary>
        /// DFS + 记忆化搜索 + 剪枝
        /// 逻辑同Solution2920_2，添加了剪枝
        /// 1. 题目限定coins[i] <= 10000，所以，如果折半了达到了14次，结果一定为0
        /// 
        /// 击败了0%，但是总算通过了，击败了0%也可能是没有C#解导致的。。。找不到其它C#解
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

            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            return dfs(0, 0);

            int dfs(int node, int lazy)  // lazy: 折半次数
            {
                if (lazy > 13) return 0;
                if (memory.ContainsKey((node, lazy))) return memory[(node, lazy)];

                int r1, r2, coin = lazy < 32 ? (coins[node] >> lazy) : 0;

                // 方法1
                r1 = coin - k;
                foreach (int _node in tree[node]) r1 += dfs(_node, lazy);
                // 方法2
                r2 = coin >> 1;
                lazy++;
                foreach (int _node in tree[node]) r2 += dfs(_node, lazy);

                memory[(node, --lazy)] = Math.Max(r1, r2);
                return memory[(node, lazy)];
            }
        }
    }
}
