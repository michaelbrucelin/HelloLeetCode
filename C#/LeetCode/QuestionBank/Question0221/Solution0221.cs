using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0221
{
    public class Solution0221 : Interface0221
    {
        /// <summary>
        /// 暴力查找
        /// 使用前缀和加速，提前剪枝
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalSquare(char[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[,] pre = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    pre[r + 1, c + 1] = pre[r, c + 1] + pre[r + 1, c] - pre[r, c] + matrix[r][c] - '0';
                }

            int d;
            for (int r = rcnt - 1; r >= 0; r--) for (int c = ccnt - 1; c >= 0; c--)
                {
                    if (r + 1 <= result && c + 1 <= result) goto ENDLOOP;
                    d = Math.Min(r, c);
                    while (d + 1 > result)
                    {
                        if (pre[r + 1, c + 1] - pre[r - d, c + 1] - pre[r + 1, c - d] + pre[r - d, c - d] == (d + 1) * (d + 1))
                        {
                            result = d + 1; break;
                        }
                        d--;
                    }
                }
            ENDLOOP:;

            return result * result;
        }
    }
}
