using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0169
{
    public class Solution0169_5 : Interface0169
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

            int lcnt = CountInRange(nums, lr, left, right);
            int rcnt = CountInRange(nums, rr, left, right);

            return lcnt > rcnt ? lr : rr;
        }

        private int CountInRange(int[] nums, int target, int left, int right)
        {
            int cnt = 0;
            for (int i = left; i <= right; i++) if (nums[i] == target) cnt++;
            return cnt;
        }
    }
}
