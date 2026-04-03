using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2232
{
    public class Solution2232 : Interface2232
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string MinimizeResult(string expression)
        {
            int len = expression.Length;
            int[] nums = new int[2], width = new int[2];
            for (int i = 0, j = 0; i < len; i++)
            {
                if (expression[i] != '+')
                {
                    nums[j] *= 10; nums[j] += expression[i] & 15; width[j]++;
                }
                else
                {
                    j++;
                }
            }

            string result = $"({expression})";
            int min = nums[0] + nums[1], n1, n2, n3, n4, pow1, pow2;
            for (int i = 1; i <= width[0]; i++) for (int j = 0; j < width[1]; j++)
                {
                    pow1 = (int)Math.Pow(10, i); pow2 = (int)Math.Pow(10, j);
                    n1 = i != width[0] ? nums[0] / pow1 : 1;
                    n2 = nums[0] % pow1;
                    n3 = nums[1] / pow2;
                    n4 = j != 0 ? nums[1] % pow2 : 1;
                    if (n1 * (n2 + n3) * n4 < min)
                    {
                        result = $"{(i != width[0] ? n1 : "")}({n2}+{n3}){(j != 0 ? n4 : "")}";
                        min = n1 * (n2 + n3) * n4;
                    }
                }

            return result;
        }
    }
}
