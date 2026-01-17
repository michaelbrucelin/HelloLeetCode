using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3047
{
    public class Solution3047 : Interface3047
    {
        /// <summary>
        /// 排序，枚举
        /// 剪枝：
        /// 1. 如果矩形B完全在矩形A内部，在A与B计算过重叠区域后，矩形B就可以忽略了
        /// 2. 如果当前矩形的长或宽小于当前的结果，这个矩形可以忽略（包含了第一点）
        /// </summary>
        /// <param name="bottomLeft"></param>
        /// <param name="topRight"></param>
        /// <returns></returns>
        public long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
        {
            int len = bottomLeft.Length;
            int[] order = new int[len];
            for (int i = 0; i < len; i++) order[i] = i;
            Comparer<int> comparer = Comparer<int>.Create((x, y) =>
            {
                if (bottomLeft[x][0] != bottomLeft[y][0]) return bottomLeft[x][0] - bottomLeft[y][0];
                if (topRight[x][0] != topRight[y][0]) return topRight[y][0] - topRight[x][0];
                if (bottomLeft[x][1] != bottomLeft[y][1]) return bottomLeft[x][1] - bottomLeft[y][1];
                if (topRight[x][1] != topRight[y][1]) return topRight[y][1] - topRight[x][1];
                return 0;
            });
            Array.Sort(order, comparer);

            int border = 0, _border, _width, _high;
            bool[] mask = new bool[len];
            for (int _i = 0, i; _i < len; _i++) if (!mask[i = order[_i]] || topRight[i][0] - bottomLeft[i][0] <= border || topRight[i][1] - bottomLeft[i][1] <= border)
                {
                    _border = 0;
                    for (int _j = _i + 1, j; _j < len; _j++)
                    {
                        if (bottomLeft[j = order[_j]][0] > topRight[i][0]) break;
                        if (topRight[j][0] <= topRight[i][0] && bottomLeft[j][1] >= bottomLeft[i][1] && topRight[j][1] <= topRight[i][1])
                        {
                            _border = Math.Max(_border, Math.Min(topRight[j][0] - bottomLeft[j][0], topRight[j][1] - bottomLeft[j][1]));
                            mask[j] = true;
                        }
                        else
                        {
                            _width = Math.Min(topRight[i][0], topRight[j][0]) - Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                            _high = Math.Min(topRight[i][1], topRight[j][1]) - Math.Max(bottomLeft[i][1], bottomLeft[j][1]);
                            _border = Math.Max(_border, Math.Min(_width, _high));
                        }
                    }
                    border = Math.Max(border, _border);
                }

            return 1L * border * border;
        }

        /// <summary>
        /// 逻辑完全同LargestSquareArea()，y轴方向的排序没有用
        /// </summary>
        /// <param name="bottomLeft"></param>
        /// <param name="topRight"></param>
        /// <returns></returns>
        public long LargestSquareArea2(int[][] bottomLeft, int[][] topRight)
        {
            int len = bottomLeft.Length;
            int[] order = new int[len];
            for (int i = 0; i < len; i++) order[i] = i;
            Comparer<int> comparer = Comparer<int>.Create((x, y) =>
            {
                if (bottomLeft[x][0] != bottomLeft[y][0]) return bottomLeft[x][0] - bottomLeft[y][0];
                if (topRight[x][0] != topRight[y][0]) return topRight[y][0] - topRight[x][0];
                return 0;
            });
            Array.Sort(order, comparer);

            int border = 0, _border, _width, _high;
            bool[] mask = new bool[len];
            for (int _i = 0, i; _i < len; _i++) if (!mask[i = order[_i]] || topRight[i][0] - bottomLeft[i][0] <= border || topRight[i][1] - bottomLeft[i][1] <= border)
                {
                    _border = 0;
                    for (int _j = _i + 1, j; _j < len; _j++)
                    {
                        if (bottomLeft[j = order[_j]][0] > topRight[i][0]) break;
                        if (topRight[j][0] <= topRight[i][0] && bottomLeft[j][1] >= bottomLeft[i][1] && topRight[j][1] <= topRight[i][1])
                        {
                            _border = Math.Max(_border, Math.Min(topRight[j][0] - bottomLeft[j][0], topRight[j][1] - bottomLeft[j][1]));
                            mask[j] = true;
                        }
                        else
                        {
                            _width = Math.Min(topRight[i][0], topRight[j][0]) - Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                            _high = Math.Min(topRight[i][1], topRight[j][1]) - Math.Max(bottomLeft[i][1], bottomLeft[j][1]);
                            _border = Math.Max(_border, Math.Min(_width, _high));
                        }
                    }
                    border = Math.Max(border, _border);
                }

            return 1L * border * border;
        }
    }
}
