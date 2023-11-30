using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1534
{
    public class Solution1534 : Interface1534
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int result = 0, len = arr.Length;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) > a) continue;
                    for (int k = j + 1; k < len; k++)
                    {
                        if (Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c) result++;
                    }
                }

            return result;
        }
    }
}
