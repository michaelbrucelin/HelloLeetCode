using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1785
{
    public class Solution1785 : Interface1785
    {
        public int MinElements(int[] nums, int limit, int goal)
        {
            long distance = goal;  // 由题目知int不够用
            for (int i = 0; i < nums.Length; i++) distance -= nums[i];
            if (distance == 0) return 0;

            if (distance < 0) distance *= -1;
            return (int)((distance - 1) / limit) + 1;
        }
    }
}
