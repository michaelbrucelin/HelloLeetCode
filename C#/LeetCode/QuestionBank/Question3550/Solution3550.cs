using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3550
{
    public class Solution3550 : Interface3550
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SmallestIndex(int[] nums)
        {
            int len = nums.Length;
            for (int i = 0, num, sum; i < len; i++)
            {
                num = nums[i]; sum = 0;
                while (num > 0) { sum += num % 10; num /= 10; }
                if (sum == i) return i;
            }

            return -1;
        }
    }
}
