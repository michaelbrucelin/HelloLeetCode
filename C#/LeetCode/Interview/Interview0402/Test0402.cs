using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0402
{
    public class Test0402
    {
        public void Test()
        {
            Interface0402 solution = new Solution0402();
            int[] nums;
            TreeNode result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { -10, -3, 0, 5, 9 };
            solution.SortedArrayToBST(nums);
        }
    }
}
