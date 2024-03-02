using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2368
{
    public class Solution2368 : Interface2368
    {
        /// <summary>
        /// DFS
        /// 逻辑没问题，但是超出了CLR允许的递归最大层数，参考测试用例03
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="restricted"></param>
        /// <returns></returns>
        public int ReachableNodes(int n, int[][] edges, int[] restricted)
        {
            HashSet<int> set = new HashSet<int>(restricted);
            if (set.Contains(0)) return 0;

            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new List<int>();
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }

            return dfs(tree, 0, -1, set);
        }

        private int dfs(List<int>[] tree, int id, int pre, HashSet<int> set)
        {
            if (set.Contains(id)) return 0;

            int result = 1;
            foreach (int _id in tree[id]) if (_id != pre) result += dfs(tree, _id, id, set);

            return result;
        }
    }
}
