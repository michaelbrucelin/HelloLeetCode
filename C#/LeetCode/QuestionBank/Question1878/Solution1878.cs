using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1878
{
    public class Solution1878 : Interface1878
    {
        /// <summary>
        /// 枚举
        /// 枚举全部的正菱形
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] GetBiggestThree(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            HashSet<int> set = new HashSet<int>();
            int offset, sum, ru, cu, rr, cr, rd, cd, rl, cl;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (!set.Contains(grid[r][c])) { minpq.Enqueue(grid[r][c], grid[r][c]); set.Add(grid[r][c]); }  // offset = 0
                    if (minpq.Count > 3) set.Remove(minpq.Dequeue());
                    offset = 1;
                    while (true)
                    {
                        sum = 0; ru = r; cu = c; rr = r + offset; cr = c + offset; rd = r + (offset << 1); cd = c; rl = r + offset; cl = c - offset;
                        if (cr >= ccnt || rd >= rcnt || cl < 0) break;

                        for (int _r = ru, _c = cu; _r < rr; _r++, _c++) sum += grid[_r][_c];  // (ru,cu) --> (rr-1,cr-1)
                        for (int _r = rr, _c = cr; _r < rd; _r++, _c--) sum += grid[_r][_c];  // (rr,cr) --> (rd-1,cd+1)
                        for (int _r = rd, _c = cd; _r > rl; _r--, _c--) sum += grid[_r][_c];  // (rd,cd) --> (rl+1,cl+1)
                        for (int _r = rl, _c = cl; _r > ru; _r--, _c++) sum += grid[_r][_c];  // (rl,cl) --> (ru+1,cu-1)

                        if (!set.Contains(sum)) { minpq.Enqueue(sum, sum); set.Add(sum); }
                        if (minpq.Count > 3) set.Remove(minpq.Dequeue());
                        offset++;
                    }
                }

            int[] result = new int[minpq.Count];
            for (int i = minpq.Count - 1; i >= 0; i--) result[i] = minpq.Dequeue();
            return result;
        }
    }
}
