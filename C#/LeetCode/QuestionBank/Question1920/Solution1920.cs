using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1920
{
    public class Solution1920 : Interface1920
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] BuildArray(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            for (int i = 0; i < len; i++) result[i] = nums[nums[i]];

            return result;
        }
    }
}
