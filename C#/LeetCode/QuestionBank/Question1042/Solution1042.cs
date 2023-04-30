using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1042
{
    public class Solution1042 : Interface1042
    {
        /// <summary>
        /// 贪心
        /// 对图的每一个连通分量BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public int[] GardenNoAdj(int n, int[][] paths)
        {
            List<int>[] adj = new List<int>[n];
            for (int i = 0; i < n; i++) adj[i] = new List<int>();
            for (int i = 0; i < paths.Length; i++)
            {
                adj[paths[i][0] - 1].Add(paths[i][1] - 1);
                adj[paths[i][1] - 1].Add(paths[i][0] - 1);
            }

            int[] result = new int[n];
            Queue<int> queue = new Queue<int>(); int visitcnt = 0;
            SortedSet<int> vexid = new SortedSet<int>();      // 1,2,3,4，用于获取下一个顶点的值
            for (int i = 0; i < n; i++)                       // 题目没说是连通图
            {
                if (result[i] != 0) continue; else queue.Enqueue(i);
                while (queue.Count > 0)
                {
                    int vex = queue.Dequeue();
                    vexid.Add(1); vexid.Add(2); vexid.Add(3); vexid.Add(4);
                    for (int j = 0, next; j < adj[vex].Count; j++)
                    {
                        next = adj[vex][j];
                        if (result[next] != 0) vexid.Remove(result[next]); else queue.Enqueue(next);
                    }
                    result[vex] = vexid.First(); visitcnt++;  // 题目保证一定有解，所以这里直接获取集合的第一个值
                }
                if (visitcnt == n) break;
            }

            return result;
        }

        /// <summary>
        /// 与GardenNoAdj()一样，将List<int>[]改为int[,]，一种类邻接矩阵的二维数组
        /// 由于每个花园最多只有3条边，所以没有使用邻接矩阵
        /// </summary>
        /// <param name="n"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public int[] GardenNoAdj2(int n, int[][] paths)
        {
            int[,] adj = new int[n, 3]; int[] ptr = new int[n];
            for (int i = 0; i < paths.Length; i++)
            {
                adj[paths[i][0] - 1, ptr[paths[i][0] - 1]++] = paths[i][1];
                adj[paths[i][1] - 1, ptr[paths[i][1] - 1]++] = paths[i][0];
            }

            int[] result = new int[n];
            Queue<int> queue = new Queue<int>(); int visitcnt = 0;
            SortedSet<int> vexid = new SortedSet<int>();      // 1,2,3,4，用于获取下一个顶点的值
            for (int i = 0; i < n; i++)                       // 题目没说是连通图
            {
                if (result[i] != 0) continue; else queue.Enqueue(i);
                while (queue.Count > 0)
                {
                    int vex = queue.Dequeue();
                    vexid.Add(1); vexid.Add(2); vexid.Add(3); vexid.Add(4);
                    for (int j = 0, next; j < 3; j++)
                    {
                        if ((next = adj[vex, j] - 1) == -1) continue;
                        if (result[next] != 0) vexid.Remove(result[next]); else queue.Enqueue(next);
                    }
                    result[vex] = vexid.First(); visitcnt++;  // 题目保证一定有解，所以这里直接获取集合的第一个值
                }
                if (visitcnt == n) break;
            }

            return result;
        }
    }
}
