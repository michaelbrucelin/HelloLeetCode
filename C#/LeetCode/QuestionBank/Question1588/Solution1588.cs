using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1588
{
    public class Solution1588 : Interface1588
    {
        /// <summary>
        /// 前缀和 + 暴力枚举
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SumOddLengthSubarrays(int[] arr)
        {
            int len = arr.Length;
            int[] pre = new int[len + 1];
            for (int i = 0; i < arr.Length; i++) pre[i + 1] = pre[i] + arr[i];

            int result = 0;
            for (int w = 1; w <= len; w += 2) for (int i = 0; i + w - 1 < len; i++)
                {
                    result += pre[i + w] - pre[i];
                }

            return result;
        }
    }
}
