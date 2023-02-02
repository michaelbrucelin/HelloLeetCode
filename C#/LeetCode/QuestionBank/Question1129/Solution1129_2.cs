using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1129
{
    public class Solution1129_2 : Interface1129
    {
        private enum EC { red, bule };

        /// <summary>
        /// BFS
        /// 每个节点记录两个值：1. 由红边进入的最小值；2. 由蓝边进入的最小值
        /// 从起点开始延逐个边向前进，如果到达一个新节点时，得到的结果大于等于当前已有的结果，则退出
        /// </summary>
        /// <param name="n"></param>
        /// <param name="redEdges"></param>
        /// <param name="blueEdges"></param>
        /// <returns></returns>
        public int[] ShortestAlternatingPaths2(int n, int[][] redEdges, int[][] blueEdges)
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

            Queue<(int start, EC color)> queue = new Queue<(int, EC)>();
            queue.Enqueue((0, EC.red)); queue.Enqueue((0, EC.bule));
            int step = 0, cnt;
            while ((cnt = queue.Count) > 0)
            {
                step++;
                for (int i = 0; i < cnt; i++)
                {
                    var point = queue.Dequeue();
                    if (point.color == EC.red)
                    {
                        if (!bEdges.ContainsKey(point.start)) continue;
                        foreach (int next in bEdges[point.start])
                        {
                            if (bBuf[next] == -1 || step < bBuf[next])
                            {
                                bBuf[next] = step; queue.Enqueue((next, EC.bule));
                            }
                        }
                    }
                    else
                    {
                        if (!rEdges.ContainsKey(point.start)) continue;
                        foreach (int next in rEdges[point.start])
                        {
                            if (rBuf[next] == -1 || step < rBuf[next])
                            {
                                rBuf[next] = step; queue.Enqueue((next, EC.red));
                            }
                        }
                    }
                }
            }

            int[] result = new int[n];
            for (int i = 0; i < n; i++) result[i] = (rBuf[i] != -1 && bBuf[i] != -1) ? Math.Min(rBuf[i], bBuf[i]) : Math.Max(rBuf[i], bBuf[i]);
            return result;
        }

        /// <summary>
        /// 逻辑与ShortestAlternatingPaths()相同，使用代码技巧精简代码
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

            Queue<(int start, EC color)> queue = new Queue<(int, EC)>();
            queue.Enqueue((0, EC.red)); queue.Enqueue((0, EC.bule));
            int step = 0, cnt;
            while ((cnt = queue.Count) > 0)
            {
                step++;
                for (int i = 0; i < cnt; i++)
                {
                    var point = queue.Dequeue();
                    Dictionary<int, HashSet<int>> nextEdges; int[] buf; EC nextColor;
                    if (point.color == EC.red)
                    {
                        nextEdges = bEdges; buf = bBuf; nextColor = EC.bule;
                    }
                    else
                    {
                        nextEdges = rEdges; buf = rBuf; nextColor = EC.red;
                    }

                    if (!nextEdges.ContainsKey(point.start)) continue;
                    foreach (int next in nextEdges[point.start])
                    {
                        if (buf[next] == -1 || step < buf[next])
                        {
                            buf[next] = step; queue.Enqueue((next, nextColor));
                        }
                    }
                }
            }

            int[] result = new int[n];
            for (int i = 0; i < n; i++) result[i] = (rBuf[i] != -1 && bBuf[i] != -1) ? Math.Min(rBuf[i], bBuf[i]) : Math.Max(rBuf[i], bBuf[i]);
            return result;
        }
    }
}
