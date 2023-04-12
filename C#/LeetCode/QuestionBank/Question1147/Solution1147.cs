using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1147
{
    public class Solution1147 : Interface1147
    {
        /// <summary>
        /// 贪心
        /// 从两边向中间贪心即可
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int LongestDecomposition(string text)
        {
            int result = 0;
            int i1 = 0, i2 = 0, j1 = text.Length - 1, j2 = text.Length - 1;
            while (i2 < j1)
            {
                if (text.Substring(i1, i2 - i1 + 1) == text.Substring(j1, j2 - j1 + 1))
                {
                    result += 2; i1 = i2 = i2 + 1; j2 = j1 = j1 - 1;
                }
                else
                {
                    i2++; j1--;
                }
            }
            if (i1 <= j2) result++;

            return result;
        }

        /// <summary>
        /// 与LongestDecomposition()一样，将字符串截取改为切片
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int LongestDecomposition2(string text)
        {
            int result = 0;
            int i1 = 0, i2 = 0, j1 = text.Length - 1, j2 = text.Length - 1;
            while (i2 < j1)
            {
                if (text[i1..(i2 + 1)] == text[j1..(j2 + 1)])
                {
                    result += 2; i1 = i2 = i2 + 1; j2 = j1 = j1 - 1;
                }
                else
                {
                    i2++; j1--;
                }
            }
            if (i1 <= j2) result++;

            return result;
        }

        /// <summary>
        /// 与LongestDecomposition()一样，将字符串截取改为逐位判断
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int LongestDecomposition3(string text)
        {
            int result = 0;
            int i1 = 0, i2 = 0, j1 = text.Length - 1, j2 = text.Length - 1;
            while (i2 < j1)
            {
                if (IsEqual(text, i1, i2, j1, j2))
                {
                    result += 2; i1 = i2 = i2 + 1; j2 = j1 = j1 - 1;
                }
                else
                {
                    i2++; j1--;
                }
            }
            if (i1 <= j2) result++;

            return result;
        }

        private bool IsEqual(string text, int i1, int i2, int j1, int j2)
        {
            if (i2 - i1 != j2 - j1) return false;
            for (int i = i1, j = j1; i <= i2; i++, j++)
                if (text[i] != text[j]) return false;

            return true;
        }
    }
}
