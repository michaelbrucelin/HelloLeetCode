using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0885
{
    public class Solution0885 : Interface0885
    {
        /// <summary>
        /// 模拟
        /// 在纸上画画就看清楚了
        /// 第1圈，起点(r-0,c-0)，向右到(r-0, c+1)，向下到(r+1,c+1)，向左到(r+1,c-1)，向上到(r-0,c-1)
        /// 第2圈，起点(r-1,c-1)，向右到(r-1, c+2)，向下到(r+2,c+2)，向左到(r+2,c-2)，向上到(r-1,c-2)
        /// 第3圈，起点(r-2,c-2)，向右到(r-2, c+3)，向下到(r+3,c+3)，向左到(r+3,c-3)，向上到(r-2,c-3)
        /// ... ...
        /// 第n圈，起点(r-n+1,c-n+1)，向右到(r-n+1, c+n)，向下到(r+n,c+n)，向左到(r+n,c-n)，向上到(r-n+1,c-n)
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="rStart"></param>
        /// <param name="cStart"></param>
        /// <returns></returns>
        public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
        {
            int id = 0, circle = 1, r, c, cnt = rows * cols, curr = 0;
            int[][] result = new int[cnt][];
            while (id < cnt)
            {
                r = rStart - circle; c = cStart - circle;
                for (r++, c++; c <= cStart + circle; c++) if (check(r, c, rows, cols)) result[id++] = [r, c];
                for (c--, r++; r <= rStart + circle; r++) if (check(r, c, rows, cols)) result[id++] = [r, c];
                for (r--, c--; c >= cStart - circle; c--) if (check(r, c, rows, cols)) result[id++] = [r, c];
                for (c++, r--; r > rStart - circle; r--) if (check(r, c, rows, cols)) result[id++] = [r, c];
                circle++;
            }

            return result;

            static bool check(int r, int c, int rcnt, int ccnt)
            {
                return r >= 0 && r < rcnt && c >= 0 && c < ccnt;
            }
        }
    }
}
