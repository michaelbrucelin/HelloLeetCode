using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2867
{
    public class Solution2867_2 : Interface2867
    {
        /// <summary>
        /// 贡献法
        /// 本质上是贡献法，计算每一个质数节点贡献了多少个结果
        /// 遍历每一个质数，以这个质数为根，计算每棵子树直接相连的非质数节点数量x
        ///     对于任意两棵子树，合法路径数量为 x*y
        ///     对于每一棵子树，合法路径数量为 x
        /// 
        /// 逻辑没问题，比Solution2867快了很多，但是依然TLE，参考测试用例05
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public long CountPaths(int n, int[][] edges)
        {
            if (n <= 1) return 0;

            // 预处理质数集合，线性筛
            HashSet<int> primes = new HashSet<int>(GetPrimes(n + 1));
            // 构建树
            Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
            foreach (var edge in edges)
            {
                tree.TryAdd(edge[0], new List<int>()); tree[edge[0]].Add(edge[1]);
                tree.TryAdd(edge[1], new List<int>()); tree[edge[1]].Add(edge[0]);
            }
            // 枚举质数
            long result = 0;
            foreach (int prime in primes) result += CountPath(tree, prime, primes);

            return result;
        }

        /// <summary>
        /// 计算以质数节点root为根的合法路径数量
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="root"></param>
        /// <param name="primes"></param>
        /// <returns></returns>
        private long CountPath(Dictionary<int, List<int>> tree, int root, HashSet<int> primes)
        {
            long result = 0;
            List<long> cnts = new List<long>(); int _cnt;
            foreach (int child in tree[root])
            {
                if (primes.Contains(child)) continue;
                _cnt = CountNode(tree, child, primes);
                result += _cnt;
                cnts.Add(_cnt);
            }
            for (int i = 0; i < cnts.Count - 1; i++) for (int j = i + 1; j < cnts.Count; j++)
                {
                    result += cnts[i] * cnts[j];
                }

            return result;
        }

        /// <summary>
        /// 计算以合数节点root为起点，合数节点的数量，BFS
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="root"></param>
        /// <param name="parent"></param>
        /// <param name="primes"></param>
        /// <returns></returns>
        private int CountNode(Dictionary<int, List<int>> tree, int root, HashSet<int> primes)
        {
            int result = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(root);
            HashSet<int> visited = new HashSet<int>(); int node;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                result++; visited.Add(node);
                foreach (int child in tree[node])
                {
                    if (!visited.Contains(child) && !primes.Contains(child)) queue.Enqueue(child);
                }
            }

            return result;
        }

        /*
        /// <summary>
        /// 计算以合数节点root为起点，合数节点的数量，DFS
        /// 
        /// DFS会因为递归层数太多导致栈溢出，.net core 8.0，参考测试用例04
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="root"></param>
        /// <param name="primes"></param>
        /// <returns></returns>
        private int CountNode(Dictionary<int, List<int>> tree, int root, int parent, HashSet<int> primes)
        {
            int result = 1;
            foreach (int child in tree[root])
            {
                if (child == root || primes.Contains(child)) continue;
                result += CountNode(tree, child, root, primes);
            }

            return result;
        }
        */

        /// <summary>
        /// 计算[1, n]之间的质数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private List<int> GetPrimes(int n)
        {
            List<int> result = new List<int>();
            bool[] mask = new bool[n]; Array.Fill(mask, true);
            for (int i = 2; i < n; i++)
            {
                if (mask[i]) result.Add(i);
                for (int j = 0; j < result.Count && i * result[j] < n; j++)
                {
                    mask[i * result[j]] = false;
                    if (i % result[j] == 0) break;
                }
            }

            return result;
        }
    }
}
