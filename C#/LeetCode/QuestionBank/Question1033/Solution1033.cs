using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1033
{
    public class Solution1033 : Interface1033
    {
        public int[] NumMovesStones(int a, int b, int c)
        {
            int[] nums = new int[] { a, b, c };
            Array.Sort(nums);

            int max = nums[2] - nums[0] - 2;
            if (max <= 1) return new int[] { max, max };

            if (nums[1] - nums[0] <= 2 || nums[2] - nums[1] <= 2)
                return new int[] { 1, max };
            else
                return new int[] { 2, max };
        }
    }
}
