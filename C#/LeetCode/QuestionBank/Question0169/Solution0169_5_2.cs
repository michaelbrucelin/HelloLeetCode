using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0169
{
    public class Solution0169_5_2 : Interface0169
    {
        /// <summary>
        /// 只是将计数的部分由朴素的统计改为LINQ查询，超时了。。。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            return MajorityElementRec(nums, 0, nums.Length - 1);
        }

        private int MajorityElementRec(int[] nums, int left, int right)
        {
            if (left == right) return nums[left];

            int mid = left + ((right - left) >> 1);
            int lr = MajorityElementRec(nums, left, mid);
            int rr = MajorityElementRec(nums, mid + 1, right);
            if (lr == rr) return lr;

            int lcnt = nums.Where((val, id) => id >= left && id <= right && val == lr).Count();
            int rcnt = nums.Where((val, id) => id >= left && id <= right && val == rr).Count();

            return lcnt > rcnt ? lr : rr;
        }
    }
}
