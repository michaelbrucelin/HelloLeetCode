using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1766
{
    public class Solution1766 : Interface1766
    {
        /// <summary>
        /// 暴力解
        /// 1. 将边集数组中的无向边改为有向边，变的方向指向根
        /// 2. 从叶子节点逐步向前找第一个互质的节点
        ///     由于题目限定nums[i]的范围是[1,50]，而暴力查找必然会检验每两个顶点是否互质，所以提前预处理出nums中所有的互质数对
        ///     也可以打表，预处理出[1,50]的所有互质数对
        /// 
        /// 如果树比较深，或者直接降维成数组（斜树），那么必然会TLE，写着玩的
        /// 逻辑没有问题，但是不出意外的TLE了，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int[] GetCoprimes(int[] nums, int[][] edges)
        {
            // 预处理互质数对
            int[] _nums = nums.Distinct().ToArray();
            Dictionary<int, HashSet<int>> pair = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < _nums.Length; i++) pair.Add(_nums[i], new HashSet<int>());
            if (pair.ContainsKey(1)) pair[1].Add(1);
            for (int i = 0; i < _nums.Length - 1; i++) for (int j = i + 1; j < _nums.Length; j++) if (GetGCD(_nums[i], _nums[j]) == 1)
                    {
                        pair[_nums[i]].Add(_nums[j]); pair[_nums[j]].Add(_nums[i]);
                    }
            // 将edges处理为有树（邻接表）
            int n = nums.Length;
            HashSet<int>[] _tree = new HashSet<int>[n];
            for (int i = 0; i < n; i++) _tree[i] = new HashSet<int>();
            foreach (var edge in edges)
            {
                _tree[edge[0]].Add(edge[1]); _tree[edge[1]].Add(edge[0]);
            }
            // 将树处理为有向树，tree[n] 表示节点n的父节点
            int[] tree = new int[n]; tree[0] = -1;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0); int node;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                foreach (int next in _tree[node])
                {
                    tree[next] = node; _tree[next].Remove(node); queue.Enqueue(next);
                }
            }

            // 暴力查找结果
            int[] result = new int[n]; result[0] = -1;
            for (int i = 1, j; i < n; i++)
            {
                j = tree[i];
                while (j != -1 && !pair[nums[i]].Contains(nums[j])) j = tree[j];
                result[i] = j;
            }

            return result;
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y)
            {
                if (x == 1 || y == 1) { x = 1; break; }
                switch ((x & 1, y & 1))
                {
                    case (0, 0): x >>= 1; y >>= 1; move++; break;
                    case (0, 1): x >>= 1; break;
                    case (1, 0): y >>= 1; break;
                    default:  // (1, 1)
                        if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                        break;
                }
            }

            return x << move;
        }
    }
}
