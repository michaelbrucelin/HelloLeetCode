using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1013
{
    public class Solution1013 : Interface1013
    {
        /// <summary>
        /// 前缀和
        /// 1. 如果数组和不是3的倍数，false，否则记 _sum = sum/3
        /// 2. 遍历一次，找出前缀和是_sum与_sum*2的位置
        ///     如果_sum*2的位置在_sum位置的右边，结果为true，否则为false
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CanThreePartsEqualSum(int[] arr)
        {
            int sum = 0, len = arr.Length;
            for (int i = 0; i < len; i++) sum += arr[i];
            if (sum % 3 != 0) return false;

            int _sum = 0, sum1 = sum / 3; int sum2 = sum1 << 1;
            bool flag = false;
            for (int i = 0; i < len; i++)
            {
                _sum += arr[i];
                if (!flag)
                {
                    if (_sum == sum1) flag = true;
                }
                else
                {
                    if (_sum == sum2 && i != len - 1) return true;
                }
            }

            return false;
        }
    }
}
