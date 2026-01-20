using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3314
{
    public class Solution3314 : Interface3314
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MinBitwiseArray(IList<int> nums)
        {
            int len = nums.Count;
            int[] result = new int[len];
            for (int i = 0, num; i < len; i++)
            {
                result[i] = -1; num = nums[i];
                for (int j = 1; j < num; j++) if ((j | (j + 1)) == num)
                    {
                        result[i] = j; break;
                    }
            }

            return result;
        }
    }
}
