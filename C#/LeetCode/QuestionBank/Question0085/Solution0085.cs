using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0085
{
    public class Solution0085 : Interface0085
    {
        /// <summary>
        /// 暴力查找
        /// 1. DP预处理出来每个位置向上最多有多少个连续的1
        /// 2. 枚举每个位置，计算以这个位置为矩形的右下角，结果是多少
        ///     从这个位置向左枚举，直到遇到0
        /// 3. 时间复杂度是O(rcnt*ccnt*ccnt)，可以比较rcnt与ccnt的大小，然后小驱动大来优化，这里就不做了
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalRectangle(char[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[] heights = new int[ccnt];
            int width, height, size;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (matrix[r][c] == '0') { heights[c] = 0; continue; }
                    width = 1; height = ++heights[c]; size = height;
                    for (int _c = c - 1; _c >= 0 && heights[_c] > 0; _c--)
                    {
                        width++; height = Math.Min(height, heights[_c]); size = Math.Max(size, width * height);
                    }
                    result = Math.Max(result, size);
                }

            return result;
        }

        /// <summary>
        /// 逻辑与MaximalRectangle()一样，小驱动大优化
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalRectangle2(char[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            if (rcnt >= ccnt)  // 小驱动大
            {
                int[] heights = new int[ccnt];
                int width, height, size;
                for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                    {
                        if (matrix[r][c] == '0') { heights[c] = 0; continue; }
                        width = 1; height = ++heights[c]; size = height;
                        for (int _c = c - 1; _c >= 0 && heights[_c] > 0; _c--)
                        {
                            width++; height = Math.Min(height, heights[_c]); size = Math.Max(size, width * height);
                        }
                        result = Math.Max(result, size);
                    }
            }
            else
            {
                int[] widths = new int[rcnt];
                int width, height, size;
                for (int c = 0; c < ccnt; c++) for (int r = 0; r < rcnt; r++)
                    {
                        if (matrix[r][c] == '0') { widths[r] = 0; continue; }
                        width = ++widths[r]; height = 1; size = width;
                        for (int _r = r - 1; _r >= 0 && widths[_r] > 0; _r--)
                        {
                            width = Math.Min(width, widths[_r]); height++; size = Math.Max(size, width * height);
                        }
                        result = Math.Max(result, size);
                    }
            }

            return result;
        }
    }
}
