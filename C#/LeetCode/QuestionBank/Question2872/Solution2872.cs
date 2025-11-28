using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2872
{
    public class Solution2872 : Interface2872
    {
        /// <summary>
        /// 贪心 + 换根DP
        /// 首先，如果整颗树不被k整除，则一定无解
        /// 其次，一棵树，拆除任意一条边，变为两棵树
        /// 所以只要能拆为两颗“合法”的树，直接拆，然后递归，这种贪心思路得到解一定正确
        ///     反证法很容易证明，这里就不描述了
        /// 每次枚举一条边，时间复杂度太高，所以这里使用换根DP
        /// 
        /// 思路整体感觉是正确的，先不写了
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="values"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
        {
            if (k == 1) return n;
            if (n == 1) return values[0] % k == 0 ? 1 : 0;
            int total = 0; foreach (int value in values) total += value;
            if (total % k != 0) return 0;

            // 预处理为图
            HashSet<int>[] graph = new HashSet<int>[n];
            for (int i = 0; i < n; i++) graph[i] = [];
            foreach (int[] edge in edges) { graph[edge[0]].Add(edge[1]); graph[edge[1]].Add(edge[0]); }

            return dp(0, total);

            int dp(int root, int sum)
            {
                if (graph[root].Count == 0) return 1;

                int root1 = root, root2 = graph[root].First();
                HashSet<int> visited = [root2];
                int sum1 = dfs(root1, visited);
                if (sum1 % k == 0) return dp(root1, sum1) + dp(root2, sum - sum1);

                throw new NotImplementedException();
            }

            int dfs(int root, HashSet<int> visited)
            {
                if (visited.Contains(root)) return 0;

                int sum = values[root];
                visited.Add(root);
                foreach (int next in graph[root]) if (!visited.Contains(next)) sum += dfs(next, visited);

                return sum;
            }
        }
    }
}
