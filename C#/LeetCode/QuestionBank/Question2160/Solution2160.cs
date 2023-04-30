using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2160
{
    public class Solution2160 : Interface2160
    {
        /// <summary>
        /// 暴力解
        /// 简单题简单做，一共有24(4*3*2*1)种可能
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MinimumSum(int num)
        {
            int[] buffer = new int[4];
            for (int i = 0; i < 4; i++)
            {
                buffer[i] = num % 10; num /= 10;
            }

            int result = int.MaxValue;
            for (int i = 0; i < 4; i++) for (int j = 0; j < 4; j++) for (int k = 0; k < 4; k++) for (int l = 0; l < 4; l++)
                        {
                            if (((1 << i) | (1 << j) | (1 << k) | (1 << l)) == 15)
                                result = Math.Min(result, buffer[i] * 10 + buffer[j] + buffer[k] * 10 + buffer[l]);
                        }

            return result;
        }
    }
}
