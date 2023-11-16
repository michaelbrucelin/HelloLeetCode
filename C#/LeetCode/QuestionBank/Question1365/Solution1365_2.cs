using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1365
{
    public class Solution1365_2 : Interface1365
    {
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int[] pres = new int[101];
            int len = nums.Length;
            for (int i = 0; i < len; i++) pres[nums[i]]++;
            for (int i = 1; i < 101; i++) pres[i] += pres[i - 1];

            int[] result = new int[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = nums[i] != 0 ? pres[nums[i] - 1] : 0;
            }

            return result;
        }
    }
}
