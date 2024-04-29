using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1329
{
    public class Solution1329_err : Interface1329
    {
        /// <summary>
        /// 全局API排序
        /// 排序规则
        ///     如果索引的“行差”与“列差”相等，即在一条对角线上，
        ///         那么比较值的大小
        ///     如果索引的“行差”与“列差”不等，即不在一条对角线上，
        ///         那么先比较行索引，再比较列索引，也就是保留原顺序
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[][] DiagonalSort(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            if (rcnt == 1 || ccnt == 1) return mat;

            Comparer<(int val, int r, int c)> comparer = Comparer<(int val, int r, int c)>.Create(
                (t1, t2) => (t1.r - t2.r) == (t1.c - t2.c)
                            ? ((t1.val - t2.val) switch { > 0 => 1, < 0 => -1, _ => 0 })
                            : ((t1.r - t2.r) switch { > 0 => 1, < 0 => -1, _ => (t1.c - t2.c) switch { > 0 => 1, < 0 => -1, _ => 0 } }));
            (int val, int r, int c)[] values = new (int val, int r, int c)[rcnt * ccnt];
            for (int r = 0, i = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) values[i++] = (mat[r][c], r, c);
            Array.Sort(values, comparer);
            for (int r = 0, i = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) mat[r][c] = values[i++].val;

            return mat;
        }
    }
}
