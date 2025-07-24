using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2322
{
    public class Solution2322 : Interface2322
    {
        /// <summary>
        /// 暴力枚举
        /// 枚举每两条边，大概率会TLE，先写出来再想优化的事，直觉上有递推关系
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int MinimumScore(int[] nums, int[][] edges)
        {
            int n = nums.Length;
            HashSet<int>[] tree = new HashSet<int>[n];
            for (int i = 0; i < n; i++) tree[i] = [];
            foreach (int[] edge in edges) { tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]); }

            int xor_all = 0;
            for (int i = 0; i < n; i++) xor_all ^= nums[i];                   // 计算出两个子树的xor值，可以O(1)计算第三个子树的xor值

            int result = int.MaxValue, _result, p1, p2, p3;
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            for (int i = n - 2; i > 0; i--) for (int j = i - 1; j > -1; j--)  // 遍历删除的两条边
                {
                    HashSet<int>[] _tree = copytree();
                    _tree[edges[i][0]].Remove(edges[i][1]); _tree[edges[i][1]].Remove(edges[i][0]);
                    _tree[edges[j][0]].Remove(edges[j][1]); _tree[edges[j][1]].Remove(edges[j][0]);
                    Array.Fill(visited, false);
                    p1 = pointree(_tree, edges[i][0]);
                    p2 = pointree(_tree, edges[i][1]);
                    p3 = xor_all ^ p1 ^ p2;
                    _result = Math.Max(Math.Abs(p1 - p2), Math.Max(Math.Abs(p1 - p3), Math.Abs(p2 - p3)));
                    result = Math.Min(result, _result);
                    if (result == 0) return 0;
                }

            return result;

            HashSet<int>[] copytree()
            {
                HashSet<int>[] _tree = new HashSet<int>[n];
                for (int i = 0; i < n; i++) _tree[i] = [.. tree[i]];
                return _tree;
            }

            int pointree(HashSet<int>[] tree, int node)
            {
                int result = 0, _node;
                queue.Enqueue(node);
                while (queue.Count > 0)
                {
                    if (visited[_node = queue.Dequeue()]) continue;
                    result ^= nums[_node];
                    visited[_node] = true;
                    foreach (int __node in tree[_node]) queue.Enqueue(__node);
                }
                return result;
            }
        }
    }
}
