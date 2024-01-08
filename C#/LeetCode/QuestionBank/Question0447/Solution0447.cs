using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0447
{
    public class Solution0447 : Interface0447
    {
        /// <summary>
        /// 枚举 + 排列组合
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int NumberOfBoomerangs(int[][] points)
        {
            Dictionary<int, Dictionary<(int x, int y), List<(int x, int y)>>> map = new Dictionary<int, Dictionary<(int x, int y), List<(int x, int y)>>>();
            int len = points.Length, dis, xi, yi, xj, yj;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    xi = points[i][0]; yi = points[i][1]; xj = points[j][0]; yj = points[j][1];
                    dis = (xi - xj) * (xi - xj) + (yi - yj) * (yi - yj);
                    if (!map.ContainsKey(dis)) map.Add(dis, new Dictionary<(int x, int y), List<(int x, int y)>>());
                    if (!map[dis].ContainsKey((xi, yi))) map[dis].Add((xi, yi), new List<(int x, int y)>());
                    map[dis][(xi, yi)].Add((xj, yj));
                    if (!map[dis].ContainsKey((xj, yj))) map[dis].Add((xj, yj), new List<(int x, int y)>());
                    map[dis][(xj, yj)].Add((xi, yi));
                }

            int result = 0;
            foreach (var dic in map.Values) foreach (var list in dic.Values)
                {
                    if (list.Count > 1) result += list.Count * (list.Count - 1);
                }
            return result;
        }

        /// <summary>
        /// 逻辑同NumberOfBoomerangs()，每个距离的每个起点，只需要记录终点数量就可以了，不需要用List记录具体的终点
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int NumberOfBoomerangs2(int[][] points)
        {
            Dictionary<int, Dictionary<(int x, int y), int>> map = new Dictionary<int, Dictionary<(int x, int y), int>>();
            int len = points.Length, dis, xi, yi, xj, yj;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    xi = points[i][0]; yi = points[i][1]; xj = points[j][0]; yj = points[j][1];
                    dis = (xi - xj) * (xi - xj) + (yi - yj) * (yi - yj);
                    if (!map.ContainsKey(dis)) map.Add(dis, new Dictionary<(int x, int y), int>());
                    if (map[dis].ContainsKey((xi, yi))) map[dis][(xi, yi)]++; else map[dis].Add((xi, yi), 1);
                    if (map[dis].ContainsKey((xj, yj))) map[dis][(xj, yj)]++; else map[dis].Add((xj, yj), 1);
                }

            int result = 0;
            foreach (var dic in map.Values) foreach (var cnt in dic.Values)
                {
                    result += cnt * (cnt - 1);
                }
            return result;
        }
    }
}
