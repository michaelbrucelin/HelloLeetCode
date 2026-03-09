using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1343
{
    public class Solution1343 : Interface1343
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            int result = 0, sum = 0, len = arr.Length;
            threshold *= k;
            for (int i = 0; i < k; i++) sum += arr[i];
            if (sum >= threshold) result++;
            for (int i = k; i < len; i++)
            {
                sum += arr[i] - arr[i - k];
                if (sum >= threshold) result++;
            }

            return result;
        }
    }
}
