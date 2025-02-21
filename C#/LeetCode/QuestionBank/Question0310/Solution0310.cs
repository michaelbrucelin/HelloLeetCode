using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0310
{
    public class Solution0310 : Interface0310
    {
        /// <summary>
        /// 暴力查找
        /// 以每一个顶点为根BFS一次，大概率会TLE，写着玩的
        /// 
        /// 逻辑没问题，不出意外的TLE了，参考测试用例03
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new List<int>();
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }

            int[] heights = new int[n];
            int minHeight = n;
            Queue<(int v, int u)> queue = new Queue<(int v, int u)>();
            (int v, int u) item;
            for (int i = 0, _height = 0, _cnt = 0; i < n; i++)
            {
                _height = 0;
                queue.Enqueue((i, -1));
                while ((_cnt = queue.Count) > 0)
                {
                    _height++;
                    for (int j = 0; j < _cnt; j++)
                    {
                        item = queue.Dequeue();
                        foreach (int _v in tree[item.v]) if (_v != item.u) queue.Enqueue((_v, item.v));
                    }
                }
                heights[i] = _height;
                minHeight = Math.Min(minHeight, _height);
            }

            List<int> result = new List<int>();
            for (int i = 0; i < n; i++) if (heights[i] == minHeight) result.Add(i);
            return result;
        }
    }
}
