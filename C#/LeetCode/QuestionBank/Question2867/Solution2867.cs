using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2867
{
    public class Solution2867 : Interface2867
    {
        /// <summary>
        /// 暴力枚举
        /// 题目的本质还是在求解树中任意两点之间的最短路径问题，而树中两节点的最短路径就是两节点到最近公共祖先的两端路径的和
        /// 1. 以节点1为根，构建树，Dictionary<int, HashSet<int>>
        /// 2. 遍历树，并统计根到每个节点的路径及其路径上质数的个数(List<int> path, int cnt)[]
        /// 3. 枚举任意两节点，计算两节点的最短路径及其路径上的质数数量，for(int i =1; i<n; i++) for(int j=i+1; j<=n; j++) ... ...
        /// 
        /// 逻辑没问题，意料之中的TLE了，参考测试用例04
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public long CountPaths(int n, int[][] edges)
        {
            if (n <= 1) return 0;

            // 预处理质数集合
            HashSet<int> primes = new HashSet<int>();
            for (int i = 1; i <= n; i++) if (IsPrime(i)) primes.Add(i);
            // 构建树，0是哑节点
            Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>() { { 0, new List<int>() { 1 } } };
            foreach (var edge in edges)
            {
                tree.TryAdd(edge[0], new List<int>()); tree[edge[0]].Add(edge[1]);
                tree.TryAdd(edge[1], new List<int>()); tree[edge[1]].Add(edge[0]);
            }
            // 遍历树，并统计根到每个节点的路径及其路径上质数的个数
            (List<int> path, int cnt)[] paths = new (List<int> path, int cnt)[n + 1];
            paths[0] = (new List<int>(), 0);
            DFSTree(tree, 0, paths, primes);
            // 枚举
            long result = 0;
            for (int i = 1; i < n; i++) for (int j = i + 1; j <= n; j++)
                {
                    if (IsLegalPath(paths, i, j, primes)) result++;
                }

            return result;
        }

        private bool IsLegalPath((List<int> path, int cnt)[] paths, int u, int v, HashSet<int> primes)
        {
            int parent = 1, left = 0, right = Math.Min(paths[u].path.Count, paths[v].path.Count) - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (paths[u].path[mid] == paths[v].path[mid])
                {
                    parent = paths[u].path[mid]; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            int cnt = paths[u].cnt + paths[v].cnt - (paths[parent].cnt << 1) + (primes.Contains(parent) ? 1 : 0);
            return cnt == 1;
        }

        private void DFSTree(Dictionary<int, List<int>> tree, int node, (List<int> path, int cnt)[] paths, HashSet<int> primes)
        {
            List<int> path = paths[node].path; int cnt = paths[node].cnt;
            foreach (int next in tree[node])
            {
                paths[next] = (new List<int>(path) { next }, cnt + (primes.Contains(next) ? 1 : 0));
                tree[next].Remove(node);
                DFSTree(tree, next, paths, primes);
            }
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if ((n & 1) == 0) return false;

            int boundary = (int)Math.Floor(Math.Sqrt(n));
            for (int i = 3; i <= boundary; i += 2) if (n % i == 0) return false;

            return true;
        }
    }
}
