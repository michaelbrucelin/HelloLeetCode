using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1920
{
    public class Solution1920_api : Interface1920
    {
        public int[] BuildArray(int[] nums)
        {
            return nums.Select(i => nums[i]).ToArray();
        }

        public int[] BuildArray2(int[] nums) => [.. nums.Select(i => nums[i])];
    }
}
