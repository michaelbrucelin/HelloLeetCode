using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2733
{
    public class Solution2733 : Interface2733
    {
        /// <summary>
        /// 脑筋急转弯
        /// 题目限定数组中所有元素各不相同，所以数组的前三项即有结果
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int FindNonMinOrMax(int[] nums)
        {
            if (nums.Length < 3) return -1;

            int first, second;
            if (nums[1] > nums[0])
            {
                first = nums[0]; second = nums[1];
            }
            else
            {
                first = nums[1]; second = nums[0];
            }

            if (nums[2] > second)
                return second;
            else if (nums[2] < first)
                return first;
            else
                return nums[2];
        }
    }
}
