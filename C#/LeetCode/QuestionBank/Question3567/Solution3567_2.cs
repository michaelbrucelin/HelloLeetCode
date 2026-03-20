using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3567
{
    public class Solution3567_2 : Interface3567
    {
        /// <summary>
        /// 滑动窗口 + 归并排序 + 懒删除
        /// 整体思路同Solution3567，优化排序的部分
        /// 假定当前 k*k 的子矩阵已经在一个数组中排好序了，数组除了记录值之外，还记录了值在原数组中的位置
        /// 这样在计算下一个 k*k 子矩阵时（要么向右偏移一列，要么向下偏移一行）
        ///     将新的 k 个值排序
        ///     将新的 k 个值与当前的 k*k 个值归并，由于记录了值在原数组中的位置，所以移除的 k 个值是已知的
        /// 当前这道题目的数据量暴力解或许就是最好的解，这里这样优化知识写着玩的
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] MinAbsDiff(int[][] grid, int k)
        {
            int rcnt = grid.Length - k + 1, ccnt = grid[0].Length - k + 1;
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            if (k == 1) return result;

            int K = k * k;
            (int, int[])[] buffer_u = new (int, int[])[K];  // (value, [rowid, colid])
            (int, int[])[] buffer_l = new (int, int[])[K];  // buffer_u 上方, buffer_l 左侧
            (int, int[])[] buffer_n = new (int, int[])[K];
            (int, int[])[] append = new (int, int[])[k];
            Comparer<(int, int[])> comparer = Comparer<(int, int[])>.Create((x, y) => x.Item1 - y.Item1);

            int idx = 0;
            for (int c = 0; c < k; c++) buffer_u[idx++] = (0, [-1, c]);
            for (int r = 0; r < k - 1; r++) for (int c = 0; c < k; c++) buffer_u[idx++] = (grid[r][c], [r, c]);
            Array.Sort(buffer_u, comparer);

            for (int r = 0; r < rcnt; r++)
            {
                for (int _c = 0, _r = r + k - 1; _c < k; _c++) append[_c] = (grid[_r][_c], [_r, _c]);
                Array.Sort(append, comparer);
                merge(buffer_u, append, buffer_l, 0, r - 1);
                Array.Copy(buffer_l, buffer_u, K);
                result[r][0] = minabs(buffer_l);

                for (int c = 1; c < ccnt; c++)
                {
                    for (int _r = r, _c = c + k - 1, R = r + k; _r < R; _r++) append[_r - r] = (grid[_r][_c], [_r, _c]);
                    Array.Sort(append, comparer);
                    merge(buffer_l, append, buffer_n, 1, c - 1);
                    Array.Copy(buffer_n, buffer_l, K);
                    result[r][c] = minabs(buffer_l);
                }
            }

            return result;

            // 将长度为 k*k 的 m1 与 长度为 k 的 m2 归并到 长度为 k*k 的 m 中，其中 m1 中的 tuple.Item2[id] == val 的项是移除的项
            static void merge((int, int[])[] m1, (int, int[])[] m2, (int, int[])[] m, int id, int val)
            {
                int idx = 0, p1 = 0, p2 = 0, len1 = m1.Length, len2 = m2.Length;
                while (p1 < len1 && p2 < len2)
                {
                    while (p1 < len1 && m1[p1].Item2[id] == val) p1++;
                    if (p1 == len1) break;
                    if (m1[p1].Item1 <= m2[p2].Item1) m[idx++] = m1[p1++]; else m[idx++] = m2[p2++];
                }
                while (p1 < len1) if (m1[p1].Item2[id] != val) m[idx++] = m1[p1++]; else p1++;
                while (p2 < len2) m[idx++] = m2[p2++];
            }

            // 计算最小绝对差，可以合并到merge中，但是那样代码逻辑不清晰，而且没有本质上的提高性能，所以单独写了
            static int minabs((int, int[])[] m)
            {
                int min = int.MaxValue, len = m.Length;
                for (int i = 1; i < len; i++) if (m[i - 1].Item1 != m[i].Item1) min = Math.Min(min, m[i].Item1 - m[i - 1].Item1);
                return min == int.MaxValue ? 0 : min;
            }
        }
    }
}
