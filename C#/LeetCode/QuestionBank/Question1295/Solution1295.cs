using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1295
{
    public class Solution1295 : Interface1295
    {
        public int FindNumbers(int[] nums)
        {
            int result = 0;
            for (int i = 0, num,len; i < nums.Length; i++)
            {
                len = 0; num = nums[i];
                while (num > 0) { len++;num /= 10; }  // 题目限定num >= 1
                result += 1 - (len & 1);
            }

            return result;
        }
    }
}
