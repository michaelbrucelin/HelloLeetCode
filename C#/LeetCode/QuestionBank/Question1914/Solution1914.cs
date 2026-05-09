using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1914
{
    public class Solution1914 : Interface1914
    {
        /// <summary>
        /// 模拟
        /// 
        /// 题目限定grid[i][j] <= 5000，所以可以借助位运算（高低位）来实现原地旋转，这里就不写了
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] RotateGrid(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[][] result = new int[rcnt][];
            for (int __r = 0; __r < rcnt; __r++) result[__r] = new int[ccnt];

            int cnt, offset, r, c, _r, _c;
            for (int r1 = 0, r2 = rcnt - 1, c1 = 0, c2 = ccnt - 1; r1 < r2 && c1 < c2; r1++, r2--, c1++, c2--)
            {
                cnt = (r2 - r1 + c2 - c1) << 1;
                offset = k % cnt;
                r = _r = r1; c = _c = c1;
                while (offset-- > 0) (_r, _c) = next(_r, _c, r1, c1, r2, c2);
                while (cnt-- > 0)
                {
                    result[_r][_c] = grid[r][c];
                    (_r, _c) = next(_r, _c, r1, c1, r2, c2);
                    (r, c) = next(r, c, r1, c1, r2, c2);
                }
            }

            return result;

            static (int, int) next(int r, int c, int r1, int c1, int r2, int c2)  // 题目限定，一定有 r1<r2 && c1<c2
            {
                switch ((r - r1, c - c1, r - r2, c - c2))
                {
                    case (0, 0, _, _): r++; break;
                    case (_, 0, 0, _): c++; break;
                    case (_, _, 0, 0): r--; break;
                    case (0, _, _, 0): c--; break;
                    case (_, 0, _, _): r++; break;
                    case (_, _, 0, _): c++; break;
                    case (_, _, _, 0): r--; break;
                    case (0, _, _, _): c--; break;
                    default: break;
                }
                return (r, c);
            }
        }
    }
}
