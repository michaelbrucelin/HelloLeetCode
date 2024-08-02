using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3128
{
    public class Solution3128 : Interface3128
    {
        /// <summary>
        /// 数学
        /// 预处理
        ///     1. 预处理每一列有多少个1，int[] colcnt
        ///     2. 预处理每一行1的位置，int[][] rowpos
        /// 枚举每个直角三角形的横边（行），计算纵边（列）的可能的数量
        /// 如果横边的左右列是c1, c2，显然c1, c2列其余的每个1都可以贡献一次
        /// 对于每一行，假设有x个1，则每个1都可以参与其余x-1个1组合一次
        ///     所以以这一行为横边的直角三角形的数量是(所有有1的列的1的数量和 - x) * (x - 1) / 2
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public long NumberOfRightTriangles(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] colcnt = new int[ccnt];
            List<int>[] rowpos = new List<int>[rcnt];
            for (int r = 0; r < rcnt; r++) rowpos[r] = new List<int>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1)
                    {
                        colcnt[c]++; rowpos[r].Add(c);
                    }

            long result = 0;
            for (int r = 0, _rcnt, _csum; r < rcnt; r++)
            {
                _rcnt = rowpos[r].Count; _csum = 0;
                for (int c = 0; c < _rcnt; c++) _csum += colcnt[rowpos[r][c]] - 1;
                result += _csum * (_rcnt - 1);
            }

            return result;
        }
    }
}
