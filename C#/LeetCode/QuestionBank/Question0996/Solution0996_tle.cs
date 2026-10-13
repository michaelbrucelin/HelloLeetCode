using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0996
{
    public class Solution0996_tle : Interface0996
    {
        /// <summary>
        /// 暴力搜索图
        /// 核心思路
        /// 1. 将数组的每一项看成图的一个顶点，如果两个顶点的和是一个完全平方数，则二者之间有一条无向边
        /// 2. 则枚举每一个顶点为起点，然后回溯尝试“走完”整张图即可
        /// 其它
        /// 1. 使用并查集判断是不是连通子图，不是的话，就不用尝试了
        /// 2. 相同的值要统计数量，例如 [2,2,2] 只有一个排列，而不是6个排列
        /// 
        /// 逻辑没有问题，TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumSquarefulPerms(int[] nums)
        {
            int n = nums.Length;
            bool[,] graph = new bool[n, n];
            Disjoint disjoint = new Disjoint(n);
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (freq.TryGetValue(nums[i], out int cnt)) freq[nums[i]] = ++cnt; else freq.Add(nums[i], 1);
                for (int j = i + 1; j < n; j++) if (is_square(nums[i] + nums[j]))
                    {
                        graph[i, j] = graph[j, i] = true; disjoint.Join(i, j);
                    }
            }
            if (disjoint.Count > 1) return 0;

            int result = 0, visited = 0, MASK = (1 << n) - 1;
            for (int i = 0; i < n; i++) backtrack(graph, visited, i, n, MASK, ref result);
            foreach (int x in freq.Values) for (int y = x; y > 1; y--) result /= y;
            return result;

            static void backtrack(bool[,] graph, int visited, int idx, int n, int MASK, ref int cnt)
            {
                visited |= 1 << idx;
                if (visited == MASK) cnt++;
                else
                {
                    for (int i = 0; i < n; i++)
                        if (((visited >> i) & 1) != 1 && graph[idx, i]) backtrack(graph, visited, i, n, MASK, ref cnt);
                }
                visited ^= 1 << idx;
            }

            static bool is_square(long x)
            {
                long _x = (long)Math.Sqrt(x);
                return _x * _x == x;
            }
        }

        public class Disjoint
        {
            public Disjoint(int n)
            {
                father = new int[n];
                rank = new int[n];
                _count = n;
                for (int i = 0; i < n; i++) father[i] = i;
            }

            private int[] father, rank;
            public int Count { get { return _count; } }
            private int _count;

            public bool Join(int x, int y)
            {
                x = Find(x); y = Find(y);
                if (x == y) return false;

                _count--;
                switch (rank[x] - rank[y])
                {
                    case < 0: father[x] = y; break;
                    case > 0: father[y] = x; break;
                    default: father[y] = x; rank[x]++; break;
                }

                return true;
            }

            public int Find(int x)
            {
                int fa = x;
                while (father[fa] != fa) fa = father[fa];
                int _x;
                while (father[x] != fa) { _x = father[x]; father[x] = fa; x = _x; }

                return fa;
            }
        }
    }
}
