using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1403
{
    public class Solution1403_2 : Interface1403
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MinSubsequence(int[] nums)
        {
            List<int> result = new List<int>();
            Array.Sort(nums);
            int target = nums.Sum() >> 1, sum = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result.Add(nums[i]);
                if ((sum += nums[i]) > target) break;
            }

            return result;
        }
    }
}
