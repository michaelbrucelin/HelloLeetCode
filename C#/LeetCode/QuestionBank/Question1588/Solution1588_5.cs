using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1588
{
    public class Solution1588_5 : Interface1588
    {
        public int SumOddLengthSubarrays(int[] arr)
        {
            int result = 0, len = arr.Length;
            for (int i = 0, cnt; i < len; i++)
            {
                cnt = ((i + 1) >> 1) * ((len - i) >> 1) + ((i >> 1) + 1) * (((len - i - 1) >> 1) + 1);
                result += arr[i] * cnt;
            }

            return result;
        }

        /// <summary>
        /// 与SumOddLengthSubarrays()一样，稍加优化，因为左右是对称的
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SumOddLengthSubarrays2(int[] arr)
        {
            int result = 0, mid = arr.Length >> 1, len = arr.Length, cnt;
            for (int i = 0; i < mid; i++)
            {
                cnt = ((i + 1) >> 1) * ((len - i) >> 1) + ((i >> 1) + 1) * (((len - i - 1) >> 1) + 1);
                result += (arr[i] + arr[len - i - 1]) * cnt;
            }
            if ((len & 1) != 0)
            {
                cnt = ((mid + 1) >> 1) * ((len - mid) >> 1) + ((mid >> 1) + 1) * (((len - mid - 1) >> 1) + 1);
                result += arr[mid] * cnt;
            }

            return result;
        }
    }
}
