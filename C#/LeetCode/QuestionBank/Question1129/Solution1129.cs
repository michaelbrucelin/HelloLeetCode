using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1129
{
    public class Solution1129 : Interface1129
    {
        private enum EC { red, bule };

        /// <summary>
        /// DFS
        /// 每个节点记录两个值：1. 由红边进入的最小值；2. 由蓝边进入的最小值
        /// 从起点开始延逐个边向前进，如果到达一个新节点时，得到的结果大于等于当前已有的结果，则退出
        /// </summary>
        /// <param name="n"></param>
        /// <param name="redEdges"></param>
        /// <param name="blueEdges"></param>
        /// <returns></returns>
        public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
        {
            if (n == 1) return new int[] { 0 };

            int[] rBuf = new int[n]; for (int i = 1; i < n; i++) rBuf[i] = -1;
            int[] bBuf = new int[n]; for (int i = 1; i < n; i++) bBuf[i] = -1;
            Dictionary<int, HashSet<int>> rEdges = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < redEdges.Length; i++)
            {
                int key = redEdges[i][0], value = redEdges[i][1];
                if (rEdges.ContainsKey(key)) rEdges[key].Add(value); else rEdges.Add(key, new HashSet<int>() { value });
            }
            Dictionary<int, HashSet<int>> bEdges = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < blueEdges.Length; i++)
            {
                int key = blueEdges[i][0], value = blueEdges[i][1];
                if (bEdges.ContainsKey(key)) bEdges[key].Add(value); else bEdges.Add(key, new HashSet<int>() { value });
            }

            // DFS
            dfs2(0, EC.red, 0, rBuf, bBuf, rEdges, bEdges);
            dfs2(0, EC.bule, 0, rBuf, bBuf, rEdges, bEdges);

            int[] result = new int[n];
            for (int i = 0; i < n; i++) result[i] = (rBuf[i] != -1 && bBuf[i] != -1) ? Math.Min(rBuf[i], bBuf[i]) : Math.Max(rBuf[i], bBuf[i]);
            return result;
        }

        private void dfs(int start, EC color, int step, int[] rBuf, int[] bBuf, Dictionary<int, HashSet<int>> rEdges, Dictionary<int, HashSet<int>> bEdges)
        {
            if (color == EC.red)
            {
                if (!bEdges.ContainsKey(start)) return;
                foreach (int next in bEdges[start])
                {
                    if (bBuf[next] == -1 || step + 1 < bBuf[next])
                    {
                        bBuf[next] = step + 1;
                        dfs(next, EC.bule, step + 1, rBuf, bBuf, rEdges, bEdges);
                    }
                }
            }
            else
            {
                if (!rEdges.ContainsKey(start)) return;
                foreach (int next in rEdges[start])
                {
                    if (rBuf[next] == -1 || step + 1 < rBuf[next])
                    {
                        rBuf[next] = step + 1;
                        dfs(next, EC.red, step + 1, rBuf, bBuf, rEdges, bEdges);
                    }
                }
            }
        }

        /// <summary>
        /// 逻辑与dfs()相同，使用代码技巧精简代码
        /// </summary>
        /// <param name="start"></param>
        /// <param name="color"></param>
        /// <param name="step"></param>
        /// <param name="rBuf"></param>
        /// <param name="bBuf"></param>
        /// <param name="rEdges"></param>
        /// <param name="bEdges"></param>
        private void dfs2(int start, EC color, int step, int[] rBuf, int[] bBuf, Dictionary<int, HashSet<int>> rEdges, Dictionary<int, HashSet<int>> bEdges)
        {
            Dictionary<int, HashSet<int>> nextEdges; int[] buf; EC nextColor;
            if (color == EC.red)
            {
                nextEdges = bEdges; buf = bBuf; nextColor = EC.bule;
            }
            else
            {
                nextEdges = rEdges; buf = rBuf; nextColor = EC.red;
            }

            if (!nextEdges.ContainsKey(start)) return;
            foreach (int next in nextEdges[start])
            {
                if (buf[next] == -1 || step + 1 < buf[next])
                {
                    buf[next] = step + 1;
                    dfs(next, nextColor, step + 1, rBuf, bBuf, rEdges, bEdges);
                }
            }
        }
    }
}
