using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1260
{
    public class Solution1260_3 : Interface1260
    {
        /// <summary>
        /// 模拟
        /// 题目的操作本质上就是一维展平后向后移动
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];

            k %= rcnt * ccnt;
            if (k == 0)
            {
                for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) result[r][c] = grid[r][c];
            }
            else
            {
                int id, cnt = rcnt * ccnt;
                for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                    {
                        id = (r * ccnt + c + k) % cnt;
                        result[id / ccnt][id % ccnt] = grid[r][c];
                    }
            }

            return result;
        }

        /// <summary>
        /// 原地更改
        /// 题目限定数值的范围是[-1000, 1000]，所以可以转成[0, 2001]然后使用高低位存储
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> ShiftGrid2(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;

            k %= rcnt * ccnt;
            if (k > 0)
            {
                for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) grid[r][c] += 1000;
                int id, cnt = rcnt * ccnt;
                for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                    {
                        id = (r * ccnt + c + k) % cnt;
                        grid[id / ccnt][id % ccnt] |= (grid[r][c] & 2047) << 11;
                    }
                for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) grid[r][c] = (grid[r][c] >> 11) - 1000;
            }

            return grid;
        }
    }
}
