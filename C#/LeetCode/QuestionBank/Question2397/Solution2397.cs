using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2397
{
    public class Solution2397 : Interface2397
    {
        /// <summary>
        /// 暴力枚举
        /// 1. 题目限定最多12列，那么最多的选择可能是(C, 12, 6) = 924，每种可能最多判断12行，924 * 12 = 11088，时间复杂度不大
        /// 2. 遍历每一种选择的可能，可以使用二进制枚举
        /// 3. 判断每一行是否全覆盖，可以使用位运算
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="numSelect"></param>
        /// <returns></returns>
        public int MaximumRows(int[][] matrix, int numSelect)
        {
            if (numSelect == matrix[0].Length) return matrix.Length;

            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[] masks = new int[rcnt];  // 每一行的掩码
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    masks[r] |= matrix[r][c] << c;
                }
            // 枚举每一种选择的可能，即组合的可能
            int result = 0, _result;
            int kset = (1 << numSelect) - 1, mset = 1 << ccnt, x, y;
            while (kset < mset)
            {
                _result = 0;
                for (int r = 0; r < rcnt; r++)
                    if ((masks[r] & kset) == masks[r]) _result++;  // ((masks[r] ^ kset) & masks[r]) == 0 把问题搞复杂了
                result = Math.Max(result, _result);

                x = kset & -kset; y = kset + x; kset = (kset & ~y) / x >> 1 | y;
            }

            return result;
        }
    }
}
