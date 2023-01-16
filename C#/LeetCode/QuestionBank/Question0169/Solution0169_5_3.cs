using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0169
{
    public class Solution0169_5_3 : Interface0169
    {
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

            var info = CountInRange(nums, lr, rr, left, right);

            return info.lcnt > info.rcnt ? lr : rr;
        }

        private (int lcnt, int rcnt) CountInRange(int[] nums, int lt, int rt, int left, int right)
        {
            int lcnt = 0, rcnt = 0;
            for (int i = left; i <= right; i++) if (nums[i] == lt) lcnt++; else if (nums[i] == rt) rcnt++;
            return (lcnt, rcnt);
        }
    }
}
