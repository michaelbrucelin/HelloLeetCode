using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2049
{
    public class Solution2049 : Interface2049
    {
        /// <summary>
        /// 递归
        /// 知道了两个子树的大小，就知道删除这个节点后余下三部分的大小了
        /// </summary>
        /// <param name="parents"></param>
        /// <returns></returns>
        public int CountHighestScoreNodes(int[] parents)
        {
            if (parents.Length <= 3) return 2;  // 题目限定至少两个节点

            int n = parents.Length;
            int[,] tree = new int[n, 2];
            for (int child = 1, parent; child < n; child++)
            {
                parent = parents[child];
                if (tree[parent, 0] == 0) tree[parent, 0] = child; else tree[parent, 1] = child;
            }

            Dictionary<long, int> map = new Dictionary<long, int>();
            rec(0);

            long max = 0;
            foreach (long key in map.Keys) max = Math.Max(max, key);
            return map[max];

            int rec(int node)
            {
                int size, lsize, rsize, osize;
                switch ((tree[node, 0], tree[node, 1]))
                {
                    case (0, 0): lsize = 0; rsize = 0; break;
                    case (0, _): lsize = 0; rsize = rec(tree[node, 1]); break;
                    case (_, 0): lsize = rec(tree[node, 0]); rsize = 0; break;
                    case (_, _): lsize = rec(tree[node, 0]); rsize = rec(tree[node, 1]); break;
                }

                size = lsize + rsize + 1;
                osize = n - size;
                long key = 1L * (lsize == 0 ? 1 : lsize) * (rsize == 0 ? 1 : rsize) * (osize == 0 ? 1 : osize);
                map.TryAdd(key, 0); map[key]++;

                return size;
            }
        }
    }
}
