using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0169
{
    public class Solution0169_3 : Interface0169
    {
        public int MajorityElement(int[] nums)
        {
            Array.Sort(nums);  // 如果自己实现堆排序，可以优化空间复杂度
            return nums[nums.Length / 2];
        }
    }
}
