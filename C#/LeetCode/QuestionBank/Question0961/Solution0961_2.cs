using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0961
{
    public class Solution0961_2 : Interface0961
    {
        /// <summary>
        /// 概率，期望
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RepeatedNTimes(int[] nums)
        {
            Random random = new Random();
            int i, j, len = nums.Length;
            while (true)
            {
                i = random.Next(0, len);
                j = random.Next(0, len);
                if (i != j && nums[i] == nums[j]) return nums[i];
            }

            throw new Exception("logic error.");
        }
    }
}
