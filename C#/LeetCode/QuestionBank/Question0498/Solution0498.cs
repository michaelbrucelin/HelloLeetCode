using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0498
{
    public class Solution0498 : Interface0498
    {
        /// <summary>
        /// 遍历
        /// 遍历上边与右边，逆序用栈中转
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[] FindDiagonalOrder(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            int[] result = new int[rcnt * ccnt];
            Stack<int> stack = new Stack<int>();
            int id = 0;
            bool desc = true;
            for (int C = 0; C < ccnt; C++, desc = !desc)
            {
                if (desc)
                {
                    for (int r = 0, c = C; r < rcnt && c >= 0; r++, c--) stack.Push(mat[r][c]);
                    while (stack.Count > 0) result[id++] = stack.Pop();
                }
                else
                {
                    for (int r = 0, c = C; r < rcnt && c >= 0; r++, c--) result[id++] = mat[r][c];
                }
            }
            for (int R = 1; R < rcnt; R++, desc = !desc)
            {
                if (desc)
                {
                    for (int r = R, c = ccnt - 1; r < rcnt && c >= 0; r++, c--) stack.Push(mat[r][c]);
                    while (stack.Count > 0) result[id++] = stack.Pop();
                }
                else
                {
                    for (int r = R, c = ccnt - 1; r < rcnt && c >= 0; r++, c--) result[id++] = mat[r][c];
                }
            }

            return result;
        }
    }
}
