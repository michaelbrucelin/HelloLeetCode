using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1782
{
    public class Solution1782 : Interface1782
    {
        /// <summary>
        /// 暴力查询
        /// 1. 预处理两份数据
        ///     1. 一维数组，每个顶点的边数
        ///     2. 邻接矩阵，每两个顶点间的边数
        /// 2. 每个query利用上面的预处理的两份数据暴力查询
        /// 
        /// 逻辑没错，本以为会TLE，结果先迎来了MLE，参考测试用例03
        /// 本地运行内存占用1.7GB
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] CountPairs(int n, int[][] edges, int[] queries)
        {
            int[] ent = new int[n]; int[,] adj = new int[n, n];
            for (int id = 0, i, j; id < edges.Length; id++)
            {
                i = edges[id][0] - 1; j = edges[id][1] - 1;
                ent[i]++; ent[j]++; adj[i, j]++; adj[j, i]++;
            }

            int len = queries.Length; int[] result = new int[len];
            for (int id = 0, cnt, tar; id < len; id++)
            {
                cnt = 0; tar = queries[id];
                for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++)
                    {
                        if (ent[i] + ent[j] - adj[i, j] > tar) cnt++;
                    }
                result[id] = cnt;
            }

            return result;
        }

        /// <summary>
        /// 与CountPairs()一样，只不过将邻接矩阵改为了数组的数组，理论上可以节省一半的内存
        /// 本地运行内存占用880MB
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] CountPairs2(int n, int[][] edges, int[] queries)
        {
            int[] ent = new int[n]; int[][] adj = new int[n][];
            for (int id = 0; id < n - 1; id++) adj[id] = new int[n - id - 1];
            for (int id = 0, i, j; id < edges.Length; id++)
            {
                i = edges[id][0] - 1; j = edges[id][1] - 1;
                if (j < i) (i, j) = (j, i);
                ent[i]++; ent[j]++; adj[i][n - j - 1]++;
            }

            int len = queries.Length; int[] result = new int[len];
            for (int id = 0, cnt, tar; id < len; id++)
            {
                cnt = 0; tar = queries[id];
                for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++)
                    {
                        if (ent[i] + ent[j] - adj[i][n - j - 1] > tar) cnt++;
                    }
                result[id] = cnt;
            }

            return result;
        }
    }
}
