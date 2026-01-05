using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1975
{
    public class Solution1975 : Interface1975
    {
        /// <summary>
        /// 逻辑思维题
        /// 1. 操作只能改变数字的符号，所以为了使矩阵的和尽可能的大，只要让矩阵中的值尽可能多的是正数即可
        /// 2. 如果矩阵中某个位置的符号为负，那么可以通过操作将负号移动到矩阵中的任意一个位置
        /// 3. 当矩阵中两个负号相邻，可以使矩阵中减少两个负号
        /// 4. 由2 3知，如果矩阵中有偶数个负号，可以将矩阵中负号的数量降为0，如果矩阵中有奇数个负号，可以将矩阵中负号的数量将为1
        /// 5. 所以，如果矩阵中有偶数个负号，结果是矩阵中所有数字的绝对值的和，如果矩阵中有奇数个负号，结果是矩阵中所有数字的绝对值的和 - 最小的绝对值*2
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public long MaxMatrixSum(int[][] matrix)
        {
            long sum = 0; int min = int.MaxValue, rcnt = matrix.Length, ccnt = matrix[0].Length, cnt = 0;
            for (int r = 0, val; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    val = Math.Abs(matrix[r][c]);
                    sum += val;
                    if (val < min) min = val;
                    if (matrix[r][c] < 0) cnt++;
                }

            return (cnt & 1) == 0 ? sum : sum - min - min;
        }
    }
}
