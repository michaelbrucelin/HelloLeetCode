using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1572
{
    public class Solution1572 : Interface1572
    {
        /// <summary>
        /// 遍历
        /// 横纵坐标相等或相加等于长度减一的项
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int DiagonalSum(int[][] mat)
        {
            int sum = 0, len = mat.Length;
            for (int i = 0; i < len; i++)
            {
                sum += mat[i][i] + mat[i][len - i - 1];
            }

            return sum - ((len & 1) != 0 ? mat[len >> 1][len >> 1] : 0);
        }
    }
}
