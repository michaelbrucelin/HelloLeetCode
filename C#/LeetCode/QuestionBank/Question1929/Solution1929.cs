using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1929
{
    public class Solution1929 : Interface1929
    {
        public int[] GetConcatenation(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len << 1];
            for (int i = 0; i < len; i++)
                result[i] = result[len + i] = nums[i];

            return result;
        }

        public int[] GetConcatenation2(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len << 1];
            Array.Copy(nums, result, len);
            Array.Copy(nums, 0, result, len, len);

            return result;
        }
    }
}
