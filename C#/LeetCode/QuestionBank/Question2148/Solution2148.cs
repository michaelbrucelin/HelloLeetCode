using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2148
{
    public class Solution2148 : Interface2148
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountElements(int[] nums)
        {
            int result = 0, len = nums.Length;
            bool flag1, flag2;
            for (int i = 0; i < len; i++)
            {
                flag1 = false;
                for (int j = 0; j < len; j++)
                {
                    if (j != i && nums[j] < nums[i]) { flag1 = true; break; }
                }
                if (!flag1) continue;
                flag2 = false;
                for (int j = 0; j < len; j++)
                {
                    if (j != i && nums[j] > nums[i]) { flag2 = true; break; }
                }
                if (flag2) result++;
            }

            return result;
        }
    }
}
