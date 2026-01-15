using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1442
{
    public class Solution1442 : Interface1442
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int CountTriplets(int[] arr)
        {
            int result = 0, len = arr.Length;
            for (int i = 0, xorl = 0; i < len; i++, xorl = 0) for (int j = i; j < len; j++)
                {
                    xorl ^= arr[j];
                    for (int k = j + 1, xorr = 0; k < len; k++, xorr = 0)
                    {
                        if ((xorr ^= arr[k]) == xorl) result++;
                    }
                }

            return result;
        }
    }
}
